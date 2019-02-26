using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Context
{
    [Table("pizza")]
    public class Pizza
    {
        [ExplicitKey]
        public int idpizza { get; set; }
        public int iddetalhe_pizza { get; set; }
        public int idsabor { get; set; }
    }
}
