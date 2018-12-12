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
        public int bloqueado = 0;
        private void cargarGrid()
        {
            AccesoDatos aq = new AccesoDatos();
            DataSet ds = new DataSet();


            try
            {

                string consulta = "select * from Materias";

                aq.cargaTabla("Materias", consulta, ref ds);
                ListadoMaterias.DataSource = ds.Tables["Materias"];

                ListadoMaterias.Columns[0].Visible = false;
                ListadoMaterias.Columns[2].Visible = false;
                ListadoMaterias.Columns[3].Visible = false;
                ListadoMaterias.Columns[4].Visible = false;
                ListadoMaterias.Columns[5].Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        private void Materias_Load(object sender, EventArgs e)
        {

            cargarGrid();
            try
            {
                txb_ID_M.Text = ListadoMaterias.Rows[0].Cells[0].Value.ToString();
                txb_NOMBRE_M.Text = ListadoMaterias.Rows[0].Cells[1].Value.ToString();
                txb_PRECIO_M.Text = ListadoMaterias.Rows[0].Cells[2].Value.ToString();
                bloqueado = 0;
            }
            catch (Exception) { }
            read();
          
        }

        private void ListadoMaterias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

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

        private void btn_Modificar_M_Click(object sender, EventArgs e)
        {
            if (bloqueado == 0)
            {
                bloqueado = 1;
                read();

            }
            else {
                AccesoDatos aq = new AccesoDatos();
                SqlCommand comando = new SqlCommand();

                try
                {

                    float foo =float.Parse( txb_PRECIO_M.Text.Replace(".",","));
                    decimal bar = Convert.ToDecimal(foo);
                    bar = Math.Round(bar, 2);
                    txb_PRECIO_M.Text = bar.ToString();
                   // MessageBox.Show(txb_PRECIO_M.Text);
                    comando = DatosSP.MateriasCarga(txb_ID_M.Text, txb_NOMBRE_M.Text, txb_PRECIO_M.Text
                        , int.Parse(n1.Value.ToString()), int.Parse(n2.Value.ToString()), int.Parse(n3.Value.ToString()));

                    aq.EjecutarProcedimientoAlmacenado(comando, "MateriaModificacion");
                    cargarGrid();
                    MessageBox.Show("Materia modificada correctamente.");
                    bloqueado = 0;
                    read();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
               
            }


           
        }

        private void Materias_Resize(object sender, EventArgs e)
        {
           
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
                
                return -100;
            }


        }

        private void grp_Materias_Enter(object sender, EventArgs e)
        {

        }

        private void lbl_ID_M_Click(object sender, EventArgs e)
        {

        }

        void read() {

            if (bloqueado == 0)
            {
                txb_ID_M.ReadOnly = true;
                txb_NOMBRE_M.ReadOnly = true;
                txb_PRECIO_M.ReadOnly = true;
                n1.ReadOnly = true;
                n2.ReadOnly = true;
                


            }
            else {
                txb_ID_M.ReadOnly = false;
                txb_NOMBRE_M.ReadOnly = false;
                txb_PRECIO_M.ReadOnly = false;
                n1.ReadOnly = false;
                n2.ReadOnly = false;
            }



        }
      
        private void ListadoMaterias_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ListadoMaterias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                float foo = float.Parse(ListadoMaterias.Rows[ListadoMaterias.CurrentRow.Index].Cells[2].Value.ToString());
                decimal bar = Convert.ToDecimal(foo);
                bar = Math.Round(bar, 2);
                txb_PRECIO_M.Text = bar.ToString();

                txb_ID_M.Text = ListadoMaterias.Rows[ListadoMaterias.CurrentRow.Index].Cells[0].Value.ToString();
                txb_NOMBRE_M.Text = ListadoMaterias.Rows[ListadoMaterias.CurrentRow.Index].Cells[1].Value.ToString();

                n1.Value = int.Parse(ListadoMaterias.Rows[ListadoMaterias.CurrentRow.Index].Cells[3].Value.ToString());
                n2.Value = int.Parse(ListadoMaterias.Rows[ListadoMaterias.CurrentRow.Index].Cells[4].Value.ToString());
                n3.Value = int.Parse(ListadoMaterias.Rows[ListadoMaterias.CurrentRow.Index].Cells[5].Value.ToString());


            }
            catch (Exception)
            {

             
            }

        }

        private void ListadoMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ListadoMaterias_CellContentClick_1(sender, e);
        }

        private void ListadoMaterias_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ListadoMaterias_CellContentClick_1(sender, e);
        }
    }
}
