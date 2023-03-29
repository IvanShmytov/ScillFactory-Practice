using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Db
{
    [Table("Roles")]
    public class Role
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Поле Имя обязательно для заполнения")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 2)]
        [Display(Name = "Имя", Prompt = "Введите имя")]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
