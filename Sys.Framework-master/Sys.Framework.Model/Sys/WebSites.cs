using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Framework.Model.Sys
{
    public class WebSites
    {
        [Key]
        public string Site_Id { get; set; }
        public string Site_Name { get; set; }
    }
}
