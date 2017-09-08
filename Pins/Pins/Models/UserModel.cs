using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pins.Models
{
    public class UserModel
    {
        [PrimaryKey]
        public string ID { get;  set;}
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string email { get; set; }
    }
}