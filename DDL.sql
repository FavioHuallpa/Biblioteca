--DROP TABLE Estudiantes;
--DROP TABLE Prestamos;
--DROP TABLE Usuario;
--DROP TABLE Empleados;
--DROP TABLE Devoluciones;
--DROP TABLE Libros;
--DROP TABLE Editoriales;
--DROP TABLE Autores;


CREATE TABLE Estudiantes
(ci INT IDENTITY(1,1) PRIMARY KEY,
nombre VARCHAR(20) NOT NULL,
apellido VARCHAR(20) NOT NULL,
direccion NVARCHAR(100) NOT NULL,
carrera NVARCHAR(60)
);
CREATE TABLE Empleados
(id INT IDENTITY(1,1) PRIMARY KEY,
nombre VARCHAR(20) NOT NULL,
apellido VARCHAR(20) NOT NULL,
email VARCHAR(50) NOT NULL,
telfono NUMERIC(10) NOT NULL,
direccion VARCHAR(MAX) NOT NULL,
);
CREATE TABLE Usuario (
	id INT IDENTITY(1,1) PRIMARY KEY,
	usuario VARCHAR(20) NOT NULL UNIQUE,
	clave VARCHAR(50) NOT NULL,
	idEmpleados INT NOT NULL,
	CONSTRAINT FK_Usuario_Empleados FOREIGN KEY(idEmpleados) REFERENCES Empleados(id)
);

CREATE TABLE Devoluciones(
cod INT IDENTITY(1,1) PRIMARY KEY,
fecha DATE NOT NULL,
);
CREATE TABLE Editoriales(
id INT IDENTITY(1,1) PRIMARY KEY,
nombre VARCHAR(60)
);
CREATE TABLE Autores(
id INT IDENTITY(1,1) PRIMARY KEY,
nombre VARCHAR(60) NOT NULL,
apellido VARCHAR(30) NOT NULL,
nacionalidad VARCHAR(50) NOT NULL
);

CREATE TABLE Libros
(cod_libro INT IDENTITY(1,1) PRIMARY KEY,
titulo VARCHAR(40) NOT NULL,
idEditoriales INT NOT NULL,
	CONSTRAINT FK_Libros_Editoriales FOREIGN KEY(idEditoriales) REFERENCES Editoriales(id),
idAutores INT NOT NULL,
	CONSTRAINT FK_Libros_Autores FOREIGN KEY(idAutores) REFERENCES Autores(id)
);

CREATE TABLE Prestamos
(no_prestamo INT IDENTITY(1,1) PRIMARY KEY,
idEmpleados INT NOT NULL,
	CONSTRAINT FK_Prestamos_Empleados FOREIGN KEY(idEmpleados) REFERENCES Empleados(id),
ciEstudiantes INT NOT NULL,
	CONSTRAINT FK_Prestamos_Estudiantes FOREIGN KEY(ciEstudiantes) REFERENCES Estudiantes(ci),
cod_libroLibros INT NOT NULL,
	CONSTRAINT FK_Prestamos_Libros FOREIGN KEY(cod_libroLibros) REFERENCES Libros(cod_libro),
codDevoluciones INT NOT NULL,
	CONSTRAINT FK_Prestamos_Devoluciones FOREIGN KEY(codDevoluciones) REFERENCES Devoluciones(cod),
fechaprestamo NCHAR(8),
fechadevolucion NCHAR(8),
);


ALTER TABLE Estudiantes ADD edad VARCHAR(50) DEFAULT SUSER_SNAME();
ALTER TABLE Usuario ADD fechaRegistro DATETIME DEFAULT GETDATE();
ALTER TABLE Usuario ADD registroActivo BIT DEFAULT 1;

CREATE PROC paUsuarioListar @parametro VARCHAR(100)
AS

   SELECT u.id as idUsuario, u.idEmpleados, u.usuario,
          e.nombre, e.apellido, e.email, e.telfono
		
   FROM Usuario u
   INNER JOIN Empleados e ON u.idEmpleados= e.id
   WHERE u.registroActivo=1
         AND e.nombre+e.apellido+e.email LIKE '%'+@parametro+'%'

select * from Estudiantes

CREATE Proc paEstudiantesListar @parametro VARCHAR(50)
AS
       select ci,nombre,apellido,direccion,edad,carrera,
	       usuarioRegistro,fecharegistro
		from Estudiantes
		where registroActivo=1 and nombre+apellido+direccion+edad LIKE '%'+@parametro+'%'

EXEC paEstudiantesListar 'faviola'

select * from Empleados
