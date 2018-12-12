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
        string emailviejo = "";
        AccesoDatos aq = new AccesoDatos();
        public Interesados()
        {
            InitializeComponent();
        }

        void cargagrid()
        {  DataSet ds = new DataSet();
        string consulta = "select * from interesados";
            aq.cargaTabla("asd", consulta, ref ds);
           dataGridView1.DataSource= ds.Tables["asd"];
        }

        private void Interesados_Load(object sender, EventArgs e)
        {
            cargagrid();
           
           

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          //  DatosSP.Interesados();
           
        }

        private void dataGridView1_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //se agrega un rowwww

            try {
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = DateTime.Today.ToShortDateString();
            }
            catch (Exception) { }
              }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int pos = e.RowIndex; // NUMERO  DE FILA QUE ABANDONA.

                string email = dataGridView1.Rows[pos].Cells[0].Value.ToString();
                string nombre = dataGridView1.Rows[pos].Cells[1].Value.ToString();
                string apellido = dataGridView1.Rows[pos].Cells[2].Value.ToString();
                string fecha = dataGridView1.Rows[pos].Cells[3].Value.ToString();
                string observacion = dataGridView1.Rows[pos].Cells[4].Value.ToString();
                DataSet ds = new DataSet();
                string consulta = "";
                try {
                    consulta = "insert into Interesados select '"+email+"','"+nombre+"','"+apellido+"','"+fecha+"','"+observacion+"'";
                    aq.cargaTabla("insert", consulta, ref ds);
                    //insert into 
                } catch (Exception)
                {
                     consulta = "update Interesados set Email='" + email + "', Nombre='" + nombre + "'," +
   " Apellido='" + apellido + "'," + " FechaConsulta='" + fecha + "',observacion='"
   + observacion + "' where Email='" + emailviejo + "'";
                    aq.cargaTabla("asd", consulta, ref ds);
                }


               
            } catch (Exception ex) {
              //  MessageBox.Show(ex.ToString());
            }
           

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int pos = e.RowIndex;
                emailviejo = dataGridView1.Rows[pos].Cells[0].Value.ToString();
            } catch (Exception) { }  
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

           
           

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
              
                string email = e.Row.Cells[0].Value.ToString();
                //  MessageBox.Show(email);

                string consulta = "delete Interesados where Email='" + email + "'";
                DataSet ds = new DataSet();
                aq.cargaTabla("asd", consulta, ref ds);
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }
        }
    }
    }

