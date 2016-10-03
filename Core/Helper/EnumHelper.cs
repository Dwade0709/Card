using System;

/// <summary>
/// 
/// </summary>
namespace Core.Helper
{
    public static class EnumHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T? ToEnumSafe<T>(this string s) where T : struct
        {
            return (IsEnum<T>(s) ? (T?)Enum.Parse(typeof(T), s) : null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsEnum<T>(this string s)
        {
            return Enum.IsDefined(typeof(T), s);
        }

    }
}
