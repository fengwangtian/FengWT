using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Model.Sys
{
    public class Actions
    {
        [Key]
        public string Action_Id { get; set; }
        public string Controller_Id { get; set; }
        public string Action_Name { get; set; }
        public string Action_Description { get; set; }
        public DateTime Action_CreateDate { get; set; }
    }
}
