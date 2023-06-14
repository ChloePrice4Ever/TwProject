using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eUseControl.Web.Models
{
    public class UserLogin
    {
        //Email
        [
            Display(Name = "Adresa de email"),
            Required(ErrorMessage = "Acest câmp este obligatoriu."),
            DataType(DataType.EmailAddress, ErrorMessage = "Introduce-ți o adresă de email validă.")
        ]
        public string Email { get; set; }

        //Password
        [
            Display(Name = "Parolă"),
            Required(ErrorMessage = "Acest câmp este obligatoriu."),
            MinLength(8, ErrorMessage = "Lungimea minimă 8 caractere."),
            MaxLength(40, ErrorMessage = "Lungimea maximă 40 caractere."),
            DataType(DataType.Password)
        ]
        public string Password { get; set; }

        //Remember
        [
            Display(Name = "Salvează parola?")
        ]
        public bool Remember { get; set; }
    }
}