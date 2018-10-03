using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SASAI
{
    class AccesoDatos
    {
        public  string Reader_Procedure(SqlCommand comando, string procedure)
        {
            try
            {
                AccesoDatos aq = new AccesoDatos();
                aq.ConfigurarProcedure(ref comando, procedure);
                comando.Connection = aq.ObtenerConexion();
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    return (reader[0].ToString());

                }
                return "error";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return "error";
            }
        }
        String rutaSasai =
    "Data Source=localhost\\sqlexpress;Initial Catalog=sasai;Integrated Security=True";
       

        public AccesoDatos()
        {
     
        }

        public void ConfigurarProcedure(ref SqlCommand comando, string consulta)
        {
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = consulta;


        }

        public SqlConnection ObtenerConexion()
        {
           SqlConnection cn = new SqlConnection(rutaSasai);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SqlDataAdapter ObtenerAdaptador(String consultaSql, SqlConnection cn)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, cn);
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void cargaTabla(String NombreTabla, String Sql, ref DataSet ds)
        {
            
            SqlConnection cn = ObtenerConexion();
            SqlDataAdapter adp = ObtenerAdaptador(Sql, cn);
            adp.Fill(ds, NombreTabla);
        }

        


        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP)
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }


    }
}
