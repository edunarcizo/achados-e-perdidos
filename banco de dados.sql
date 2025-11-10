create database achados_perdidos;
use achados_perdidos;
create table achados_perdidos(
id INT NOT NULL auto_increment,
descricao_item VARCHAR(255),
quem_encontrou VARCHAR(100),
data_encontro DATE NOT NULL,
foto_item longblob,
primary key (id));
