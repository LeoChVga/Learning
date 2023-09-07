using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LACTEOS_SAN_BUENA
{
    public partial class Form1 : Form
    {
        //instanciamos la clase iniciar sesion para tener todo dentro de una clase
        // y asi reciclar codigo
        Iniciar_Sesion_clase bd = new Iniciar_Sesion_clase();
        public Form1()
        {
            InitializeComponent();
        }
        

        //boton de login
        public void iniciar_sesion_btn_Click(object sender, EventArgs e)
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

                        this.Hide();
                        General g = new General();
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

        //codigo nada mas para tener los textbox de usuario y password llenos al momento de estar trabajando
        //en el codigo
        private void Form1_Load(object sender, EventArgs e)
        {
            TB_password.Text = "123";
            TB_Usuario.Text = "leonardo";
        }

        
        //codigo para que al  momento de presionar enter estando en el textbox de password se 
        //manden los campos para iniciar sesion 
        private void TB_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                
                bd.cargar_datos(TB_Usuario, TB_password);
            }
        }
        //codigo para que al  momento de presionar enter estando en el textbox de usuario  se 
        //manden los campos para iniciar sesion
        private void TB_Usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                bd.cargar_datos(TB_Usuario, TB_password);
            }
        }

        
        
    }
}
