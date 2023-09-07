using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace PROYECTO_BASE_DE_DATOS
{
    class Iniciosesion
    {
        private string cadenaConexion = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
        public static string NombreCompleto = "";
        public static string TipoUsuario = "";
        public static string Id_usuario_vr = "";


        public Boolean IniciarSesion(string nomus, string con)
        {
            NombreCompleto = "";
            TipoUsuario = "";
            Id_usuario_vr = "";

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            SqlParameter Parnomus = new SqlParameter("@nomus", nomus);
            SqlParameter parcon = new SqlParameter("@con", con);

            SqlCommand comando = new SqlCommand("select Nombre_Usuario,Apellido_Usuario,Id_Usuario from Usuarios where Usuario= @nomus and Password_usuario COLLATE Latin1_General_CS_AS =@con ", conexion);
            comando.Parameters.Add(Parnomus);
            comando.Parameters.Add(parcon);
           
            SqlDataReader lector= comando.ExecuteReader();
            while (lector.Read())
            {
                NombreCompleto=lector.GetString(0) + " "+ lector.GetString(1);
                Id_usuario_vr = lector.GetString(2);

               
            }
            lector.Close();
            conexion.Close();
            if (string.IsNullOrEmpty(NombreCompleto))
            {
                return false;
            }
            else
            {
                return true;
               
            }
           
        }
        public string id_us()
        {
            return Id_usuario_vr;
        }
    }
}
