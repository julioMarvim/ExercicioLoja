﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioLoja.Entidades
{
    public class Pedido
    {
        public virtual int Id { get; set; }
        public virtual DateTime DataDoPedido { get; set; }
        public virtual int QuantidadeDeProdutos { get; set; }
        public virtual int ValorTotal { get; set; }
        public virtual Cliente Cliente { get; set; } 
        public virtual IList<Produto> Produtos { get; set; }
    }
}