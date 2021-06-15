using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CadastrosFornecedores.Models
{
    public class Empresa
    {
        public int Id{ get; set; }

        [Required, MaxLength(2)]
        public string UF { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required, MaxLength(18)]
        public string Cnpj { get; set; }

        public ICollection<Fornecedor> Fornecedores { get; set; }
    }
}
