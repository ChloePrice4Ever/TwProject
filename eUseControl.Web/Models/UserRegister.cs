using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eUseControl.Web.Models
{
    public class UserRegister
    {
        //Name
        [
            Display(Name = "Prenume"),
            Required(ErrorMessage = "Acest câmp este obligatoriu."),
            MinLength(4, ErrorMessage = "Lungimea minimă 4 caractere."),
            MaxLength(20, ErrorMessage = "Lungimea maximă 20 caractere.")
        ]
        public string Name { get; set; }

        //Surname
        [
            Display(Name = "Nume"),
            Required(ErrorMessage = "Acest câmp este obligatoriu."),
            MinLength(4, ErrorMessage = "Lungimea minimă 4 caractere."),
            MaxLength(20, ErrorMessage = "Lungimea maximă 20 caractere.")
        ]
        public string Surname { get; set; }

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
    }
}