using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application.Services
{
    public static class CommonService //<T> where T : class
    {
        //private static T _item { get; set; }
        public static DateTime CreatedAt;
        public static int CreatedBy;
        public static bool IsActive;
        


        public static int GetCurrentUser()
        {
            return 1;
        }
    }
}
