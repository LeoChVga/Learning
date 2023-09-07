using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace LACTEOS_SAN_BUENA
{
    class Iniciar_Sesion_clase
    {

        //esta es la clase donde se hace la validacion de campos para el login y la conexion con sql 
        private string cadenaConexion = "Data Source=Leo-PC; Initial Catalog=Lacteos_San_Buena; Integrated Security=True";
        public static string NombreCompleto = "";
        public static string TipoUsuario = "";
        public static string puesto = "";
        public static string id_us2 = "";


        public Boolean IniciarSesion(string nomus, string con)
        {
            //saco estos valores del select pero pueden cambiar mas adelante dependiendo la situacion
            NombreCompleto = "";
            TipoUsuario = "";
            puesto = "";
            id_us2 = "";

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            SqlParameter Parnomus = new SqlParameter("@nomus", nomus);
            SqlParameter parcon = new SqlParameter("@con", con);

            //consulta para validar password y usuario 
            SqlCommand comando = new SqlCommand("SELECT Nombre,Apellido_P, Puesto,t_u.T_Usuario_ID  FROM T_Inicio_de_Secion i_S  inner join T_Usuario t_u on I_S.T_Usuario_ID = t_u.T_Usuario_ID WHERE NomUsuario= @nomus and Password COLLATE Latin1_General_CS_AS =@con", conexion);
            comando.Parameters.Add(Parnomus);
            comando.Parameters.Add(parcon);

            SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                NombreCompleto = lector.GetString(0) + " " + lector.GetString(1);
                puesto = lector.GetString(2);
                id_us2 = lector.GetString(3);


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
            return id_us2;
        }

        public void cargar_datos(TextBox TB_Usuario, TextBox TB_password)
        {
            //instancia para la clase de message box personalizados
            Message_box_personalizado mb = new Message_box_personalizado();
            if (!string.IsNullOrEmpty(TB_Usuario.Text) && !string.IsNullOrEmpty(TB_password.Text))
            {
                try
                {
                    Iniciar_Sesion_clase bd = new Iniciar_Sesion_clase();

                    Boolean res = bd.IniciarSesion(TB_Usuario.Text, TB_password.Text);

                    if (res)
                    {

                        General g = new General();
                        Form1 f = new Form1();
                        f.Hide();
                        g.Show();
                    }
                    else
                    {
                        mb.Message_box(1);

                    }
                }
                catch
                {
                    mb.Message_box(3);
                }

            }
            else
            {
                mb.Message_box(2);
            }
        }
    }
}
