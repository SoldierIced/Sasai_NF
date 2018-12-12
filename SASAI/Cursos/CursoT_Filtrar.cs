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
    public partial class CursoT_Filtrar : Form
    {

        public string consulta = "";
        public CursoT_Filtrar()
        {
            InitializeComponent();
        }

        private void CursoT_Filtrar_Load(object sender, EventArgs e)
        {

        }

        public string armar_consulta() {

            string d1 = " AND ";
            int num = 0;


            string ar = "select cursos.CodCurso as [Codigo de curso],NombreCurso as Nombre,FechaFinal as [Fecha de Inicio],FechaFinal as[Fecha de finalizacion],CapacidadMax as Capacidad, EspecialidadesXCursos.CodEspecialidad as[Codigo de Especialidad] from cursos inner join EspecialidadesXCursos on cursos.CodCurso=EspecialidadesXCursos.CodCurso  ";


            if (tb_nombre.Text != string.Empty)
            {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += " nombreCurso  like '%" + tb_nombre.Text + "%' ";
                num++;
            }

            if (tb_fechai.Text != string.Empty)
            {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += " FechaInicio like '%" + tb_fechai.Text + "%' ";
                num++;
            }

            if (tb_fechaf.Text != string.Empty)
            {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += "  FechaFinal like '%" + tb_fechaf.Text + "%' ";
                num++;
            }


          //  MessageBox.Show(ar);
            return ar;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //filtrar

          consulta=  armar_consulta();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
