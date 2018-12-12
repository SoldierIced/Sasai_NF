using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SASAI
{
    public partial class AlumnosF : Form
    {
        // public string qseyo { get; set; }
        SqlCommand comando = new SqlCommand();
        AccesoDatos aq = new AccesoDatos();
        DataSet ds = new DataSet();
        public string consulta = "";
        public string dni = "";
        public int tablita { get; set; }
        public AlumnosF()
        {
            InitializeComponent();
        }

        private void AlumnosF_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
          //  MessageBox.Show(comboBox1.SelectedIndex.ToString());
            if (comboBox1.SelectedIndex != -1) {

                string aux = armarconsulta(comboBox1.Text);
                aq.cargaTabla("Ver si esta en inscriptos", aux, ref ds);
                //  MessageBox.Show(ds.Tables["Ver si esta en inscriptos"].Rows.Count.ToString());
                if (ds.Tables["Ver si esta en inscriptos"].Rows.Count != 0)
                {
                    consulta = aux;
                    tablita = int.Parse( comboBox1.SelectedIndex.ToString())+1;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    tablita = 0;
                    MessageBox.Show("Alumno no encontrado, vuelva a intentarlo");
                }
            }
            else
            {
                tablita = 0;
                MessageBox.Show("Seleccione alguna de las tablas disponibles.");
            }

        


          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        public string armarconsulta( string tabla)
        {
            string d1 = " AND ";
           int num = 0;


           string  ar = "select * from  " + tabla;
            

            if (textBox1.Text != string.Empty)
            {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += " DNI = '" + textBox1.Text + "' ";
                num++;
            }
            if (textBox2.Text != string.Empty)
            {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += "  Nombre like '%" + textBox2.Text + "%' ";
                num++;
            }

            if (textBox3.Text != string.Empty)
            {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += "  Apellido like '%" + textBox3.Text + "%' ";
                num++;

            }

            if (textBox4.Text != string.Empty)
            {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += "  email  like '%" + textBox4.Text + "%' ";
                num++;

            }
          //  MessageBox.Show(ar);
            if (ar == "select * from  Inscriptos")
                ar = "select DNI, Nombre, Apellido, UltimoCurso as 'Codigo de ultimo Curso', Email, Telefono, TipoConst as 'Comprobante que trajo'," +
                    " Const_Analitico, Const_Cuil as 'Const. de Cuil',fotoc_DNi as 'Fotocopia de DNI', Foto4x4 as 'Fotos 4x4', Const_Trabajo as 'Certificado laboral'," +
                    "constNaci as 'Const. Nacimiento', FechaEntregaDoc as 'Fecha de entrega de documentacion', Observaciones from Inscriptos";
            if (ar == "select * from  Preinscriptos")
                ar = "SELECT [DNI],[codcurso],[IDinscripto],[Nombre],[Apellido],[Email],[Telefono],[Turno],[Modalidad] FROM [SASAI].[dbo].[Preinscriptos]";


            return ar;
            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}


