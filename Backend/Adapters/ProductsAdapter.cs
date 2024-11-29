using Backend.Models;
using System.Data;
using System.Data.SqlClient;

namespace Backend.Adapters
{
    public class ProductsAdapter
    {
        private readonly string connection = "Server=Localhost;Database=Ionic;Trusted_Connection=True";
        private SqlConnection conn = new();
        private SqlCommand cmd = new();
        public bool CreateProduct(ProductsRequest model)
        {
            using (conn = new(connection))
            {
                try
                {
                    conn.Open();
                    cmd = new("SP_Crear_Producto", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@descripcion", model.Descripcion);
                    cmd.Parameters.AddWithValue("@valorUnitario", model.ValorUnitario);
                    cmd.Parameters.AddWithValue("@estado", 1);
                    int res = cmd.ExecuteNonQuery();
                    return res == 1;
                }
                catch (Exception)
                {
                    return false;
                }

            }

        }

        public List<ProductsRequest> ReadProducts()
        {
            using (conn = new(connection))
            {
                List<ProductsRequest> listProducts = new();
                try
                {
                    conn.Open();
                    cmd = new("SP_Consultar_Productos", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlDataReader res = cmd.ExecuteReader();
                    while (res.Read())
                    {
                        ProductsRequest req = new();
                        req.IdProducto = res.GetInt32(0);
                        req.Descripcion = res.GetString(1);
                        req.ValorUnitario = res.GetDecimal(2);
                        req.Estado = res.GetBoolean(3);
                        listProducts.Add(req);
                    }
                    return listProducts;
                }
                catch (Exception)
                {
                    return listProducts;
                }

            }

        }
    }
}
