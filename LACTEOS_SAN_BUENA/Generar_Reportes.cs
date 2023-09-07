using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace LACTEOS_SAN_BUENA
{
    class Generar_Reportes
    {
        private string server = "Data Source=Leo-PC; Initial Catalog=Lacteos_San_Buena; Integrated Security=True";
        SqlConnection conectar = new SqlConnection();
        string cadenaAleatoria_Id_merma = string.Empty;
        string cadenaAleatoria_Id_incidente = string.Empty;
        string cadenaAleatoria_Id_insumo = string.Empty;
        string cadena_Aleatoria_id_bitacora_insumo = string.Empty;
        string cadena_Aleatoria_id_bitacora_vehiculo = string.Empty;
        string cadena_Aleatoria_id_vehiculo_ = string.Empty;
        string cadena_Aleatoria_id_personas_ = string.Empty;
        string cadena_Aleatoria_id_bitacora_e_s_ = string.Empty;
        Iniciar_Sesion_clase login = new Iniciar_Sesion_clase();


        public void Generar_Reporte_Merma(TextBox AreaTB, TextBox Total_kilosTB,TextBox DescripcionTB,ComboBox tipomerma )
        {
            // --------------------------------------------------
            //new guid genera una cadena aleatoria que se usa para la id de todo lo que necesite 
            cadenaAleatoria_Id_merma = Guid.NewGuid().ToString();
           
            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Reporte_merma_procd", conectar);
            cmd.CommandType = CommandType.StoredProcedure;
            General G = new General();
            
            //se le dan valor a todas las variables 
            //cmd.Parameters.AddWithValue("@fecha", );
            cmd.Parameters.AddWithValue("@Area", AreaTB.Text);
            cmd.Parameters.AddWithValue("@Total_Kilos", Total_kilosTB.Text);
            cmd.Parameters.AddWithValue("@Descripcion", DescripcionTB.Text);
            cmd.Parameters.AddWithValue("@T_Merma_ID", cadenaAleatoria_Id_merma);
            cmd.Parameters.AddWithValue("@T_Usuario_ID",login.id_us() );
            cmd.Parameters.AddWithValue("@Tipo_Merma", tipomerma.Text);
            
          
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());

                throw;
            }
            
            //cerramos conexion despues de realizar todos los procedimientos 
            conectar.Close();
            AreaTB.Text = "";
            Total_kilosTB.Text = "";
            DescripcionTB.Text = "";
            tipomerma.SelectedIndex = 1;
            
        }


        public void Generar_Reporte_Incidentes(TextBox AreaTB, TextBox DescripcionTB,TextBox turno)
        {
            // --------------------------------------------------
            //new guid genera una cadena aleatoria que se usa para la id de todo lo que necesite 
            cadenaAleatoria_Id_incidente = Guid.NewGuid().ToString();

            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Reporte_incidentes", conectar);
            cmd.CommandType = CommandType.StoredProcedure;
            General G = new General();

            //se le dan valor a todas las variables 
           
            cmd.Parameters.AddWithValue("@area", AreaTB.Text);
            cmd.Parameters.AddWithValue("@descripcion", DescripcionTB.Text);
            cmd.Parameters.AddWithValue("@t_usuario_id", login.id_us());
            cmd.Parameters.AddWithValue("@t_reporte_id", cadenaAleatoria_Id_incidente);
            cmd.Parameters.AddWithValue("@turno",turno.Text);


            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());

                throw;
            }

            //cerramos conexion despues de realizar todos los procedimientos 
            conectar.Close();

            AreaTB.Text = "";
            DescripcionTB.Text = "";
            AreaTB.Text = "";
            turno.Text = "";

        }
        public void Generar_Reporte_Insumos(TextBox AreaTB, TextBox Batas_devueltas, TextBox turno,TextBox batas_dañadas, TextBox batas_entregadas, TextBox anotaciones)
        {
            // --------------------------------------------------
            //new guid genera una cadena aleatoria que se usa para la id de todo lo que necesite 
            cadenaAleatoria_Id_insumo = Guid.NewGuid().ToString();
            cadena_Aleatoria_id_bitacora_insumo = Guid.NewGuid().ToString();

            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Reporte_Insumos_Procd", conectar);
            cmd.CommandType = CommandType.StoredProcedure;
            General G = new General();

            //se le dan valor a todas las variables 

            cmd.Parameters.AddWithValue("@area", AreaTB.Text);
            cmd.Parameters.AddWithValue("@batas_devueltas", Batas_devueltas.Text);
            cmd.Parameters.AddWithValue("@turno", turno.Text);
            cmd.Parameters.AddWithValue("@t_insumos_id", cadenaAleatoria_Id_insumo);
            cmd.Parameters.AddWithValue("@t_bitacora_insumos_id", cadena_Aleatoria_id_bitacora_insumo);
            cmd.Parameters.AddWithValue("@batas_dañadas", batas_dañadas.Text);
            cmd.Parameters.AddWithValue("@Batas_Entregadas", batas_entregadas.Text);
            cmd.Parameters.AddWithValue("@anotaciones", anotaciones.Text);
            cmd.Parameters.AddWithValue("@T_usuario_ID",login.id_us() );




            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());

                throw;
            }

            //cerramos conexion despues de realizar todos los procedimientos 
            conectar.Close();

            AreaTB.Text = "";
            batas_dañadas.Text = "";
            Batas_devueltas.Text = "";
            batas_entregadas.Text="";
            turno.Text = "";
            anotaciones.Text = "";
        }
         public void Generar_Reporte_Vehiculos( TextBox TB_nombre_chofer_vehiculos,TextBox TB_placas_vehiculos,TextBox TB_marca_vehiculos ,TextBox TB_modelo_vehiculos ,TextBox TB_año_vehiculos,TextBox TB_motivo_visita_vehiculos, TextBox TB_observaciones_vehiculos, ComboBox Tipo_vehiculo)
        {
            // --------------------------------------------------
            //new guid genera una cadena aleatoria que se usa para la id de todo lo que necesite 
            cadenaAleatoria_Id_incidente = Guid.NewGuid().ToString();
             cadena_Aleatoria_id_bitacora_vehiculo=Guid.NewGuid().ToString();
             cadena_Aleatoria_id_vehiculo_=Guid.NewGuid().ToString();

            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Reporte_Vehiculos", conectar);
            cmd.CommandType = CommandType.StoredProcedure;
            General G = new General();

            //se le dan valor a todas las variables 
           
            cmd.Parameters.AddWithValue("@nombre_chofer",TB_nombre_chofer_vehiculos.Text);
            cmd.Parameters.AddWithValue("@marca",TB_marca_vehiculos.Text);
            cmd.Parameters.AddWithValue("@modelo", TB_modelo_vehiculos.Text);
            cmd.Parameters.AddWithValue("@placas", TB_placas_vehiculos.Text);
            cmd.Parameters.AddWithValue("@año",TB_año_vehiculos.Text);
            cmd.Parameters.AddWithValue("@tipo_vehiculo",Tipo_vehiculo.Text);

            cmd.Parameters.AddWithValue("@motivo_visita",TB_motivo_visita_vehiculos.Text);
            cmd.Parameters.AddWithValue("@observaciones",TB_observaciones_vehiculos.Text);
            cmd.Parameters.AddWithValue("@t_vehiculos_id", cadena_Aleatoria_id_vehiculo_);
            cmd.Parameters.AddWithValue("@t_bitacora_e_s_id", cadena_Aleatoria_id_bitacora_vehiculo);
            cmd.Parameters.AddWithValue("@t_usuario_id",login.id_us());



            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());

                throw;
            }

            //cerramos conexion despues de realizar todos los procedimientos 
            conectar.Close();

            TB_nombre_chofer_vehiculos.Text = "";
            TB_marca_vehiculos.Text = "";
            TB_modelo_vehiculos.Text = "";
            TB_placas_vehiculos.Text= "";
            TB_año_vehiculos.Text= "";
            TB_motivo_visita_vehiculos.Text= "";
            TB_observaciones_vehiculos.Text= "";
    }


         public void Generar_Reporte_entrada_personas(TextBox TB_nombre_personas, TextBox TB_tipo_identificacion_personas, TextBox TB_motivo_visita_personas, TextBox TB_observaciones_personas)
         {
             // --------------------------------------------------
             //new guid genera una cadena aleatoria que se usa para la id de todo lo que necesite 
            // cadenaAleatoria_Id_incidente = Guid.NewGuid().ToString();
            // cadena_Aleatoria_id_bitacora_vehiculo = Guid.NewGuid().ToString();
             //cadena_Aleatoria_id_vehiculo_ = Guid.NewGuid().ToString();
             cadena_Aleatoria_id_personas_ = Guid.NewGuid().ToString();
             cadena_Aleatoria_id_bitacora_e_s_ = Guid.NewGuid().ToString();

             conectar.ConnectionString = server;
             conectar.Open();
             //se crea el cmd para usar un procedimiento almacenado
             SqlCommand cmd = new SqlCommand("Reporte_Personas", conectar);
             cmd.CommandType = CommandType.StoredProcedure;
             General G = new General();

             //se le dan valor a todas las variables 

             cmd.Parameters.AddWithValue("@nombre",TB_nombre_personas.Text);
             cmd.Parameters.AddWithValue("@Tipo_Identificacion",TB_tipo_identificacion_personas.Text);
             cmd.Parameters.AddWithValue("@Motivo_Visita",TB_motivo_visita_personas .Text);
             cmd.Parameters.AddWithValue("@Observaciones", TB_observaciones_personas.Text);
             cmd.Parameters.AddWithValue("@T_Personas_Id", cadena_Aleatoria_id_personas_);
             cmd.Parameters.AddWithValue("@T_Bitacora_E_S_ID", cadena_Aleatoria_id_bitacora_e_s_);
             cmd.Parameters.AddWithValue("@T_Usuario_ID", login.id_us());


            // cmd.Parameters.AddWithValue("@motivo_visita", TB_motivo_visita_vehiculos.Text);
            // cmd.Parameters.AddWithValue("@observaciones", TB_observaciones_vehiculos.Text);
            // cmd.Parameters.AddWithValue("@t_vehiculos_id", cadena_Aleatoria_id_vehiculo_);
            // cmd.Parameters.AddWithValue("@t_bitacora_e_s_id", cadena_Aleatoria_id_bitacora_vehiculo);
           //  cmd.Parameters.AddWithValue("@t_usuario_id", login.id_us());



             try
             {
                 cmd.ExecuteNonQuery();
             }
             catch (SqlException EX)
             {
                 MessageBox.Show(EX.ToString());

                 throw;
             }

             //cerramos conexion despues de realizar todos los procedimientos 
             conectar.Close();

             TB_nombre_personas.Text = "";
            TB_tipo_identificacion_personas.Text = "";
             TB_motivo_visita_personas.Text = "";
             TB_observaciones_personas.Text = "";
             //TB_año_vehiculos.Text = "";
             //TB_motivo_visita_vehiculos.Text = "";
             //TB_observaciones_vehiculos.Text = "";
         }

   } 
 
}
