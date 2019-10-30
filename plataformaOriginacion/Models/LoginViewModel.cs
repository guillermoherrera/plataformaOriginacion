using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plataformaOriginacion.Models
{
    public class LoginViewModel
    {
        [BindProperty]
        public InputModel input { get; set; }

        [TempData]
        public String ErrorMenssage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "<font color='red'>El campo Usuario es obligatorio</font>")]
            //[EmailAddress(ErrorMessage = "<font color='red'>El campo Correo electronico debe tener un formato valido</font>")]
            public String User { get; set; }

            [Required(ErrorMessage = "<font color='red'>El campo Contraseña es obligatorio</font>")]
            [DataType(DataType.Password)]
            [StringLength(100, ErrorMessage = "<font color='red'>El numero de caracteres del {0} debe ser al menos {2}</font>", MinimumLength = 3)]
            public String Password { get; set; }

        }
    }
}
