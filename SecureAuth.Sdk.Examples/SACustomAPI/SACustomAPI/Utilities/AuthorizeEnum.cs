using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SACustomAPI.Utilities
{
    public class AuthorizeEnum
    {
        [Flags]
        public enum State
        {
            Index = 0x0,
            Adapt = 0x1,
            Select = 0x2,
            Otp = 0x4
        }
    }
}