using CadastrosFornecedores.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosFornecedores.Database
{
    public class FornecedorContext : DbContext
    {
        public FornecedorContext(DbContextOptions options) 
            : base(options)
        {           
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
