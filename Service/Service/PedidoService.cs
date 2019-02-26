using AutoMapper;
using Infra.Context;
using Infra.DaoInterface;
using Service.Dto;
using Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Service
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoDao _service;

        public PedidoService(IPedidoDao service)
        {
            _service = service;
        }

        public PedidoFeitoDto CadastrarPedido(PedidoDto objPedido)
        {
            Pizza objPed = new Pizza();
            objPed.iddetalhe_pizza = BuscarDetalhe(objPedido.Tamanho);
            objPed.idsabor = BuscarSabor(objPedido.Sabor);

            Personalizacao objPer = new Personalizacao();
            if (objPedido.Personalizacao != "")
            {
                objPer = BuscarPersonalizacao(objPedido.Personalizacao);
            } else
            {
                objPer = null;
            }
            
            int idpizza = _service.CadastrarPizza(objPed, objPer);

            decimal valorTotal = CalcularValorTotal(idpizza);
            int tempoPreparo = CalcularTempoPreparo(idpizza);

            Pedido obj = new Pedido();
            obj.idpizza = idpizza;
            obj.valor_total = valorTotal;
            obj.tempo_preparo = tempoPreparo;

            int idpedido = _service.CadastrarPedido(obj);


            PedidoFeitoDto objFeito = new PedidoFeitoDto();

            objFeito.TempoPreparo = tempoPreparo;
            objFeito.ValorTotal = valorTotal;
            objFeito.Tamanho = objPedido.Tamanho;
            objFeito.Sabor = objPedido.Sabor;
            string personalizacao = "";
            if (objPer != null)
            {
                personalizacao = objPedido.Personalizacao + " (R$" + objPer.valor_adicional + ")";
            }
            objFeito.Personalizacao = personalizacao;

            return objFeito;
        }

        // Faz o calculo do valor total do pedido
        public decimal CalcularValorTotal(int idpizza)
        {
            return _service.CalcularValorTotal(idpizza);
            
        }

        // Faz o calculo do tempo de preparo total
        public int CalcularTempoPreparo(int idpizza)
        {
            return _service.CalcularTempoPreparo(idpizza);            
        }

        // Busca o id do sabor
        public int BuscarSabor(string sabor)
        {
            return _service.BuscarSabor(sabor);            
        }

        // Busca o id da personalização
        public Personalizacao BuscarPersonalizacao(string personalizacao)
        {
            return _service.BuscarPersonalizacao(personalizacao);
        }

        // Busca o id do tamanho
        public int BuscarDetalhe(string tamanho)
        {
            return _service.BuscarDetalhePizza(tamanho);
        }
    }
}
