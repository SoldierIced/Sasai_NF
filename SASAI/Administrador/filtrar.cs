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
    public partial class filtrar : Form
    {
        public string consulta { get; set; }


        public filtrar()
        {
            InitializeComponent();
           
        }
       
             
        private void button2_Click(object sender, EventArgs e)
        {
            string aux = "";
            armarconsulta(ref aux);
            consulta = aux;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        public void armarconsulta(ref string ar) {
            string d1 = " AND ";
           
            int num = 0;
            if (ar == string.Empty)
            {
                ar = "select * from ";

                ar += listBox1.SelectedItem.ToString() + " ";
            }

            if (textBox1.Text != string.Empty) {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += " Usuario = '" + textBox1.Text + "' ";
                num++;
            }
            if (textBox2.Text != string.Empty) {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += "  FechaTrn = '" + textBox2.Text + "' ";
                num++;
            }

            if (textBox3.Text != string.Empty)
            {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += "  Campo = '" + textBox3.Text + "' ";
                num++;

            }

            if (textBox4.Text != string.Empty)
            {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += "  pk  like '%" + textBox4.Text + "%' ";
                num++;

            }
            if (listBox2.SelectedIndex != -1) {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                string numeritolist = "";
                if (listBox2.SelectedIndex == 0) { numeritolist = "I"; }
                else if (listBox2.SelectedIndex == 1) { numeritolist = "U"; }
                else { numeritolist = "D"; }

                ar += "  TipoTrn = '" + numeritolist + "' ";
                num++;
            }

        }

        private void filtrar_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("ControlPreinscriptos");
            listBox1.Items.Add("ControlAlumxMatexCurso");
            listBox1.SelectedIndex = 0;
        }
    }
}
