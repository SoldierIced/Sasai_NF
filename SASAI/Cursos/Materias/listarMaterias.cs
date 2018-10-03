using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SASAI
{
    public partial class listarMaterias : Form
    {
        public string[] codigo;
        public string[] NombreM;
        public int tam { get; set; }

        public listarMaterias()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString() == "si")
            {
                checkBox1.Checked = true;
            }
            else {
                checkBox1.Checked = false;
            }
        }

        private void listarMaterias_Load(object sender, EventArgs e)
        {
            AccesoDatos aq = new AccesoDatos();
            DataSet ds = new DataSet();
            string consulta = "select * from materias";
            aq.cargaTabla("Materias", consulta, ref ds);
            dataGridView1.DataSource = ds.Tables[0];
           // dataGridView1.Columns[0].Visible = false;
           // dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns.Add("Selec", "Selecionado");
            for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                dataGridView1.Rows[i].Cells[3].Value = "no";
            }
         //   dataGridView1.Columns[3].Visible = false;




        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {

                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value = "si";
            }
            else
            {
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value = "no";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //creo el vector del tamaño cantidad materias
            int tamaño = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "si") {
                    tamaño++; }
            }
            //MessageBox.Show(tamaño.ToString());
            codigo = new string[tamaño];
            NombreM = new string[tamaño];
            int SIaux = 0;
            int SIaux2 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "si")
                {
                    codigo[SIaux] = dataGridView1.Rows[i].Cells[0].Value.ToString(); SIaux++;
                    NombreM[SIaux2] = dataGridView1.Rows[i].Cells[1].Value.ToString(); SIaux2++;
                }
            }

            tam = tamaño;
            DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
