using ITUniver.Calc.DB.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITUniver.Calc.DB.Models
{
    public class User : IEntity
    {
        public virtual long Id { get; set; }
        [Display(Name = "Имя")]
        public virtual string Name { get; set; }
        [Display(Name = "Логин")]
        public virtual string Login { get; set; }
        [Display(Name = "Пароль")]
        public virtual string Password { get; set; }
        [Display(Name = "Пол")]
        public virtual bool Sex { get; set; }
        [Display(Name = "Дата рождения")]
        public virtual DateTime? BirthDay { get; set; }

        public virtual ICollection<HistoryItem> History { get; set; }
        [Display(Name = "Статус")]
        public virtual UserStatus Status { get; set; }
        [Display(Name = "Доступ")]
        public virtual Role Role { get; set; }
    }

    public enum UserStatus
    {  
        Deleted = 0,
        Active = 1,
        Ban = 2
    }
}
