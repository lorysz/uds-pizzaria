using Infra.Context;
using Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ServiceInterface
{
    public interface IPedidoService
    {
        PedidoFeitoDto CadastrarPedido(PedidoDto objPedido);

        decimal CalcularValorTotal(int idpizza);

        // Faz o calculo do tempo de preparo total
        int CalcularTempoPreparo(int idpizza);

        // Busca o id do sabor
        int BuscarSabor(string sabor);

        // Busca o id da personalização
        Personalizacao BuscarPersonalizacao(string personalizacao);

        int BuscarDetalhe(string tamanho);        
    }
}
