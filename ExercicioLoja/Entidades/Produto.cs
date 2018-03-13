using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioLoja.Entidades
{
    public class Produto
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual DateTime DataDeFabricacao { get; set; }
        public virtual DateTime DataDeValidade { get; set; }
        public virtual decimal Preco { get; set; }

    }
}
