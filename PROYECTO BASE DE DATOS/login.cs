using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace PROYECTO_BASE_DE_DATOS
{
    public partial class login : Form
    {
      

        public login()
        {
            InitializeComponent();

        }

        private void Inicio_sesion_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(usuario.Text) && !string.IsNullOrEmpty(password.Text))
            {
                try
                {
                   Iniciosesion bd =new Iniciosesion();
                   
                    Boolean res= bd.IniciarSesion (usuario.Text,password.Text);
                 
                    if (res)
                    {

                       General g = new General();
                       this.Hide();
                       g.Show();
                    }
                    else
                    {
                        MessageBox.Show("Campos incorrectos");

                    }
                }
                catch
                {
                    MessageBox.Show("Error");
                }

            }
            else
            {
                MessageBox.Show("Complete los datos");
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            
        }

       
        
      

        }
    }


