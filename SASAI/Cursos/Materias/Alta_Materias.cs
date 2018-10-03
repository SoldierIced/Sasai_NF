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
    public partial class Alta_Materias : Form
    {
        public Alta_Materias()
        {
            InitializeComponent();
        }

        //usada para capturar la cantidad de filas del datagrid en MATERIAS
        public static String Variable2;

        public int ObtenerID() {

            string idNuevo;
            idNuevo = Variable2;

            int cantidad;
            cantidad = int.Parse(idNuevo.ToString());
            //MessageBox.Show(cantidad.ToString());
            cantidad = cantidad + 1;
            return cantidad;

        }

        public static int ValidarNombre(string Nom_Materiaa)
        {

            AccesoDatos aq = new AccesoDatos();
            SqlCommand comando = new SqlCommand();
            try
            {
                comando = DatosSP.MateriasValidar(Nom_Materiaa);
                aq.ConfigurarProcedure(ref comando, "VerificarMateria");
                //MessageBox.Show("Nombre Valido");
                comando.Connection = aq.ObtenerConexion();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read()) {
                    return (int.Parse(reader[0].ToString()));
                }

                return -100;
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Nombre Invalido");
                //MessageBox.Show(ex.ToString());
                return -100;
            }


        }


        public bool DatosMateria (string nombre, string precio) {

            if (nombre != "" && precio != "")
            {

                if (ValidarNombre(nombre) == 1)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("NOMBRE MATERIA REPETIDO");
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        private void btn_altaMateria_Click(object sender, EventArgs e)
        {
            AccesoDatos aq = new AccesoDatos();
            SqlCommand comando = new SqlCommand();

            try
            { 
                if (DatosMateria(txb_NombreM.Text, txb_PrecioM.Text) == true)
                {
                    string IDConseguido;
                    int id=ObtenerID();

                    IDConseguido = "00" + id.ToString();
                    comando = DatosSP.MateriasCarga(IDConseguido, txb_NombreM.Text, txb_PrecioM.Text);
                    aq.EjecutarProcedimientoAlmacenado(comando, "CrearMateria");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Alta_Materias_Load(object sender, EventArgs e)
        {
            Variable2 = Materias.Variable;
        }
    }
}
