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
    public partial class Message_box_personalizado : Form
    {

        //form para mostrar un message box personalizado y situacional al error o caso que se solicite
        public Message_box_personalizado()
        {
            InitializeComponent();  
        }

        //dependiendo el valor que se mande al usar el metodo el mensage del label sera distinto 
        //hacemos esto para mejorar la estetica del programa
        public void Message_box(int n)
        {
            if (n==1) 
            {
                label1.Text = "Campos Incorrectos";
                
            }
            else
                if (n==2)
                {
                    label1.Text = "Complete los datos";
                    
                }
                else
                    if (n==3)
                    {
                        label1.Text = "ERROR!";
                        
                    }
            this.Show();
        }

        
        private void iniciar_sesion_btn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
