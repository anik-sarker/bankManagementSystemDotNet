using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BMS.Models
{
    public class MangrTransection
    {
        public Branch Branch { get; set; }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Enter the destination branch id")]
        public int BranchId { get; set; }
        public double Amount { get; set; }
        public string TransDate { get; set; } //current Date 
        public bool Authorized { get; set; }

    }
}