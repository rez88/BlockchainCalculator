using ITUniver.Calc.DB.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITUniver.Calc.DB.Models
{
    public class Operation : IEntity
    {
        public virtual long Id { get; set; }
        [Display(Name = "Операция")]
        public virtual string Name { get; set; }
        [Display(Name = "Автор")]
        public virtual string Owner { get; set; }
        [Display(Name = "Аргументы")]
        public virtual int ArgsCount { get; set; }
        [Display(Name = "Дата обработки")]
        public virtual DateTime CreationDate { get; set; }
        public virtual ICollection<HistoryItem> History { get; set; }
    }
}
