using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCalc.Models
{
    public class RegisterModel
    {
        [Display(Name = "Имя")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ты кто такой?")]
        public string Name { get; set; }

        [Display(Name = "Логин")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Без логина нельзя")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Без пароля нельзя")]
        public string Password { get; set; }

        [Display(Name = "Дата рождения")]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Пол")]
        public bool Sex { get; set; }

    }
}