using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class reg_Page
    {
        [Key]
        public int UserId { get; set; }
        public string F_name { get; set; }
        public string L_name { get; set; }
        public string Phone_no { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}