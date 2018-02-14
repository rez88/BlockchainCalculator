﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCalc.Models
{
    public class LoginModel
    {

        [Display(Name = "Пользователь")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ты кто такой?")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Без пароля нельзя")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}