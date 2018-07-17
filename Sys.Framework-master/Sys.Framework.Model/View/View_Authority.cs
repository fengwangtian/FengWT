using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sys.Framework.Model.View
{
    public class View_Authority
    {
        [Key]
        public string User_Id { set; get; }
        public int Site_Id { set; get; }
        public string Controller_Name { set; get; }
        public string Action_Name { set; get; }
    }
}