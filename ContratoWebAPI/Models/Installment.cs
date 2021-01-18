using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ContratoWebAPI.Models;

namespace ContratoWebAPI.Models
{
    public class Installment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public double Contracts { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public double ExpirationDate { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public decimal Value { get; set; }

        public string status { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Contrato inválida")]
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
    }
}