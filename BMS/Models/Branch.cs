using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BMS.Models
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int  CurrentEmployees { get; set; }
        public int CurrentManagers { get; set; }
        public double BranchBalance { get; set; }
    }
}