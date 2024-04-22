using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data;

namespace ITcompanyDB.Models
{
    public class Company
    {
        [DisplayName("Идентификатор")]
        public int CompanyId { get; set; }

        [DisplayName("Название компании")]
        public string CompanyName { get; set; } = string.Empty;

        [DisplayName("Дата основания")]
        [DataType(DataType.Date)]
        public DateTime FoundedDate { get; set; }

        [DisplayName("Тип компании")]
        public string Type { get; set; } = string.Empty;

        [DisplayName("Количество сотрудников")]
        public int EmployeeCount { get; set; }

        [DisplayName("Выручка (в миллионах)")]
        public decimal Revenue { get; set; }
    }
}
