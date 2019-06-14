using System;
using System.ComponentModel;
using System.Reflection;

namespace SecureAuth.Sdk.Models
{
    public static class LanguageWrapper
    {
        /// <summary>
        /// Gets the description of an enum from LanguageEnum.
        /// </summary>
        /// <returns>The description, which will be the language code used for SMS delivery.</returns>
        /// <param name="en">The Enum</param>
        public static string GetDescription(LanguageEnum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if(memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if(attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }
    }
}
