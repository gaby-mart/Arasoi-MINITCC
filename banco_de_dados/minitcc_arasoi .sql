create database Arasoi;
use Arasoi;

create table campeonato(
cod_campeonato int (5) primary key not null,
filiacao varchar (10) not null,
data date not null
);

-- Alterações necessárias 07092024
alter table campeonato add nome_campeonato varchar(20) not null;
alter table campeonato add data_inicio date not null;
alter table campeonato add data_fim date not null;
--
desc campeonato;
select *from campeonato;

insert into campeonato (cod_campeonato,filiacao,data) values (12345,'FPK','2024-08-09');

create table atleta(
CPF varchar (14) primary key not null,
nome_atleta varchar (40) not null,
altura float (4) not null,
idade int (2) not null,
kyu int (1) not null,
dan int (1),
dojo varchar (20) not null,
cidade varchar (20) not null,
cod_campeonato int (5) not null,
Constraint FK_atleta_campeonato_cod_campeonato Foreign key (cod_campeonato)
References campeonato (cod_campeonato)
);

desc atleta;
select *from atleta;

insert into atleta (CPF, nome_atleta, altura, idade, kyu, dan, dojo, cidade, cod_campeonato) values 
('489.378.801-90', 'Ana', '1.50', '17', '5', '0', 'Kuroshiô', 'Sumaré', '12345');

create table categoria(
cod_categoria int (5) primary key not null,
qtd_atletas int (2),
nome_categoria varchar (10) not null,
koto int (2) not null,
cod_campeonato int (5) not null,
Constraint FK_categoria_campeonato_cod_campeonato Foreign key (cod_campeonato)
References campeonato (cod_campeonato)
);
desc categoria;
select * from categoria;

insert into categoria (cod_categoria, qtd_atletas, nome_categoria, koto, cod_campeonato) values 
('33333', '10', 'sub18', '69', '12345'); 

create table chave(
cod_chave int(5) primary key not null,
total_pontos int (2),
tempo time,
faltas int (1),
cod_categoria int (5) not null,
Constraint FK_chave_categoria_cod_categoria Foreign key (cod_categoria)
References categoria (cod_categoria)
);
desc chave;
select * from chave;

insert into chave (cod_chave, total_pontos, tempo, faltas, cod_categoria) values
('98765', '10', '00:05:00', '3', '33333');

create table atleta_aka(
cod_atleta int (3) not null,
nome_atleta varchar (30) not null,
faltas int (1),
pontos int (2),
CPF varchar (14) not null,
Constraint FK_atleta_aka_atleta_CPF Foreign key (CPF)
References atleta (CPF)
);
desc atleta_aka;
select * from atleta_aka;

insert into atleta_aka (cod_atleta, nome_atleta, faltas, pontos, CPF) values 
('001', 'Goku', '0', '02', '489.378.801-90');

create table atleta_ao(
cod_atleta int (3) not null,
nome_atleta varchar (30) not null,
faltas int (1),
pontos int (2),
CPF varchar (14) not null,
Constraint FK_atleta_ao_atleta_CPF Foreign key (CPF)
References atleta (CPF)
);
desc atleta_ao;
select * from atleta_ao;

insert into atleta_ao (cod_atleta,nome_atleta,faltas,pontos,CPF) values 
('003','Gaby','1','08','489.378.801-90');

