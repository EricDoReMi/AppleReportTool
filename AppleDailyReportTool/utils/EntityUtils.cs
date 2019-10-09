using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AppleDailyReportTool.utils
{
    public partial class EntityUtils
    {
        public static void FillEntity<E>(OleDbDataReader reader, Object obj)
        {
            E entity = (E)obj;

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string columnName = reader.GetName(i);//数据库中字段的名字
                string propertyName = ToCamel(columnName);
                Object columnValue = reader.GetValue(i);

                PropertyInfo property = entity.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);

                if (Convert.IsDBNull(columnValue))
                {
                    property.SetValue(entity, null, null);
                }
                else
                {
                    property.SetValue(entity, columnValue, null);
                }


            }
        }

        //将数据库中的ColumnName首字母大写
        private static string ToCamel(string name)
        {


            //首字母大写
            return name.Substring(0, 1).ToUpper() + name.Substring(1);
        }

        public static object SqlNull(object obj)
        {
            if (obj == null)
                return DBNull.Value;

            return obj;
        }
    }
}
