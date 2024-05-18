using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_12_EF.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public String Name { get; set; } = null!;
        public int? PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }
        public List<Course>? Courses { get; set; }
        public List<Homework>? Homeworks { get; set; }

    }
}
