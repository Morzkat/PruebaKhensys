using System;

namespace PruebaKhensys.Core.Entities.Models
{
    public class Employee : BaseModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public ExcuseType ExcuseType { get; set; }
        public DateTime Date { get; set; }
    }
}
