using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace entCMS.Common
{
    public static class ConverterHelper
    {
        /// <summary>
        /// 泛型转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ConverterValue<T>(object value)
        {
            T obj = default(T);

            //尝试 调用Convert类
            try
            {
                string method = "To" + typeof(T).Name;//需要反射的方法名称,即Convert类中的方法名称
                MethodInfo mi = typeof(Convert).GetMethod(method, new Type[] { typeof(object) });
                obj = (T)(mi.Invoke(null, new object[] { value }));
            }
            catch
            {
            }

            return obj;
        }
    }
}
