# Árboles Binarios (MVC en C#)

## Descripción del proyecto

Este proyecto consiste en el desarrollo de una aplicación de consola en C# que implementa un **Árbol Binario de Búsqueda (BST)** utilizando el patrón de arquitectura **Modelo-Vista-Controlador (MVC)**.

La aplicación permite administrar elementos identificados mediante una letra, representando archivos o carpetas. Se implementan operaciones de inserción, búsqueda, actualización y eliminación, además de diferentes recorridos para visualizar y analizar la estructura del árbol.

## Arquitectura del proyecto

El proyecto está organizado siguiendo el patrón MVC, separando las responsabilidades de cada componente:

- **Models:** contiene la lógica del árbol binario de búsqueda, la estructura de los nodos y los resultados de las operaciones.
- **Views:** se encarga de mostrar los mensajes, resultados de las operaciones, recorridos y representación gráfica del árbol en consola.
- **Controllers:** coordina la interacción entre el modelo y la vista, ejecutando las operaciones y mostrando sus resultados.

### Estructura de carpetas

```text
Taller1DocuTrackBST/
│
├── Controllers/
│   └── ArbolController.cs
│
├── Models/
│   ├── ArbolBinario.cs
│   ├── Nodo.cs
│   └── ResultadoOperacion.cs
│
├── Views/
│   └── ArbolVista.cs
│
├── Program.cs
└── README.md
```

## Funcionalidades implementadas

- **Inserción:** permite agregar elementos al árbol binario de búsqueda.
- **Búsqueda:** permite localizar elementos y conocer la cantidad de comparaciones realizadas.
- **Actualización:** permite modificar el nombre de un elemento, conservando su clasificación como archivo o carpeta.
- **Eliminación:** permite eliminar nodos contemplando los tres casos posibles:
  - Nodo hoja (sin hijos).
  - Nodo con un solo hijo.
  - Nodo con dos hijos.
- **Recorridos:** implementa los siguientes recorridos del árbol:
  - Preorden.
  - Inorden.
  - Postorden.
  - Por niveles.
- **Visualización:** muestra la estructura del árbol binario de búsqueda mediante una representación jerárquica en consola.
- **Altura:** calcula la altura del árbol.
- **Comparación de nombres:** utiliza una comparación que no distingue entre mayúsculas y minúsculas.

## Validación de datos de entrada

Se implementaron validaciones en las operaciones de inserción, búsqueda, eliminación y actualización para garantizar que los datos ingresados cumplan con las condiciones establecidas.

Las validaciones son las siguientes:

- **Nombre obligatorio:** no se permiten valores nulos, vacíos o que contengan únicamente espacios.
- **Eliminación de espacios:** se utiliza `Trim()` para quitar los espacios al inicio y al final del nombre.
- **Longitud del nombre:** se permite únicamente un carácter por elemento.
- **Tipo de carácter:** el carácter ingresado debe ser una letra válida. No se aceptan números ni caracteres especiales.
- **Validación en actualización:** el nuevo nombre del elemento también debe cumplir las condiciones anteriores.
- **Mensajes de error:** cuando un dato no cumple las condiciones, el programa informa el motivo mediante un mensaje.

**Nota:** Para este ejercicio se restringieron los nombres a una sola letra, con el propósito de facilitar las pruebas y la visualización del árbol.

## Datos utilizados en las pruebas

Para comprobar el funcionamiento de las operaciones se utilizaron los siguientes datos:

### 1. Inserción de elementos

Se insertaron 14 elementos:

```text
M, H, T, D, J, P, W, B, F, I, K, N, R, Z
```

### 2. Búsqueda de elementos

Se realizaron 6 búsquedas:

```text
D, B, T, Z, A, X
```

- Elementos encontrados: `D`, `B`, `T`, `Z`.
- Elementos no encontrados: `A`, `X`.

### 3. Actualización de elementos

Se realizaron 3 actualizaciones para comprobar diferentes situaciones:

| Elemento original | Nuevo elemento | Caso probado |
|---|---|---|
| B | C | Nodo hoja |
| W | Y | Nodo con un hijo |
| M | O | Nodo raíz |

### 4. Eliminación de elementos

Se realizaron 3 eliminaciones:

| Elemento eliminado | Caso probado |
|---|---|
| C | Nodo hoja |
| Z | Nodo con un hijo |
| N | Nodo con dos hijos (raíz) |

### 5. Recorridos y altura

Al finalizar las operaciones se ejecutaron los cuatro recorridos del árbol y se calculó su altura para verificar la estructura resultante.

## Requisitos

- .NET SDK 8.0 o superior.
- Visual Studio Code o Visual Studio.
- C#.

## Ejecución del proyecto

1. Abrir una terminal en la carpeta del proyecto.
2. Compilar la aplicación:

```bash
dotnet build
```

3. Ejecutar el programa:

```bash
dotnet run
```

## Resultado esperado

Al ejecutar la aplicación se muestran en consola:

- Los resultados de las inserciones y se muestra la estructura del árbol.
- Los resultados de las búsquedas y sus comparaciones.
- Los resultados de las actualizaciones y se muestra como va quedando el árbol.
- Los resultados de las eliminaciones y se muestra como va quedando el árbol.
- La representación visual del árbol después de las modificaciones.
- Los recorridos preorden, inorden, postorden y por niveles.
- La altura final del árbol.

El recorrido **inorden** permite comprobar que los elementos del árbol se encuentran organizados de acuerdo con las reglas de un árbol binario de búsqueda.

Autor: Jesus Ramirez.
Profesor: 
Programacion III.
Universidad de Manizales.