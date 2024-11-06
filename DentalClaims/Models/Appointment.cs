using System;
using System.ComponentModel.DataAnnotations;

namespace DentalClaims.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do paciente é obrigatório.")]
        public string NomePaciente { get; set; } = string.Empty;  // Valor padrão

        [Required(ErrorMessage = "A data é obrigatória.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O procedimento é obrigatório.")]
        public string Procedimento { get; set; } = string.Empty;  // Valor padrão

        public Appointment() { }

        public Appointment(string nomePaciente, DateTime data, string procedimento)
        {
            NomePaciente = nomePaciente;
            Data = data;
            Procedimento = procedimento;
        }
    }
}
