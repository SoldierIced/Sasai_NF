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
                ar = "select TipoTrn as [Tipo de transaccion],Tabla,PK as [Claves primarias],Campo as [Campo Modificado], ValorOriginal,ValorNuevo,FechaTrn as [Fecha de Modificacion],Usuario from ControlPreinscriptos";

               
            }

            if (textBox1.Text != string.Empty) {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += " Usuario like '%" + textBox1.Text + "%' ";
                num++;
            }
            if (textBox2.Text != string.Empty) {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += "  FechaTrn like '%" + textBox2.Text + "%' ";
                num++;
            }

            if (textBox3.Text != string.Empty)
            {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += "  Campo like '%" + textBox3.Text + "%' ";
                num++;

            }

            if (textBox4.Text != string.Empty)
            {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += "  pk  like '%" + textBox4.Text + "%' ";
                num++;

            }
            if (textBox5.Text != string.Empty)
            {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += " ValorNuevo   like '%" + textBox5.Text + "%' ";
                num++;

            }
            if (textBox6.Text != string.Empty)
            {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                ar += " ValorOriginal   like '%" + textBox6.Text + "%' ";
                num++;

            }
            if (comboBox1.SelectedIndex != -1) {
                if (num != 0) { ar += d1; num = 0; }
                else { ar += " where "; }
                string numeritolist = "";
                if (comboBox1.SelectedIndex == 0) { numeritolist = "I"; }
                else if (comboBox1.SelectedIndex == 1) { numeritolist = "U"; }
                else { numeritolist = "D"; }

                ar += "  TipoTrn = '" + numeritolist + "' ";
                num++;
            }

        }

        private void filtrar_Load(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
