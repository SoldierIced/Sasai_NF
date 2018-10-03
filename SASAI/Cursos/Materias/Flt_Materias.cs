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
    public partial class Flt_Materias : Form
    {
        public Flt_Materias()
        {
            InitializeComponent();
        }
        public string consulta { get; set; }

        public void armarconsulta(ref string ar)
        {
            string d1 = " AND ";
            string d2 = "";
            int num = 0;

            
                ar = "select * from Materias" + " ";
            
            if (rbt_Igual_Precio.Checked == true)
            {
              //  MessageBox.Show("entro al if que esta precionado boton");
                if (txt_precio_M.Text != string.Empty)
                {
                    
                    if (num != 0) { ar += d1; num = 0; }
                    else { ar += " where "; }
                    ar += "  Monto = '" + 800 + "' ";
                   // MessageBox.Show(ar);
                    num++;
                }
            }
            if (rbt_Menor_Precio.Checked == true)
            {
                if (txt_precio_M.Text != string.Empty)
                {

                    if (num != 0) { ar += d1; num = 0; }
                    else { ar += " where "; }
                    ar += "  Monto <= '" + txt_precio_M.Text + "' ";
                    num++;
                }
            }
            if (rbt_Mayor_Precio.Checked == true)
            {
                if (txt_precio_M.Text != string.Empty)
                {

                    if (num != 0) { ar += d1; num = 0; }
                    else { ar += " where "; }
                    ar += "  Monto >= '" + txt_precio_M.Text + "' ";
                    num++;
                }
            }
            //Termina los radio buttons 



            if (txt_Nombre_M.Text != string.Empty) {

                if (num != 0) { ar += d1; num = 0; }

                else { ar += " where "; }

                ar += "NombreMateria LIKE '%" + txt_Nombre_M.Text + "%' ";
                //MessageBox.Show(ar);
                num++;
            }


            if (txt_ID_M.Text != string.Empty)
            {

                if (num != 0) { ar += d1; num = 0; }

                else { ar += " where "; }

                ar += "CodMateria LIKE '%" + txt_ID_M.Text + "%' ";
                //MessageBox.Show(ar);
                num++;
            }




        }

       public void btn_filtrarM_M_Click(object sender, EventArgs e)
       {
                string aux = "";
                armarconsulta(ref aux);
                consulta = aux;
            this.DialogResult = DialogResult.OK;
            //MessageBox.Show(consulta);
            this.Close();
       }
    }
}
