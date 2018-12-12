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
                while (reader.Read())
                {
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

        public bool DatosMateria(string nombre, string precio)
        {

            if (nombre != "" && precio != "")
            {

                if (ValidarNombre(nombre) == -1)
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
                    int id = ObtenerID()+1;

                    IDConseguido = "00" + id.ToString();
                   // MessageBox.Show(IDConseguido);
                    string doble = txb_PrecioM.Text;
                    decimal doblesss = Convert.ToDecimal(doble);
                    int number = Decimal.ToInt32(doblesss);


                    if (number > 0)
                    {
                        comando = DatosSP.MateriasCarga(IDConseguido, txb_NombreM.Text, number.ToString(), int.Parse(n1.Value.ToString()), int.Parse(n2.Value.ToString()), int.Parse(textBox1.Text));
                        aq.EjecutarProcedimientoAlmacenado(comando, "CrearMateria");
                        MessageBox.Show("Materia creada correctamente");
                        this.Close();
                    }
                    else {
                        MessageBox.Show("Tiene que ser un numero positivo.");
                    }


                  
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Ingrese un numero correcto");
            }
        }

        string verficar_cantidadMaterias()
        {
            AccesoDatos aw = new AccesoDatos();
            DataSet dr = new DataSet();
            aw.cargaTabla("queseio", "select count(codmateria) from materias", ref dr);

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
        private void Alta_Materias_Load(object sender, EventArgs e)
        {
            Variable2 = verficar_cantidadMaterias();
        }

        private void txb_PrecioM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
