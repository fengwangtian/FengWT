using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Model.Sys
{
    public class UserInfo
    {
        [Key]
        public string User_Id { get; set; }
        public string User_LoginName { get; set; }
        public string User_Name { get; set; }
        public string User_LoginPassword { get; set; }
        public DateTime User_CreateDate { get; set; }
        public int User_State { get; set; }
        public string User_Role { get; set; }
    }
}
