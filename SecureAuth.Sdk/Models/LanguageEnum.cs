using System;
using System.ComponentModel;

namespace SecureAuth.Sdk.Models
{
    public enum LanguageEnum
    {
        [Description("en")]
        English = 0,
        [Description("ar")]
        Arabic = 1,
        [Description("zh-Hans")]
        ChineseSimplified = 2,
        [Description("zh-Hant")]
        ChineseTraditional = 3,
        [Description("cs")]
        Czech = 4,
        [Description("nl")]
        Dutch = 5,
        [Description("fr")]
        French = 6,
        [Description("de")]
        German = 7,
        [Description("hu")]
        Hungarian = 8,
        [Description("it")]
        Italian = 9,
        [Description("ja")]
        Japanese = 10,
        [Description("ko")]
        Korean = 11,
        [Description("pl")]
        Polish = 12,
        [Description("pt")]
        Portuguese = 13,
        [Description("ro")]
        Romanian = 14,
        [Description("ru")]
        Russian = 15,
        [Description("sk")]
        Slovak = 16,
        [Description("es")]
        Spanish = 17
    }
}
