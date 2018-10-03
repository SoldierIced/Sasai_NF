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
    public partial class UsuariosModificacion : Form
    {
        public UsuariosModificacion()
        {
            InitializeComponent();
            txt_passAnterior.PasswordChar ='*';
            txt_passNueva.PasswordChar = '*';
            txt_passNuevaConfirm.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool passame = false;
            AccesoDatos conexion = new AccesoDatos();

            string consulta = "VerificarUsuario";
            SqlCommand comando = new SqlCommand();


            comando = Usuario_class.Usuarios_completo(Formularios.Usuario, txt_passAnterior.Text, 2);
            conexion.ConfigurarProcedure(ref comando, consulta);
            comando.Connection = conexion.ObtenerConexion();

            SqlDataReader reader = comando.ExecuteReader();

           // MessageBox.Show(txt_passAnterior.Text);
            while (reader.Read())
            {

                if (int.Parse(reader[0].ToString()) == 1)
                { 
                    passame = true;
                }

            }


            if (passame==true)
            { if (txt_passNueva.TextLength>=5) { 
                if (txt_passNuevaConfirm.Text == txt_passNueva.Text)
                {
                        if (txt_passNueva.Text != txt_passAnterior.Text)
                        {
                            comando = Usuario_class.Usuarios_completo(Formularios.Usuario, txt_passNueva.Text);
                            if (conexion.EjecutarProcedimientoAlmacenado(comando, "UsuarioCambioContra") != 0)
                            {

                                MessageBox.Show("Se ha cambiado correctamente la contraseña.");

                            }
                        }
                        else {    MessageBox.Show("La contraseña nueva es igual a la anterior. Porfavor cambiela. "); }
                    }
                else { MessageBox.Show("No coinciden la nueva contraseña con la verificacion."); }
                }
            else
                {
                    MessageBox.Show("Recuerde que la contraseña tiene que tener minimo 5 caracteres.");
                }

            }
            else { MessageBox.Show("Contraseña actual incorrecta."); }
            txt_passAnterior.Clear();
            txt_passNueva.Clear();
            txt_passNuevaConfirm.Clear();

        }

        private void lbl_passAnterior_Click(object sender, EventArgs e)
        {

        }

        private void txt_passNueva_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
