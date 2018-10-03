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
        public int tablita { get; set; }
        public AlumnosF()
        {
            InitializeComponent();
        }

        private void AlumnosF_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand();
            AccesoDatos aq = new AccesoDatos();
            DataSet ds = new DataSet();
            /* DatosSP.Inscripto_DNI(ref comando, int.Parse(textBox1.Text));

             aq.EjecutarProcedimientoAlmacenado(comando, "verificarExistenciaInscripto");
             */
            string consulta = "exec verificarExistenciaInscripto " + textBox1.Text;
            aq.cargaTabla("asd", consulta, ref ds);
            dataGridView1.DataSource = ds.Tables[0];
            try
            {
                if (dataGridView1.Columns[dataGridView1.Columns.Count - 2].HeaderText == "baja")
                {

                    AlumnoSelecionado af = new AlumnoSelecionado(dataGridView1.Rows[0].Cells[0].Value.ToString(), 2);
                    af.ShowDialog();
                    this.Close();
                }
                else
                {
                    

                    if (dataGridView1.Columns[dataGridView1.Columns.Count - 2].HeaderText == "observaciones")
                    {
                        AlumnoSelecionado af = new AlumnoSelecionado(dataGridView1.Rows[0].Cells[0].Value.ToString(), 1);
                        af.ShowDialog();
                        this.Close();
                    }


                }
            }
            catch(Exception ex) {
                
            MessageBox.Show( "Alumnos no encontrado");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        public void armarconsulta(ref string ar, string tabla)
        {
            string d1 = " AND ";

            int num = 0;
            if (ar == string.Empty)
            {
                ar = "select * from  " + tabla;


            }

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
            if (textBox5.Text != string.Empty)
            {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += "  UltimoCurso  like '%" + textBox5.Text + "%' ";
                num++;

            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}


