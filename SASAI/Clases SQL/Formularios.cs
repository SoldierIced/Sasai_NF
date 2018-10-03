using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace SASAI
{
     class Formularios
    {
       
        public static Form1 DIOS = new Form1();
        public static string Usuario = "";
        public static int acceso=0;

        public static Form1 enviarFormulario()
        {
            return DIOS;
        }

        public static void cerrarFormularioHijo()
        {
            for (int i = 0; i < DIOS.MdiChildren.Length; i++)
            {
                
                DIOS.MdiChildren[i].Close();
            }
        }

        public static void AbrirFormularioPadre (Form x) {

            cerrarFormularioHijo();
            x.MdiParent = DIOS;
            x.WindowState = FormWindowState.Maximized;
            x.ControlBox = false;
            x.ShowInTaskbar = false;
            x.FormBorderStyle = FormBorderStyle.FixedDialog;
            //x.AutoScaleDimensions = new System.Drawing.SizeF(DIOS.Size.Width,DIOS.Size.Height);
            //x.PerformAutoScale();
            x.Show();
            


        }
        public static void AbrirFormularioHijos(Form x)
        {
            
            x.ShowDialog();
            
        }




    }


    
}
