using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Security.Cryptography;
using cj;

namespace gmWeight
{
    static class Dao
    {
        /// <summary>
        /// 尝试登陆
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userpassword"></param>
        /// <returns></returns>
        public static DataTable tryLogin(string username, string userpassword)
        {
            DataTable dt = new DataTable();
            string sql_select = string.Empty;
            try
            {
                userpassword = md5(userpassword);
                sql_select = string.Format("SELECT tid,name,style,safeCode,phone,lineGroup FROM logisticsTerminal WHERE code = '{0}' AND codeKey = '{1}' AND workStatus = 1", username, userpassword);
                dt = SqlHelper.ExecuteDataSetText(sql_select).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        /// <summary>
        /// 生成MD5码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static string md5(string data)
        {
            data = data + "jetaime2018";
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding("GB2312").GetBytes(data));
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }



    }
}
