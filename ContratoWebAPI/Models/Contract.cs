using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ContratoWebAPI.Models;

namespace ContratoWebAPI.Models
{
    public class Contract
    {
        [Key]
        public int Id { get {return Id;} private set{ } }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime HiringDate { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public double NumberOfInstallments { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public decimal ValueFinanced { get; set; }

        public double Installments { get; set; }
    }
}