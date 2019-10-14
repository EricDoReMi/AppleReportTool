using AppleDailyReportTool.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace AppleDailyReportTool.dao
{
    public abstract partial class BaseDAO<E>
    {

        protected OleDbTransaction trans = null;//事务
                                                //数据库基本操作
        #region 数据库基本操作   


        /**//// <summary>   
            /// 执行SQL命令，返回Entity的集合 
            /// </summary>
            /// <param name="conn">数据库连接</param> 
            /// <param name="sqlStr">sql语句</param>   
            /// <param name="paras">可变参数,目的是省略了手动构造数组的过程</param>   
            /// <returns>sql语句执行成功的条数</returns>   
        protected List<E> queryEntity(OleDbConnection conn, string sqlStr, params OleDbParameter[] paras)
        {

            //调用query返回结果集
            OleDbDataReader reader = SelectToDataReader(conn, sqlStr, paras);

            //遍历结果集的数据封装成实体对象返回
            List<E> list = new List<E>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(ToEntity(reader));
                }
            }

            return list;
        }

        /**//// <summary>   
            /// 执行SQL命令，不需要返回数据的修改，删除可以使用本函数   
            /// </summary>
            /// <param name="conn">数据库连接</param> 
            /// <param name="sqlStr">sql语句</param>   
            /// <param name="paras">参数,默认为null</param>   
            /// <returns>sql语句执行成功的条数</returns>   
        protected long ExecuteSQLNonquery(OleDbConnection conn, string sqlStr, params OleDbParameter[] paras)
        {

            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            cmd.Transaction = trans;

            cmd.Parameters.AddRange(paras);


            return cmd.ExecuteNonQuery();

        }



        /**//// <summary>   
            /// 根据SQL命令返回数据OleDbDataReader数据表,   
            /// </summary> 
            /// <param name="conn">数据库连接</param> 
            /// <param name="sqlStr">sql语句</param>  
            /// <param name="paras">参数,默认值null</param>   
            /// <returns>OleDbDataReader</returns>  
        protected OleDbDataReader SelectToDataReader(OleDbConnection conn, string sqlStr, params OleDbParameter[] paras)
        {
            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            cmd.Transaction = trans;


            cmd.Parameters.AddRange(paras);

            OleDbDataReader reader = cmd.ExecuteReader();
            return reader;
        }


        /**//// <summary>   
            /// 根据SQL命令返回数据DataTable数据表,   
            /// 可直接作为dataGridView的数据源   
            /// </summary> 
            /// <param name="conn">数据库连接</param> 
            /// <param name="sqlStr">sql语句</param>   
            /// <param name="paras">参数,默认值null</param>   
            /// <returns>DataTable</returns>   
        protected DataTable SelectToDataTable(OleDbConnection conn, string sqlStr, params OleDbParameter[] paras)
        {
            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            cmd.Transaction = trans;
            cmd.Parameters.AddRange(paras);

            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        /**//// <summary>   
            /// 根据SQL命令返回OleDbDataAdapter，   
            /// 使用前请在主程序中添加命名空间System.Data.OleDb   
            /// </summary>   
            /// <param name="conn">数据库连接</param> 
            /// <param name="sqlStr">sql语句</param>   
            /// <param name="paras">参数,默认值null</param>  
            /// <returns>OleDbDataAdapter</returns>   
        protected OleDbDataAdapter SelectToOleDbDataAdapter(OleDbConnection conn, string sqlStr, params OleDbParameter[] paras)
        {
            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            cmd.Transaction = trans;

            cmd.Parameters.AddRange(paras);

            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            return adapter;
        }

        protected List<E> queryDataTableEntity(OleDbConnection conn, string sqlStr, params OleDbParameter[] paras)
        {

            //调用query返回结果集
            DataTable tb = SelectToDataTable(conn, sqlStr, paras);

            //遍历结果集的数据封装成实体对象返回
            List<E> list = new List<E>();

            if (tb.Rows.Count > 0)
            {

                foreach (DataRow row in tb.Rows)
                {
                    list.Add(ToEntity(row));
                }

            }



            return list;
        }

        public OleDbConnection Begin()
        {
            OleDbConnection conn = OLDBHelper.GetConnection();
            conn.Open();
            trans = conn.BeginTransaction();
            return conn;

        }

        public void Commit()
        {
            trans.Commit();
        }

        public void RollBack()
        {
            trans.Rollback();
        }

        public void Close()
        {
            OLDBHelper.CloseConnection();
        }


        //每个子类需要去重写的ToEntity方法
        public abstract E ToEntity(DataRow dataRow);

        //每个子类需要去重写的ToEntity方法
        public abstract E ToEntity(OleDbDataReader reader);

        #endregion
    }
}
