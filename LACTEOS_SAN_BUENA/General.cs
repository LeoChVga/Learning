using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace LACTEOS_SAN_BUENA
{
    public partial class General : Form
    {
        Generar_Reportes g = new Generar_Reportes();
        public General()
        {
            InitializeComponent();
        }
       
        
        //boton para salir de la aplicacion
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //boton para maximinzar la ventana
        private void btn_ventana_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btn_ventana.Visible = false;
            btn_restaurar.Visible = true;
        }

        //boton para restaurar el tamaño de ventana original
        private void btn_restaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btn_restaurar.Visible = false;
            btn_ventana.Visible = true;
        }

        //Boton para minimizar la ventana
        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //codigo para poder mover la ventana 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint="SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //mas codigo para poder mover la ventana
        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112, 0xf012,0);
        }

        //boton para cerrar
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        //timer para reloj y hora de form general 
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_hora.Text = DateTime.Now.ToLongTimeString();
            lbl_fecha.Text = DateTime.Now.ToShortDateString();//.ToLongDateString();
            
        }

        //load del form general 
        private void General_Load(object sender, EventArgs e)
        {
            //Pnl_info_merma.Hide();
            timer1.Enabled = true;
            Pnl_Merma.Hide();
            Panel_incidentes.Hide();
            panel_personas.Hide();
            panel_prod.Hide();
            Panel_vehiculos.Hide();

            
            
        }

        
        //boton de reporte merma, muestra el panel de pnl_merna 
        private void btn_merma_Click(object sender, EventArgs e)
        {

            //Pnl_info_merma.Hide();

            Pnl_Merma.Show();
            Panel_incidentes.Hide();
            panel_personas.Hide();
            panel_prod.Hide();
            Panel_vehiculos.Hide();
            
        }

        private void btn_incidente_Click(object sender, EventArgs e)
        {
          //  Pnl_info_merma.Hide();

            Pnl_Merma.Hide();
            Panel_incidentes.Show();
            panel_personas.Hide();
            panel_prod.Hide();
            Panel_vehiculos.Hide();
            
        }

        private void btn_Reg_personal_Click(object sender, EventArgs e)
        {
            Pnl_Merma.Hide();
            Panel_incidentes.Hide();
            panel_personas.Show();
            panel_prod.Hide();
            Panel_vehiculos.Hide();
        //    Pnl_info_merma.Hide();

           

        }

        

        private void btn_reg_vehiculos_Click(object sender, EventArgs e)
        {

            Pnl_Merma.Hide();
            Panel_incidentes.Hide();
            panel_personas.Hide();
            panel_prod.Hide();
            Panel_vehiculos.Show();
           // Pnl_info_merma.Hide();

        }

        private void btn_reg_prods_Click(object sender, EventArgs e)
        {
            Pnl_Merma.Hide();
           Panel_incidentes.Hide();
            panel_personas.Hide();
            panel_prod.Show();
            Panel_vehiculos.Hide();
            //Pnl_info_merma.Hide();

        }
        private void btn_info_area_Click(object sender, EventArgs e)
        {
            paneles Panel_ = new paneles(lbl_fecha);
            Panel_.Show();

        }
        private void button5_Click(object sender, EventArgs e)
        {
            
            g.Generar_Reporte_Merma(TB_Area_merma, TB_Total_Kilos_Merma, TB_Descripcion_merma,CB_Tipo_Merma_Merma);
            
        }

        private void BTN_Generar_reporte_inc_Click(object sender, EventArgs e)
        {
            g.Generar_Reporte_Incidentes(TB_Area_inc, TB_Descripcion_inc,TB_Turno_inc);
        }

        private void BTN_Generar_reporte_prods_Click(object sender, EventArgs e)
        {
            g.Generar_Reporte_Insumos(TB_area_prods, TB_batas_devueltas_prods, TB_turno_prods, TB_batas_dañadas_prods, TB_batas_entregadas_prods, TB_anotaciones_prods);
        }

       

        private void BTN_generar_reporte_vehiculos_Click_1(object sender, EventArgs e)
        {
            g.Generar_Reporte_Vehiculos(TB_nombre_chofer_vehiculos, TB_placas_vehiculos, TB_marca_vehiculos, TB_modelo_vehiculos, TB_año_vehiculos, TB_motivo_visita_vehiculos, TB_observaciones_vehiculos,CB_tipo_vehiculo_vehiculos);

        }

        
        private void BTN_generar_reporte_personas_Click_1(object sender, EventArgs e)
        {
            g.Generar_Reporte_entrada_personas(TB_nombre_personas, TB_tipo_identificacion_personas, TB_motivo_visita_personas, TB_observaciones_personas);

        }

        private void Pnl_info_merma_Paint(object sender, PaintEventArgs e)
        {

        }

        
        

    }
}
