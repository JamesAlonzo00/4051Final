using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model
{
    public class Appointment
    {
        private static int autoIncreament;
        public int Id { get; set; }
        public string date { get; set; }

        public Appointment()
        {
            autoIncreament++;
            Id = autoIncreament;
        }
    }
}
