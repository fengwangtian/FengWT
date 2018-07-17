using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Model.Sys
{
    public class Controllers
    {
        [Key]
        public string Controller_Id { get; set; }
        public string Site_Id { get; set; }
        public string Controllers_Name { get; set; }
        public string Controllers_Description { get; set; }
        public DateTime Controllers_CreateDate { get; set; }
    }
}
