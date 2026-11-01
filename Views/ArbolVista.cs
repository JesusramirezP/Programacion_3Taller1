
using Taller1DocuTrackBST.Models;
namespace Taller1DocuTrackBST.Views;

// Se encarga de presentar los resultados en la consola.
public class ArbolVista
{
    //Procedimiento para mostar un mensaje general en consola
    public void MostrarMensaje(string mensaje)  // Muestra un mensaje general en la consola.
    {
        Console.WriteLine(mensaje);
    }



    // Procedimiento para mostrar el resultado de una operación del árbol.
    public void MostrarResultado(string operacion, ResultadoOperacion resultado)
    {
        string estado = resultado.Exito ? "Operación satisfactoria." : "Operación fallida.";

        Console.WriteLine($"{estado} {operacion}");
        Console.WriteLine(resultado.Mensaje);

        if (resultado.Comparaciones > 0)
        {
            Console.WriteLine(
                $"Comparaciones: {resultado.Comparaciones}");
        }
    }

    


    // Procedimiento para mostrar el recorrido 
    public void MostrarRecorrido(string nombreRecorrido, List<string> resultado)    
    {
        Console.WriteLine(nombreRecorrido);                                         // Mostramos en consola 

        if (resultado.Count == 0)                                                   //Consultamos si el arbol no esta vacio
        {
            Console.WriteLine("El árbol está vacío.");                              //Muestra mensaje en consola
            return;
        }

        Console.WriteLine(string.Join(" -> ", resultado));                          //Mustra resultado en consola separando con ->       
    }



    ///////////////////////////////////////////////////////////////////
    /// Mostrar la representacion grafica del arbol
    
    public void MostrarArbol(Nodo? raiz)
    {
        Console.WriteLine(" ");
        Console.WriteLine("********* Estructura del árbol *********");           // Se muestra mensaje en consola

        if (raiz == null)                                                       // Se consulta si el arbol esta vacio o no
        {
            Console.WriteLine("El árbol está vacío.");                          // Muestra mensaje en consola
            return;
        }

        Console.WriteLine(raiz.Nombre);                                         // Inicia mostrando la raiz

        MostrarHijos(raiz.Izquierdo, "", false);                                // 
        MostrarHijos(raiz.Derecho, "", true);
    }



    private void MostrarHijos(Nodo? nodo, string prefijo, bool esDerecho)
    {
        if (nodo == null)
            return;

        // Hacia la izquierda (├──): los nodos menores que el padre.
        // Hacia la derecha (└──): los nodos mayores que el padre.
        string conector = esDerecho ? "└── " : "├── ";                           //Para el primer simbolo (└──)se optiene con Alt+192 - Alt+196 (x2), Para el segundo simbolo (├──) se optiene con Alt+195 - Alt+196 (x2)

        Console.WriteLine(prefijo + conector + nodo.Nombre);

        string nuevoPrefijo = prefijo + (esDerecho ? "    " : "│   ");           //Para este simbolo ( │ ) se optiene con Alt+179 

        MostrarHijos(nodo.Izquierdo, nuevoPrefijo, false);
        MostrarHijos(nodo.Derecho, nuevoPrefijo, true);
    }



    ////////////////////////////////////////////////////////////////////
    /// Mostrar altura del arbol
    
    public void MostrarAltura(int altura)
    {
        Console.WriteLine($"Altura del árbol: {altura}");
    }


    ////////////////////////////////////////////////////////////////////
    /// Mostrar conteos para ordenamiento de pasos en consola
    
    public void MostrarConteo(int cont)
    {
        Console.Write($"{cont}. ");
    }


}
