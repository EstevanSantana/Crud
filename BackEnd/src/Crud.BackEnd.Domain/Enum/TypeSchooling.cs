using System.ComponentModel.DataAnnotations;

namespace Crud.BackEnd.Domain.Enum
{
    public enum TypeSchooling
    {
        [Display(Name = "Infantil")]
        Children = 1,
        [Display(Name = "Fundamental")]
        Elementary = 2,
        [Display(Name = "Médio")]
        Middle = 3,
        [Display(Name = "Superior")]
        Higher = 4
    }
}
