using System;

namespace PruebaKhensys.Core.Entities.Models
{
    public class Employee : BaseModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public DateTime Date { get; set; }
    }
}
