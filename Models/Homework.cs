using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_12_EF.Models
{
    public class Homework
    {
        public enum Type
        {
            Application,
            Pdf,
            Zip
        }
        public int HomeworkId { get; set; }
        public string Content { get; set; }
        public Type ContentType { get; set; }
        public DateTime SubmissionTime { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

    }
}
