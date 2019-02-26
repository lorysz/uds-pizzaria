using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Context
{
    [Table("personalizacao")]
    public class Personalizacao
    {
        [ExplicitKey]
        public int idpersonalizacao { get; set; }
        public string nome { get; set; }
        public decimal valor_adicional { get; set; }
        public int tempo_adicional { get; set; }
    }
}
