﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebApp.Models
{
    public class PasswordResetViewModel : LoginViewModel
    {
        public string Token { get; set; }
    }
}
