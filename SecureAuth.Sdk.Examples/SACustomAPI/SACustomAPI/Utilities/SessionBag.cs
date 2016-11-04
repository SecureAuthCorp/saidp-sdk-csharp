using System.Dynamic;
using System.Web;

namespace SACustomAPI.Utilities
{
    public sealed class SessionBag : DynamicObject
    {
        private static readonly SessionBag sessionBag;

        static SessionBag()
        {
            sessionBag = new SessionBag();
        }

        private SessionBag()
        {
        }

        private HttpSessionStateBase Session
        {
            get { return new HttpSessionStateWrapper(HttpContext.Current.Session); }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = Session[binder.Name];
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            Session[binder.Name] = value;
            return true;
        }

        public override bool TryGetIndex(GetIndexBinder
               binder, object[] indexes, out object result)
        {
            int index = (int)indexes[0];
            result = Session[index];
            return result != null;
        }

        public override bool TrySetIndex(SetIndexBinder binder,
               object[] indexes, object value)
        {
            int index = (int)indexes[0];
            Session[index] = value;
            return true;
        }

        public static dynamic Current
        {
            get { return sessionBag; }
        }
    }
}