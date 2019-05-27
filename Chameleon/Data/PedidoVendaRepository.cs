using Chameleon.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Chameleon.Data
{
    public static class PedidoVendaRepository
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["MySqlDataBase"].ConnectionString;

        public static IList<PedidoVenda> GetPedidosVenda()
        {
            string sql = "SELECT " +
                "so.id_sales_order as Id, " +
                "DATE_FORMAT(so.created_at, '%d/%m/%Y') as DataCriacao, " +
                "CASE so.payment_method " +
                    "WHEN 'credit_card' then 'Cartão de Crédito' " +
                    "WHEN 'in_cash'  then 'Dinheiro' " +
                "end as FormaPagamento, " +
                "SUM(soi.paid_price) as Total, " +
                "CONCAT(c.first_name, ' ', c.last_name) as Nome " +
            "FROM " +
                 "sales_order so " +
            "LEFT JOIN " +
                 "sales_order_item soi " +
                 "ON soi.fk_sales_order = so.id_sales_order " +
            "LEFT JOIN " +
                 "customer c " +
                 "ON c.id_customer = so.fk_customer " +
            "WHERE " +
                  "so.fk_store = 1 " +
            "GROUP BY " +
                    "so.id_sales_order";

            using (var conn = new MySqlConnection(_connectionString))
            {
                return conn.Query<PedidoVenda>(sql).ToList();
            }
        }
    }
}
