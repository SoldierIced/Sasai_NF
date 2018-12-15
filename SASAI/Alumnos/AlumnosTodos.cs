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
    public partial class AlumnosTodos : Form
    {
       
        public int numtabla { get; set; }
        DataSet ds = new DataSet();
        AccesoDatos aq = new AccesoDatos();
        string consulta = "";
        public AlumnosTodos()
        {
            InitializeComponent();
        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dtt = new DataSet();
                AlumnosF F = new AlumnosF();
                Formularios.AbrirFormularioHijos(F);
              string aux=  F.consulta;
                if (F.tablita == 1 || F.tablita == 2) {
                    numtabla = F.tablita;
       aq.cargaTabla("cargar",aux,ref dtt);
                dataGridView1.DataSource = dtt.Tables["cargar"];
                }
                else
                {
                  //  AlumnoSelecionado af = new AlumnoSelecionado(F.dni, 2);
                 //   af.ShowDialog();
                    
                }
            }
            catch (Exception) { }
        }

        private void AlumnosTodos_Load(object sender, EventArgs e)
        {            
            cargardata();
            numtabla = 1;
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
         }
        public void cargardata() {
            try
            {
                ds = new DataSet();
                GestionSql aw = new GestionSql();
                consulta = "select top(30) DNI, Nombre, Apellido, UltimoCurso as 'Codigo de ultimo Curso', Email, Telefono, TipoConst as 'Comprobante que trajo'," +
                    " Const_Analitico, Const_Cuil as 'Const. de Cuil',fotoc_DNi as 'Fotocopia de DNI', Foto4x4 as 'Fotos 4x4', Const_Trabajo as 'Certificado laboral'," +
                    "constNaci as 'Const. Nacimiento', FechaEntregaDoc as 'Fecha de entrega de documentacion', Observaciones from Inscriptos";
                aq.cargaTabla("tabla", consulta, ref ds);

                dataGridView1.DataSource = ds.Tables["tabla"];
                numtabla = 1;
                dataGridView1.Columns[7].Visible = false;
               
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

           

        }



        private void AlumnosTodos_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Height = this.Height - 180;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                
                string Dni = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["DNI"].Value.ToString();
                AlumnoSelecionado aqr = new AlumnoSelecionado(Dni, numtabla);
                Formularios.AbrirFormularioHijos(aqr);
                cargardata();
            }
            catch (Exception ex ) { MessageBox.Show(ex.ToString()); }
           
            

            
        }

        private void btn_enviarEmail_Click(object sender, EventArgs e)
        {
            Formularios.AbrirFormularioHijos(new EnviarMailMasivo(dataGridView1, 4));
        }
    }
}
