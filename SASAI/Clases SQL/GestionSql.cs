using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace SASAI
{
    class GestionSql
        {
        public GestionSql()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }



       

  
   


        public bool ActualizarEnBD(String NombreTabla, DataSet ds,string procedure_sql)
        {
            int FilasActualizadas = 0;
            foreach (DataRow fila in ds.Tables[NombreTabla].Rows)
            {
                SqlCommand Comando = new SqlCommand();
               // ArmarParametrosUsuarios(ref Comando, fila); seria DatosSP.alumnos
                AccesoDatos ad = new AccesoDatos();

                FilasActualizadas = ad.EjecutarProcedimientoAlmacenado(Comando,procedure_sql);
            }
            if (FilasActualizadas >= 1)
                return true;
            else
                return false;
        }

        

     /*   public static void Usuario_SP(string usuario, string contrasena,string sp)
        {
           
            AccesoDatos aq = new AccesoDatos();
            SqlCommand Comando = DatosSP.Usuarios(usuario, contrasena);
            aq.EjecutarProcedimientoAlmacenado(Comando, sp);


        }

    */
        
        public Boolean InsertarProductosEnBD(String NombreTabla, DataSet ds)
        {
            int FilasInsertadas = 0;
            foreach (DataRow fila in ds.Tables[NombreTabla].Rows)
            {
                SqlCommand Comando = new SqlCommand();
             //   ArmarParametrosUsuarios(ref Comando, fila);
                AccesoDatos ad = new AccesoDatos();
                FilasInsertadas = ad.EjecutarProcedimientoAlmacenado(Comando, "spInsertarProducto");
            }
            if (FilasInsertadas >= 1)
                return true;
            else
                return false;
        }

    }
}
