﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSparkClient
{
    // Reference From https://stackoverflow.com/questions/1799370/getting-attributes-of-enums-value

    /// <summary>
    /// 枚举帮助类
    /// </summary>
    /// <remarks>
    /// 可快捷地获取到枚举的描述信息
    /// </remarks>
    public static class EnumHelper
    {
        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="enumVal">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        /// <remarks>
        /// <para>Using Example:</para>
        /// <para>
        /// string desc = myEnumVariable.GetAttributeOfType<see>
        ///     <cref>&amp;lt;DescriptionAttribute&amp;gt;</cref>
        /// </see>
        /// .Description();
        /// </para>
        /// </remarks>
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
    }
}