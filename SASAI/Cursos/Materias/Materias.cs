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
    

    public partial class Materias : Form
    {
        public Materias()
        {
            InitializeComponent();
        }


        public static String Variable;


        private void cargarGrid() {
            AccesoDatos aq = new AccesoDatos();
            DataSet ds = new DataSet();
            

            try
            {

                string consulta = "select CodMateria, NombreMateria,Monto from Materias";

                aq.cargaTabla("Materias", consulta, ref ds);
                ListadoMaterias.DataSource = ds.Tables["Materias"];


            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            cargarGrid();
            try {
                txb_ID_M.Text = ListadoMaterias.Rows[0].Cells[0].Value.ToString();
                txb_NOMBRE_M.Text = ListadoMaterias.Rows[0].Cells[1].Value.ToString();
                txb_PRECIO_M.Text = ListadoMaterias.Rows[0].Cells[2].Value.ToString();
            }
            catch (Exception) { }
            

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



        private void Materias_Resize(object sender, EventArgs e)
        {
            ListadoMaterias.Height = this.Height - 150;
            ListadoMaterias.Width = this.Width - 38;
        }

        private void btn_Filtrar_M_Click(object sender, EventArgs e)
        {

            //Formularios.AbrirFormularioHijos(new Flt_Materias());
            string consulta = "";
            Flt_Materias f = new Flt_Materias();
            if (f.ShowDialog() == DialogResult.OK)
            {
                consulta = f.consulta;

            }
            //MessageBox.Show(consulta);
            try
            {
                AccesoDatos aq = new AccesoDatos();
                DataSet ds = new DataSet();
                aq.cargaTabla("Materias", consulta, ref ds);
                ListadoMaterias.DataSource = ds.Tables["Materias"];
            }
            catch (Exception) { }
            //cargarGrid();
        }

        private void btn_Agregar_M_Click(object sender, EventArgs e)
        {
            string CantidadFilas = ListadoMaterias.Rows.Count.ToString();
            int cant = Convert.ToInt32(CantidadFilas.ToString());
            cant = cant - 1;

            Variable = cant.ToString();

            Formularios.AbrirFormularioHijos(new Alta_Materias());
            cargarGrid();
        }

        private void btn_Modificar_M_Click(object sender, EventArgs e)
        {

            

            AccesoDatos aq = new AccesoDatos();
            SqlCommand comando = new SqlCommand();

            try
            {


               

                if (ValidarNombre(txb_NOMBRE_M.Text) == 1)
                {
                    comando = DatosSP.Materias(txb_ID_M.Text, txb_NOMBRE_M.Text);
                    aq.EjecutarProcedimientoAlmacenado(comando, "MateriaModificacionNombre");
                }
                else { MessageBox.Show("Nombre Materia Repetido"); }

                comando = DatosSP.Materias2(txb_ID_M.Text, txb_PRECIO_M.Text);
                aq.EjecutarProcedimientoAlmacenado(comando, "MateriaModificacionPrecio");
                cargarGrid();
            }
            catch (Exception ex)
            {
                  MessageBox.Show(ex.ToString());
            }
        }

        private void ListadoMaterias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ListadoMaterias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            string CantidadFilas = ListadoMaterias.Rows.Count.ToString();
            int cant = Convert.ToInt32(CantidadFilas.ToString());
            cant = cant - 1;

            //MessageBox.Show(CantidadFilas);
            //MessageBox.Show(cant.ToString());
            // cargo en la texbox desde la tabla datagrid
            int i = 0;

            for (i = 0; i < cant; i++) { 
                if (ListadoMaterias.Rows[i].Selected == true)
                {
                    txb_ID_M.Text = ListadoMaterias.Rows[i].Cells[0].Value.ToString();
                    txb_NOMBRE_M.Text = ListadoMaterias.Rows[i].Cells[1].Value.ToString();
                    txb_PRECIO_M.Text = ListadoMaterias.Rows[i].Cells[2].Value.ToString();
                }
            }

        }
    }
    
}
