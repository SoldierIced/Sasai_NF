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
    public partial class CursoT : Form
    {
        public CursoT()
        {
            InitializeComponent();
        }
        AccesoDatos aq = new AccesoDatos();
        DataSet ds = new DataSet();
        string consulta = "";
        public void cargarNombreCursos(ref DataGridView da) {

            try {
                int tam = da.Rows.Count;
                for (int i = 0; i < tam; i++)
                {
                    consulta = "select nombre,Codespecialidad from Especialidades where Codespecialidad='" + da.Rows[i].Cells[da.Rows[i].Cells.Count - 1].Value + "'";
                    aq.cargaTabla("codespenombre" + i, consulta, ref ds);
                    da.Rows[i].Cells[da.Rows[i].Cells.Count - 1].Value = ds.Tables["codespenombre" + i].Rows[0][0].ToString();
                }
            } catch (Exception) { }
            
        }
        public void cargargrid() {
            try
            {

                string consulta2 = "select cursos.CodCurso as [Codigo de curso],NombreCurso as Nombre,FechaFinal as [Fecha de Inicio],FechaFinal as[Fecha de finalizacion],CapacidadMax as Capacidad, EspecialidadesXCursos.CodEspecialidad as[Codigo de Especialidad] from cursos inner join EspecialidadesXCursos on cursos.CodCurso=EspecialidadesXCursos.CodCurso";
                aq.cargaTabla("Cursos", consulta2, ref ds);

                dataGridView1.DataSource = ds.Tables["Cursos"];
                dataGridView1.Columns["Codigo de Especialidad"].Visible = false;
                cargarNombreCursos(ref dataGridView1);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void az(string val) { MessageBox.Show(val); }
        private void CursoT_Load(object sender, EventArgs e)
        {            cargargrid();
                      
        }

        private void button1_Click(object sender, EventArgs e)
        {

            CursoT_Filtrar CursoF = new CursoT_Filtrar();

            Formularios.AbrirFormularioHijos(CursoF);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].ToString(); codigo de curso del seleccionado.
            // abrir curso seleccionado.
            int rowi=dataGridView1.CurrentRow.Index;
            int celi = dataGridView1.Columns.Count - 1;
            //az(dataGridView1.CurrentRow.Index.ToString());

            if (dataGridView1.CurrentRow.Index>=0)
            {
                Cursos.CursoSeleccionado au = new Cursos.CursoSeleccionado(dataGridView1.Rows[rowi].Cells[0].Value.ToString(),
dataGridView1.Rows[rowi].Cells[5].Value.ToString()
// ds.Tables[rowi].Rows[0][1].ToString()

);
                Formularios.AbrirFormularioHijos(au);
            }
           
            }
    }
}
