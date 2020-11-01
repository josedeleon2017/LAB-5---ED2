# LABORATORIO #5

***Kevin Romero      1047519***

***José De León      1072619***

---

### **Objetivos:**

- Aplicar los conceptos de la cifrado de llave privada

---

### Contenido

- Implementación de una interfaz de cifrado
- Cifrado de llave privada Cesar
- Cifrado de llave privada ZigZag
- Cifrado de llave privada Ruta
- Implementación de los tres cifrados anteriores para strings en un proyecto de consola
- Implementación de los tres cifrados anteriores para archivos de texto en una API

---

### Uso del Proyecto de Consola
Al compilar la clase ***program*** observará el resultado del cifrado y descrifado, cesar, zig zag y ruta para una frase previamente ingresada.

---

### Uso de la API

1. Haga una petición **POST** en ***api/cipher/{method}*** agregando en el apartado form-data el **archivo de texto** a cifrar, la llave con la que se ingresa el archivo deberá llamarse **file**, en este mismo apartado tambien deberá agregar un campo de tipo **texto** con el nombre de llave **key** para la llave privada para el cifrado. Finalmente deberá  intercambiar  el parámetro de la petición por el nombre del método de cifrado deseado.
***(ej: api/cipher/cesar)***
***(ej: api/cipher/zigzag)***
***(ej: api/cipher/ruta)***

El archivo cifrado resultante lo podrá encontrar en la solución del proyecto dentro de la carpeta ***Data/ciphers*** con el nombre del archivo original y con la extension específica del método de cifrado utilizado **.csr .zz .rt**

2. Haga una petición **POST** en ***api/decipher*** agregando en el apartado form-data el **archivo de texto** a descifrar, la llave con la que se ingresa el archivo deberá llamarse **file**, en este mismo apartado tambien deberá agregar un campo de tipo **texto** con el nombre de llave **key** para la llave privada para el cifrado.

Si la llave es la correcta podrá encontrar el archivo descifrado en la solución del proyecto dentro de la carpeta ***Data/deciphers*** con el nombre original y en formato de texto plano.

