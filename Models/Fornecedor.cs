using System;
using System.ComponentModel.DataAnnotations;

namespace CadastrosFornecedores.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        [Required]
        public string Cpf_Cnpj { get; set; }

        [Required]
        [DataType(DataType.Date)] 
        [DisplayFormat(DataFormatString = "0:dd/MM/yyyy hh:MM:ss")]
        public DateTime HoraCadastro { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)] 
        public string Telefone { get; set; }

        [Required]
        public bool PessoaFisica { get; set; }

        [Required]
        public string RG { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="0:dd/MM/yyyy")]
        public DateTime DataNascimento { get; set; }

        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }


    }
}
