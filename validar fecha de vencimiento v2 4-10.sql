--version 2 de verificacion de fechas -
drop procedure VerificarMateriaPosta
go
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