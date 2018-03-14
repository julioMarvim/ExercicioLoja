using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioLoja.Entidades
{
    public class Fornecedor
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }                
        public virtual string Telefone { get; set; }
        public virtual string Endereco { get; set; }
        public virtual int CNPJ { get; set; }
        public virtual IList<Produto> Produtos { get; set; }
    }
}
