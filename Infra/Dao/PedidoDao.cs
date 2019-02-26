using Dapper;
using Infra.Context;
using Infra.DaoInterface;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Dao
{
    public class PedidoDao : IPedidoDao
    {
        private IConfiguration _config;

        public PedidoDao(IConfiguration configuracoes)
        {
            _config = configuracoes;
        }
        public int CadastrarPizza(Pizza objPedido, Personalizacao objPersonalizado)
        {
            using (MySqlConnection conexao = new MySqlConnection(
                _config.GetConnectionString("db_pizzaria"))) {
                var idpizza = conexao.Insert<Pizza>(objPedido);
                if (objPersonalizado != null)
                {
                    var personalizacao = conexao.Execute("INSERT INTO pizza_personalizada (idpizza, idpersonalizacao) VALUES(@idpizza, @idpersonalizacao)", new { idpizza = (int)idpizza, objPersonalizado.idpersonalizacao });
                }

                return (int)idpizza;
            }
        }

        public int CadastrarPedido(Pedido objPedido)
        {
            using (MySqlConnection conexao = new MySqlConnection(
                _config.GetConnectionString("db_pizzaria")))
            {
                var idpedido = conexao.Insert<Pedido>(objPedido);

                return (int)idpedido;
            }
        }

        public decimal CalcularValorTotal(int idpizza)
        {
            using (MySqlConnection conexao = new MySqlConnection(
                _config.GetConnectionString("db_pizzaria")))
            {
                var resultadoDetalhePizza = conexao.QueryFirst("SELECT dp.valor FROM pizza pi" +
                                                 " JOIN detalhe_pizza dp on dp.iddetalhe_pizza = pi.iddetalhe_pizza" +
                                                 " WHERE pi.idpizza = @idpizza", new { idpizza = idpizza });
                decimal valorTotal = 0.00m;
                foreach (dynamic item in resultadoDetalhePizza)
                {
                    valorTotal += item.Value;
                }

                var resultadoPersonalizacao = conexao.QueryFirst("SELECT ifnull(SUM(p.valor_adicional), 0.00) FROM pizza pi" +
                                                 " LEFT JOIN pizza_personalizada pd on pd.idpizza = pi.idpizza" +
                                                 " JOIN personalizacao p on p.idpersonalizacao = pd.idpersonalizacao" +
                                                 " WHERE pi.idpizza = @idpizza", new { idpizza = idpizza });

                foreach (dynamic item in resultadoPersonalizacao)
                {
                    valorTotal += item.Value;
                }
                return valorTotal;
            }
        }

        public int CalcularTempoPreparo(int idpizza)
        {
            using (MySqlConnection conexao = new MySqlConnection(
                _config.GetConnectionString("db_pizzaria")))
            {
                var resultadoDetalhePizza = conexao.QueryFirst("SELECT SUM(dp.tempo_preparo) as preparo, SUM(sa.adicional_tempo) as adicional FROM pizza pi " +
                                                                "JOIN detalhe_pizza dp on dp.iddetalhe_pizza = pi.iddetalhe_pizza " +
                                                                "JOIN sabor sa on sa.idsabor = pi.idsabor " +
                                                                "WHERE pi.idpizza = @idpizza", new { idpizza = idpizza });

                int tempoTotal = 0;
                foreach (dynamic item in resultadoDetalhePizza)
                {
                    tempoTotal += (int)item.Value;
                }

                var resultadoPersonalizacao = conexao.QueryFirst("SELECT ifnull(SUM(p.tempo_adicional), 0) as tempo FROM pizza pi" +
                                                 " LEFT JOIN pizza_personalizada pd on pd.idpizza = pi.idpizza" +
                                                 " JOIN personalizacao p on p.idpersonalizacao = pd.idpersonalizacao" +
                                                 " WHERE pi.idpizza = @idpizza", new { idpizza = idpizza });

                foreach (dynamic item in resultadoPersonalizacao)
                {
                    tempoTotal += (int)item.Value;
                }

                return tempoTotal;
            }
        }

        public int BuscarSabor(string sabor)
        {
            using (MySqlConnection conexao = new MySqlConnection(
                _config.GetConnectionString("db_pizzaria")))
            {
                var resultadoSabor = conexao.QueryFirstOrDefault("SELECT idsabor FROM sabor WHERE nome = @sabor", new { sabor = sabor });
                int idsabor = 0;
                foreach (dynamic item in resultadoSabor)
                {
                    if (item.Key == "idsabor")
                    {
                        idsabor = item.Value;
                    }
                }
                return idsabor;
            }
        }

        public Personalizacao BuscarPersonalizacao(string personalizacao)
        {
            using (MySqlConnection conexao = new MySqlConnection(
                _config.GetConnectionString("db_pizzaria")))
            {
               return conexao.QueryFirstOrDefault<Personalizacao>("SELECT * FROM personalizacao WHERE nome = @personalizacao", new { personalizacao });
            }
        }

        public int BuscarDetalhePizza(string tamanho)
        {
            using (MySqlConnection conexao = new MySqlConnection(
                _config.GetConnectionString("db_pizzaria")))
            {
                switch (tamanho)
                {
                    case "Grande":
                        tamanho = "G";
                        break;
                    case "Média":
                        tamanho = "M";
                        break;
                    case "Pequena":
                        tamanho = "P";
                        break;
                    default:
                        break;
                }
                var resultadoDetalhe = conexao.QueryFirstOrDefault("SELECT iddetalhe_pizza FROM detalhe_pizza WHERE tamanho = @tamanho", new { tamanho });
                int iddetalhe = 0;
                foreach (dynamic item in resultadoDetalhe)
                {
                    if (item.Key == "iddetalhe_pizza")
                    {
                        iddetalhe = item.Value;
                    }
                }
                return iddetalhe;
            }
        }
    }
}
