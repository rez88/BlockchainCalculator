using System;
using System.ComponentModel.DataAnnotations;

namespace ITUniver.Calc.DB.Models
{
    public class HistoryItem : IHistoryItem
    {
        public virtual long Id { get; set; }
        [Display(Name = "Операция")]
        public virtual long Operation { get; set; }
        [Display(Name = "Аргументы")]
        public virtual string Args { get; set; }
        [Display(Name = "Результат")]
        public virtual double? Result { get; set; }
        [Display(Name = "Дата выпонения")]
        public virtual DateTime ExecDate { get; set; }
        [Display(Name = "Автор")]
        public virtual User Author { get; set; }
    }
}
