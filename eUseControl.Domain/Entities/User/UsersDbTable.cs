using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eUseControl.Domain.Enums;

namespace eUseControl.Domain.Entities.User
{
    public class UsersDbTable
    {
        //Id
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
            MaxLength(30, ErrorMessage = "Lungimea maximă 30 caractere.")
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

        //Level
        public URole Level { get; set; }

        //AvatarUrl
        [StringLength(100)]
        public string AvatarUrl { get; set; }

        //RegisterDate
        [DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; }

        //UpdateRegisterDate
        [DataType(DataType.Date)]
        public DateTime UpdateRegisterDate { get; set; }

        //PrivateIp
        [StringLength(15)]
        public string PrivateIp { get; set; }

        //LastLogin
        [DataType(DataType.Date)]
        public Nullable<DateTime> LastLogin { get; set; }

    }
}
