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
    
    public partial class InteresadoEspecifico : Form
    {
        DataSet ds = new DataSet();
        AccesoDatos sq = new AccesoDatos();
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public InteresadoEspecifico(string email, string nombre, string apellido)
        {
            InitializeComponent();
            Email = email;
            Nombre = nombre;
            Apellido = apellido;
        }

        private void bt_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InteresadoEspecifico_Load(object sender, EventArgs e)
        {
            tb_Email.Text = Email;
            tb_Nombre.Text = Nombre;
            tb_Apellido.Text = Apellido;

        }

        private void bt_Aceptar_Click(object sender, EventArgs e)
        {try
            {
                DateTime fecha = new DateTime();
                fecha = DateTime.Today;
                string consulta = "select count (Email) from Inscriptos where Email =  '" + tb_Email.Text + "'";
                sq.cargaTabla("TablaExiste", consulta, ref ds);
                

         
                 if (ds.Tables["TablaExiste"].Rows[0][0].ToString() == "0")
                  {
                      consulta = "insert into Interesados (Email, Nombre, Apellido, FechaConsulta) select '" + tb_Email.Text + "','" + tb_Nombre.Text + "','" + tb_Apellido.Text + "','" + fecha + "'";
                      sq.cargaTabla("Tablacargo", consulta, ref ds);
                      this.Close();
                  }
                  else
                  {
                      MessageBox.Show("Este mail ya está inscripto"); this.Close();
                  }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Preinscripciones.Confirmacion cq = new Preinscripciones.Confirmacion();

            if (cq.ShowDialog()==DialogResult.OK){
                string consulta = "delete from Interesados  where email='" + tb_Email.Text + "'";
                sq.cargaTabla("q", consulta, ref ds);
                MessageBox.Show("Interesado eliminado.");
                this.Close();
            }

            


        }
    }
}
