using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SASAI
{
    public partial class ABMAdministrador : Form
    {
        public ABMAdministrador()
        {
            InitializeComponent();
        }


        public  bool DatosUsuario(string user, string contra)
        {

            if (user != "" && contra != "")
            {
                if (user.Length <= 20)
                {


                    if (Usuario_class.UsuarioenUso(user) == 1)
                    {
                        MessageBox.Show("Este usuario ya este en uso.");
                    }


                    else
                    {

                        if (contra.Length >= 5 && contra.Length <= 20)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Recuerde que la contraseña tiene que tener minimo de 5 caracteres y maximo de 20.");
                        }
                    }
                }// fin if de lenght de usuario
                else { MessageBox.Show("El nombre de usuario debe tener como maximo 20 caracteres"); }
            } //textbox distintos de null.
            else
            {
                MessageBox.Show("No se perminten campos vacios.");
            }

            return false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            string procedure = "CrearUsuario";
            SqlCommand comando = new SqlCommand();

            if (DatosUsuario(textBox1.Text, textBox2.Text) == true) { 
                 if (Usuario_class.CrearUsuario(ref comando, procedure, textBox1.Text, textBox2.Text, 1) == 1)
                {
                MessageBox.Show("Usuario Creado.");
                textBox1.Clear();
                textBox2.Clear();
                    this.Close();
                }
            }


        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
