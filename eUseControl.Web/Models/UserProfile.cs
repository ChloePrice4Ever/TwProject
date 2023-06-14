using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eUseControl.Domain.Enums;

namespace eUseControl.Web.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ProfileUrl { get; set; }
    }
}