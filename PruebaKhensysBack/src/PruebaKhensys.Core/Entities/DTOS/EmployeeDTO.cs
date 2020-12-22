
namespace PruebaKhensys.Core.Entities.DTOS
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public ExcuseTypeDTO ExcuseType { get; set; }
        public string Date { get; set; }
    }
}
