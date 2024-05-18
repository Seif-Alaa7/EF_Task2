using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_12_EF.Models
{
    public class Resource
    {
        public enum Type
        {
            Video,
            Presentation,
            Document,
            Other

        }
        public int ResourceId { get; set; }
        public string Name { get; set; }
        public String Url { get; set; }
        public Type ResourceType { get; set; }
        public int CourseId { get; set; }

    }
}
