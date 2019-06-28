using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Client : BaseModel
    {
        [Key]
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Source { get; set; }
        public string Classification { get; set; }
        public string Mobile { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string WhatsNumber { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public List<Call> Calls { get; set; }
        [ForeignKey(nameof(EmployeeID))]
        public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
    }
}
