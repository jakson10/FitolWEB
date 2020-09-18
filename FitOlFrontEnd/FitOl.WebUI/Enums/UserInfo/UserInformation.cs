using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FitOl.WebUI.Enums.UserInfo
{
    public class UserInformation
    {
        public string Token { get; set; }

        public AppUserDtoss appUser { get; set; }

    }
}
