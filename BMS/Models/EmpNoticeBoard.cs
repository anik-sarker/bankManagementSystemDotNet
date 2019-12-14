﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BMS.Models
{
    public class EmpNoticeBoard
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string MesBody { get; set; }
        public bool Seen { get; set; } = false;
    }
}