create table bitacora (
id_bit int(10) PRIMARY KEY NOT NULL auto_increment,
hora time,
fecha date,
usuario varchar(100),
descripcion varchar(500),
accion varchar(500),
tabla varchar(50),
ip varchar(100)
);
ALTER TABLE bitacora auto_increment=16100;

create user dumpy identified by 'dumpy';   
 
/*GRANT ALL PRIVILEGES ON sancarlos2.* TO 'dumpy'@'%' WITH GRANT OPTION;*/


GRANT EXECUTE, PROCESS, SELECT, SHOW DATABASES, SHOW VIEW, ALTER, ALTER ROUTINE,
    CREATE, CREATE ROUTINE, CREATE TEMPORARY TABLES, CREATE VIEW, DELETE, DROP,
    EVENT, INDEX, INSERT, REFERENCES, TRIGGER, UPDATE, CREATE USER, FILE,
    LOCK TABLES, RELOAD, REPLICATION CLIENT, REPLICATION SLAVE, SHUTDOWN,
    SUPER
        ON *.* TO dumpy@'%'
    WITH GRANT OPTION;
    
  /*USUARIO QUE DEBERA UTILIZARSE PARA ENTRAR AL SISTEMA*/  
  
create user usuariodbs identified by 'aABvAGwAYQA='; /* LA CONTRASEÑA CON LA QUE DEBEN INGRESAR SERA: hola*/
insert into usuario (usuario, contrasenia) values ('usuariodbs', 'aABvAGwAYQA=');   
 
/*GRANT ALL PRIVILEGES ON sancarlos2.* TO 'dumpy'@'%' WITH GRANT OPTION;*/


GRANT EXECUTE, PROCESS, SELECT, SHOW DATABASES, SHOW VIEW, ALTER, ALTER ROUTINE,
    CREATE, CREATE ROUTINE, CREATE TEMPORARY TABLES, CREATE VIEW, DELETE, DROP,
    EVENT, INDEX, INSERT, REFERENCES, TRIGGER, UPDATE, CREATE USER, FILE,
    LOCK TABLES, RELOAD, REPLICATION CLIENT, REPLICATION SLAVE, SHUTDOWN,
    SUPER
        ON *.* TO usuariodbs@'%'
    WITH GRANT OPTION;
    
    
flush privileges;


/* ER DE SEGURIDAD*/

-- 
-- TABLE: aplicacion 
--

CREATE TABLE aplicacion(
    id_aplicacion        INT         AUTO_INCREMENT,
    nombre_aplicacion    CHAR(40),
    PRIMARY KEY (id_aplicacion)
)ENGINE=MYISAM
;



-- 
-- TABLE: perfil 
--

CREATE TABLE perfil(
    id_perfil        INT         AUTO_INCREMENT,
    nombre_perfil    CHAR(40),
    PRIMARY KEY (id_perfil)
)ENGINE=MYISAM
;



-- 
-- TABLE: perfil_privilegios 
--

CREATE TABLE perfil_privilegios(
    id_aplicacion    INT    NOT NULL,
    id_perfil        INT    NOT NULL,
    ins              INT,
    sel              INT,
    upd              INT,
    del              INT,
    PRIMARY KEY (id_aplicacion, id_perfil)
)ENGINE=MYISAM
;



-- 
-- TABLE: usuario 
--

CREATE TABLE usuario(
    usuario            CHAR(50)    NOT NULL,
    contrasenia        CHAR(80),
    fecha_creacion     DATE,
    estado             CHAR(10),
    id_empleados_pk    CHAR(10),
    id_empresa_pk      INT,
    PRIMARY KEY (usuario)
)ENGINE=MYISAM
;



-- 
-- TABLE: usuario_privilegios 
--

CREATE TABLE usuario_privilegios(
    usuario          CHAR(50)    NOT NULL,
    id_aplicacion    INT         NOT NULL,
    ins              INT,
    sel              INT,
    upd              INT,
    del              INT,
    id_perfil        INT,
    PRIMARY KEY (usuario, id_aplicacion)
)ENGINE=MYISAM
;



-- 
-- TABLE: perfil_privilegios 
--

ALTER TABLE perfil_privilegios ADD CONSTRAINT Refaplicacion3 
    FOREIGN KEY (id_aplicacion)
    REFERENCES aplicacion(id_aplicacion)
;

ALTER TABLE perfil_privilegios ADD CONSTRAINT Refperfil4 
    FOREIGN KEY (id_perfil)
    REFERENCES perfil(id_perfil)
;


-- 
-- TABLE: usuario_privilegios 
--

ALTER TABLE usuario_privilegios ADD CONSTRAINT Refperfil1 
    FOREIGN KEY (id_perfil)
    REFERENCES perfil(id_perfil)
;

ALTER TABLE usuario_privilegios ADD CONSTRAINT Refusuario5 
    FOREIGN KEY (usuario)
    REFERENCES usuario(usuario)
;

ALTER TABLE usuario_privilegios ADD CONSTRAINT Refaplicacion6 
    FOREIGN KEY (id_aplicacion)
    REFERENCES aplicacion(id_aplicacion)
;





DROP FUNCTION IF EXISTS `ValidarContrasena`;
DELIMITER $$
USE `sancarlos2`$$
create function `ValidarContrasena`(iusuario nvarchar(20), icon nvarchar(20), iip nvarchar(20)) RETURNS int(2)
IF EXISTS (select usuario from usuario where iusuario = usuario) THEN
BEGIN
DECLARE psw char(20);
SELECT contrasenia into psw FROM usuario WHERE usuario=iusuario;
	IF icon != psw THEN
	insert into bitacora(hora,fecha,usuario,descripcion,accion,tabla,ip)values(current_time(),curdate(),iusuario,'Fallo loggeo','Login','usuario',iip);
	return 0;
	else
	insert into bitacora(hora,fecha,usuario,descripcion,accion,tabla,ip)values(current_time(),curdate(),iusuario,'Loggeo exitoso','Login','usuario',iip);
	return 1;
	END IF;
END;
ELSE 
return 0;
insert into bitacora(hora,fecha,usuario,descripcion,accion,tabla,ip)values(current_time(),curdate(),iusuario,'Fallo loggeo','Login','usuario',iip);
END IF;


DROP FUNCTION IF EXISTS `registraroperacion`;
DELIMITER $$
USE `sancarlos2`$$
create function `registraroperacion`(iusuario nvarchar(100), iaccion nvarchar(500), idescrip nvarchar(500),itabla nvarchar(50), iip nvarchar(20)) RETURNS int(2)
BEGIN
	insert into bitacora(hora,fecha,usuario,descripcion,accion,tabla,ip)values(current_time(),curdate(),iusuario,idescrip,iaccion,itabla,iip);
    return 1;
END;


