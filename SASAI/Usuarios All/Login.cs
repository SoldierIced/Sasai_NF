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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Txt_Contra.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccesoDatos aq = new AccesoDatos();
            DataSet ds = new DataSet();
            string consulta = "select* from Usuarios where usuario = '"+Txt_Usuario.Text+"' and contrasena = '"+Txt_Contra.Text+"'";

            // AccesoDatos aq = new AccesoDatos();
            //  DataSet ds = new DataSet();
            //  string consulta = "select* from Usuarios where usuario = '"+Txt_Usuario.Text+"' and contrasena = '"+Txt_Contra.Text+"'";
            SqlCommand comando = new SqlCommand();


            try {

              //  MessageBox.Show(Usuario_class.VerificarUsuarioActivo(Txt_Usuario.Text, Txt_Contra.Text).ToString());


               switch (Usuario_class.VerificarUsuarioActivo(Txt_Usuario.Text, Txt_Contra.Text)) 
                {
                    case 1:
                        Formularios.Usuario = Txt_Usuario.Text;
                        Formularios.acceso = Usuario_class.VerificarAlluser(Txt_Usuario.Text, Txt_Contra.Text);
                       
                        this.Hide();
                        consulta = "insert into  Logen  select numerito = 1";
                        aq.cargaTabla("a", consulta, ref ds);
                        Formularios.enviarFormulario().ShowDialog();
                        this.Close();
                        break;
                    case -1:
                        MessageBox.Show("Este usuario no existe.");
                        
                        break;
                    case -2:
                        MessageBox.Show("Contraseña equivocada.");

                        break;
                    case -3:
                        MessageBox.Show("Este usuario esta dado de baja.");

                        break;
                    case -100:
                        MessageBox.Show("Datos Incorrectos");

                        break;
                    default:
                        break;

                }
                Txt_Contra.Clear();
            
              
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
            
            
            
            
            
        
            


        }

    

        private void Txt_Contra_TextChanged(object sender, EventArgs e)
        {
            

            
        }

        private void Txt_Contra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

          

        private void Login_Load(object sender, EventArgs e)
        {
         
        }

        private void Txt_Usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
             
            }
        }
    }
}
