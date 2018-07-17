using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Model.Sys
{
    public class RoleActions
    {
        [Key]
        public string Role_Id { get; set; }
        public string Action_Id { get; set; }
    }
}
