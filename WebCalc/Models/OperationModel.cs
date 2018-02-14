using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Models
{
    public class OperationModel
    {
        public OperationModel()
        {
            Operations = new List<SelectListItem>();
        }

        [Display(Name = "Операция")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Непонятно какую операцию выполнять!")]
        public string Operation { get; set; }

        [Display(Name = "Аргументы")]
        public IEnumerable<double> Args { get; set; }

        [Display(Name = "Результ")]
        [ReadOnly(true)]
        public double? Result { get; set; }

        public IEnumerable<SelectListItem> Operations { get; set; }

    }
}