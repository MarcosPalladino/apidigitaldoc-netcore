-- Rdigitaldoc@2020
--Data Source=robsonamendonca.database.windows.net;Initial Catalog=digitaldoc;User ID=robsonamendonca;Password=********;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False 
CREATE DATABASE digitaldoc

USE digitaldoc


CREATE TABLE papeis
(
    Id int NOT NULL IDENTITY(1,1),
    TipoPapel varchar(250) NOT NULL,
    PRIMARY KEY (id)     
);

CREATE TABLE empresas
(
    Id int NOT NULL IDENTITY(1,1),
    NomeFantasia varchar(50) NOT NULL,
    CNPJ varchar (15) NOT NULL,
    Telefone varchar(20),
    Email varchar(200),
    PRIMARY KEY (id),
    CONSTRAINT UK_CNPJ UNIQUE(CNPJ)

);

CREATE TABLE usuarios_papeis
(
    Id_usuario int NOT NULL ,
    Id_papel int NOT NULL
);

CREATE TABLE usuarios
(
    Id int NOT NULL IDENTITY(1,1),
    NomeCompleto varchar(60) NOT NULL,
    CPF varchar (15) NOT NULL,
    Telefone varchar(20),
    Email varchar(200) NOT NULL,
    Senha varchar(60) NOT NULL,
    EmpresaId int NOT NULL,
    PRIMARY KEY (id),
    CONSTRAINT UK_CPF_EMAIL UNIQUE(CPF,Email)
    ,
    CONSTRAINT FK_UsuariosId_Empresas FOREIGN KEY (EmpresaId)
        REFERENCES empresas (Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE    
);


CREATE TABLE documentos
(
    Id int NOT NULL IDENTITY(1,1),
    UrlDocumento varchar(max) NOT NULL,
    UsuarioId int NOT NULL,
    PRIMARY KEY (id)
    ,
    CONSTRAINT FK_DocumentoId_Usuario FOREIGN KEY (UsuarioId)
        REFERENCES usuarios (Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE    
);


--  massa de dados:

-- insert into papeis(TipoPapel) values ('Visualização'),('Edição'),('Download')
-- insert into empresas (NomeFantasia,CNPJ,Telefone, Email) Values('Empresa 1','11.111.1111/01','11-222-222','eu@ue.com')
-- insert into usuarios (NomeCompleto, CPF, Telefone, Email, Senha, EmpresaId) values('Usuario Testes','111.111.111-11','11111-1111','vc@vc.com.br','xxxx',1) ;
-- insert into usuarios_papeis (Id_usuario, Id_papel) values (1,1);
-- insert into documentos (UrlDocumento, UsuarioId) values ('https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png',1);

