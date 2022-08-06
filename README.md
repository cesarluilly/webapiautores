# webapiautores


## Instalamos los Paquetes de ORM Y TOOLS para usar EntityFramework.

![ormentity.jpg](./imgReadme/ormentity.jpg)
![ormentitytools.jpg](./imgReadme/ormentitytools.jpg)

### Agregamos los string de conecciones.
Estas conecciones se agregan en el appsetting ya que puede darse 
el caso de que yo quiero utilizar una cadena de coneccion 
para development y otra cadena de coneccion para produccion ya 
que van a estar apuntando a diferentes bases de datos y es por
eso que no es recomendable agregarlos en el codigo.

![connectionString](./imgReadme/connectionString.jpg)

### Pasos para generar nuestra DB a partir de las Entitys.

* > `Add-Migration Inicial`
* > `Update-Database`













