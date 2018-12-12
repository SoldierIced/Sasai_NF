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
    class DatosSP
    {
        public static void Notas_tiponota(ref SqlCommand comando, string tiponota) {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@tiponota", SqlDbType.VarChar, 40);
            SqlParametros.Value = tiponota;
        }
        public static void Notas(ref SqlCommand comando,string codcurso,string codmate,string codeespe,string nota,int legajo,string modalidad,string turno) {
            //@codmateria varchar(40),@codcurso varchar(40),@codespecialidad varchar(40),@notamateria int, @legajo int
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = comando.Parameters.Add("@codmateria", SqlDbType.VarChar,40);
            SqlParametros.Value = codmate;
            SqlParametros = comando.Parameters.Add("@codcurso", SqlDbType.VarChar,40);
            SqlParametros.Value = codcurso;
            SqlParametros = comando.Parameters.Add("@codespecialidad", SqlDbType.VarChar,40);
            SqlParametros.Value = codeespe;
            SqlParametros = comando.Parameters.Add("@notamateria", SqlDbType.VarChar,30);
            SqlParametros.Value = nota;
            SqlParametros = comando.Parameters.Add("@legajo", SqlDbType.Int);
            SqlParametros.Value = legajo;
            SqlParametros = comando.Parameters.Add("@modalidad", SqlDbType.NVarChar,40);
            SqlParametros.Value = modalidad;
            SqlParametros = comando.Parameters.Add("@turno", SqlDbType.NVarChar,40);
            SqlParametros.Value = turno;

        }
        public static void Notasp(ref SqlCommand comando, string codcurso, string codmate, string codeespe, string nota, int legajo)
        {
            //@codmateria varchar(40),@codcurso varchar(40),@codespecialidad varchar(40),@notamateria int, @legajo int
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = comando.Parameters.Add("@codmateria", SqlDbType.VarChar, 40);
            SqlParametros.Value = codmate;
            SqlParametros = comando.Parameters.Add("@codcurso", SqlDbType.VarChar, 40);
            SqlParametros.Value = codcurso;
            SqlParametros = comando.Parameters.Add("@codespecialidad", SqlDbType.VarChar, 40);
            SqlParametros.Value = codeespe;
            SqlParametros = comando.Parameters.Add("@notamateria", SqlDbType.VarChar,30);
            SqlParametros.Value = nota;
            SqlParametros = comando.Parameters.Add("@legajo", SqlDbType.Int);
            SqlParametros.Value = legajo;
            

        }

        public static void Preinscriptos_DNI(ref SqlCommand comando,string DNI) {

            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = comando.Parameters.Add("@DNI", SqlDbType.Int);
            SqlParametros.Value = DNI;

        }
        public static SqlCommand alumnosxmateriasxcursoo(string especialidad,string codcurso,string materia) {
            //@dni int ,@materia varchar(40),@especialidad varchar (40),@codcurso varchar (40)
            SqlCommand comando = new SqlCommand();
            SqlParameter SqlParametros = new SqlParameter();
                       SqlParametros = comando.Parameters.Add("@especialidad", SqlDbType.NVarChar, 40);
            SqlParametros.Value = especialidad;
            SqlParametros = comando.Parameters.Add("@codcurso", SqlDbType.NVarChar, 40);
            SqlParametros.Value = codcurso;
            SqlParametros = comando.Parameters.Add("@materia", SqlDbType.NVarChar, 40);
            SqlParametros.Value = materia;
            return comando;

        }
        public static SqlCommand EspecialidadCarga(string CodE, string NombreE, string Duracion)
        {

            SqlCommand Comando = new SqlCommand();
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@Codespecialidad", SqlDbType.NVarChar, 40);
            SqlParametros.Value = CodE;

            SqlParametros = Comando.Parameters.Add("@nombre", SqlDbType.NVarChar, 100);
            SqlParametros.Value = NombreE;

            SqlParametros = Comando.Parameters.Add("@AniosAprox", SqlDbType.Int);
            SqlParametros.Value = int.Parse(Duracion);



            return Comando;
        }
        public static void EspecialidadNombre(ref SqlCommand Comando, string NombreE)
        {                      
            SqlParameter SqlParametros = new SqlParameter();
             SqlParametros = Comando.Parameters.Add("@nombre", SqlDbType.NVarChar, 100);
            SqlParametros.Value = NombreE;
       
        }

        public static void Legajo(ref SqlCommand Comando, string legajo) {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@legajo", SqlDbType.Int);
            SqlParametros.Value = legajo;
        }

        public static SqlCommand Materias (string CodMateria,string NombreMateria)
        {
        
            SqlCommand Comando = new SqlCommand();
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@ID", SqlDbType.NVarChar, 40);
            SqlParametros.Value = CodMateria;
            SqlParametros = Comando.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
            SqlParametros.Value = NombreMateria;
            //SqlParametros = Comando.Parameters.Add("@Monto", SqlDbType.Money);
            //SqlParametros.Value = int.Parse(monto);
            //,string monto 
            return Comando;
        }

        public static SqlCommand Materias2(string CodMateria, string Monto)
        {

            SqlCommand Comando = new SqlCommand();
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@ID", SqlDbType.NVarChar, 40);
            SqlParametros.Value = CodMateria;
            SqlParametros = Comando.Parameters.Add("@Monto", SqlDbType.Money);

            decimal pu = Convert.ToDecimal(Monto);
            SqlParametros.Value = decimal.ToDouble(pu);


            return Comando;
        }

        public static SqlCommand MateriasValidar(string NombreM)
        {

            SqlCommand Comando = new SqlCommand();
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
            SqlParametros.Value = NombreM;

            return Comando;
        }

        public static SqlCommand MateriasCarga(string CodM, string NombreM, string PrecioM, int par, int rec, int fin)
        {

            SqlCommand Comando = new SqlCommand();
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@ID", SqlDbType.NVarChar, 40);
            SqlParametros.Value = CodM;

            SqlParametros = Comando.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
            SqlParametros.Value = NombreM;
            
            SqlParametros = Comando.Parameters.Add("@Monto", SqlDbType.Money);
            SqlParametros.Value = Convert.ToDecimal(PrecioM);
            SqlParametros = Comando.Parameters.Add("@cantpar", SqlDbType.Int);
            SqlParametros.Value = par;
            SqlParametros = Comando.Parameters.Add("@cantrecu", SqlDbType.Int);
            SqlParametros.Value = rec;
            SqlParametros = Comando.Parameters.Add("@cantfina", SqlDbType.Int);
            SqlParametros.Value = fin;
          

            return Comando;
        }


        public static SqlCommand DetalleMov (string CodMov ,string Usuario ,string Antes,
                                             string Despues, DateTime fecha)
         {
            SqlCommand Comando = new SqlCommand();
             SqlParameter SqlParametros = new SqlParameter();
             SqlParametros = Comando.Parameters.Add ("@CodMov",SqlDbType.Int);
             SqlParametros.Value = CodMov;
             SqlParametros = Comando.Parameters.Add ("@Usuario",SqlDbType.NVarChar, 20);
             SqlParametros.Value = Usuario;
             SqlParametros = Comando.Parameters.Add ("@Antes",SqlDbType.NVarChar, 100);
             SqlParametros.Value = Antes;
             SqlParametros = Comando.Parameters.Add ("@Despues",SqlDbType.NVarChar, 100);
             SqlParametros.Value = Despues;
             SqlParametros = Comando.Parameters.Add ("@fecha",SqlDbType.Date);
             SqlParametros.Value = fecha;
             return Comando;
             
         }
        
        public static SqlCommand MateriasxCurso 
            (string CodMateria  ,string CodCurso  ,string CodEspecialidad )
         {
            SqlCommand Comando = new SqlCommand();
             SqlParameter SqlParametros = new SqlParameter();
             SqlParametros = Comando.Parameters.Add ("@CodMateria",SqlDbType.NVarChar,40);
             SqlParametros.Value = CodMateria;
             SqlParametros = Comando.Parameters.Add ("@CodCurso",SqlDbType.NVarChar,40);
             SqlParametros.Value = CodCurso;
             SqlParametros = Comando.Parameters.Add ("@CodEspecialidad",SqlDbType.NVarChar,40);
             SqlParametros.Value = CodEspecialidad;
                         
             return Comando;
             
         }

        public static SqlCommand Cursos
            (string CodCurso  ,string FechaInicio  ,string FechaFinal, int Nota_Min,int CapacidadMax )
         {
            SqlCommand Comando = new SqlCommand();
             SqlParameter SqlParametros = new SqlParameter();
             SqlParametros = Comando.Parameters.Add ("@CodCurso",SqlDbType.NVarChar,40);
             SqlParametros.Value = CodCurso;
             SqlParametros = Comando.Parameters.Add ("@FechaInicio",SqlDbType.Date);
             SqlParametros.Value = FechaInicio;
             SqlParametros = Comando.Parameters.Add ("@FechaFinal",SqlDbType.Date);
             SqlParametros.Value = FechaFinal;
             SqlParametros = Comando.Parameters.Add ("@Nota_Min",SqlDbType.Date);
             SqlParametros.Value = Nota_Min;
             SqlParametros = Comando.Parameters.Add ("@CapacidadMax",SqlDbType.Date);
             SqlParametros.Value = CapacidadMax;
                         
             return Comando;
             
         }
         
        public static SqlCommand EspecialidadesXCursos
             (string CodCurso  ,string CodEspecialidad  ) 
         {
            SqlCommand Comando = new SqlCommand();
             SqlParameter SqlParametros = new SqlParameter();
             SqlParametros = Comando.Parameters.Add ("@CodCurso",SqlDbType.NVarChar,40);
             SqlParametros.Value = CodCurso;
             SqlParametros = Comando.Parameters.Add ("@CodEspecialidad ",SqlDbType.Date);
             SqlParametros.Value = CodEspecialidad ;
          return Comando;
             
         }

        public static SqlCommand Especialidades
             (string nombre   ,string Codespecialidad,int AniosAprox)
         {
            SqlCommand Comando = new SqlCommand();
             SqlParameter SqlParametros = new SqlParameter();
             SqlParametros = Comando.Parameters.Add ("@Codespecialidad",SqlDbType.NVarChar,40);
             SqlParametros.Value = Codespecialidad ;
             SqlParametros = Comando.Parameters.Add ("@nombre",SqlDbType.NVarChar,40);
             SqlParametros.Value = nombre;
             SqlParametros = Comando.Parameters.Add ("@AniosAprox",SqlDbType.Int);
             SqlParametros.Value = AniosAprox;
          return Comando;
             
         }
        
         public static SqlCommand AlumnosxMateriasxCursos 
             (int DNI,string CodMateria ,string Codcurso,string CodEspecialidad, int NotaMateria )
         {
            SqlCommand Comando = new SqlCommand();
             SqlParameter SqlParametros = new SqlParameter();
          SqlParametros = Comando.Parameters.Add ("@DNI",SqlDbType.Int);
             SqlParametros.Value = DNI ;
             SqlParametros = Comando.Parameters.Add ("@CodMateria",SqlDbType.NVarChar,40);
             SqlParametros.Value = CodMateria ;
             SqlParametros = Comando.Parameters.Add ("@Codcurso",SqlDbType.NVarChar,40);
             SqlParametros.Value = Codcurso  ;
             SqlParametros = Comando.Parameters.Add ("@NotaMateria",SqlDbType.Int);
             SqlParametros.Value = NotaMateria;
          return Comando;
             
         }

        public static SqlCommand Inscriptos 
             (string dniold,int DNI, string Nombre, string Apellido, string UltimoCurso,
             string Email, string Telefono, bool Activo, bool Const_Analitico, bool Const_Cuil,
             bool Fotoc_DNI, bool Foto4x4, bool Const_Trabajo,
              DateTime FechaEntregaDoc, string observaciones,string tipocom, bool consnaci,string especialidad)
            
         {
            SqlCommand Comando = new SqlCommand();
             SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@DNI", SqlDbType.Int);
            SqlParametros.Value = DNI;
            SqlParametros = Comando.Parameters.Add("@DNIold", SqlDbType.Int);
            SqlParametros.Value = dniold;
            SqlParametros = Comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50);
            SqlParametros.Value = Nombre;
            SqlParametros = Comando.Parameters.Add("@Apellido", SqlDbType.NVarChar, 50);
            SqlParametros.Value = Apellido;
            SqlParametros = Comando.Parameters.Add("@UltimoCurso", SqlDbType.NVarChar, 40);
            SqlParametros.Value = UltimoCurso;
            SqlParametros = Comando.Parameters.Add("@Email", SqlDbType.NVarChar, 100);
            SqlParametros.Value = Email;
            SqlParametros = Comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 50);
            SqlParametros.Value = Telefono;
            SqlParametros = Comando.Parameters.Add("@Activo", SqlDbType.Bit);
            SqlParametros.Value = Activo;
            SqlParametros = Comando.Parameters.Add("@Const_Analitico", SqlDbType.Bit);
            SqlParametros.Value = Const_Analitico;
            SqlParametros = Comando.Parameters.Add("@Const_Cuil", SqlDbType.Bit);
            SqlParametros.Value = Const_Cuil;
            SqlParametros = Comando.Parameters.Add("@Fotoc_DNI", SqlDbType.Bit);
            SqlParametros.Value = Fotoc_DNI;
            SqlParametros = Comando.Parameters.Add("@Foto4x4", SqlDbType.Bit);
            SqlParametros.Value = Foto4x4;
            SqlParametros = Comando.Parameters.Add("@Const_Trabajo", SqlDbType.Bit);
            SqlParametros.Value = Const_Trabajo;
            SqlParametros = Comando.Parameters.Add("@FechaEntregaDoc", SqlDbType.Date);
            SqlParametros.Value = FechaEntregaDoc;
            SqlParametros = Comando.Parameters.Add("@observaciones", SqlDbType.NVarChar, 50);
            SqlParametros.Value = observaciones;
            SqlParametros = Comando.Parameters.Add("@tipoconst", SqlDbType.NVarChar, 70);
            SqlParametros.Value = tipocom;
            SqlParametros = Comando.Parameters.Add("@constnaci", SqlDbType.Bit);
            SqlParametros.Value = consnaci;
            SqlParametros = Comando.Parameters.Add("@especialidad", SqlDbType.NVarChar,40);
            SqlParametros.Value = especialidad;

            return Comando;
             
         }
        
         public static SqlCommand Interesados 
             (string Email,string Nombre,string Apellido, string FechaConsulta,string observacion)
         {
         SqlCommand Comando = new SqlCommand();
             SqlParameter SqlParametros = new SqlParameter();
          SqlParametros = Comando.Parameters.Add ("@Email",SqlDbType.NVarChar, 100);
             SqlParametros.Value = Email ;
          SqlParametros = Comando.Parameters.Add ("@Nombre",SqlDbType.NVarChar, 50);
             SqlParametros.Value = Nombre ;
             SqlParametros = Comando.Parameters.Add ("@Apellido",SqlDbType.NVarChar, 50);
             SqlParametros.Value = Apellido;
             SqlParametros = Comando.Parameters.Add ("@FechaConsulta",SqlDbType.NVarChar,50);
             SqlParametros.Value = FechaConsulta;
            SqlParametros = Comando.Parameters.Add("@observacion", SqlDbType.NVarChar, 300);
            SqlParametros.Value = observacion;

            return Comando;
         }
        
        public static SqlCommand Preinscriptos 
             (int DNI,string codcurso,string IDinscripto,string Nombre,string Apellido,
              string Email,string Telefono,string Turno,string Modalidad,string especialidad)
         {
          SqlCommand Comando = new SqlCommand();
             SqlParameter SqlParametros = new SqlParameter();
          SqlParametros = Comando.Parameters.Add ("@DNI",SqlDbType.Int);
             SqlParametros.Value = DNI;
          SqlParametros = Comando.Parameters.Add ("@codcurso",SqlDbType.NVarChar, 40);
             SqlParametros.Value = codcurso;
             SqlParametros = Comando.Parameters.Add ("@Idinscripto",SqlDbType.Int);
             SqlParametros.Value = IDinscripto;
             SqlParametros = Comando.Parameters.Add ("@Nombre",SqlDbType.NVarChar, 50);
             SqlParametros.Value = Nombre;
             SqlParametros = Comando.Parameters.Add ("@Apellido",SqlDbType.NVarChar, 50);
             SqlParametros.Value = Apellido;
             SqlParametros = Comando.Parameters.Add ("@Email",SqlDbType.NVarChar, 100);
             SqlParametros.Value = Email;
             SqlParametros = Comando.Parameters.Add ("@Telefono",SqlDbType.NVarChar, 30);
             SqlParametros.Value = Telefono;
                         SqlParametros = Comando.Parameters.Add ("@Turno",SqlDbType.NVarChar, 60);
             SqlParametros.Value = Turno;
             SqlParametros = Comando.Parameters.Add ("@Modalidad", SqlDbType.NVarChar, 60);
             SqlParametros.Value = Modalidad;
            SqlParametros = Comando.Parameters.Add("@usuarioactivo", SqlDbType.NVarChar, 20);
            SqlParametros.Value = Formularios.Usuario;
            SqlParametros = Comando.Parameters.Add("@especialidad", SqlDbType.NVarChar, 20);
            SqlParametros.Value = especialidad;

            return Comando;
             
         }
        
    }

    class Usuario_class
    {
        public static SqlCommand Usuarios_completo(string usuario, string contrasena, int val = 1)
        {

            SqlCommand Comando = new SqlCommand();
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@user", SqlDbType.NVarChar, 20);
            SqlParametros.Value = usuario;
            SqlParametros = Comando.Parameters.Add("@contra", SqlDbType.NVarChar, 20);
            SqlParametros.Value = contrasena;
            SqlParametros = Comando.Parameters.Add("@acceso", SqlDbType.Int);
            SqlParametros.Value = val;


            return Comando;
        }

        public static void Usuario_user (ref SqlCommand Comando,string user)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@user", SqlDbType.NVarChar, 20);
            SqlParametros.Value = user;
            
        }
        public static void Usuario_baja(ref SqlCommand Comando, int baja)
        {
            
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@baja", SqlDbType.Bit);
            SqlParametros.Value = baja;

        }
        public static void Usuario_Contrasena (ref SqlCommand Comando, string contra)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@contra", SqlDbType.NVarChar, 20);
            SqlParametros.Value = contra;

        }

        public static int ActualizarUser(string usuario, string contrasena, int val ,int baja)
        {
            SqlCommand comando = new SqlCommand();
            AccesoDatos aq = new AccesoDatos();
          comando=  Usuario_class.Usuarios_completo(usuario, contrasena, val);
            Usuario_class.Usuario_baja(ref comando, baja);
            aq.ConfigurarProcedure(ref comando, "ActualizarUsuario");
            comando.Connection = aq.ObtenerConexion();

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                if (int.Parse(reader[0].ToString()) == 1)
                {
                    return 1;
                }

            }

            return -1;
        }

        public static int UsuarioenUso(string nombreuser)
        {
            SqlCommand comando = new SqlCommand();
            AccesoDatos aq = new AccesoDatos();
            Usuario_class.Usuario_user(ref comando, nombreuser);

            aq.ConfigurarProcedure(ref comando, "UsuarioEnuso");
            comando.Connection = aq.ObtenerConexion();

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                if (int.Parse(reader[0].ToString()) == 1)
                {
                    return 1;
                }

            }
            return -1;
        }
        public static int VerificarUsuarioActivo(string nombreuser, string contrasena)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                AccesoDatos aq = new AccesoDatos();
                Usuario_user(ref comando, nombreuser);
                Usuario_Contrasena(ref comando, contrasena);


                aq.ConfigurarProcedure(ref comando, "VerificarUsuarioActivo");
                comando.Connection = aq.ObtenerConexion();

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {


                    //  MessageBox.Show( reader[0].ToString());

                    return (int.Parse(reader[0].ToString()));

                }
                return -100;
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -100;
            }
        }
       
        public static int VerificarAlluser(string nombreuser,string contrasena)
        {
            try { 
            SqlCommand comando = new SqlCommand();
            AccesoDatos aq = new AccesoDatos();
            comando = Usuario_class.Usuarios_completo(nombreuser,contrasena,1);

            aq.ConfigurarProcedure(ref comando, "userall");
            comando.Connection = aq.ObtenerConexion();

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                if (int.Parse(reader[0].ToString()) != 0)
                {
                    return int.Parse(reader[0].ToString());
                }

            }
                return -1;

            }
            catch (Exception ex) {
                
                return -1;
            }
        }

        public static int CrearUsuario (ref SqlCommand comando, string procedure, string nombreuser,string contra,int acceso =1)
        {
            AccesoDatos aq = new AccesoDatos();

           comando= Usuario_class.Usuarios_completo(nombreuser, contra, acceso);

            aq.ConfigurarProcedure(ref comando, procedure);
            comando.Connection = aq.ObtenerConexion();

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                if (int.Parse(reader[0].ToString()) == 1)
                {
                    return 1;
                }

            }
            return -1;

        }


    }
}