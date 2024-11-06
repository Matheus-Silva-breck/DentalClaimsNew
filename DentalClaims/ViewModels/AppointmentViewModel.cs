using System;
using System.ComponentModel.DataAnnotations;

namespace DentalClaims.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome do Paciente")]
        [Required(ErrorMessage = "O nome do paciente é obrigatório.")]
        public required string NomePaciente { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage = "A data é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Display(Name = "Procedimento")]
        [Required(ErrorMessage = "O procedimento é obrigatório.")]
        public required string Procedimento { get; set; }
    }
}
