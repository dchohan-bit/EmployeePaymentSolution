using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string userType { get; set; }
        public DateTime lastLoginDate { get; set; }
        public virtual ICollection<Board> boards { get; set; }
        public virtual ICollection<Post> posts { get; set; }
    }
}