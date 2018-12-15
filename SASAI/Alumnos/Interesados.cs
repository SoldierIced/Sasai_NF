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


    public partial class Interesados : Form
    {
        AccesoDatos aq = new AccesoDatos();
        public Interesados()
        {
            InitializeComponent();
        }

        void cargagrid()
        {
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();
            string consulta = "select * from interesados";
            aq.cargaTabla("asd", consulta, ref ds);
            dataGridView1.DataSource = ds.Tables["asd"];
            colorgrid();
            dataGridView1.Columns["Email"].ReadOnly = true;

        }
        void colorgrid()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (validaremailinscripto(dataGridView1.Rows[i].Cells["Email"].Value.ToString()) > 0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                }
            }
        }
        private void Interesados_Load(object sender, EventArgs e)
        {
            cargagrid();
        }

        int validaremailinscripto(string email)
        {
            DataSet ds = new DataSet();
            string consulta = "select email from inscriptos where email='" + email + "'";
            aq.cargaTabla("asd", consulta, ref ds);
            return ds.Tables["asd"].Rows.Count;

        }


        private void button1_Click(object sender, EventArgs e)
        {

            Alumnos.NuevoInteresado at = new Alumnos.NuevoInteresado();
            Formularios.AbrirFormularioHijos(at);
            if (at.DialogResult == DialogResult.OK)
            {
                cargagrid();

            }



        }

        private void Interesados_Resize(object sender, EventArgs e)
        {
            dataGridView1.Height = this.Height - 180;

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) { 
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                try
                {
                    string email = dataGridView1.SelectedRows[i].Cells["Email"].Value.ToString();
                    DataSet dt = new DataSet();
                    string consulta = "delete  from interesados where email='" + email + "'";
                    aq.cargaTabla("asd", consulta, ref dt);
                }
                catch (Exception ex)
                {
                }
            }
            MessageBox.Show("Seleccionados eliminados correctamente");
            cargagrid();
            }
            else
            {
                MessageBox.Show("Para borrar registros, debe seleccionar una fila!");
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                string email = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                string nombre = dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                string apellido = dataGridView1.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
                string observac = dataGridView1.Rows[e.RowIndex].Cells["Observacion"].Value.ToString();
                string fechaconsulta = dataGridView1.Rows[e.RowIndex].Cells["FechaConsulta"].Value.ToString();
                DataSet dt = new DataSet();
                string consulta = "update interesados set nombre='"+nombre+"',apellido='"+apellido+"',observacion='"+observac+"',fechaconsulta='"+fechaconsulta+"' where email='" + email + "'";
              //  MessageBox.Show(consulta);
                aq.cargaTabla("asd", consulta, ref dt);
            }
            catch (Exception ex)
            {
            }
        }
    }

}

