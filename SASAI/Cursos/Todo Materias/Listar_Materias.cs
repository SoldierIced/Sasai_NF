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
    public partial class Listar_Materias : Form
    {
        public Listar_Materias()
        {
            InitializeComponent();
        }
        public string[] codigo;
        public string[] NombreM;
        public int tam { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {

            //creo el vector del tamaño cantidad materias
            int tamaño = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "si")
                {
                    tamaño++;
                }
            }
            //MessageBox.Show(tamaño.ToString());
            codigo = new string[tamaño];
            NombreM = new string[tamaño];
            int SIaux = 0;
            int SIaux2 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "si")
                {
                    codigo[SIaux] = dataGridView1.Rows[i].Cells[0].Value.ToString(); SIaux++;
                    NombreM[SIaux2] = dataGridView1.Rows[i].Cells[1].Value.ToString(); SIaux2++;
                }
            }

            tam = tamaño;
            DialogResult = DialogResult.OK;
            this.Close();

        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {

                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value = "si";
            }
            else
            {
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value = "no";
            }
        }

         string verficar_cantidadMaterias() {
            AccesoDatos aw = new AccesoDatos();
            DataSet dr = new DataSet();
            aw.cargaTabla("queseio", "select count(codmateria) from materias", ref dr);

            try
            {
                if (dr.Tables["queseio"].Rows[0][0].ToString() != "")
                    return dr.Tables["queseio"].Rows[0][0].ToString();
                else
                {
                    return "0";
                }
            }
            catch (Exception) { return "0"; }
        }

        private void Listar_Materias_Load(object sender, EventArgs e)
        {
            while (verficar_cantidadMaterias()=="0") { 
            if (verficar_cantidadMaterias() == "0")
            {
                MessageBox.Show("No hay materias creadas, porfavor cree una.");
                Alta_Materias alt = new Alta_Materias();
                Formularios.AbrirFormularioHijos(alt);
            }
            else {
              
            }
            }
            cargardata();
        }
        void cargardata ()
        {

            try
            {
              //  dataGridView1.DataSource = null;
                AccesoDatos aq = new AccesoDatos();
                DataSet dss = new DataSet();
                string consulta = "select * from materias";
                aq.cargaTabla("Materias", consulta, ref dss);
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dss.Tables["Materias"];

                dataGridView1.Columns.Add("Selec", "Selecionado");
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                  
                    dataGridView1.Rows[i].Cells[6].Value = "no";
                }
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1.Columns[i].Visible = false;
                }
                dataGridView1.Columns[1].Visible = true;
                dataGridView1.Columns["Selec"].Visible = false;




            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }



        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString() == "si")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellContentClick(sender, e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnmas_Click(object sender, EventArgs e)
        {
            Alta_Materias al = new Alta_Materias();
            
            Formularios.AbrirFormularioHijos(al);
            Listar_Materias aw = new Listar_Materias();

            cargardata();
            



        }
    }
}
