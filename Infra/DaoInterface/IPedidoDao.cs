using Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.DaoInterface
{
    public interface IPedidoDao
    {
        int CadastrarPizza(Pizza objPedido, Personalizacao objPersonalizado);

        int CadastrarPedido(Pedido objPedido);

        decimal CalcularValorTotal(int idpizza);

        int CalcularTempoPreparo(int idpizza);

        int BuscarSabor(string sabor);

        Personalizacao BuscarPersonalizacao(string personalizacao);

        int BuscarDetalhePizza(string tamanho);
    }
}
