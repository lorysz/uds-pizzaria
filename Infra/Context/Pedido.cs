using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Context
{
    [Table("pedido")]
    public class Pedido
    {
        [ExplicitKey]
        public int idpedido { get; set; }
        public int idpizza { get; set; }
        public decimal valor_total { get; set; }
        public int tempo_preparo { get; set; }
    }
}
