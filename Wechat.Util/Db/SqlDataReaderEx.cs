using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Reflection;

namespace Wechat.Util.Db
{
    // Token: 0x02000015 RID: 21
    public static class SqlDataReaderEx
    {
        // Token: 0x0600006A RID: 106 RVA: 0x000033B8 File Offset: 0x000015B8
        public static T To<T>(this SQLiteDataReader reader) where T : new()
        {
            if (reader == null || !reader.HasRows)
            {
                return default(T);
            }
            T t = Activator.CreateInstance<T>();
            Dictionary<string, PropertyInfo> fieldnameFromCache = SqlDataReaderEx.GetFieldnameFromCache<T>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string key = reader.GetName(i).ToLower();
                if (fieldnameFromCache.ContainsKey(key))
                {
                    PropertyInfo propertyInfo = fieldnameFromCache[key];
                    if (propertyInfo.PropertyType == typeof(string))
                    {
                        object obj = null;
                        string @string = reader.GetString(i);
                        propertyInfo.SetValue(t, Convert.IsDBNull(@string) ? obj : @string, null);
                    }
                    else if (propertyInfo.PropertyType == typeof(int))
                    {
                        object obj = 0;
                        int @int = reader.GetInt32(i);
                        propertyInfo.SetValue(t, Convert.IsDBNull(@int) ? obj : @int, null);
                    }
                    else if (propertyInfo.PropertyType == typeof(decimal))
                    {
                        object obj = 0m;
                        decimal @decimal = reader.GetDecimal(i);
                        propertyInfo.SetValue(t, Convert.IsDBNull(@decimal) ? obj : @decimal, null);
                    }
                    else if (propertyInfo.PropertyType == typeof(double))
                    {
                        object obj = 0.0;
                        double @double = reader.GetDouble(i);
                        propertyInfo.SetValue(t, Convert.IsDBNull(@double) ? obj : @double, null);
                    }
                    else if (propertyInfo.PropertyType == typeof(DateTime))
                    {
                        object obj = default(DateTime);
                        string string2 = reader.GetString(i);
                        propertyInfo.SetValue(t, Convert.IsDBNull(string2) ? obj : string2, null);
                    }
                    else if (propertyInfo.PropertyType == typeof(bool))
                    {
                        object obj = false;
                        bool boolean = reader.GetBoolean(i);
                        propertyInfo.SetValue(t, Convert.IsDBNull(boolean) ? obj : boolean, null);
                    }
                    else
                    {
                        object obj = null;
                        object value = reader.GetValue(i);
                        propertyInfo.SetValue(t, Convert.IsDBNull(value) ? obj : value, null);
                    }
                }
            }
            return t;
        }

        // Token: 0x0600006B RID: 107 RVA: 0x00003644 File Offset: 0x00001844
        private static Dictionary<string, PropertyInfo> GetFieldnameFromCache<T>()
        {
            int hashCode = typeof(T).GetHashCode();
            if (!SqlDataReaderEx.propInfoCache.ContainsKey(hashCode))
            {
                SqlDataReaderEx.propInfoCache.Add(hashCode, SqlDataReaderEx.GetFieldname<T>());
            }
            return SqlDataReaderEx.propInfoCache[hashCode];
        }

        // Token: 0x0600006C RID: 108 RVA: 0x0000368C File Offset: 0x0000188C
        private static Dictionary<string, PropertyInfo> GetFieldname<T>()
        {
            Dictionary<string, PropertyInfo> dictionary = new Dictionary<string, PropertyInfo>();
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                dictionary.Add(propertyInfo.GetFiledName(), propertyInfo);
            }
            return dictionary;
        }

        // Token: 0x0600006D RID: 109 RVA: 0x000036D0 File Offset: 0x000018D0
        public static List<T> ToList<T>(this SQLiteDataReader reader) where T : new()
        {
            if (reader == null || !reader.HasRows)
            {
                return null;
            }
            List<T> list = new List<T>();
            while (reader.Read())
            {
                list.Add(reader.To<T>());
            }
            return list;
        }

        // Token: 0x0600006E RID: 110 RVA: 0x00003708 File Offset: 0x00001908
        public static string GetFiledName(this PropertyInfo propInfo)
        {
            string name = propInfo.Name;
            foreach (object obj in propInfo.GetCustomAttributes(false))
            {
                if (obj is DataFieldAttribute)
                {
                    name = (obj as DataFieldAttribute).Name;
                    break;
                }
            }
            return name.ToLower();
        }

        // Token: 0x04000033 RID: 51
        private static Dictionary<int, Dictionary<string, PropertyInfo>> propInfoCache = new Dictionary<int, Dictionary<string, PropertyInfo>>();
    }
}
