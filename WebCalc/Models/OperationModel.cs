using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCalc.Models
{
    public class OperationModel
    {
        [Display(Name = "Операция")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Непонятно какую операцию выполнять!")]
        public string Operation { get; set; }

        [Display(Name = "Аргументы")]
        public IEnumerable<double> Args { get; set; }

        [Display(Name = "Результ")]
        [ReadOnly(true)]
        public double? Result { get; set; }

    }
}