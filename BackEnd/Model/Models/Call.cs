using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Call : BaseModel
    {
        [Key]
        public int CallID { get; set; }
        public string Location { get; set; }
        public DateTime? Date { get; set; }
        public string Project { get; set; }
        public bool IsDone { get; set; }
        public bool IsIncome { get; set; }
        public string Type { get; set; }
        [ForeignKey(nameof(ClientID))]
        public Client Client { get; set; }
        public int ClientID { get; set; }
        [ForeignKey(nameof(EmployeeID))]
        public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
    }
}
