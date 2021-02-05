using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace CodeBase.Helpers
{
    public class Util
    {
        public static bool IsEmailAlreadyUsed(string email)
        {
            return Current.Services.MemberService.GetByEmail(email) != null;
        }

        public static bool IsUsernameAlreadyUsed(string username)
        {
            return Current.Services.MemberService.GetByUsername(username) != null;
        }
    }
}
