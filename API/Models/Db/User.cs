using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Db
{
    [Table("Users")]
    public class User
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле Имя обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Имя", Prompt = "Введите имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле Фамилия обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия", Prompt = "Введите фамилию")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле Email обязательно для заполнения")]
        [EmailAddress]
        [Display(Name = "Login", Prompt = "example.com")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле Пароль обязательно для заполнения")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль", Prompt = "Введите пароль")]
        [StringLength(100, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 3)]
        public string Password { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public User()
        {
            Roles = new List<Role>();
            Comments = new List<Comment>();
        }
    }
}
