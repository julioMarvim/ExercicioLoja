using ExercicioLoja.DAO;
using ExercicioLoja.Entidades;
using ExercicioLoja.Infra;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioLoja
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InterfaceUsuario.MenuCliente();
        }
    }       
}
