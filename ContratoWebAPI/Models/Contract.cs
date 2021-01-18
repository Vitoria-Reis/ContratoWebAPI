using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContratoWebAPI.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public date HiringDate { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public double NumberOfInstallments { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public decimal ValueFinanced { get; set; }

        public double Installments { get; set; }
    }
}