# Laboratorio #4 — CRUD en C# con Conexión a MySQL y Manejo Binario de Imágenes

Aplicación de escritorio para la gestión de un inventario de productos, con persistencia en MySQL y almacenamiento de imágenes como datos binarios, en C# y .NET 10.

**Universidad Tecnológica de Panamá** — Facultad de Ingeniería de Sistemas Computacionales
Herramientas de Programación Aplicada III (.Net) · Grupo 1IL133 · II Semestre 2026

- **Estudiante:** Diego Sanjur
- **Facilitadora:** Irina Fong

---

## Descripción

Este repositorio contiene una aplicación de Windows Forms que implementa las cuatro operaciones básicas de una base de datos (crear, consultar, modificar y eliminar) sobre una tabla de productos alojada en MySQL. Cada producto se compone de un identificador, nombre, precio, cantidad y una imagen, que no se guarda como una ruta de archivo sino como datos binarios dentro de la propia base de datos, en un campo de tipo `LONGBLOB`.

La aplicación está organizada en tres capas: una clase modelo que representa al producto, una clase de acceso a datos que concentra toda la comunicación con MySQL mediante el conector `MySql.Data`, y el formulario que se encarga únicamente de la interfaz y de traducir las acciones del usuario en llamadas a esa capa de datos. El punto central del laboratorio es la conversión de tipos en ambos sentidos: la imagen seleccionada en el `PictureBox` se transforma en un arreglo de bytes mediante un `MemoryStream` para poder viajar a la base de datos, y los bytes recuperados se reconstruyen como un `Bitmap` para mostrarse dentro del `DataGridView`.

## Estructura del repositorio

```
Laboratorio 4 - Diego Sanjur/
├── Producto.cs          Clase modelo con las propiedades del producto
├── Conexion.cs          Capa de acceso a datos y operaciones CRUD
├── Form1.cs             Lógica de la interfaz y eventos de los controles
└── Form1.Designer.cs    Código generado por el diseñador de formularios
```

---

## Base de datos

El esquema `laboratorio4` contiene una sola tabla. La columna `id` es autoincremental, por lo que MySQL asigna su valor y la aplicación nunca lo envía al insertar. La columna `imagen` se declara como `LONGBLOB` porque almacena los ceros y unos del archivo gráfico, que en .NET se mapean directamente al tipo `byte[]`.

```sql
CREATE DATABASE IF NOT EXISTS laboratorio4;
USE laboratorio4;

CREATE TABLE IF NOT EXISTS productos (
    id       INT NOT NULL AUTO_INCREMENT,
    nombre   VARCHAR(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    precio   DECIMAL(10,2) NOT NULL,
    cantidad INT NOT NULL,
    imagen   LONGBLOB NOT NULL,
    PRIMARY KEY (id)
);
```

Antes de ejecutar la aplicación debe ajustarse la cadena de conexión en `Conexion.cs` con las credenciales locales del servidor.

**Conceptos:** tipos de datos de MySQL, llave primaria, `AUTO_INCREMENT`, campos binarios `BLOB`, correspondencia entre tipos de SQL y de C#.

## Clase Producto

Clase modelo que representa una fila de la tabla `productos`. Sus cinco atributos se exponen como propiedades automáticas, es decir, declaradas con `{ get; set; }` sin escribir el campo privado ni el cuerpo de los accesores: el compilador los genera por detrás. El `get` se ejecuta al leer la propiedad y el `set` al asignarle un valor, lo que permite agregar validaciones más adelante sin modificar el código que la utiliza.

La propiedad `Imagen` se declara como `byte[]?` porque un producto puede no tener imagen asociada, y el signo de interrogación habilita la nulabilidad estricta para que el compilador acepte ese caso sin advertencias.

**Conceptos:** clases modelo, encapsulamiento, propiedades automáticas, accesores `get` y `set`, tipos por referencia, nulabilidad estricta.

**Diagrama UML**

```
┌────────────────────────────────────────────┐
│                 Producto                   │
├────────────────────────────────────────────┤
│ + <<property>> Id: int                     │
│ + <<property>> Nombre: string              │
│ + <<property>> Precio: decimal             │
│ + <<property>> Cantidad: int               │
│ + <<property>> Imagen: byte[]?             │
└────────────────────────────────────────────┘
```

## Clase Conexion

Concentra toda la comunicación con la base de datos, de modo que el formulario nunca ejecuta instrucciones SQL por su cuenta. Todos sus miembros son estáticos porque la clase no conserva estado propio: se invocan directamente sobre el nombre de la clase, sin crear un objeto.

El método `ObtenerConexion` construye un `MySqlConnection` a partir de la cadena de conexión y lo devuelve ya abierto; si el servidor no responde o las credenciales son incorrectas, captura la `MySqlException` y devuelve `null`, valor que los demás métodos verifican antes de continuar. `GetProductos` ejecuta la consulta con un `MySqlDataReader` y recorre el resultado fila por fila, mapeando cada registro a un objeto `Producto` que se agrega a una lista genérica.

Los tres métodos de escritura reciben un `Dictionary<string, object>` en el que cada clave es el nombre de una columna y cada valor el dato correspondiente. A partir de esas claves se arma dinámicamente la instrucción SQL con sus marcadores de parámetro, lo que permite reutilizar el mismo método con cualquier tabla. `UpdateSeguro` y `DeleteSeguro` reciben además la columna y el valor del identificador para construir la cláusula `WHERE`, sin la cual la operación afectaría a todos los registros de la tabla.

Ninguna consulta concatena los valores dentro de la cadena SQL: todos se envían como parámetros mediante `AddWithValue`, lo que evita la inyección de SQL. Los objetos de conexión, comando y lector se declaran dentro de bloques `using` para que sus recursos no administrados se liberen al salir del bloque, incluso si ocurre una excepción.

**Conceptos:** capa de acceso a datos, miembros estáticos, proveedor `MySql.Data`, objetos `Connection`, `Command` y `DataReader`, consultas parametrizadas, inyección de SQL, bloque `using` y recursos no administrados, manejo de excepciones con `try` y `catch`, colecciones genéricas `List` y `Dictionary`.

**Diagrama UML**

```
┌──────────────────────────────────────────────────────────────────────┐
│                          <<static>> Conexion                         │
├──────────────────────────────────────────────────────────────────────┤
│ - <<static>> cadenaConexion: string                                  │
├──────────────────────────────────────────────────────────────────────┤
│ + <<static>> ObtenerConexion(): MySqlConnection?                     │
│ + <<static>> GetProductos(filtro: string): List<Producto>            │
│ + <<static>> InsertSeguro(tabla, data): bool                         │
│ + <<static>> UpdateSeguro(tabla, data, idColumna, idValor): bool     │
│ + <<static>> DeleteSeguro(tabla, idColumna, idValor): bool           │
└──────────────────────────────────────────────────────────────────────┘
                                   │ devuelve
                                   ▼
┌────────────────────────────────────────────┐
│                 Producto                   │
└────────────────────────────────────────────┘
```

## Formulario Form1

Contiene la lógica de la interfaz y los manejadores de los eventos de cada control. Al cargarse, el evento `Load` invoca a `cargarProductos`, que solicita la lista a la capa de datos y llena el `DataGridView` fila por fila.

La conversión de imágenes ocurre en dos direcciones. Al mostrar, los bytes de cada producto se envuelven en un `MemoryStream`, a partir del cual se construye un `Bitmap`; de ese mapa de bits se crea una segunda copia con `new Bitmap(bmp)` para desvincular la imagen del flujo de memoria, que se destruye al cerrarse el bloque `using`. Al guardar, el método `ImageToByteArray` realiza el camino inverso: escribe la imagen del `PictureBox` en un `MemoryStream` con formato PNG y devuelve el arreglo de bytes resultante.

La validación se resuelve en el método `datosCorrectos`, que utiliza `decimal.TryParse` e `int.TryParse` para comprobar que el precio y la cantidad sean numéricos. A diferencia de `Parse`, estos métodos no lanzan una excepción cuando el texto es inválido: devuelven un valor booleano que indica el éxito de la conversión y entregan el número convertido a través de un parámetro marcado con `out`.

Para modificar o eliminar, el evento `CellClick` del `DataGridView` carga en el formulario el producto de la fila seleccionada y guarda su identificador en el campo `idSeleccionado`, que actúa como referencia del registro sobre el que se aplicará la operación. La eliminación solicita confirmación mediante un `MessageBox` de tipo Sí/No antes de ejecutarse.

**Conceptos:** programación orientada a eventos, manejadores de eventos, controles `TextBox`, `PictureBox`, `DataGridView` e `ImageList`, cuadro de diálogo `OpenFileDialog`, flujos de memoria con `MemoryStream`, clase `Bitmap`, validación con `TryParse` y parámetros de salida `out`, separación entre interfaz y acceso a datos.

**Diagrama UML**

```
┌──────────────────────────────────────────────────────────────────────┐
│                          Form1 : Form                                │
├──────────────────────────────────────────────────────────────────────┤
│ - listaProductos: List<Producto>                                     │
│ - myProducto: Dictionary<string, object>                             │
│ - imagenSeleccionada: bool                                           │
│ - idSeleccionado: int                                                │
├──────────────────────────────────────────────────────────────────────┤
│ - cargarProductos(filtro: string)                                    │
│ - datosCorrectos(): bool                                             │
│ - CargarDatosProductos()                                             │
│ - ImageToByteArray(image: Image?): byte[]?                           │
│ - limpiarCampos()                                                    │
│ - btnGuardar_Click()      - btnModificar_Click()                     │
│ - btnEliminar_Click()     - btnLimpiar_Click()                       │
│ - dgvProductos_CellClick()                                           │
│ - pictureBox2_Click()     - txtBusqueda_TextChanged()                │
└──────────────────────────────────────────────────────────────────────┘
                                   │ usa
                                   ▼
┌──────────────────────────────────────────────────────────────────────┐
│                          <<static>> Conexion                         │
└──────────────────────────────────────────────────────────────────────┘
```

---

## Funcionalidades

**Consultar.** Al abrir el formulario, la rejilla se llena con los registros existentes y muestra cada imagen en una columna de tipo `DataGridViewImageColumn` configurada con `ImageLayout` en `Zoom`, para que la imagen se vea completa sin deformarse.

**Buscar.** El evento `TextChanged` del campo de búsqueda filtra los registros en tiempo real por identificador, nombre, precio o cantidad, mediante una cláusula `LIKE` parametrizada.

**Agregar.** Se completan los campos del formulario y se selecciona una imagen haciendo clic sobre el `PictureBox`, lo que abre un `OpenFileDialog` restringido a archivos de imagen.

**Modificar.** Al seleccionar un producto en la rejilla, sus datos se cargan en el formulario; una vez editados, la operación actualiza únicamente el registro correspondiente a su identificador.

**Eliminar.** Elimina de la tabla el producto seleccionado, previa confirmación del usuario.
