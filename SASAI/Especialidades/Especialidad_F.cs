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
    public partial class Especialidad_F : Form
    {
        public Especialidad_F()
        {
            InitializeComponent();
        }

        private void Especialidad_F_Load(object sender, EventArgs e)
        {
            
        }

        public string consulta { get; set; }


        public void armarconsulta(ref string ar)
        {
            string d1 = " AND ";
            string d2 = "";
            int num = 0;


            ar = "select * from Especialidades" + " ";


            if (numericUpDown1.Text != "0")
            {

                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += "  AniosAprox = '" + numericUpDown1.Text + "' ";
                num++;
            }

            if (txt_Nombre_E.Text != string.Empty)
            {

                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += "nombre LIKE '%" + txt_Nombre_E.Text + "%'";
                num++;
                MessageBox.Show(ar);
            }


            if (txt_ID_E.Text != string.Empty)
            {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += "Codespecialidad LIKE '%" + txt_ID_E.Text + "%'";
                num++;
            }

        }
        private void btn_filtrarM_M_Click(object sender, EventArgs e)
        {
            string aux = "";
            armarconsulta(ref aux);
            consulta = aux;
            this.DialogResult = DialogResult.OK;
            MessageBox.Show(consulta);
            this.Close();
        }
    }
}
