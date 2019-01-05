# Sorteos
Se solicitan desarrollar 5 casos de uso.
Crear Sorteo
Descripción: Se debe desarrollar un servicio web que posea un método que permita la creación
de los sorteos de los juegos del sistema, para ello el sistema deberá.
1. Validar que los parámetros requeridos para la creación de los sorteos o del sorteo que se
desea crear estén completos. En caso contrario deberá indicar el parámetro faltante, junto
con el siguiente mensaje. “El parámetro XXXX es un parámetro obligatorio. Por favor
verifique e intente de nuevo.” Los parámetros requeridos están dados por la definición de
la base de datos.
2. Un juego puede tener uno o n sorteos cada uno en un horario y un día en específico, si se
intenta crear un sorteo de un juego el sistema deberá validar que la hora y el día en el que
se desea realizar el sorteo se encuentre disponible, en caso contrario deberá mostrar un
mensaje de error indicando “El sorteo de hora XXXX para el día XXX del juego XXXX
ya se encuentra registrado en el sistema”
3. El juego define la cantidad de ítems (números) que forman parte del juego
4. Los juegos deberán de ser creados en estatus inactivos y deberá ser activados a través de
la opción correspondiente para poder ser asignados a algún Dominio.
Consultar Sorteos x Juego
Descripción: Se debe desarrollar un servicio web que posea un método que permita la consulta
de los sorteos de un juego en específico, esta consulta deberá devolver todos los datos de los
sorteos del juego.
1. En caso de que el juego ingresado no se encuentre registrado o se encuentre en estatus
“Eliminado”, el sistema deberá mostrar un mensaje indicando “El juego que intenta
consultar no se encuentra registrado en el sistema”.

Eliminar Sorteo
Descripción: Se debe desarrollar un servicio web que posea un método que permita la
eliminación del o los sorteos de un juego registrado.
1. La eliminación es lógica, no física, por lo que el sistema deberá actualizar el estatus del
usuario a “Eliminado”.
2. En caso de que el sorteo a eliminar no se encuentre registrado o se encuentre en estatus
“Eliminado”, el sistema deberá mostrar un mensaje indicando “El sorteo que intenta
eliminar no se encuentra registrado en el sistema”.

3. Para poder eliminar un sorteo el sistema deberá validar que no existan apuestas activas
(pendientes por ejecutarse) asociadas al sorteo.

Modificar Sorteos
Descripción: Se debe desarrollar un servicio web que posea un método que permita la
actualización de los datos de un los sorteos de un juego registrado en el sistema, para ello deberá:
1. Validar que los parámetros requeridos para la actualización del sorteo se encuentren
completos. En caso contrario deberá indicar el parámetro faltante, junto con el siguiente
mensaje. “El parámetro XXXX es un parámetro obligatorio. Por favor verifique e intente
de nuevo.” Los parámetros requeridos están dados por la definición de la base de datos.
2. Validar que el sorteo se encuentre registrado y este asociado al juego. En caso contrario
deberá mostrar un mensaje indicando “El sorteo que intenta actualizar no se encuentra
registrado o no pertenece al Juego XXXXXX”.
