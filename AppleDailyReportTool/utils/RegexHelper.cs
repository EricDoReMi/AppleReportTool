using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AppleDailyReportTool.utils
{
    /// <summary>
    /// 正则表达式工具类
    /// </summary>
    public partial class RegexHelper
    {
        /// <summary>
        /// 通过正则表达式匹配出相应字符串,并获得第一个匹配结果
        /// </summary>
        /// <param name="regexStr">正则表达式</param>
        /// <param name="context">原始字符串</param>
        /// <returns>按正则表达式提取出的字符串</returns>
        public static string GetFirstStrByRegex(string regexStr, string context)
        {

            string returnStr = "";
            Regex regex = new Regex(regexStr, RegexOptions.IgnoreCase);

            MatchCollection matchs = regex.Matches(context);
            foreach (Match match in matchs)

            {

                returnStr = match.Value;
                return returnStr;

            }

            return returnStr;


        }

        /// <summary>
        /// 通过正则表达式匹配出相应字符串,已逗号分隔
        /// </summary>
        /// <param name="regexStr">正则表达式</param>
        /// <param name="context">原始字符串</param>
        /// <returns>按正则表达式提取出的字符串</returns>
        public static string GetStrArrComByRegex(string regexStr, string context)
        {

            string returnStr = "";
            Regex regex = new Regex(regexStr, RegexOptions.IgnoreCase | RegexOptions.Multiline);

            MatchCollection matchs = regex.Matches(context);
            foreach (Match match in matchs)

            {

                returnStr += match.Value + ",";

            }

            if (returnStr.Length > 0)
            {
                returnStr = returnStr.Substring(0, returnStr.Length - 1);
            }
            return returnStr;


        }

        /// <summary>
        /// 按正则表达式替换字符串中的字符
        /// </summary>
        /// <param name="regexStr"></param>
        /// <param name="context"></param>
        /// <param name="replaceStr"></param>
        /// <returns></returns>
        public static string ReplaceStrByRegex(string regexStr, string context, string replaceStr)
        {

            string returnStr = context;
            Regex regex = new Regex(regexStr, RegexOptions.IgnoreCase);
            MatchCollection matchs = regex.Matches(context);
            if (matchs.Count > 0)
            {
                returnStr = regex.Replace(context, replaceStr);
            }

            return returnStr;


        }
    }
}
