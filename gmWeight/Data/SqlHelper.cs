using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;


namespace cj
{

    /// <summary>
    /// 数据库的通用访问代码 苏飞修改
    /// 
    /// 此类为抽象类， 
    /// 不允许实例化，在应用时直接调用即可
    /// </summary>
    public abstract class SqlHelper
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string connectionString = "Data Source=122.112.255.163;Initial Catalog=dtgm_shop2013_new;Persist Security Info=True;User ID=sa;Password=gMzx2018select123!@#;Pooling=true";
        // Hashtable to store cached parameters
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString {
            get { return connectionString; }
            set { connectionString = value; }
        }

        /// <summary>
        /// 获取使用的数据库(或快照)链接串
        /// </summary>
        /// <param name="commandText">存储过程名或都SQL命令文本</param>
        /// <returns></returns>
        public static string GetRealConnectionString(string commandText, CommandType commandType)
        {

            return connectionString;
        }

        #region//ExecteNonQuery方法

        /// <summary>
        ///执行一个不需要返回值的SqlCommand命令，通过指定专用的连接字符串。
        /// 使用参数数组形式提供参数列表 
        /// </summary>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
        public static int ExecteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            int val = 0;
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(GetRealConnectionString(cmdText, cmdType)))
            {
                try
                {
                    //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                    val = cmd.ExecuteNonQuery();
                }
                catch (Exception er)
                {
                    
                }
                //清空SqlCommand中的参数列表
                cmd.Parameters.Clear();
            }
            return val;
        }

        /// <summary>
        ///执行一个不需要返回值的SqlCommand命令，通过指定专用的连接字符串。
        /// 使用参数数组形式提供参数列表 
        /// </summary>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
        public static int ExecteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecteNonQuery(connectionString ,cmdType, cmdText, commandParameters);
        }

        /// <summary>
        ///存储过程专用
        /// </summary>
        /// <param name="cmdText">存储过程的名字</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
        public static int ExecteNonQueryProducts(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecteNonQuery(CommandType.StoredProcedure, cmdText, commandParameters);
        }

        /// <summary>
        ///Sql语句专用
        /// </summary>
        /// <param name="cmdText">T_Sql语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
        public static int ExecteNonQueryText(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecteNonQuery(CommandType.Text, cmdText, commandParameters);
        }

        /// <summary>
        ///执行一个不需要返回值的SqlCommand命令，通过指定专用的连接字符串。
        /// 使用参数数组形式提供参数列表 
        /// </summary>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdTextlist">存储过程的名字或者 T-SQL 语句</param>
        /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
        public static int ExecteNonQuery(string connectionString, CommandType cmdType, ArrayList cmdTextlist)
        {
            int num = 0;
            SqlCommand cmd = new SqlCommand();
            SqlTransaction tran; //定义事务            
            //OracleCommand Cmd = con.CreateCommand();
            //tran = mycon.BeginTransaction();//事务开始
            using (SqlConnection conn = new SqlConnection(GetRealConnectionString("insert", cmdType)))//使他自动变成写,到写连接字符串去
            {
                string sqls = "";
                conn.Open();
                tran = conn.BeginTransaction();//事务开始
                try
                {                    
                    foreach (string str in cmdTextlist)
                    {
                        sqls = str;//记录错误的
                        //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中
                        PrepareCommand(cmd, conn, tran, cmdType, str, null);
                        int val = cmd.ExecuteNonQuery();
                        num = num + val;  
                    }
                    tran.Commit();//全部成功提交
                    cmdTextlist.Clear();//清空数组信息
                }

                catch (Exception er)
                {
                    num = -1;
                    tran.Rollback();//有一个失败,回滚
                }

            }
            return num;
        }

        /// <summary>
        ///执行一个不需要返回值的SqlCommand命令，通过指定专用的连接字符串。
        /// 使用参数数组形式提供参数列表 
        /// </summary>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdTextlist">存储过程的名字或者 T-SQL 语句</param>
        /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
        public static int ExecteNonQuery(ArrayList cmdTextlist)
        {
            return ExecteNonQuery(connectionString, CommandType.Text, cmdTextlist);
        }

        #endregion
        #region//GetTable方法

        /// <summary>
        /// 执行一条返回结果集的SqlCommand，通过一个已经存在的数据库连接
        /// 使用参数数组提供参数
        /// </summary>
        /// <param name="connecttionString">一个现有的数据库连接</param>
        /// <param name="cmdTye">SqlCommand命令类型</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个表集合(DataTableCollection)表示查询得到的数据集</returns>
        public static DataTableCollection GetTable(string connecttionString, CommandType cmdTye, string cmdText, SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connecttionString))
            {
                try
                {
                    PrepareCommand(cmd, conn, null, cmdTye, cmdText, commandParameters);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);
                }
                catch (Exception er)
                {
                }
            }
            DataTableCollection table = ds.Tables;
            return table;
        }

        /// <summary>
        /// 执行一条返回结果集的SqlCommand，通过一个已经存在的数据库连接
        /// 使用参数数组提供参数
        /// </summary>
        /// <param name="cmdTye">SqlCommand命令类型</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个表集合(DataTableCollection)表示查询得到的数据集</returns>
        public static DataTableCollection GetTable(CommandType cmdTye, string cmdText, SqlParameter[] commandParameters)
        {
            return GetTable(connectionString, cmdTye, cmdText, commandParameters);
        }


        /// <summary>
        /// 存储过程专用
        /// </summary>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个表集合(DataTableCollection)表示查询得到的数据集</returns>
        public static DataTableCollection GetTableProducts(string cmdText, SqlParameter[] commandParameters)
        {
            return GetTable(CommandType.StoredProcedure, cmdText, commandParameters);
        }

        /// <summary>
        /// Sql语句专用
        /// </summary>
        /// <param name="cmdText"> T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个表集合(DataTableCollection)表示查询得到的数据集</returns>
        public static DataTableCollection GetTableText(string cmdText, SqlParameter[] commandParameters)
        {
            return GetTable(CommandType.Text, cmdText, commandParameters);
        }
        #endregion


        /// <summary>
        /// 为执行命令准备参数
        /// </summary>
        /// <param name="cmd">SqlCommand 命令</param>
        /// <param name="conn">已经存在的数据库连接</param>
        /// <param name="trans">数据库事物处理</param>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">Command text，T-SQL语句 例如 Select * from Products</param>
        /// <param name="cmdParms">返回带参数的命令</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            //判断数据库连接状态
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            //判断是否需要事物处理
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        #region//ExecuteReader方法
        /// <summary>
        /// 返回一个Reader
        /// </summary>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个Reader</returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlConnection conn = new SqlConnection(GetRealConnectionString(cmdText, cmdType));
            SqlCommand cmd = new SqlCommand();
            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch (Exception er)
            {
                conn.Close();
                return null;
            }

        }

        /// <summary>
        /// 返回一个Reader
        /// </summary>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个Reader</returns>
        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteReader(connectionString, cmdType, cmdText, commandParameters);
        }

        /// <summary>
        /// 返回一个Reader
        /// </summary>
        /// <param name="cmdText">存储过程的名字</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个Reader</returns>
        public static SqlDataReader ExecuteReaderProducts(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteReader(connectionString, CommandType.StoredProcedure, cmdText, commandParameters);
        }
        
        /// <summary>
        ///Sql语句专用(返回Reader)
        /// </summary>
        /// <param name="cmdText">T_Sql语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个Reader</returns>
        public static SqlDataReader ExecuteReaderText(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteReader(connectionString, CommandType.Text, cmdText, commandParameters);
        }
        #endregion


        #region//ExecuteDataSet方法

        /// <summary>
        /// return a dataset
        /// </summary>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>return a dataset</returns>
        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(GetRealConnectionString(cmdText, cmdType)))
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                }
                catch (Exception er)
                {
                }
            }
            return ds;
        }

        /// <summary>
        /// 返回一个DataSet
        /// </summary>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>return a dataset</returns>
        public static DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteDataSet(connectionString, cmdType, cmdText, commandParameters);
        }

        /// <summary>
        /// 返回一个DataSet
        /// </summary>
        /// <param name="cmdText">存储过程的名字</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>return a dataset</returns>
        public static DataSet ExecuteDataSetProducts(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteDataSet(connectionString, CommandType.StoredProcedure, cmdText, commandParameters);
        }

        /// <summary>
        /// 返回一个DataSet
        /// </summary>

        /// <param name="cmdText">T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>return a dataset</returns>
        public static DataSet ExecuteDataSetText(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteDataSet(connectionString, CommandType.Text, cmdText, commandParameters);
        }


        public static DataView ExecuteDataSet(string connectionString, string sortExpression, string direction, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            DataView dv = null;
            using (SqlConnection conn = new SqlConnection(GetRealConnectionString(cmdText, cmdType)))
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    dv = ds.Tables[0].DefaultView;
                    dv.Sort = sortExpression + " " + direction;                    
                }
                catch (Exception er){
                }
            }
            return dv;
        }
        #endregion


        #region // ExecuteScalar方法


        /// <summary>
        /// 返回第一行的第一列
        /// </summary>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个对象</returns>
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(SqlHelper.connectionString, cmdType, cmdText, commandParameters);
        }

        /// <summary>
        /// 返回第一行的第一列
        /// </summary>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个字符串</returns>
        public static string ExecuteScalarToStr(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            object ec = ExecuteScalar(SqlHelper.connectionString, cmdType, cmdText, commandParameters);
            if (ec == null)
            {
                return "";
            }
            return ec.ToString();
        }

        /// <summary>
        /// 返回第一行的第一列存储过程专用
        /// </summary>
        /// <param name="cmdText">存储过程的名字</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个对象</returns>
        public static object ExecuteScalarProducts(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(SqlHelper.connectionString, CommandType.StoredProcedure, cmdText, commandParameters);
        }

        /// <summary>
        /// 返回第一行的第一列Sql语句专用
        /// </summary>
        /// <param name="cmdText">者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个对象</returns>
        public static object ExecuteScalarText(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(SqlHelper.connectionString, CommandType.Text, cmdText, commandParameters);
        }

        /// <summary>
        /// 返回第一行的第一列Sql语句专用
        /// </summary>
        /// <param name="cmdText">者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回字符串</returns>
        public static string ExecuteScalarTextToStr(string cmdText, params SqlParameter[] commandParameters)
        {
            object ec = ExecuteScalar(SqlHelper.connectionString, CommandType.Text, cmdText, commandParameters);
            if (ec == null)
            {
                return "";
            }
            return ec.ToString();
        }

        /// <summary>
        /// Execute a SqlCommand that returns the first column of the first record against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            object val = null;
            using (SqlConnection connection = new SqlConnection(GetRealConnectionString(cmdText, cmdType)))
            {
                val = ExecuteScalar(connection, cmdType, cmdText, commandParameters);
            }
            return val;
        }

        /// <summary>
        /// Execute a SqlCommand that returns the first column of the first record against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            object val = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                val = cmd.ExecuteScalar();
            }
            catch (Exception er)
            {
            }
            cmd.Parameters.Clear();
            return val;
        }

        #endregion


        /// <summary>
        /// add parameter array to the cache
        /// </summary>
        /// <param name="cacheKey">Key to the parameter cache</param>
        /// <param name="cmdParms">an array of SqlParamters to be cached</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// Retrieve cached parameters
        /// </summary>
        /// <param name="cacheKey">key used to lookup parameters</param>
        /// <returns>Cached SqlParamters array</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];
            if (cachedParms == null)
                return null;
            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();
            return clonedParms;
        }

        #region 生成参数

        public static SqlParameter MakeInParam(string ParamName, SqlDbType DbType,  object Value)
        {
            return MakeParam(ParamName, DbType, 0, ParameterDirection.Input, Value);
        }
        public static SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        public static SqlParameter MakeOutParam(string ParamName, SqlDbType DbType)
        {
            return MakeParam(ParamName, DbType, 0, ParameterDirection.Output, null);
        }

        public static SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }

        public static SqlParameter MakeReParam(string ParamName, SqlDbType DbType)
        {
            return MakeParam(ParamName, DbType, 0, ParameterDirection.ReturnValue, null);
        }

        public static SqlParameter MakeReParam(string ParamName, SqlDbType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.ReturnValue, null);
        }

        public static SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;

            param = MakeParam(ParamName, DbType, Size);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;

            return param;
        }

        private static SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size)
        {
            SqlParameter param;

            if (Size > 0)
                param = new SqlParameter(ParamName, DbType, Size);
            else
                param = new SqlParameter(ParamName, DbType);

            return param;
        }

        #endregion 生成参数结束


        /// <summary>
        /// 检查是否存在
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        /// <returns>bool结果</returns>
        public static bool Exists(string strSql)
        {
            int cmdresult = Convert.ToInt32(ExecuteScalar(connectionString, CommandType.Text, strSql, null));
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 检查是否存在
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        /// <param name="cmdParms">参数</param>
        /// <returns>bool结果</returns>
        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            int cmdresult = Convert.ToInt32(ExecuteScalar(connectionString, CommandType.Text, strSql, cmdParms));
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}