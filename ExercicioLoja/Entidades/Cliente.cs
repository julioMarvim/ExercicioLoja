using ExercicioLoja.DAO;
using ExercicioLoja.Infra;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioLoja.Entidades
{
    public class Cliente
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Endereco { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string Filiacao { get; set; }
        public virtual string Status { get; set; }
        public virtual decimal LimiteDeCredito { get; set; }
        public virtual string Documento { get; set; }

       


    }
}
