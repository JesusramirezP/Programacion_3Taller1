namespace Taller1DocuTrackBST.Models;                  // Organiza la clase dentro de la capa Model.



public sealed class Nodo                               // Representa un nodo del arbol binario, que puede ser una carpeta o un archivo.                                      
{
    public string Nombre { get; set; }                  // Guarda el nombre del archivo o carpeta. Se puede consultar y modificar mediante get y set.
    public bool EsCarpeta { get; private set; }         // Indica si el nodo representa una carpeta (true) o un archivo (false). Solo se puede consultar despues de crear el nodo.
    public Nodo? Izquierdo { get; set; }                // Referencia al hijo izquierdo. Puede ser null si no existe.
    public Nodo? Derecho { get; set; }                  // Referencia al hijo derecho. Puede ser null si no existe.


    public Nodo(string nombre, bool esCarpeta)          // Constructor: se ejecuta al crear un nuevo nodo. Recibe el nombre y el tipo de elemento.
    {
        
        if (string.IsNullOrWhiteSpace(nombre))                                                  // Valida que nombre no sea nulo, vacio o contenga unicamente espacios en blanco.
        {                                                                                       // Si el nombre no es valido, lanza una excepcion.
            throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));
        }

        Nombre = nombre.Trim();                         // Guarda el nombre eliminando espacios al principio y al final.

        EsCarpeta = esCarpeta;                          // Guarda si el elemento es una carpeta o un archivo.
    }


    // Permite actualizar el tipo desde las operaciones del modelo.
    internal void CambiarTipo(bool esCarpeta)
    {
        EsCarpeta = esCarpeta;
    }

}