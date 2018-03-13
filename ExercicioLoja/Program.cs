using ExercicioLoja.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioLoja
{
    class Program
    {
        static void Main(string[] args)
        {
            NHibernateHelper.GeraSchema();

            Console.Read();
        }
    }
}
