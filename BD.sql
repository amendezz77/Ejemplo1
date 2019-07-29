
/* Se crea la BD base1*/
create database base 1

/* Indicando que se va a usar la BD base1*/
use base1

/* Creando la tabla articulos*/
create articulos

/* Para cargar unos datos en la tabla*/
insert into articulos values(1,'Pera',15.50);
insert into articulos values(2,'Limón',16.95);
insert into articulos values(3,'Guacamole',15.54);

/* Para mostrar lo que se cargo*/
select * from articulos