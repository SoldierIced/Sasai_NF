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


namespace SASAI.Alumnos
{
    public partial class CursadaAlumno : Form
    {
        DataSet ds = new DataSet();
        string consulta = "";
        AccesoDatos aq = new AccesoDatos();
        string leg = "";
        
        public CursadaAlumno(string nombre,string apellido,string legajo)
        {
            InitializeComponent();
            txtalumno.Text = apellido + ", " + nombre;
            leg = legajo;
            txtlegajo.Text = legajo+"";
           
        }

        public int verificarlist(string val,ListBox list) {

            for (int i = 0; i < list.Items.Count; i++) { 
                if (val == list.Items[i].ToString()) return i;
            }
            return -1;
        }

     

        private void CursadaAlumno_Load(object sender, EventArgs e)
        {

            try
            {
                consulta = "select c.CodCurso as [Codigo de curso],c.NombreCurso as [Nombre del curso],ac.CodMateria  as [Materia],ac.NotaMateria as [Nota Final],ac.modalidad as Modalidad,ac.turno as Turno, c.FechaFinal as [Fecha Curso] from AlumnosxMateriasxCursos as ac inner join Cursos as c on ac.Codcurso= c.CodCurso where  legajo =" + leg + " order by 'Codigo de curso'";
                aq.cargaTabla("materiasxcurso", consulta, ref ds);
                dataGridView1.DataSource = ds.Tables["materiasxcurso"];
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                  //  MessageBox.Show(dataGridView1.Rows[i].Cells["Materia"].Value.ToString());
                    string a = "";
                    a = saberNombrmateria(dataGridView1.Rows[i].Cells["Materia"].Value.ToString());
                    if (a != "")
                    {

                        dataGridView1.Rows[i].Cells["Materia"].Value = a;
                    }




                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
          
          
            // saber datos del alumno


        }
        public string saberNombrmateria(string codcu)
        {
            DataSet dr = new DataSet();
            aq.cargaTabla("queseyo", "select NombreMateria from Materias where CodMateria ='" + codcu + "'", ref dr);
            try {
                if (dr.Tables["queseyo"].Rows[0][0].ToString() != string.Empty) {
                    return dr.Tables["queseyo"].Rows[0][0].ToString();
                }
            } catch(Exception)
            { return ""; }
            
            return "";
        }

    }
}
