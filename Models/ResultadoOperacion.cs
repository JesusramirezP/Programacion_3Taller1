namespace Taller1DocuTrackBST.Models;


public class ResultadoOperacion                                     // Contiene el resultado de una operación realizada por el árbol.
{
    public bool Exito { get; }                                      // Indica si la operación tuvo éxito.

    public string Mensaje { get; }                                  // Describe el resultado de la operación.

    public int Comparaciones { get; }                               // Registra cuántas comparaciones se realizaron.

    // Constructor que inicializa los datos del resultado.
    public ResultadoOperacion(bool exito, string mensaje, int comparaciones = 0)
    {
        Exito = exito;
        Mensaje = mensaje;
        Comparaciones = comparaciones;
    }
}