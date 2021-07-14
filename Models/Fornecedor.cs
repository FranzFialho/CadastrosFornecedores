using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadastrosFornecedores.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required]
        [DisplayName("CPF / CNPJ")]
        public string Cpf_Cnpj { get; set; }

        [Required]
        [DisplayName("Nº Telefone")]
        public string Telefone { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }


        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }


    }
}
