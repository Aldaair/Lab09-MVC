using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;
namespace Data
{
    public class ProductDataAccess
    {
        private string connectionString = "Data Source=LAB1504-11\\SQLEXPRESS;Initial Catalog=Tecsup; Integrated Security = True";
        public List<Product> ListProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("ListProducts", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductId = Convert.ToInt32(reader["product_id"]),
                                Name = reader["name"].ToString(),
                                Price = Convert.ToDecimal(reader["price"]),
                                Stock = Convert.ToInt32(reader["stock"]),
                                Active = Convert.ToBoolean(reader["active"])
                            };

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }
        public List<Product> GetProducts()
        {
            ProductDataAccess productDataAccess = new ProductDataAccess();
            return productDataAccess.ListProducts();
        }

      


    }
}
