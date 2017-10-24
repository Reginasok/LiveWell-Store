using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Web.Models;
using System.Data.SqlClient;

namespace Project.Web.DAL
{
    public class ProductSqlDAL : IProductDAL
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=SpaceProducts;User ID=te_student;Password=sqlserver1";
        private string SQL_GetAllProducts = "Select * from products;";
        private string SQL_GetAProduct = "Select * from products where product_id = @productId;";

        public List<Product> GetProducts(int id)
        {
            //List<Product> meditationList = new List<Product>();
            Product product = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetAllProducts, conn);
                    cmd.Parameters.AddWithValue("@productId", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Product p = new Product();
                        p.ProductId = Convert.ToInt32(reader["product_id"]);
                        p.Name = Convert.ToString(reader["name"]);
                        p.Description = Convert.ToString(reader["description"]);
                        p.Price = Convert.ToDouble(reader["price"]);
                        p.ImageName = Convert.ToString(reader["image_name"]);
                        product = p;
                        //meditationList.Add(product);
                    }
                    return product;
                }
            }
            catch (SqlException)
            {
                throw;
            }

        }

        public List<Product> GetProducts()
        {
            List<Product> output = new List<Product>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetAProduct, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Product p = new Product();
                        p.ProductId = Convert.ToInt32(reader["product_id"]);
                        p.Name = Convert.ToString(reader["name"]);
                        p.Description = Convert.ToString(reader["description"]);
                        p.Price = Convert.ToDouble(reader["price"]);
                        p.ImageName = Convert.ToString(reader["image_name"]);
                        output.Add(p);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return output;

        }
    }
}