using Backend.Models;
using System.Data;
using System.Data.SqlClient;

namespace Backend.Adapters
{
    public class ImptoAdapter
    {
        private readonly string connection = "Server=Localhost;Database=Ionic;Trusted_Connection=True";
        private SqlConnection conn = new();
        private SqlCommand cmd = new();
        public bool CreateImpto(ImptoRequest model)
        {
            using (conn = new(connection))
            {
                try
                {
                    conn.Open();
                    cmd = new("SP_Crear_Inpuesto", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@idProducto", model.IdProducto);
                    cmd.Parameters.AddWithValue("@porcentajeImpto", model.PorcentajeImpto);
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

        public List<ImptoRequest> ReadImptos()
        {
            using (conn = new(connection))
            {
                List<ImptoRequest> listImpto = new();
                try
                {
                    conn.Open();
                    cmd = new("SP_Consultar_Inpuestos", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlDataReader res = cmd.ExecuteReader();
                    while (res.Read())
                    {
                        ImptoRequest req = new();
                        req.IdImpto = res.GetInt32(0);
                        req.IdProducto = res.GetInt32(1);
                        req.PorcentajeImpto = res.GetDecimal(2);
                        req.Estado = res.GetBoolean(3);
                        req.Producto = res.GetString(4);
                        listImpto.Add(req);
                    }
                    return listImpto;
                }
                catch (Exception)
                {
                    return listImpto;
                }

            }

        }
    }
}
