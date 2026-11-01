namespace Taller1DocuTrackBST.Models;


public class ArbolBinario                                                   // Administra la estructura del arbol binario de búsqueda.
{
    public Nodo? Raiz { get; private set; }                                 // Representa el primer nodo del arbol. Si es null, el arbol está vacío.

    // Compara nombres sin distinguir mayúsculas y minúsculas.
    private static readonly StringComparer Comparador =
        StringComparer.OrdinalIgnoreCase;



    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Insertar
    
    public ResultadoOperacion Insertar(string nombre, bool esCarpeta)       // Inserta un nodo y devuelve el resultado de la operación.
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Validaciones antes de insertar un elemento.
    
        if (string.IsNullOrWhiteSpace(nombre))             // Validamos que el nombre no sea nulo ni esté vacío.
        {
            return new ResultadoOperacion(false, "Error: El nombre no puede estar vacío.");
        }
        nombre = nombre.Trim();                            // Eliminamos espacios al inicio y al final.

        if (nombre.Length != 1)                            // Validamos que el nombre solo tenga una letra. Restringimos el ejercicio a una letra
        {
            return new ResultadoOperacion(false, "Error: Debes ingresar solo una letra.");
        }
        else if (!char.IsLetter(nombre[0]))                // Validamos que el nombre sea una letra valida, no un caracter especial o un numero.
        {
            return new ResultadoOperacion(false, "Error: El elemento debe ser una letra válida, no un caracter especial ni un número.");
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        /// Insertar Raiz
        if (Raiz == null)                   // Si el árbol está vacío, el nuevo nodo será la raíz.
        {
            Raiz = new Nodo(nombre, esCarpeta);

            return new ResultadoOperacion(true, $"'{nombre}' Insertado como raíz.");
        }

        // Comenzamos desde la raiz.
        Nodo actual = Raiz;

        // Contador de comparaciones.
        int comparaciones = 0;

        // Recorremos el arbol hasta encontrar una posición libre.
        while (true)
        {
            // Comparamos el nombre nuevo con el nombre actual.
            int comparacion = Comparador.Compare(nombre, actual.Nombre);

            // Registramos la comparación.
            comparaciones++;

            // Si los nombres son iguales, rechazamos el duplicado.
            if (comparacion == 0)
            {
                return new ResultadoOperacion(false, $"El nombre '{nombre}' ya existe.", comparaciones);
            }

            // Si el nombre nuevo es menor, avanzamos a la izquierda.
            if (comparacion < 0)
            {
                // Si no hay hijo izquierdo, insertamos aquí.
                if (actual.Izquierdo == null)
                {
                    actual.Izquierdo = new Nodo(nombre, esCarpeta);

                    return new ResultadoOperacion(true, $"'{nombre}' insertado a la izquierda de '{actual.Nombre}'.",
                        comparaciones);
                }

                // Continuamos por el subárbol izquierdo.
                actual = actual.Izquierdo;
            }
            else
            {
                // Si no hay hijo derecho, insertamos aqui.
                if (actual.Derecho == null)
                {
                    actual.Derecho = new Nodo(nombre, esCarpeta);

                    return new ResultadoOperacion(true,$"'{nombre}' insertado a la derecha de '{actual.Nombre}'.",
                        comparaciones);
                }

                // Continuamos por el subárbol derecho.
                actual = actual.Derecho;
            }
        }
    }



    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Buscar

    public ResultadoOperacion Buscar(string nombre)
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Validaciones antes de buscar un elemento.
    
        if (string.IsNullOrWhiteSpace(nombre))             // Validamos que el nombre no sea nulo ni esté vacío.
        {
            return new ResultadoOperacion(false,"Error. El nombre no puede estar vacío.");
        }
        nombre = nombre.Trim();                            // Eliminamos espacios al inicio y al final.

        if (nombre.Length != 1)                            // Validamos que el nombre solo tenga una letra. Restringimos el ejercicio a una letra
        {
            return new ResultadoOperacion(false, "Error: Debes ingresar solo una letra.");
        }
        else if (!char.IsLetter(nombre[0]))                // Validamos que el nombre sea una letra valida, no un caracter especial o un numero.
        {
            return new ResultadoOperacion(false, "Error: El elemento debe ser una letra válida, no un caracter especial ni un número.");
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Nodo? actual = Raiz;
        int comparaciones = 0;

        while (actual != null)
        {
            int comparacion = Comparador.Compare(nombre,actual.Nombre);

            comparaciones++;

            if (comparacion == 0)
            {
                return new ResultadoOperacion(true,$"'{nombre}' fue encontrado.",comparaciones);
            }

            actual = comparacion < 0 ? actual.Izquierdo: actual.Derecho;
        }

        return new ResultadoOperacion(false, $"'{nombre}' no fue encontrado.",comparaciones);
    }



    ///////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////
    // Eliminar

    public ResultadoOperacion Eliminar(string nombre)
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Validaciones antes de eliminar un elemento.
    
        if (string.IsNullOrWhiteSpace(nombre))             // Validamos que el nombre no sea nulo ni esté vacío.
        {
            return new ResultadoOperacion(false,"Error. El nombre no puede estar vacío.");
        }
        nombre = nombre.Trim();                            // Eliminamos espacios al inicio y al final.

        if (nombre.Length != 1)                            // Validamos que el nombre solo tenga una letra. Restringimos el ejercicio a una letra
        {
            return new ResultadoOperacion(false, "Error: Debes ingresar solo una letra.");
        }
        else if (!char.IsLetter(nombre[0]))                // Validamos que el nombre sea una letra valida, no un caracter especial o un numero.
        {
            return new ResultadoOperacion(false, "Error: El elemento debe ser una letra válida, no un caracter especial ni un número.");
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        bool eliminado = false;

        Raiz = EliminarRecursivo(Raiz,nombre,ref eliminado);

        if (eliminado)
        {
            return new ResultadoOperacion(true,$"'{nombre}' fue eliminado.");
        }

        return new ResultadoOperacion(false,$"'{nombre}' no fue encontrado.");
    }

    
    private Nodo? EliminarRecursivo(Nodo? nodo,string nombre,ref bool eliminado)
    {
        if (nodo == null)
            return null;

        int comparacion = Comparador.Compare(nombre,nodo.Nombre);

        if (comparacion < 0)
        {
            nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo,nombre,ref eliminado);
        }
        else if (comparacion > 0)
        {
            nodo.Derecho = EliminarRecursivo(nodo.Derecho,nombre,ref eliminado);
        }
        else
        {
            eliminado = true;
            // Caso 1: no tiene hijos.
            if (nodo.Izquierdo == null && nodo.Derecho == null)
                return null;

            // Caso 2: tiene un solo hijo.
            if (nodo.Izquierdo == null)
                return nodo.Derecho;

            if (nodo.Derecho == null)
                return nodo.Izquierdo;

            // Caso 3: tiene dos hijos.
            Nodo sucesor = ObtenerMinimo(nodo.Derecho);

            nodo.Nombre = sucesor.Nombre;
            nodo.CambiarTipo(sucesor.EsCarpeta);

            nodo.Derecho = EliminarMinimo(nodo.Derecho);
        }

        return nodo;
    }

    private Nodo ObtenerMinimo(Nodo nodo)
    {
        while (nodo.Izquierdo != null)
            nodo = nodo.Izquierdo;

        return nodo;
    }

    private Nodo? EliminarMinimo(Nodo? nodo)
    {
        if (nodo == null)
            return null;

        if (nodo.Izquierdo == null)
            return nodo.Derecho;

        nodo.Izquierdo = EliminarMinimo(nodo.Izquierdo);

        return nodo;
    }



    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Actualizar
    
    public ResultadoOperacion Actualizar(string nombreAnterior,string nombreNuevo)
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Validaciones antes de actualizar un elemento.
        
        if (string.IsNullOrWhiteSpace(nombreAnterior) || string.IsNullOrWhiteSpace(nombreNuevo))
        {
            return new ResultadoOperacion(false, "Los nombres no pueden estar vacíos.");
        }

        nombreAnterior = nombreAnterior.Trim();
        nombreNuevo = nombreNuevo.Trim();

        /////////////////////////////////////////
        //Validamos el dato nuevo
        if (nombreNuevo.Length != 1)                            // Validamos que el nombreNuevo solo tenga una letra. Restringimos el ejercicio a una letra
        {
            return new ResultadoOperacion(false, "Error: Debes ingresar solo una letra.");
        }
        else if (!char.IsLetter(nombreNuevo[0]))                // Validamos que el nombreNuevo sea una letra valida, no un caracter especial o un numero.
        {
            return new ResultadoOperacion(false, "Error: El elemento debe ser una letra válida, no un caracter especial ni un número.");
        }
        /////////////////////////////////////////
        
        
        Nodo? nodo = BuscarNodo(Raiz, nombreAnterior);

        if (nodo == null)
        {
            return new ResultadoOperacion(false,$"'{nombreAnterior}' no existe.");
        }

        if (Comparador.Equals(nombreAnterior, nombreNuevo))
        {
            return new ResultadoOperacion(true,"El nombre no necesita cambios.");
        }

        if (BuscarNodo(Raiz, nombreNuevo) != null)
        {
            return new ResultadoOperacion(false,$"'{nombreNuevo}' ya existe.");
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        bool esCarpeta = nodo.EsCarpeta;

        ResultadoOperacion eliminacion = Eliminar(nombreAnterior);

        if (!eliminacion.Exito)
        {
            return eliminacion;
        }

        return Insertar(nombreNuevo, esCarpeta);
    }

    private Nodo? BuscarNodo(Nodo? nodo, string nombre)
    {
        while (nodo != null)
        {
            int comparacion = Comparador.Compare(nombre,nodo.Nombre);

            if (comparacion == 0)
                return nodo;

            nodo = comparacion < 0? nodo.Izquierdo: nodo.Derecho;
        }

        return null;
    }



    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Recorrido preorden: raíz, izquierda, derecha.
    
    public List<string> Preorden()
    {
        List<string> resultado = new List<string>();

        PreordenRecursivo(Raiz, resultado);

        return resultado;
    }

    private void PreordenRecursivo(Nodo? nodo,List<string> resultado)
    {
        if (nodo == null)
            return;

        resultado.Add(nodo.Nombre);

        PreordenRecursivo(nodo.Izquierdo, resultado);
        PreordenRecursivo(nodo.Derecho, resultado);
    }



    /////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// Recorrido Inorden
    
    public List<string> Inorden()
    {
        List<string> resultado = new List<string>();

        InordenRecursivo(Raiz, resultado);

        return resultado;
    }

    private void InordenRecursivo(Nodo? nodo,List<string> resultado)
    {
        if (nodo == null)
            return;

        InordenRecursivo(nodo.Izquierdo, resultado);

        resultado.Add(nodo.Nombre);

        InordenRecursivo(nodo.Derecho, resultado);
    }



//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
/// Recorrido Postorden

    public List<string> Postorden()
    {
        List<string> resultado = new List<string>();

        PostordenRecursivo(Raiz, resultado);

        return resultado;
    }

    private void PostordenRecursivo(Nodo? nodo,List<string> resultado)
    {
        if (nodo == null)
            return;

        PostordenRecursivo(nodo.Izquierdo, resultado);

        PostordenRecursivo(nodo.Derecho, resultado);

        resultado.Add(nodo.Nombre);
    }



////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Recorre el árbol nivel por nivel utilizando una cola.
    
    public List<string> PorNiveles()
    {
        List<string> resultado = new List<string>();

        if (Raiz == null)
            return resultado;

        Queue<Nodo> cola = new Queue<Nodo>();

        cola.Enqueue(Raiz);

        while (cola.Count > 0)
        {
            Nodo actual = cola.Dequeue();

            resultado.Add(actual.Nombre);

            if (actual.Izquierdo != null)
                cola.Enqueue(actual.Izquierdo);

            if (actual.Derecho != null)
                cola.Enqueue(actual.Derecho);
        }

        return resultado;
    }




    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// Calcula la altura total del árbol.
    public int Altura()
    {
        return CalcularAltura(Raiz);
    }

    // Calcula recursivamente la altura de cada subárbol.
    private int CalcularAltura(Nodo? nodo)
    {
        if (nodo == null)                                                   // Un árbol vacío tiene altura cero.
        {
            return 0;
        }

        int alturaIzquierda = CalcularAltura(nodo.Izquierdo);               // Calculamos la altura del subárbol izquierdo.

        int alturaDerecha = CalcularAltura(nodo.Derecho);                   // Calculamos la altura del subárbol derecho.

        return 1 + Math.Max(alturaIzquierda, alturaDerecha);                // La altura es el mayor subárbol más el nivel del nodo actual.
    }
 
}
    
    