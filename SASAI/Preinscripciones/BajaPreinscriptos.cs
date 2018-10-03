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
//using Microsoft.Office.Interop;

namespace SASAI
{
    public partial class BajaPreinscriptos : Form
    {
        public BajaPreinscriptos()
        {
            InitializeComponent();
        }
        AccesoDatos aq = new AccesoDatos();
        DataSet ds = new DataSet();
        private void BajaPreinscriptos_Load(object sender, EventArgs e)
        {

            string consulta = "select DNI,codcurso as [Ultimo Curso],Nombre,Apellido,Email,Telefono,Turno,Modalidad,baja from Preinscriptos";

            aq.cargaTabla("Preinscriptos", consulta, ref ds);
            dataGridView1.DataSource = ds.Tables[0];
           

            for (int i = 0; i < dataGridView1.Columns.Count; i++) { 
                dataGridView1.Columns[i].ReadOnly =true;

            }
            dataGridView1.Columns[8].ReadOnly = false;

        }
        


        private void BajaPreinscriptos_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Height = this.Height - 150;
            dataGridView1.Width = this.Width -40;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                if (dataGridView1.Rows[i].Cells[8].Value.ToString()=="True") { 
            string consulta = "update Preinscriptos set baja = 1 where DNI ="+dataGridView1.Rows[i].Cells[0].Value;

                    aq.cargaTabla("Preinscriptosbaja", consulta, ref ds);
                    
                }

            }
           

        }
    }
}
