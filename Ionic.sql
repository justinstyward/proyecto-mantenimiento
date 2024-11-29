/*
 * BASE DE DATOS CREADA POR JUSTIN
 * VERSION 0.0.1
 * COPYRIGHT 2024
 */

 --Creamos la base de datos [Ionic]
create database [Ionic]
go

--Usamos la base de datos [Ionic]
use [Ionic]
go

--Creamos la tabla Cliente
create table Cliente
(
idCliente int identity (1,1) not null,
nit varchar(20) not null,
razonSocial varchar(20) not null,
telefono varchar(10) not null,
direccion varchar(20) not null,
--Establecemos la llave pimaria
constraint PK_Cliente primary key (idCliente)
)
go

--Creamos la tabla Usuario
create table Usuario
(
idUsuario int identity (1,1) not null,
correo varchar(20) not null,
clave varchar(64) not null,
estado bit not null,
--Establecemos la llave pimaria
constraint PK_Usuario primary key (idUsuario)
)
go

--Creamos la tabla Productos
create table Productos
(
idProducto int identity (1,1) not null,
descripcion varchar(20) not null,
valorUnitario money not null,
estado bit not null,
--Establecemos la llave pimaria
constraint PK_Productos primary key (idProducto)
)
go

--Creamos la tabla Impuestos
create table Impuestos
(
idImpto int identity (1,1) not null,
idProducto int not null,
porcentajeImpto money not null,
estado bit not null,
--Establecemos la llave pimaria y foranea
constraint PK_Impuestos primary key (idImpto),
constraint FK_Impuestos_Producto foreign key (idProducto) references Productos (idProducto)
)
go

--Creamos la tabla FacturaEnc
create table FacturaEnc
(
idFactura int identity (1,1) not null,
idCliente int not null,
fechaFactura datetime not null,
fechaVencimiento datetime not null,
consecutivo int not null,
valorTotal money not null,
impuestos money not null,
valorTotalMasImptos money not null,
--Establecemos la llave pimaria y foranea
constraint PK_FacturaEnc primary key (idFactura),
constraint FK_FacturaEnc_Cliente foreign key (idCliente) references Cliente (idCliente)
) 
go

--Creamos la tabla FacturaDet
create table FacturaDet
(
idFacturaDet int identity (1,1) not null,
idFactura int not null,
idProducto datetime not null,
cantidad datetime not null,
valorTotal money not null,
--Establecemos la llave pimaria y foranea
constraint PK_FacturaDet primary key (idFactura),
constraint FK_FacturaDet_FacturaEnc foreign key (idFactura) references FacturaEnc (idFactura),
constraint FK_FacturaDet_Producto foreign key (idProducto) references Producto (idProducto)
) 
go
 

/*
 * PROCEMINIENTOS ALMACENADOS
 */

 /*
 * Usuarios
 */

--Creamos el procedimiento almacenado 'SP_Registrar_Usuario' para resgistrar los usuarios--
create proc SP_Registrar_Usuario
@correo varchar(20),
@clave varchar(64),
@estado bit
as
insert into Usuario values (@correo, @clave, @estado)
go

--probamos el procedimiento almacenado
exec SP_Registrar_Usuario 'reoarrieta@gmail.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 1

--Creamos el procedimiento almacenado 'SP_Consultar_Usuario' para consultar los usuarios--
create proc SP_Consultar_Usuario
@correo varchar(20),
@clave varchar(64)
as
select * from Usuario where correo = @correo and clave = @clave
go

--probamos el procedimiento almacenado
exec SP_Consultar_Usuario 'reoarrieta@gmail.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4'


 /*
 * Productos
 */

--Creamos el procedimiento almacenado 'SP_Crear_Producto' para guardar los productos--
create proc SP_Crear_Producto
@descripcion varchar(20),
@valorUnitario money,
@estado bit
as
insert into Productos values (@descripcion, @valorUnitario, @estado)
go

exec SP_Crear_Producto 'Teclado', 1000.00, 1

--Creamos el procedimiento almacenado 'SP_Consultar_Productos' para consultar los usuarios--
create proc SP_Consultar_Productos
as
select * from Productos order by 1 desc
go

exec SP_Consultar_Productos

 /*
 * Clientes
 */

--Creamos el procedimiento almacenado 'SP_Crear_Cliente' para guardar los productos--
create proc SP_Crear_Cliente
@nit varchar(20),
@razonSocial varchar(20),
@telefono varchar(10),
@direccion varchar(20)
as
insert into Cliente values (@nit, @razonSocial, @telefono, @direccion)
go

exec SP_Crear_Cliente '1234567', 'ReoArrieta', '9291825', 'Calle 80'

--Creamos el procedimiento almacenado 'SP_Consultar_Clientes' para consultar los usuarios--
create proc SP_Consultar_Clientes
as
select * from Cliente order by 1 desc
go

exec SP_Consultar_Clientes

 /*
 * Inpuestos
 */

 --Creamos el procedimiento almacenado 'SP_Crear_Inpuesto' para guardar los productos--
create proc SP_Crear_Inpuesto
@idProducto int,
@porcentajeImpto money,
@estado bit
as
insert into Impuestos values (@idProducto, @porcentajeImpto, @estado)
go

exec SP_Crear_Inpuesto 1, 19, 1

--Creamos el procedimiento almacenado 'SP_Consultar_Inpuestos' para consultar los usuarios--
create proc SP_Consultar_Inpuestos
as
select i.*, p.descripcion from Impuestos i
inner join Productos p on p.idProducto = i.idProducto
order by 1 desc
go

exec SP_Consultar_Inpuestos