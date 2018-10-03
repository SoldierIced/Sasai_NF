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

namespace SASAI
{
    public partial class Alta_Especialidad : Form
    {
        public Alta_Especialidad()
        {
            InitializeComponent();
        }
        public static String Variable2;


        public int ObtenerID()
        {

            string idNuevo;
            idNuevo = Variable2;

            int cantidad;
            cantidad = int.Parse(idNuevo.ToString());
            //MessageBox.Show(cantidad.ToString());
            cantidad = cantidad + 1;
            return cantidad;

        }


        public bool DatosEspecialidad(string nombre, string duracion)
        {

            if (nombre != "" && duracion != "")
            {

                //if (ValidarNombre(nombre) == -1)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
                return true;
            }
            else
            {
                return false;
            }

        }

        string verficar_cantidadEspe()
        {
            AccesoDatos aw = new AccesoDatos();
            DataSet dr = new DataSet();
            aw.cargaTabla("queseio", "select count(codespecialidad) from Especialidades", ref dr);

            try
            {
                if (dr.Tables["queseio"].Rows[0][0].ToString() != "")
                    return dr.Tables["queseio"].Rows[0][0].ToString();
                else
                {
                    return "0";
                }
            }
            catch (Exception) { return "0"; }
        }
        private void Alta_Especialidad_Load(object sender, EventArgs e)
        {
            Variable2 = verficar_cantidadEspe();
        }

        private void btn_altaEspecialidad_Click(object sender, EventArgs e)
        {
            AccesoDatos aq = new AccesoDatos();
            SqlCommand comando = new SqlCommand();

            try
            {
                if (DatosEspecialidad(txb_NombreE.Text, numericUpDown1.Text) == true)
                {
                    string IDConseguido;
                    int id = ObtenerID();

                    IDConseguido = "00" + id.ToString();
                    comando = DatosSP.EspecialidadCarga(IDConseguido, txb_NombreE.Text, numericUpDown1.Text);
                    aq.EjecutarProcedimientoAlmacenado(comando, "CrearEspecialidad");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
