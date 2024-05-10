CREATE TABLE Cliente (
	Id bigint not null identity(1,1),
	Nome varchar(40) not null,
	CPF varchar(14) not null,
	TipoClienteId bigint not null,
	Sexo varchar(1) not null,
	SituacaoClienteId bigint not null
)
go
CREATE TABLE TipoCliente (
	Id bigint not null identity(1,1),
	Descricao varchar(40) not null
)
go
CREATE TABLE SituacaoCliente (
	Id bigint not null identity(1,1),
	Descricao varchar(40) not null
)
go
alter table Cliente
add constraint Cliente_Id_PK primary key ( Id )
go
alter table TipoCliente
add constraint TipoCliente_Id_PK primary key ( Id )
go
alter table SituacaoCliente
add constraint SituacaoCliente_Id_PK primary key ( Id )
go
alter table Cliente
add constraint Cliente_TipoCliente_FK FOREIGN KEY ( TipoClienteId ) references TipoCliente(Id)
go
alter table Cliente
add constraint Cliente_SituacaoCliente_FK FOREIGN KEY ( SituacaoClienteId ) references SituacaoCliente(Id)
go
alter table Cliente
add constraint Cliente_CPF_UK UNIQUE ( CPF )
go
INSERT INTO SituacaoCliente ( Descricao ) VALUES ( 'Ativo' )
go
INSERT INTO SituacaoCliente ( Descricao ) VALUES ( 'Inativo' )
go
INSERT INTO TipoCliente ( Descricao ) VALUES ( 'Externo' )
go
INSERT INTO TipoCliente ( Descricao ) VALUES ( 'Interno' )
go
