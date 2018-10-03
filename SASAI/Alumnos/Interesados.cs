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
  
    
    public partial class Interesados : Form
    {
        DataSet ds = new DataSet();
        AccesoDatos aq = new AccesoDatos();
        public Interesados()
        {
            InitializeComponent();
        }

        private void Interesados_Load(object sender, EventArgs e)
        {
            string consulta = "select top 50 * from Interesados";
            aq.cargaTabla("Interesados", consulta, ref ds);

            if (ds.Tables["Interesados"].Rows.Count.ToString() == "0")
            {
                 ds = new DataSet();
                consulta = "insert into Interesados select 'base','base','base',GETDATE() ";
                aq.cargaTabla("asd", consulta, ref ds);
                consulta = "select top 50 * from Interesados";
                aq.cargaTabla("Interesados", consulta, ref ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else {
                 ds = new DataSet();
                consulta = "delete Interesados where Email= 'base'";
                aq.cargaTabla("asd", consulta, ref ds);
                consulta = "select top 50 * from Interesados";
                aq.cargaTabla("Interesados", consulta, ref ds);

                dataGridView1.DataSource = ds.Tables[0];

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string email = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                string nombre = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                string apellido = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                InteresadoEspecifico inte = new InteresadoEspecifico(email, nombre, apellido);
                Formularios.AbrirFormularioHijos(inte);

                ds = new DataSet();
                string consulta = "select top 50 * from Interesados";
                aq.cargaTabla("Interesados", consulta, ref ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception) { }
           
        }

        private void dataGridView1_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {

        }

        /* private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {

         }*/

    }
    }

