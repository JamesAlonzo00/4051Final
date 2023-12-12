using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model
{
    public class Customer
    {
        private static int autoIncreament;
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string phoneNum { get; set; }
        public string Email { get; set; }

        public Customer()
        {
            autoIncreament++;
            Id = autoIncreament;
        }
    }
}
