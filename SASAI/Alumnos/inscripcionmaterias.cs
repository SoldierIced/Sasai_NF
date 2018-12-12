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
    public partial class inscripcionmaterias : Form
    {

        public string codmateria = "";
        public string modalidad = "";
        public string turno = "";
       AccesoDatos aq = new AccesoDatos();
        DataSet ds = new DataSet();
        
        
        public inscripcionmaterias(string codmateria)
        {
            InitializeComponent();
       
            this.codmateria = codmateria;
           
            sabernombremateria();
            radioButton2.Checked = true;
            radioButton3.Checked = true;
        }

       public void sabernombremateria() {

            aq.cargaTabla("a", "select NombreMateria from materias where codmateria='" + codmateria + "'", ref ds);
            textBox1.Text=  ds.Tables["a"].Rows[0][0].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                turno = "NOCHE";
            }
            else { turno = "MAÑANA"; }

            if (radioButton3.Checked == true)
            {
                modalidad = "PRESENCIAL";
            }
            else { modalidad= "LIBRE"; }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void inscripcionmaterias_Load(object sender, EventArgs e)
        {

        }
    }
}
