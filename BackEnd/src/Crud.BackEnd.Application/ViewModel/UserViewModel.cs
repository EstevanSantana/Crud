using Crud.BackEnd.Domain.Enum;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Crud.BackEnd.Application.ViewModel
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("FirstName")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]

        public string FistName { get; set; }

        [DisplayName("LastName")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]

        public string LastName { get; set; }

        [EmailAddress]
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Birthday")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Schooling { get; set; }
    }
}
