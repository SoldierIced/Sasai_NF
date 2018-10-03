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
    public partial class Auditoria : Form
    {
       
        public Auditoria()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string consulta="";
            filtrar f = new filtrar();
            if (f.ShowDialog() == DialogResult.OK) {
                 consulta = f.consulta;
                
            }
            //MessageBox.Show(consulta);
            try {
                AccesoDatos aq = new AccesoDatos();
                DataSet ds = new DataSet();
                aq.cargaTabla("Controlweaa", consulta, ref ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception) { }

        }

        private void Auditoria_Load(object sender, EventArgs e)
        {
            AccesoDatos aq = new AccesoDatos();
            DataSet ds = new DataSet();
            string consulta = "select * from controlpreinscriptos";
            aq.cargaTabla("Controlweaa", consulta, ref ds);

            dataGridView1.DataSource = ds.Tables[0];

        }

        private void Auditoria_Resize(object sender, EventArgs e)
        {
            dataGridView1.Height = this.Height - 150;
            dataGridView1.Width = this.Width -38;
        }
    }
}
