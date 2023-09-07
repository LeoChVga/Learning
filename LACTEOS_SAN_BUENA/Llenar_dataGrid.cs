using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
namespace LACTEOS_SAN_BUENA
{
    class Llenar_dataGrid
    {
        string server = "Data Source=Leo-PC; Initial Catalog=Lacteos_San_Buena; Integrated Security=True";
        SqlConnection conectar = new SqlConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();

        public void Llenar_dataGrid_merma_reporte(DataGridView grid)
        {
            

            DataTable contenedor = new DataTable();
            conectar.ConnectionString = server;
            conectar.Open();
            string query = "select m.Fecha,m.Area,m.Descripcion,m.Tipo_Merma,m.Total_Kiloa, CONCAT(u.Nombre,' ',u.Apellido_P,' ',u.Apellido_M) as Encargado, u.Puesto  from T_Merma m inner join	T_Usuario u on m.T_Usuario_ID=u.T_Usuario_ID";
            SqlCommand cmd = new SqlCommand(query, conectar);
            try
            {
                cmd.ExecuteNonQuery();

                adapter.SelectCommand = cmd;

                adapter.Fill(contenedor);

                grid.DataSource = contenedor;



            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error" + ex, ToString());
                throw;
            }

            conectar.Close();

          

            



            //SqlCommand cmd2 = new SqlCommand("select*from T_Merma where month(T_Merma.Fecha)=05 ", conectar);
            //SqlDataReader registro2 = cmd2.ExecuteReader();
            

            
        }
        public void Llenar_dataGrid_personas_reporte(DataGridView grid)
        {


            DataTable contenedor = new DataTable();
            conectar.ConnectionString = server;
            conectar.Open();
            string query = "select p.Nombre,p.Tipo_Identificacion, b.Fecha,b.Motivo_Visita,b.Observaciones from T_Personas p inner join T_Bitacora_E_S b on p.T_Bitacora_E_S_ID=b.T_Bitacora_E_S_ID ";
            SqlCommand cmd = new SqlCommand(query, conectar);
            try
            {
                cmd.ExecuteNonQuery();

                adapter.SelectCommand = cmd;

                adapter.Fill(contenedor);

                grid.DataSource = contenedor;



            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error" + ex, ToString());
                throw;
            }

            conectar.Close();







            //SqlCommand cmd2 = new SqlCommand("select*from T_Merma where month(T_Merma.Fecha)=05 ", conectar);
            //SqlDataReader registro2 = cmd2.ExecuteReader();



        }

        public void Llenar_dataGrid_productos_reporte(DataGridView grid)
        {


            DataTable contenedor = new DataTable();
            conectar.ConnectionString = server;
            conectar.Open();
            string query = "select b_i.Fecha ,i.Area,i.Turno, i.Batas_entregadas,i.Batas_Devueltas,i.Batas_Dañadas,i.Anotaciones ,CONCAT(u.Nombre,' ',u.Apellido_P,' ',u.Apellido_M) as Encargado, Puesto   from  T_Insumo i inner join T_Bitacora_Insumos b_i on i.T_Bitacora_Insumos_ID=b_i.T_Bitacora_Insumos_ID inner join T_Usuario u on b_i.T_Usuario_ID = u.T_Usuario_ID ";
            SqlCommand cmd = new SqlCommand(query, conectar);
            try
            {
                cmd.ExecuteNonQuery();

                adapter.SelectCommand = cmd;

                adapter.Fill(contenedor);

                grid.DataSource = contenedor;



            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error" + ex, ToString());
                throw;
            }

            conectar.Close();







            //SqlCommand cmd2 = new SqlCommand("select*from T_Merma where month(T_Merma.Fecha)=05 ", conectar);
            //SqlDataReader registro2 = cmd2.ExecuteReader();



        }
        public void Llenar_dataGrid_vehiculos_reporte(DataGridView grid)
        {


            DataTable contenedor = new DataTable();
            conectar.ConnectionString = server;
            conectar.Open();
            string query = "select b.Fecha,v.Nombre_Chofer,v.Placas,v.Tipo_Vehiculo,v.Marca,v.Modelo,v.Año,b.Motivo_Visita,b.Observaciones from T_Vehiculos v inner join T_Bitacora_E_S b on v.T_Bitacora_E_S_ID=b.T_Bitacora_E_S_ID  ";
            SqlCommand cmd = new SqlCommand(query, conectar);
            try
            {
                cmd.ExecuteNonQuery();

                adapter.SelectCommand = cmd;

                adapter.Fill(contenedor);

                grid.DataSource = contenedor;



            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error" + ex, ToString());
                throw;
            }

            conectar.Close();







            //SqlCommand cmd2 = new SqlCommand("select*from T_Merma where month(T_Merma.Fecha)=05 ", conectar);
            //SqlDataReader registro2 = cmd2.ExecuteReader();



        }
        public void Llenar_dataGrid_incidentes_reporte(DataGridView grid)
        {


            DataTable contenedor = new DataTable();
            conectar.ConnectionString = server;
            conectar.Open();
            string query = "select i.Fecha, i.Area,I.Turno,i.Descripcion as Descripcion_Del_Incidente, CONCAT(u.Nombre,' ',u.Apellido_P,' ',u.Apellido_M) as Encargado,Puesto From T_Reporte_Incidentes i inner join T_Usuario u on i.T_Usuario_ID=u.T_Usuario_ID ";
            SqlCommand cmd = new SqlCommand(query, conectar);
            try
            {
                cmd.ExecuteNonQuery();

                adapter.SelectCommand = cmd;

                adapter.Fill(contenedor);

                grid.DataSource = contenedor;



            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error" + ex, ToString());
                throw;
            }

            conectar.Close();







            //SqlCommand cmd2 = new SqlCommand("select*from T_Merma where month(T_Merma.Fecha)=05 ", conectar);
            //SqlDataReader registro2 = cmd2.ExecuteReader();



        }
        public void Llenar_labels_kilos_merma(Label lbl_total_merma_kilos_mes, Label lbl_total_merma_dia,Timer FECHA)
        {
             conectar.ConnectionString = server;
            conectar.Open();


            //string query2 = "select SUM(Total_Kiloa) as kilos_mes  from T_Merma  where month(T_Merma.Fecha)="+FECHA;
            //string query3 = "select SUM(Total_Kiloa) as kilos_dia  from T_Merma  where day(T_Merma.Fecha)="+FECHA;
           
            SqlCommand cmd_mes = new SqlCommand("select SUM(Total_Kiloa) as kilos_mes  from T_Merma  where month(T_Merma.Fecha)='"+FECHA+"'",conectar);

            SqlCommand cmd_dia = new SqlCommand("select SUM(Total_Kiloa) as kilos_dia  from T_Merma  where day(T_Merma.Fecha)='" + FECHA + "'", conectar);
           
            
            SqlDataReader registro2 = cmd_dia.ExecuteReader();
            SqlDataReader registro3 = cmd_mes.ExecuteReader();
            //SqlDataReader registro3 = cmd3.ExecuteReader();



            if (registro2.Read() && registro3.Read())
            {
                lbl_total_merma_dia.Text = registro3["kilos_mes"].ToString();

                lbl_total_merma_kilos_mes.Text = registro2["kilos_dia"].ToString();
            }
            else
            {
                MessageBox.Show("error en registro 2 read ");
            }


            conectar.Close();
        }
    }
}
