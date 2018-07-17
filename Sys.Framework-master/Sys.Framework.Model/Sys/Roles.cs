using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Model.Sys
{
    public class Roles
    {
        [Key]
        public string Role_Id { get; set; }
        public string Role_Name { get; set; }
    }
}
