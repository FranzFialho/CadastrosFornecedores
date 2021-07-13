using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadastrosFornecedores.Models
{
    public class Empresa
    {
        public int Id{ get; set; }

        [Required, MaxLength(2)]
        [DisplayName("Estado")]
        public string UF { get; set; }

        [Required]
        [DisplayName("Nome da Empresa")]
        public string Nome { get; set; }

        [Required, MaxLength(18)]
        [DisplayName("CNPJ")]
        public string Cnpj { get; set; }

        public ICollection<Fornecedor> Fornecedores { get; set; }
    }
}
