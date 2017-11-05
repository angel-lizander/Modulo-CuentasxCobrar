Create database CuentasxCobrar
go

USE CuentasxCobrar
create table Cuentas(
IDDocumentos int primary  key identity,
Descripcion varchar(90),
Cuentacontable int,
Estado bit);

create table Clientes(
IDClientes int primary key identity,
Nombre varchar(40),
Cedula int unique,
Credito float,
Estado bit);

create table Transacciones(
IDTransacciones int primary key identity,
TipoMovimiento char(2),
IDTipoDocumento int,
IDCliente int,
Fecha datetime, 
Monto decimal(5,0));

create table Asientos(
IDAsientos int identity,
Descripcion varchar(20),
IDClientes int, 
Cuenta int,
TipoMovimiento char(2),
FechaAsiento datetime, 
MontoAsiento float,
Estado bit);

Create table CuentasContable(
IDCuentasContables int identity,
CuentasContables int)
 go

 Insert into CuentasContable values (001002)
 Insert into Cuentas values ('Nota de credito', 001002,1)

 Create table Asientos(
  noasiento int PRIMARY KEY,
  descripcion varchar(200),
  fechaasiento varchar(10),
  cuenta int, 
  tipomovimiento varchar(4),
  monto float(50)
)