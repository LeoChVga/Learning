using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace LACTEOS_SAN_BUENA
{
    public partial class paneles : Form
    {
        string server = "Data Source=Leo-PC; Initial Catalog=Lacteos_San_Buena; Integrated Security=True";
        SqlConnection conectar = new SqlConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();
        //Timer timer;

        int t_dia, t_mes, t_anual;
            
        public paneles(Label t1)
        {
            //22/02/2022
            InitializeComponent();
            //timer = t1;
            string tiempo_dia_str = Convert.ToString(t1.Text);
            string tiempo_mes_str = Convert.ToString(t1.Text);
            string tiempo_anual_str = Convert.ToString(t1.Text);
            
           
            

            //for (int i = 0; i < fecha_str.Length; i++)
            //{
            //    Console.WriteLine(fecha_str[i]);
            //}

            tiempo_dia_str = tiempo_dia_str.Substring(0, 2);
            tiempo_mes_str = tiempo_mes_str.Substring(3,2);
            tiempo_anual_str = tiempo_anual_str.Substring(6, 4);

            MessageBox.Show(tiempo_anual_str );
            MessageBox.Show(tiempo_mes_str);
            MessageBox.Show(tiempo_dia_str);


            t_dia = int.Parse(tiempo_dia_str);
            t_mes = int.Parse(tiempo_mes_str);

            t_anual = int.Parse(tiempo_anual_str);
            



            
        }

       

        private void paneles_Load(object sender, EventArgs e )
        {
            General g = new General();
            Llenar_dataGrid LD = new Llenar_dataGrid();
            LD.Llenar_dataGrid_merma_reporte(DTG_estadistica_merma);
            LD.Llenar_dataGrid_incidentes_reporte(DTG_Estadistica_incidentes);
            LD.Llenar_dataGrid_personas_reporte(DTG_estadisticas_personal);
            LD.Llenar_dataGrid_vehiculos_reporte(dtg_vehiculos);
            LD.Llenar_dataGrid_productos_reporte(DTG_productos);


            conectar.ConnectionString = server;
            conectar.Open();


            //string query2 = "select SUM(Total_Kiloa) as kilos_mes  from T_Merma  where month(T_Merma.Fecha)="+FECHA;
           // string query3 = "select SUM(Total_Kiloa) as kilos_dia  from T_Merma  where day(T_Merma.Fecha)="+FECHA;
            string kilos_dia;
           // kilos_dia = registro3["kilos_mes"].ToString();
            //MessageBox.Show(kilos_dia);
            SqlCommand cmd_mes = new SqlCommand("select SUM(Total_Kiloa) as kilos_mes  from T_Merma  where month(T_Merma.Fecha)=" + t_mes + "", conectar);

            SqlCommand cmd_dia = new SqlCommand("select SUM(Total_Kiloa) as kilos_dia  from T_Merma  where day(T_Merma.Fecha)=" + t_dia , conectar);


            SqlDataReader registro2 = cmd_dia.ExecuteReader();
            SqlDataReader registro3 = cmd_mes.ExecuteReader();
            //SqlDataReader registro3 = cmd3.ExecuteReader();
           
           
            if (registro3.Read())
            {
                //tb_merma_mes.Text = registro3["kilos_mes"].ToString();

               //tb_merma_dia.Text = registro2["kilos_dia"].ToString();
                kilos_dia = registro3["kilos_mes"].ToString();
                MessageBox.Show(kilos_dia);
            }
            else
            {
                MessageBox.Show("error en registro 2 read ");
            }

            registro3.Close();
            registro2.Close();
            conectar.Close();
        }

        private void tb_merma_dia_TextChanged(object sender, EventArgs e)
        {

        }

        private void DTG_estadistica_merma_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

       

       
    }
}
