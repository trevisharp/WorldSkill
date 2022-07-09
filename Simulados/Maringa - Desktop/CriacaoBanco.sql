create database provaM
go

create table tbIMC(
	id int identity primary key,
	nome varchar(100),
	peso float,
	altura float,
	imc float,
	classificacao varchar(100)
);

create table tbCEP(
	id int identity primary key,
	nome varchar(100),
	cep varchar(11),
	endereco varchar(100)
);

create table tbTempetura(
	id int identity primary key,
	nome varchar(100),
	temperatura float,
	temperatura_convertida float
);

create table tbConsumo(
	id int identity primary key,
	nome varchar(100),
	combustivel varchar(20),
	distancia float,
	media float,
	preco decimal,
	media_litro_gasto float,
	preco_para_percorrer decimal
);


select * from tbIMC
select * from tbTempetura
select * from tbConsumo
select * from tbCEP


drop database provaMaringa