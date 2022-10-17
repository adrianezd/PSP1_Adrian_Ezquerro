# PSP1_Adrian_Ezquerro

Ejercicio Clase Hilos

Esta práctica consistirá en la realización de un programa para practicar y familiarizarnos con
el uso de los Hilos (Thread), con el objetivo de aportar comportamiento asíncrono a
nuestras aplicaciones.
La aplicación será de tipo consola y ofrecerá diferentes servicios asíncronos, de tal manera
que el usuario pueda activar y desactivar cada uno de ellos de manera independiente, así
cómo configurar cada uno de ellos de manera independiente.
Los servicios serán los siguientes:
● Comprobar modificación de directorio
Hilo que esté comprobando constantemente si un directorio ha sido modificado, es
decir, si se le han añadido (o eliminado) ficheros o subdirectorios.
● Comprobar número máximo de líneas de fichero
Hilo que esté comprobando constantemente si un fichero sobrepasa un cierto
número de líneas. Deberás establecer el límite máximo de líneas de un fichero, de
tal manera que cuando se sobrepase, borre líneas del principio y mantenga las
últimas.
Se deberán declarar las clases “ServicioXxx”, las cuales contendrán los estados posibles
del servicio (Arrancado/Parado), así cómo sus posibles opciones de configuración (ruta a
analizar, delay, etc.) y los métodos que se consideren necesarios.
También deberemos crear un fichero de Log donde se vayan registrando los posibles
cambios encontrados por los hilos.
No podrás usar Console desde fuera de la clase Program. Se deberá organizar el
código en capas.
Desde el “main” de nuestra aplicación se ofrecerá el menú para cambiar el estado, u
opciones, de los distintos servicios. Cuando accedamos a la opción de cada servicio, se
deberá mostrar un submenú con las opciones de dicho servicio, así cómo la opción “Atrás”
para salir al menú principal.

Ejemplo:

Adicional:
Crear un fichero donde guardemos la configuración, de tal manera que al arrancar la
aplicación, cargue del mismo las posibles opciones de configuración, como podrían ser:
- Tiempo de delay que tenga cada hilo para comprobar los cambios.
- Fichero que comprobará cada hilo.
- Etc.
La repera:
Que se puedan crear X hilos para chequear X ficheros.
Pista: usaríamos un List de hilos para almacenar la referencia de cada hilo en el List.
