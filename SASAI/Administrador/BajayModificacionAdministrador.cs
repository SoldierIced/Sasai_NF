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
    public partial class BajayModificacionAdministrador : Form
    {
       

        public BajayModificacionAdministrador()
        {
            InitializeComponent();
            

        }
        private void BajayModificacionAdministrador_Load(object sender, EventArgs e)
        {


            actualizargrid();


        }

       public void actualizargrid()
        {
            try { 
            AccesoDatos aq = new AccesoDatos();
            DataSet ds = new DataSet();
            string consulta = "select * from Usuarios";
            aq.cargaTabla("Usuarios", consulta, ref ds);
            dataGridView1.DataSource = ds.Tables["Usuarios"];
            dataGridView1.Rows[2].Cells[3].Selected = true;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            }
            catch (Exception) { }
        }
      

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text != "")
            {
                try
                {
                    if (int.Parse(textBox3.Text) <= 10 && int.Parse(textBox3.Text) >= 1)
                    {
                        int aux;
                        if (checkBox1.Checked == true)
                        {
                            aux = 1;
                        }
                        else
                        {
                            aux = 0;
                        }
                        try
                        {
                            Usuario_class.ActualizarUser(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), aux);
                            MessageBox.Show("Registro modificado.");
                            actualizargrid();

                        }

                        catch (Exception ex) { }

                    }
                    else { MessageBox.Show("El nivel de acceso tiene que ser entre el 1 y el 10."); }
                }
                catch (Exception) { }
            }
            else { MessageBox.Show("No se permiten campos vacios."); }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

          
                
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           textBox1.Text= dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
           textBox2.Text= dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
           textBox3.Text= dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            try {
            //    MessageBox.Show(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString());
                if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString() == "True")
                {
                    checkBox1.Checked = true;
                }
                else { checkBox1.Checked = false; }
            }

            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            
            
        }
    }
}
