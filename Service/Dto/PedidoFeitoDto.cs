using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dto
{
    public class PedidoFeitoDto
    {
        public string Tamanho { get; set; }
        public string Sabor { get; set; }
        public string Personalizacao { get; set; }
        public decimal ValorTotal { get; set; }
        public int TempoPreparo { get; set; }
    }
}
