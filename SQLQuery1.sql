Create database CuentasxCobrar
go


create table Documentos(
IDD int primary  key,
Descripción varchar(90)
Cuenta int,
Estado bit);

create table Clientes(
IDC int primary key,
Nombre varchar(40),
Cedula int,
Credito float,
Estado bit);

create table Transacciones(
IDT int primary key,
TipoDo char(2),
Fecha datetime, 
Monto float
Doctransacciones int,
IDC int,
);

create table Asientos(
IDA int,
Descripcion varchar(20),
IDD int, 
Cuenta int,
TipoMo char(2),
FechaAsiento datetime, 
MontoAsiento float,
Estado bool,
IDD int FOREIGN KEY REFERENCES Documentos(IDD) 
Cuenta int FOREIGN KEY REFERENCES Documentos(int)); 