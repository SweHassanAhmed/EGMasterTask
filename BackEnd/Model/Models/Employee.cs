using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Employee : BaseModel
    {
        [Key]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Client> Clients { get; set; }
        public List<Call> Calls { get; set; }
    }
}
