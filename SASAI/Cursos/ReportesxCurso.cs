using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SASAI.Cursos
{
    public partial class ReportesxCurso : Form
    {
        AccesoDatos aq = new AccesoDatos();
        string curso = "";
        public ReportesxCurso(string codcurso)
        {
            InitializeComponent();
            this.curso = codcurso;
        }
        void dd (string val) { MessageBox.Show(val); }

        void cargarchar(System.Windows.Forms.DataVisualization.Charting.Chart cha, string x, string y,string serie, System.Windows.Forms.DataVisualization.Charting.SeriesChartType at= System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar) {


            cha.Series.Add(serie);
            cha.Series[serie].ChartType = at;
            cha.Series[serie].Points.AddXY(x, y);
            cha.Series[serie].MarkerStep = 1;
            


        }

        private void ReportesxCurso_Load(object sender, EventArgs e)
        {
            DataSet dt = new DataSet();
            //traer los datos del curso porque van a ser necesarios.
            aq.cargaTabla("Curso", "SELECT [CodCurso],[FechaInicio],[FechaFinal],[NombreCurso],[Nota_Min],[CapacidadMax],[actual] FROM [SASAI].[dbo].[Cursos] where codcurso='" + this.curso + "'", ref dt);
            string notamin = dt.Tables["Curso"].Rows[0]["Nota_Min"].ToString();
            string nombrecurso = dt.Tables["Curso"].Rows[0]["NombreCurso"].ToString();
            lb_curso.Text += nombrecurso;
                       
            //primero saber cuales son las materias de dicho curso.
            aq.cargaTabla("Materias", "select MateriasxCurso.CodMateria, Materias.NombreMateria from materiasxcurso inner join Materias on MateriasxCurso.CodMateria = Materias.CodMateria where CodCurso ='" + this.curso + "'", ref dt);
            //cantidad total de alumnos en el curso
            aq.cargaTabla("cantidadcurso", "select COUNT(legajo) from AlumnosxMateriasxCursos where Codcurso='" + curso + "' ", ref dt);
            int cantidad_alumnos = int.Parse(dt.Tables["cantidadcurso"].Rows[0][0].ToString()) / dt.Tables["Materias"].Rows.Count;
            lb_cantidad.Text += cantidad_alumnos;


            //cargar primer chart
            if (dt.Tables["Materias"].Rows.Count != 0)
            {
                // saber las cantidades de alumnos de dichas materias
                for (int i = 0; i < dt.Tables["Materias"].Rows.Count; i++)
                {
                    DataSet ds = new DataSet();
                    string materia = dt.Tables["Materias"].Rows[i]["CodMateria"].ToString();
                    string nombre = dt.Tables["Materias"].Rows[i]["NombreMateria"].ToString();
                    aq.cargaTabla("CantAlumn", "select * from AlumnosxMateriasxCursos where Codcurso='" + this.curso + "' and CodMateria='" + materia + "' and NotaMateria>="+notamin, ref ds);
                    string cantidad = ds.Tables["CantAlumn"].Rows.Count.ToString();
                    cargarchar(chart1,"", cantidad, nombre);
                }

            }
            else {
                dd("No se puede graficar datos de un curso sin una materia cargada como minimo.");
            }
            //--------------------------------------------------- cierre de carga  de chart1


            //cargar chart2

            //saber los datos de los alumnos de dicho curso
            DataSet df = new DataSet();
            aq.cargaTabla("Alumnos", "select * from AlumnosxMateriasxCursos where Codcurso='" + this.curso + "' order by legajo", ref df);
            int alumnos_aprobados = 0;
            for (int i = 0; i < df.Tables["Alumnos"].Rows.Count; i+=3)
            {
                if (aprobo(df.Tables["Alumnos"].Rows[i]["legajo"].ToString(), int.Parse(notamin)) == true) {
                    alumnos_aprobados++;
                }

            }

           
            System.Drawing.Font aw = new System.Drawing.Font("Microsoft Sans Serif", 12);
            chart1.Titles[0].Font = aw;
            chart2.Series["Series1"].Points.Add();
            chart2.Series["Series1"].Points[0].SetValueY(alumnos_aprobados.ToString());
            chart2.Series["Series1"].Points[0].CustomProperties = "LabelsHorizontalLineSize=1.5, PieLabelStyle=Outside, LabelsRadialLineSize=0, PieLineColor=Black";
            chart2.Series["Series1"].Points[0].AxisLabel = ((alumnos_aprobados*100)/cantidad_alumnos)+"%";
            chart2.Series["Series1"].Points[0].LegendText = "Alumnos Aprobados";
            chart2.Series["Series1"].Points[0].Color = Color.Green;


            chart2.Series["Series1"].Points.Add();
            chart2.Series["Series1"].Points[1].SetValueY((cantidad_alumnos - alumnos_aprobados));
            chart2.Series["Series1"].Points[1].CustomProperties = "LabelsHorizontalLineSize=1.5, PieLabelStyle=Outside, LabelsRadialLineSize=0, PieLineColor=Black";
            chart2.Series["Series1"].Points[1].AxisLabel = (((cantidad_alumnos - alumnos_aprobados)* 100)/cantidad_alumnos)+"%";
            chart2.Series["Series1"].Points[1].LegendText = "Alumnos Desaprobados";
            chart2.Series["Series1"].Points[1].Color = Color.Red;
            // cargarchar(chart2, alumnos_aprobados.ToString(), alumnos_aprobados.ToString(), "Alumnos Aprobados");
            // cargarchar(chart2, (cantidad_alumnos - alumnos_aprobados).ToString(), (cantidad_alumnos-alumnos_aprobados).ToString(), "Alumnos Desaprobados", System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie);


        }
        bool aprobo(string legajo, int notamin) {

            DataSet df = new DataSet();
            aq.cargaTabla("Alumnos", "select * from AlumnosxMateriasxCursos where Codcurso='" + this.curso + "' order by legajo", ref df);

            bool aprobo = true;
            for (int i = 0; i < df.Tables["Alumnos"].Rows.Count; i++)
            {
                if (legajo == df.Tables["Alumnos"].Rows[i]["legajo"].ToString()) {

                    if (int.Parse(df.Tables["Alumnos"].Rows[i]["NotaMateria"].ToString()) < notamin) {

                        aprobo = false;
                        return false;
                    }


                }
            }
            return true;

        }
    }
}
