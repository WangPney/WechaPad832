using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Wechat.Util.Db
{

    public static class SqlLiteHelper
    {
        public static string DBName = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "jianwangsan.db");//"D:/jianwang111.db";
        public static string ipadDBName = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "ipadAuth.db");//"D:/jianwang111.db";

        public static void CreateDatabase(string databaseName)
        {
            SQLiteConnection.CreateFile(databaseName);
        }


        /// <summary>
        /// 获取连接
        /// </summary>
        /// <returns></returns>
        public static SQLiteConnection GetConnection(string databaseName)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection($"Data Source={databaseName};Pooling=true;FailIfMissing=false;Journal Mode=WAL");
            if (m_dbConnection.State != ConnectionState.Open)
            {
                m_dbConnection.Open();
            }
            return m_dbConnection;


        }


        public static int ExcuteSql(this SQLiteConnection dbConnection, string sql, bool closeConection = false)
        {
            int count = 0;
            try
            {
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                count = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Util.Log.Logger.GetLog("SqlliteHelper").Error(sql, ex);
                throw ex;
            }
            finally
            {
                if (closeConection)
                {
                    dbConnection.Close();
                }
            }
            return count;

        }

        public static T QuerySql<T>(this SQLiteConnection dbConnection, string sql, bool closeConection = false) where T : new()
        {
            T result = default(T);
            try
            {
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    result = reader.To<T>();
                }

            }
            catch (Exception ex)
            {
                Util.Log.Logger.GetLog("SqlliteHelper").Error(sql, ex);
                throw ex;
            }
            finally
            {
                if (closeConection)
                {
                    dbConnection.Close();
                }
            }
            return result;
        }

        public static IList<T> QueryListSql<T>(this SQLiteConnection dbConnection, string sql, bool closeConection = false) where T : new()
        {
            IList<T> result = default(IList<T>);
            try
            {
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                result = reader.ToList<T>();

            }
            catch (Exception ex)
            {
                Util.Log.Logger.GetLog("SqlliteHelper").Error(sql, ex);
                throw ex;
            }
            finally
            {
                if (closeConection)
                {
                    dbConnection.Close();
                }
            }
            return result;
        }
    }


    public static class SqlDataReaderEx
    {
        /// <summary>
        /// 属性反射信息缓存 key:类型的hashCode,value属性信息
        /// </summary>
        private static Dictionary<int, Dictionary<string, PropertyInfo>> propInfoCache = new Dictionary<int, Dictionary<string, PropertyInfo>>();

        /// <summary>
        /// 将SqlDataReader转成T类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static T To<T>(this SQLiteDataReader reader) where T : new()
        {
            if (reader == null || reader.HasRows == false) return default(T);

            var res = new T();
            var propInfos = GetFieldnameFromCache<T>();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                var n = reader.GetName(i).ToLower();
                if (propInfos.ContainsKey(n))
                {
                    PropertyInfo prop = propInfos[n];

                    object defaultValue = null;//引用类型或可空值类型的默认值

                    if (prop.PropertyType == typeof(string))
                    {
                        defaultValue = default(string);
                        var v = reader.GetString(i);
                        prop.SetValue(res, (Convert.IsDBNull(v) ? defaultValue : v), null);
                    }
                    else if (prop.PropertyType == typeof(int))
                    {
                        defaultValue = default(int);
                        var v = reader.GetInt32(i);
                        prop.SetValue(res, (Convert.IsDBNull(v) ? defaultValue : v), null);
                    }
                    else if (prop.PropertyType == typeof(decimal))
                    {
                        defaultValue = default(decimal);
                        var v = reader.GetDecimal(i);
                        prop.SetValue(res, (Convert.IsDBNull(v) ? defaultValue : v), null);
                    }
                    else if (prop.PropertyType == typeof(double))
                    {
                        defaultValue = default(double);
                        var v = reader.GetDouble(i);
                        prop.SetValue(res, (Convert.IsDBNull(v) ? defaultValue : v), null);
                    }
                    else if (prop.PropertyType == typeof(DateTime))
                    {
                        defaultValue = default(DateTime);
                        var v = reader.GetString(i);
                        prop.SetValue(res, (Convert.IsDBNull(v) ? defaultValue : v), null);
                    }
                    else if (prop.PropertyType == typeof(bool))
                    {
                        defaultValue = default(bool);
                        var v = reader.GetBoolean(i);
                        prop.SetValue(res, (Convert.IsDBNull(v) ? defaultValue : v), null);
                    }
                    else
                    {
                        defaultValue = default(object);
                        var v = reader.GetValue(i);
                        prop.SetValue(res, (Convert.IsDBNull(v) ? defaultValue : v), null);
                    }



                }
            }

            return res;
        }

        private static Dictionary<string, PropertyInfo> GetFieldnameFromCache<T>()
        {
            Dictionary<string, PropertyInfo> res = null;
            var hashCode = typeof(T).GetHashCode();
            if (!propInfoCache.ContainsKey(hashCode))
            {
                propInfoCache.Add(hashCode, GetFieldname<T>());
            }
            res = propInfoCache[hashCode];
            return res;
        }

        /// <summary>
        /// 获取一个类型的对应数据表的字段信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static Dictionary<string, PropertyInfo> GetFieldname<T>()
        {
            var res = new Dictionary<string, PropertyInfo>();
            var props = typeof(T).GetProperties();
            foreach (PropertyInfo item in props)
            {
                res.Add(item.GetFiledName(), item);
            }
            return res;
        }



        /// <summary>
        /// 将SqlDataReader转成List<T>类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this SQLiteDataReader reader) where T : new()
        {
            if (reader == null || reader.HasRows == false) return null;
            var res = new List<T>();
            while (reader.Read())
            {
                res.Add(reader.To<T>());
            }
            return res;
        }

        /// <summary>
        /// 获取该属性对应到数据表中的字段名称
        /// </summary>
        /// <param name="propInfo"></param>
        /// <returns></returns>
        public static string GetFiledName(this PropertyInfo propInfo)
        {
            var fieldname = propInfo.Name;
            var attr = propInfo.GetCustomAttributes(false);
            foreach (var a in attr)
            {
                if (a is DataFieldAttribute)
                {
                    fieldname = (a as DataFieldAttribute).Name;
                    break;
                }
            }
            return fieldname.ToLower();
        }
    }


    public class DataFieldAttribute : Attribute
    {
        public DataFieldAttribute()
        {

        }
        public DataFieldAttribute(string name)
        {
            m_name = name;
        }
        private string m_name = null;

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
    }


}
