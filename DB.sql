use master
drop database sasai
go

create database SASAI
go

use SASAI
create table Logen (numerito int default 0 not null)
--go
create table Usuarios (
usuario varchar(20) not null,
contrasena nvarchar(20) not null,
acceso int not null,
baja bit not null default 0,
constraint pk_claveUsuarios Primary Key (usuario)
)
create table Materias (
CodMateria varchar(40)  not null,
NombreMateria varchar(100)  not null,
Monto money not null,
CantPar int not null,
CantRec int not null,
CantFin int not null,
constraint pk_claveMaterias Primary Key (CodMateria)

)
create table MateriasxCurso (
CodMateria varchar(40)  not null,
CodCurso varchar(40)  not null,
CodEspecialidad varchar(40) not null,
constraint pk_claveMateriasxcurso Primary Key (CodMateria,CodCurso,codespecialidad)

)
create table Cursos(
CodCurso varchar(40)  not null,
FechaInicio date,
FechaFinal date,
NombreCurso varchar(70),
Nota_Min int not null,
CapacidadMax int ,
actual int default 0 ,
constraint pk_Cursos Primary Key (codcurso)

)
create table EspecialidadesXCursos (

CodCurso varchar(40) not null,
CodEspecialidad varchar(40) not null,
constraint pk_EspecialidadesXCurso Primary Key(codcurso,CodEspecialidad)

)
create table Especialidades (
Codespecialidad varchar(40) not null,
nombre varchar(100) not  null,
AniosAprox int not null,

constraint pk_Especialidades Primary Key(codEspecialidad) 
)
create table AlumnosxMateriasxCursos (
legajo int  not null,
CodMateria varchar(40)  not null,
Codcurso varchar(40)  not null,
CodEspecialidad varchar(40),
NotaMateria varchar(30) not null,
usuario varchar(20) not null,
idInscripto int  not null,
MontoaPagar money not null,
modalidad varchar(40) not null,
turno varchar (40) not null,
fecha date not null,
constraint pk_claveMatAproAlum Primary Key (legajo,Codmateria,codcurso)
)
create table Inscriptos (
legajo int identity(1,1) not null,
DNI int  not null,
Nombre varchar(50)  not null,
Apellido varchar(50)  not null,
UltimoCurso varchar(40)not null,
Email varchar(100)  not null,
Telefono varchar(50)  not null,
Activo bit not null default 1,

TipoConst varchar (70) not null,
Const_Analitico Bit not null default 0,
Const_Cuil  Bit not null default 0,
Fotoc_DNI  Bit not null default 0,
Foto4x4  Bit not null default 0,
Const_Trabajo  Bit not null default 0,
constNaci bit not null default 0,
FechaEntregaDoc date not null,
observaciones text, 
especialidad varchar(40) not null,
constraint pk_claveInscriptos Primary Key (legajo)
)
create table Interesados (
Email varchar(100)  not null,
Nombre varchar(50)  not null,
Apellido varchar(50)  not null,
FechaConsulta varchar(50) not null,
observacion varchar(300),
constraint pk_claveInteresados Primary Key (Email))


create table Preinscriptos (
DNI int  not null,
codcurso varchar(40) not null default '0' ,
IDinscripto int not null default '0',
Nombre varchar(50)  not null,
Apellido varchar(50)  not null ,
Email varchar(100)  not null default '',
Telefono varchar(30)  not null default '0',
Turno varchar(60) not null default'Mañana',
Modalidad varchar(60) not null ,
Usuario varchar(20) not null,
baja bit default 0,
especialidad varchar(40) not null,

constraint pk_clavePreinscriptos Primary Key (DNI,codcurso)

)
create table ControlAlumxMatexCurso (
  TipoTrn char(1), 
  Tabla varchar(128), 
  PK varchar(1000), 
  Campo varchar(128), 
  ValorOriginal varchar(1000), 
  ValorNuevo varchar(1000), 
  FechaTrn datetime, Usuario varchar(128)
  )
CREATE TABLE ControlPreinscriptos (
  TipoTrn char(1), 
  Tabla varchar(128), 
  PK varchar(1000), 
  Campo varchar(128), 
  ValorOriginal varchar(1000), 
  ValorNuevo varchar(1000), 
  FechaTrn datetime, Usuario varchar(128))
  
create table NotasxMateriaXalumnoxCurso(
legajo int  not null,
CodMateria varchar(40)  not null,
Codcurso varchar(40)  not null,
codespecialidad varchar(40)  not null,
notaparcial int not null default 0,
tipoNota varchar(40) not null,
constraint pk_notasxalumnos Primary Key (legajo,Codmateria,codcurso,notaparcial,tiponota)
)

go
-----------------conecciones de tablas-------------------------------------------------------------------------------------
use SASAI
 --------- tabla especialidad x cursos-------------------------------------------------------------------------------------
alter table EspecialidadesxCursos add constraint Fk_EspecialidadesxCursoxEsp
foreign key (Codespecialidad) references Especialidades (codespecialidad)
alter table EspecialidadesxCursos add constraint Fk_EspecialidadesxCursoxCurso
foreign key (codCurso) references Cursos (Codcurso)
------- tabla materias  x curso--------------------------------------------------------------------------------------------
alter table Materiasxcurso add constraint Fk_MateriasxCursoxMaterias
foreign key (CodMateria) references Materias(Codmateria)
alter table Materiasxcurso add constraint Fk_MateriasxCursoxEspeXCursos
 foreign key (codcurso,codespecialidad) references EspecialidadesxCursos (codcurso,codespecialidad)  
------- tabla alumnos por materia x curso----------------------------------------------------------------------------------
alter table AlumnosxMateriasxCursos add constraint Fk_AlumnosxMateriasxCursosxMate
foreign key (CodMateria,CodCurso,Codespecialidad) 
references MateriasxCurso(CodMateria,CodCurso,CodEspecialidad)
alter table alumnosxMateriasxCursos add constraint Fk_AlumnosxMateriasxCursosxIscriptos
foreign key (legajo) references Inscriptos (legajo)
----------- tabla notas----------------------------------------------------------------------------------------------
go
alter table notasxMateriaxAlumnoxCurso add constraint fk_notas1 foreign key (legajo,Codmateria,codcurso) 
references AlumnosxMateriasxCursos (legajo,Codmateria,codcurso)
go
-----------------------carga valores tabla---------------------------------------------------------------------------------

insert into usuarios (usuario,contrasena,acceso,baja)
select 'admin','',6,1 union
select 'nehuen','123',10,0 union 
select 'pedron','123',9,1 union
select 'leandro','123',8,0 union
select 'mariano','123',5,0 union
select 'batman','123',7,0 union
select 'robin','123',6,1 

go

select * from EspecialidadesXCursos
go

--insert into Especialidades(Codespecialidad,nombre,AniosAprox)
--select '001','Tecnicatura Superior en Programacion',2 union
--select '002','Tecnicatura Superior en Sistemas Informaticos',1 union
--select '003','Ingenieria Mecanica',5 union
--select '004','Ingenieria Electrica',5 union
--select '005','Ingenieria Civil',5
--go

--insert into Materias(CodMateria,NombreMateria,Monto)
--select '001','Matematica',800 union
--select '002','Introduccion a la Programacion',800 union
--select '003','Introduccion a la Informatica',600
--go

--insert into Cursos(CodCurso,FechaInicio,FechaFinal,Nota_Min,CapacidadMax,actual)
--select '001','10/04/2018','09/06/2018',6,100,0 union
--select '002','10/06/2018','09/08/2018',6,100,1 union
--select '003','10/08/2018','10/10/2018',6,100,0 
--go

--insert into EspecialidadesXCursos(CodCurso,CodEspecialidad)
--select '001','001' union
--select '002','001' union
--select '003','001' union
--select '002','002' 
--go


insert into Interesados select '','','','',GETDATE()
go


--delete Interesados
--insert into Inscriptos(DNI,Nombre,Apellido,UltimoCurso,Email,Telefono,Activo,Const_Analitico,Const_Cuil,Fotoc_DNI,Foto4x4,Const_Trabajo,FechaEntregaDoc,TipoConst)
--select 40459112, 'leandro', 'arroyo', '002', 'martin_arroyo@hotmail.es', 1161595480, 1, 1, 1, 1, 1,1, '15/07/2018','Cursando Ultimo Año' union
--select 40459113, 'mariano', 'perez', '002', 'martin_arroyo97@hotmail.com', 1161595481, 1, 1, 1, 1, 1,1, '15/07/2018','AFK' union
--select 40459114, 'nehuen', 'fortes', '002', 'calladitobienslow@gmail.com', 1161595482, 1, 1, 1, 1, 1,1, '15/07/2018','CDC'
--go
---------------------------- procedure------------------------------------------------------------------------------------
create procedure VerificarPreinscripto (
@DNI int)
as
declare @aux int =0
set @aux=(select COUNT(DNI) from Preinscriptos where DNI=@DNI)
select @aux

go
create procedure MateriaModificacion
(@ID varchar(40), @Name varchar(100), @Monto money,@cantpar int , @cantrecu int , @cantfina int)

as
update Materias
set 
NombreMateria = @Name, Monto = @Monto, cantPar = @cantpar, cantrec=@cantrecu,cantfin = @cantfina

where CodMateria = @ID 
return 
go

----------------------------------------------------------------------------------------------------------------

----------------------------------------------------------------------------------------------------------------

go
create procedure VerificarUsuario 
@user varchar(20), @contra varchar(20), @acceso int
as
select count(acceso)
from Usuarios
where usuario=@user and contrasena = @contra
go
--------------------------------------------------------------------------------------------
create procedure ActualizarUsuario
(@user varchar(20), @contra varchar(20),@acceso int,@baja int )
as
update Usuarios 
set 
contrasena =@contra,
acceso =@acceso,
baja = @baja
where usuario =@user
return 
go
--------------------------------------------------------------------------------------------
create procedure UsuarioCambioContra
(@user varchar(20), @contra varchar(20),@acceso int )

as
update Usuarios 
set 
contrasena =@contra
where usuario =@user
return 
go
---------------------------------------------------------------------------
create procedure UsuarioEnuso
@user varchar(20)
as
select COUNT (usuario)
from Usuarios
where usuario=@user
go

--------------------------------------------------------------------------------------------
create procedure userall
(@user varchar(20), @contra varchar(20), @acceso int)
as
select acceso
from Usuarios
where usuario=@user and contrasena=@contra


--------------------------------------------------------------------------------------------
go
create procedure CrearUsuario
@user varchar(20), @contra nvarchar(20) , @acceso int
as
insert into Usuarios(usuario,contrasena,acceso)
select @user,@contra, @acceso 

select count (usuario)
from usuarios
where usuario =@user
--------------------------------------------------------------------------------------------
go
create procedure EliminarInscripto (
@DNI int 
)
AS
    DELETE FROM Inscriptos
    WHERE DNI=@DNI
    RETURN

go
--------------------------------------------------------------------------------------------
go
create procedure VerificarUsuarioActivo (
@user varchar(20), @contra nvarchar(20)
)
AS
declare @ar int
set @ar = 4 

if ((select COUNT(usuario)from Usuarios where usuario= @user)>0) begin
		if((select COUNT(usuario)from Usuarios where usuario= @user and baja=0)>0)
					begin		
					if((select COUNT(usuario)from Usuarios where usuario= @user and contrasena=@contra)>0) begin set @ar=1 end
					else begin set @ar=-2 end
					end
		else begin set @ar=-3 end

end
else begin set @ar=-1 end

select @ar
-- muestra -3 = USUARIO DADO DE BAJA
-- muestra -2 = CONTRASENA MAL
-- muestra -1 = USUARIO NO EXISTE
-- muestra	1 = USUARIO Y CONTRASENA Y NO DADO DE BAJA PERFECTO.
  go
  
--------------------------------------------------------------------------------------------
--drop procedure VerificarMateria
--go
create procedure VerificarMateria (
@Name varchar(100) 
)
AS
declare @ar int
set @ar = 4 

if ((select COUNT(NombreMateria)from Materias where NombreMateria = @Name)>0) 
begin set @ar=1
end
else begin set @ar=-1 end

select @ar
  go  
  -- muestra -1 = NOMBRE MATERIA NO EXISTE
  -- muestra 1 = CASO CONTRARIO 

--------------------------------------------------------------------------------------------
--drop procedure CrearMateria
--go

create procedure VerificarMateriaPosta
  ( @legajo int ,@codmateria varchar (40) , @idinscripto int,@codcurso varchar(40),@modalidad varchar(40),@turno varchar(40),@user varchar(40),@fechita date )
as
declare @cantcur int
set @cantcur= (select COUNT(codcurso) from Cursos)
declare @nota int declare @fecha date declare @fecha2 date declare @fechadecu date
set @nota=0 declare @notac int
declare @aux varchar(30)
while (@cantcur>0) begin 
set @aux='Aprobada en:'
set @aux=(select @aux + CAST( @cantcur as varchar(4)))
set @nota= (select NotaMateria from AlumnosxMateriasxCursos where CodMateria=@codmateria and Codcurso=@cantcur and legajo=@legajo) --localizamos la nota que se saco en dicho curso.
set @notac=(select Nota_Min from Cursos where CodCurso=@cantcur )
set @fecha= (select fecha from AlumnosxMateriasxCursos where CodMateria=@codmateria and Codcurso=@cantcur and legajo=@legajo)--localizamos la fecha de cuando tuvo esa  nota.
set @fecha2=@fecha
set @fecha2= DATEADD (YEAR,1,@fecha)
if (@fecha2>@fechita) begin -- si es mayor es porque no se vencio la materia
 --preguntar si la nota esta aprobada o no.
	if(@nota>=@notac) begin -- si es true es porque la tiene aprobada y no vencida
 insert into AlumnosxMateriasxCursos  select @legajo,@codmateria,@codcurso,'001',@nota,'Sistema.Trasf.Notas',@idinscripto,0,
 @aux,'--' ,@fecha
 set @cantcur=-9
 select 1
  end
  -- si la nota no esta aprobada no nos interesa.
	 end
set @cantcur=@cantcur-1
end
if (@cantcur=0) begin 
insert into AlumnosxMateriasxCursos  select @legajo,@codmateria,@codcurso,'001',0,@user,@idinscripto,0,@modalidad,@turno,@fechita
      end 
go


create procedure CrearMateria(
@ID varchar(40), @Name varchar(100), @Monto money,@cantpar int , @cantrecu int , @cantfina int )

as
insert into Materias(CodMateria,NombreMateria,Monto,Cantpar,cantrec,cantfin)
select @ID,@Name,@Monto,@cantpar,@cantrecu,@cantfina

go
--------------------------------------------------------------------------------------------
create procedure CargaPreinscripto (
 @DNI int,@codcurso varchar(40),@IDinscripto int,@Nombre varchar(50),@Apellido varchar(50),
              @Email varchar(100),@Telefono varchar(30),@Turno varchar(60),@Modalidad varchar(60),
              @usuarioactivo varchar(20),@especialidad varchar(40))
as


insert into Preinscriptos (DNI,codcurso,IDinscripto,Nombre,Apellido,Email,Telefono,Turno,Modalidad,Usuario,especialidad)
select @DNI,@codcurso,@IDinscripto,@Nombre,@Apellido,@Email,@Telefono,@Turno,@Modalidad, @usuarioactivo,@especialidad

go
--------------------------------------------------------------------------------------------
go

create procedure CargaInscripto (
@dniold int,@DNI int, @Nombre varchar(50), @Apellido varchar(50),@UltimoCurso varchar(40),@Email varchar(100),
@Telefono varchar(50), @activo bit, @Const_Analitico bit, @Const_Cuil bit, @Fotoc_DNI bit,
 @Foto4x4 bit, @Const_Trabajo bit, @FechaEntregaDoc date, @observaciones text,@tipoconst varchar(70),
 @constnaci bit, @especialidad varchar(40))
as
insert into Inscriptos (DNI,Nombre,Apellido,UltimoCurso,Email,Telefono,Activo,Const_Analitico,Const_Cuil,Fotoc_DNI,Foto4x4,
Const_Trabajo,FechaEntregaDoc,observaciones,TipoConst,constNaci,especialidad)
select @DNI , @Nombre , @Apellido ,@UltimoCurso ,@Email , @Telefono, @activo,
 @Const_Analitico , @Const_Cuil , @Fotoc_DNI , @Foto4x4 , @Const_Trabajo , @FechaEntregaDoc, @observaciones,@tipoconst,@constnaci,@especialidad
go

go
create procedure ModificarInscripto (
@dniold int,@dni int , @Nombre varchar(50), @Apellido varchar(50),@UltimoCurso varchar(40),@Email varchar(100), @Telefono varchar(50), @activo bit,
 @Const_Analitico bit, @Const_Cuil bit, @Fotoc_DNI bit, @Foto4x4 bit, @Const_Trabajo bit, @FechaEntregaDoc date, @observaciones text,@tipoconst varchar (70),@constnaci bit,@especialidad varchar(40))

as
 
update Inscriptos 
set
DNI =@dni,
Nombre =@Nombre,
Apellido =@Apellido,
UltimoCurso =@UltimoCurso,
Email=@Email,
Telefono =@Telefono,
TipoConst =@tipoconst,
Const_Analitico=@Const_Analitico,
Const_Cuil=@Const_Cuil,
Fotoc_DNI  =Fotoc_DNI,
Foto4x4  =@Foto4x4,
Const_Trabajo=@Const_Trabajo,
constNaci =@constnaci,
FechaEntregaDoc =@FechaEntregaDoc,
observaciones =@observaciones,
especialidad =@especialidad
where dni=@dniold
 
go


go

create procedure verificarExistenciaInscripto (
@DNI int
)

as
declare @int int 
set @int=0
set @int = (select COUNT(DNI) from Inscriptos where DNI=@DNI)
if (@int<>0) begin select * from Inscriptos where DNI=@DNI end 
else 
begin select * from Preinscriptos where DNI=@DNI end


go


create procedure ExistenciaCurso 
as


if ((select Count(CodCurso) from Cursos where actual=1)=1) begin
select codcurso from Cursos where actual=1
 end
 else begin select -1 end
 
 go
 create procedure CrearEspecialidad
@Codespecialidad varchar(40),@nombre varchar(100),@AniosAprox int
as
insert into Especialidades select @Codespecialidad,@nombre,@AniosAprox
go

 create procedure ModificarEspecialidad
@Codespecialidad varchar(40),@nombre varchar(100),@AniosAprox int
as
update Especialidades set AniosAprox =@AniosAprox ,nombre=@nombre
where Codespecialidad= @Codespecialidad
go

create procedure EncontrarEspecialidad
(@Nombre varchar(100))
as
select Codespecialidad from especialidades where nombre= @Nombre

go
create procedure VerificarxMateriaAlumno (
@legajo int ,@materia varchar(40),@especialidad varchar (40),@codcurso varchar (40)
)
as

if ((select COUNT(NotaMateria) from AlumnosxMateriasxCursos where CodMateria=@materia and Codcurso=@codcurso and CodEspecialidad=@especialidad and legajo=@legajo)>0)
begin 
select CodMateria,Codcurso,NotaMateria from AlumnosxMateriasxCursos where CodMateria=@materia and Codcurso=@codcurso and CodEspecialidad=@especialidad and legajo=@legajo
end
else 
begin select -1 end
go
create procedure UpdateNotas 
@codmateria varchar(40),@codcurso varchar(40),@codespecialidad varchar(40),@notamateria varchar(30), @legajo int,@modalidad varchar(40),@turno nvarchar(40)
as
update AlumnosxMateriasxCursos set NotaMateria=@notamateria,
  turno=@turno, modalidad=@modalidad
  where Codcurso=@codcurso and CodMateria=@codmateria and CodEspecialidad=@codespecialidad and legajo=@legajo
go
 
create procedure Materiavencida
(@nota int ,@codcuro varchar (40),@especialidad varchar (40))
as
declare @fecha date, @notamin int

set @fecha = (select FechaFinal from Cursos inner join EspecialidadesXCursos on Cursos.CodCurso=EspecialidadesXCursos.CodCurso where actual=1 )
set @fecha=(select dateadd(year,1,@fecha))



set @notamin= (select Nota_Min from Cursos inner join EspecialidadesXCursos on Cursos.CodCurso=EspecialidadesXCursos.CodCurso where actual=1)

if ( @fecha > GETDATE()) begin if (@nota> @notamin or @nota = @notamin)
 begin select 1 end 
--en caso de que si este aprobada y no vencida devuelve la nota.
else begin  select -1 end

end

else begin select -1 end
-- devuelve -1 porque la materia esta vencida o no esta aprobada.
go
create procedure UpdateNotas2 
@codmateria varchar(40),@codcurso varchar(40),@codespecialidad varchar(40),@notamateria varchar(30), @legajo int
as
update AlumnosxMateriasxCursos set NotaMateria=@notamateria
  where Codcurso=@codcurso and CodMateria=@codmateria and CodEspecialidad=@codespecialidad and legajo=@legajo
go

create procedure updatenotaparciales
@codmateria varchar(40),@codcurso varchar(40),@codespecialidad varchar(40),@notamateria int, @legajo int,@tiponota varchar(40)
as
if (select count (legajo) from NotasxMateriaXalumnoxCurso where CodMateria=@codmateria and Codcurso=@codcurso
 and codespecialidad=@codespecialidad and tipoNota=@tiponota and legajo=@legajo)>0
 begin update NotasxMateriaXalumnoxCurso set notaparcial=@notamateria where CodMateria=@codmateria and Codcurso=@codcurso
 and codespecialidad=@codespecialidad and tipoNota=@tiponota and legajo=@legajo  end
 else begin insert into NotasxMateriaXalumnoxCurso select @legajo,@codmateria,@codcurso,@codespecialidad,@notamateria,@tiponota end

go
 --------------------------------------------trigger-----------------------------------------
go
create trigger  controlFechas
on logen
after insert
as
begin 
set nocount on;
declare @aux int
declare @dnifake int
set @aux= (select count(DNI) from inscriptos)
set @dnifake=0
while(@aux>0)begin 
set @dnifake= (select top 1 DNI from inscriptos where  TipoConst <> 'Comprobante de Titulo legalizado.' and TipoConst <> 'No trajo comprobante.' and TipoConst <>'vencido.'
and DATEADD (MONTH,1,FechaentregaDoc)< getdate())
--select @dnifake as 'DNI De persona que va recorriendo el while'
--if (@dnifake<>0 and @dnifake<>null) begin 
update inscriptos 
set TipoConst='vencido.',const_Analitico=0
where DNI=@dnifake
--select @dnifake as 'dni fake dentro del if .'
 --end
-- select @aux as 'auxiliar.'
 set @aux=@aux-1
end
end
go


create TRIGGER dbo.trIUDUPreinscripciones ON preinscriptos FOR INSERT, UPDATE, DELETE
AS 

DECLARE @bit int ,	
        @field int ,	
        @maxfield int ,	
        @char int ,	
        @fieldname varchar(128) ,	
        @TableName varchar(128) ,	
        @PKCols varchar(1000) ,	
        @sql varchar(2000), 	
        @UpdateDate varchar(21) ,	
        @UserName varchar(128) ,	
        @Type char(1) ,	
        @PKSELECT varchar(1000)
	
SELECT @TableName = 'Preinscriptos' --<-- cambiar el nombre de la tabla 

-- Fecha y Usuario
SELECT @UserName =  (select Usuario from inserted) ,
       @UpdateDate = convert(varchar(8), getdate(), 112) + 
                     ' ' + 
                     convert(varchar(12), getdate(), 114)

SET NoCount ON 

-- Identificar que evento se está ejecutando (Insert, Update o Delete) 
--en base a cursores especiales (inserted y deleted)
if exists (SELECT * FROM inserted) 
  if exists (SELECT * FROM deleted) --Si es un update
    SELECT @Type = 'U'
  else                              --Si es un insert
    SELECT @Type = 'I'
else                                --si es un delete
    SELECT @Type = 'D'
	
-- Obtenemos la lista de columnas de los cursores
SELECT * INTO #ins FROM inserted
SELECT * INTO #del FROM deleted
	
-- Obtener las columnas de llave primaria
SELECT @PKCols = coalesce(@PKCols + ' and', ' on') + 
       ' i.' + 
       c.COLUMN_NAME + ' = d.' + 
       c.COLUMN_NAME
 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk
  JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE c
  ON c.TABLE_NAME = pk.TABLE_NAME
  AND c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
 WHERE pk.TABLE_NAME = @TableName AND 
  pk.CONSTRAINT_TYPE = 'PRIMARY KEY'
	
-- Obtener la llave primaria y columnas para la inserción en la tabla de auditoria
SELECT 
 @PKSELECT = coalesce(@PKSelect+'+','') + 
 '''<' + 
 COLUMN_NAME + 
 '=''+convert(varchar(100),coalesce(i.' + 
 COLUMN_NAME +',d.' + 
 COLUMN_NAME + '))+''>''' 
 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk  
 JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE c
  ON c.TABLE_NAME = pk.TABLE_NAME
  AND c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
 WHERE pk.TABLE_NAME = @TableName
  AND CONSTRAINT_TYPE = 'PRIMARY KEY'
	
if @PKCols is null --<-- Este trigger solo funciona si la tabla tiene llave primaria
 BEGIN
  RAISERROR('no PK on table %s', 16, -1, @TableName)
  RETURN
 END
	
--Loop para armar el query de inserción en la tabla de log. 
--Un registro por cada campo afectado.
SELECT 
 @field = 0, 
 @maxfield = max(ORDINAL_POSITION) 
 FROM INFORMATION_SCHEMA.COLUMNS 
 WHERE TABLE_NAME = @TableName
	
while @field < @maxfield
 BEGIN
  SELECT @field = min(ORDINAL_POSITION) 
   FROM INFORMATION_SCHEMA.COLUMNS 
   WHERE TABLE_NAME = @TableName and ORDINAL_POSITION > @field
  SELECT @bit = (@field - 1 )% 8 + 1
  SELECT @bit = power(2,@bit - 1)
  SELECT @char = ((@field - 1) / 8) + 1
  if substring(COLUMNS_UPDATED(),@char, 1) & @bit > 0 or @Type in ('I','D')
   BEGIN
     SELECT @fieldname = COLUMN_NAME 
      FROM INFORMATION_SCHEMA.COLUMNS 
	  WHERE TABLE_NAME = @TableName and ORDINAL_POSITION = @field
     SELECT @sql = 'insert ControlPreinscriptos (TipoTrn, Tabla, PK, Campo, ValorOriginal, ValorNuevo, FechaTrn, Usuario)'
     SELECT @sql = @sql + 	' SELECT ''' + @Type + ''''
     SELECT @sql = @sql + 	',''' + @TableName + ''''
     SELECT @sql = @sql + 	',' + @PKSelect
     SELECT @sql = @sql + 	',''' + @fieldname + ''''
     SELECT @sql = @sql + 	',convert(varchar(1000),d.' + @fieldname + ')'
     SELECT @sql = @sql + 	',convert(varchar(1000),i.' + @fieldname + ')'
     SELECT @sql = @sql + 	',''' + @UpdateDate + ''''
     SELECT @sql = @sql + 	',''' + @UserName + ''''
     SELECT @sql = @sql + 	' from #ins i full outer join #del d'
     SELECT @sql = @sql + 	@PKCols
     SELECT @sql = @sql + 	' where i.' + @fieldname + ' <> d.' + @fieldname 
     SELECT @sql = @sql + 	' or (i.' + @fieldname + ' is null and  d.' + @fieldname + ' is not null)' 
     SELECT @sql = @sql + 	' or (i.' + @fieldname + ' is not null and  d.' + @fieldname + ' is null)' 
     exec (@sql)
   END
 END
	 
SET NoCount OFF 
GO
create TRIGGER dbo.trIUDUAlumnxMatexCursos ON AlumnosxMateriasxCursos FOR INSERT, UPDATE, DELETE
AS 

DECLARE @bit int ,	
        @field int ,	
        @maxfield int ,	
        @char int ,	
        @fieldname varchar(128) ,	
        @TableName varchar(128) ,	
        @PKCols varchar(1000) ,	
        @sql varchar(2000), 	
        @UpdateDate varchar(21) ,	
        @UserName varchar(128) ,	
        @Type char(1) ,	
        @PKSELECT varchar(1000)
	
SELECT @TableName = 'AlumnosxMateriasxCursos' --<-- cambiar el nombre de la tabla 

-- Fecha y Usuario
SELECT @UserName = (select Usuario from inserted),
       @UpdateDate = convert(varchar(8), getdate(), 112) + 
                     ' ' + 
                     convert(varchar(12), getdate(), 114)

SET NoCount ON 

-- Identificar que evento se está ejecutando (Insert, Update o Delete) 
--en base a cursores especiales (inserted y deleted)
if exists (SELECT * FROM inserted) 
  if exists (SELECT * FROM deleted) --Si es un update
    SELECT @Type = 'U'
  else                              --Si es un insert
    SELECT @Type = 'I'
else                                --si es un delete
    SELECT @Type = 'D'
	
-- Obtenemos la lista de columnas de los cursores
SELECT * INTO #ins FROM inserted
SELECT * INTO #del FROM deleted
	
-- Obtener las columnas de llave primaria
SELECT @PKCols = coalesce(@PKCols + ' and', ' on') + 
       ' i.' + 
       c.COLUMN_NAME + ' = d.' + 
       c.COLUMN_NAME
 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk
  JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE c
  ON c.TABLE_NAME = pk.TABLE_NAME
  AND c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
 WHERE pk.TABLE_NAME = @TableName AND 
  pk.CONSTRAINT_TYPE = 'PRIMARY KEY'
	
-- Obtener la llave primaria y columnas para la inserción en la tabla de auditoria
SELECT 
 @PKSELECT = coalesce(@PKSelect+'+','') + 
 '''<' + 
 COLUMN_NAME + 
 '=''+convert(varchar(100),coalesce(i.' + 
 COLUMN_NAME +',d.' + 
 COLUMN_NAME + '))+''>''' 
 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk  
 JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE c
  ON c.TABLE_NAME = pk.TABLE_NAME
  AND c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
 WHERE pk.TABLE_NAME = @TableName
  AND CONSTRAINT_TYPE = 'PRIMARY KEY'
	
if @PKCols is null --<-- Este trigger solo funciona si la tabla tiene llave primaria
 BEGIN
  RAISERROR('no PK on table %s', 16, -1, @TableName)
  RETURN
 END
	
--Loop para armar el query de inserción en la tabla de log. 
--Un registro por cada campo afectado.
SELECT 
 @field = 0, 
 @maxfield = max(ORDINAL_POSITION) 
 FROM INFORMATION_SCHEMA.COLUMNS 
 WHERE TABLE_NAME = @TableName
	
while @field < @maxfield
 BEGIN
  SELECT @field = min(ORDINAL_POSITION) 
   FROM INFORMATION_SCHEMA.COLUMNS 
   WHERE TABLE_NAME = @TableName and ORDINAL_POSITION > @field
  SELECT @bit = (@field - 1 )% 8 + 1
  SELECT @bit = power(2,@bit - 1)
  SELECT @char = ((@field - 1) / 8) + 1
  if substring(COLUMNS_UPDATED(),@char, 1) & @bit > 0 or @Type in ('I','D')
   BEGIN
     SELECT @fieldname = COLUMN_NAME 
      FROM INFORMATION_SCHEMA.COLUMNS 
	  WHERE TABLE_NAME = @TableName and ORDINAL_POSITION = @field
     SELECT @sql = 'insert ControlAlumxMatexCurso (TipoTrn, Tabla, PK, Campo, ValorOriginal, ValorNuevo, FechaTrn, Usuario)'
     SELECT @sql = @sql + 	' SELECT ''' + @Type + ''''
     SELECT @sql = @sql + 	',''' + @TableName + ''''
     SELECT @sql = @sql + 	',' + @PKSelect
     SELECT @sql = @sql + 	',''' + @fieldname + ''''
     SELECT @sql = @sql + 	',convert(varchar(1000),d.' + @fieldname + ')'
     SELECT @sql = @sql + 	',convert(varchar(1000),i.' + @fieldname + ')'
     SELECT @sql = @sql + 	',''' + @UpdateDate + ''''
     SELECT @sql = @sql + 	',''' + @UserName + ''''
     SELECT @sql = @sql + 	' from #ins i full outer join #del d'
     SELECT @sql = @sql + 	@PKCols
     SELECT @sql = @sql + 	' where i.' + @fieldname + ' <> d.' + @fieldname 
     SELECT @sql = @sql + 	' or (i.' + @fieldname + ' is null and  d.' + @fieldname + ' is not null)' 
     SELECT @sql = @sql + 	' or (i.' + @fieldname + ' is not null and  d.' + @fieldname + ' is null)' 
     exec (@sql)
   END
 END
	 
SET NoCount OFF 
GO



--------------------------------------
create trigger BorrarCantLoges
on logen
after insert
as
if ((select count (numerito)from logen)>10)
begin 
delete logen 
insert into logen select 1
end

go


insert into Materias 
select '001','Matematica',700,2,2,1 union
select '002','Introduccion a la Programacion',700,2,2,1 union
select '003','Introduccion a la Informatica',700,2,2,1 
insert into Especialidades
select '001','Tecnico Superior en Programacion',2

select * from AlumnosxMateriasxCursos