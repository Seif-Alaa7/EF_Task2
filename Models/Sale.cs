using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seperated_project.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public Product product { get; set; }
        public Customer customer { get; set; }
        public Store store { get; set; }
    }
}
