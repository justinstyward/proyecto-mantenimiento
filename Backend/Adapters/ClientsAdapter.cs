using Backend.Models;
using System.Data;
using System.Data.SqlClient;

namespace Backend.Adapters
{
    public class ClientsAdapter
    {
        private readonly string connection = "Server=Localhost;Database=Ionic;Trusted_Connection=True";
        private SqlConnection conn = new();
        private SqlCommand cmd = new();
        public bool CreateClient(ClientsRequest model)
        {
            using (conn = new(connection))
            {
                try
                {
                    conn.Open();
                    cmd = new("SP_Crear_Cliente", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@nit", model.Nit);
                    cmd.Parameters.AddWithValue("@razonSocial", model.RazonSocial);
                    cmd.Parameters.AddWithValue("@telefono", model.Telefono);
                    cmd.Parameters.AddWithValue("@direccion", model.Direccion);
                    int res = cmd.ExecuteNonQuery();
                    return res == 1;
                }
                catch (Exception)
                {
                    return false;
                }

            }

        }

        public List<ClientsRequest> ReadClients()
        {
            using (conn = new(connection))
            {
                List<ClientsRequest> listProducts = new();
                try
                {
                    conn.Open();
                    cmd = new("SP_Consultar_Clientes", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlDataReader res = cmd.ExecuteReader();
                    while (res.Read())
                    {
                        ClientsRequest req = new();
                        req.IdCliente = res.GetInt32(0);
                        req.Nit = res.GetString(1);
                        req.RazonSocial = res.GetString(2);
                        req.Telefono = res.GetString(3);
                        req.Direccion = res.GetString(4);
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
