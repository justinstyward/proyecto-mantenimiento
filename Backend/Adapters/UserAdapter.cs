
using Backend.Models;
using Backend.Tools;
using System.Data;
using System.Data.SqlClient;

namespace Backend.Adapters
{
    public class UserAdapter
    {
        private readonly string connection = "Server=Localhost;Database=Ionic;Trusted_Connection=True";
        private SqlConnection conn = new();
        private SqlCommand cmd = new();
        public bool CreateUser(UserRequest model)
        {
            using (conn = new(connection))
            {
                try
                {
                    model.Clave = Encrypt.GetSHA256(model.Clave);
                    conn.Open();
                    cmd = new("SP_Registrar_Usuario", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@correo", model.Correo);
                    cmd.Parameters.AddWithValue("@clave", model.Clave);
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

        public bool ReadUser(UserRequest model)
        {
            using (conn = new(connection))
            {
                try
                {
                    model.Clave = Encrypt.GetSHA256(model.Clave);
                    conn.Open();
                    cmd = new("SP_Consultar_Usuario", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@correo", model.Correo);
                    cmd.Parameters.AddWithValue("@clave", model.Clave);
                    SqlDataReader res = cmd.ExecuteReader();
                    return res.HasRows;
                }
                catch (Exception)
                {
                    return false;
                }

            }

        }
    }
}
