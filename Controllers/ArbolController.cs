
using Taller1DocuTrackBST.Models;
using Taller1DocuTrackBST.Views;

namespace Taller1DocuTrackBST.Controllers;

// Coordina el Model y la View.
public class ArbolController
{
    private readonly ArbolBinario _arbol;
    private readonly ArbolVista _vista;

    public ArbolController()
    {
        _arbol = new ArbolBinario();
        _vista = new ArbolVista();
    }

    public void Iniciar()
    {
        ///////////////////////////////////////////////////////////////////////////////
        // Insercion de 14 elementos en el arbol.

        _vista.MostrarMensaje("");                                                      //Salto de renglo
        _vista.MostrarMensaje("************ Insertar 14 elementos ************");       //Mostrar mensaje
        _vista.MostrarMensaje("");                                                      //Salto de renglo

        //Arreglo para insertar los 14 elementos
        string[] nombres =
        {
            "M", "H", "T", "D", "J", "P", "W",
            "B", "F", "I", "K", "N", "R", "Z"
        };

        int conteo_insert = 0;                                                                  //Variable de conteo para mostar el orden en la consola
        foreach (string nombre in nombres)
        {
            conteo_insert++;                                                                    //Incrementa la variable de conteo
            ResultadoOperacion insercion = _arbol.Insertar(nombre, true);

            _vista.MostrarConteo(conteo_insert);                                                //Mustra el valor de la variable de conteo
            _vista.MostrarResultado("Elemento insertado",insercion);                            //Muestra la operacion
        }

        _vista.MostrarArbol(_arbol.Raiz);           //Mustra el arbol 
        _vista.MostrarMensaje("");                  // Salto de linea
        _vista.MostrarMensaje("- Hacia la izquierda (├──): los nodos menores que el padre.");   //Informacion para interpretar el arbol
        _vista.MostrarMensaje("- Hacia la derecha (└──): los nodos mayores que el padre.");     //Informacion para interpretar el arbol
        _vista.MostrarMensaje("---------------------------------------------");
        _vista.MostrarMensaje("---------------------------------------------");

        

        ////////////////////////////////////////////////////////////////////////
        // Realizamos seis busquedas.

        _vista.MostrarMensaje("");                                              //Salto de renglo
        _vista.MostrarMensaje("************ Buscar 6 elementos ************");  //Mostrar mensaje
        _vista.MostrarMensaje("");                                              //Salto de renglo

        //Arreglo para buscar los 6 elementos
        string[] nombresBuscar =
        {
            "D", "B",       // Dos busquedas por la izquierda.
            "T", "Z",       // Dos busquedas por la derecha.
            "A", "X"        // Dos nombres inexistentes.
        };

        int conteo_buscar = 0;                                                  //Variable de conteo para mostar el orden en la consola
        foreach (string nombre in nombresBuscar)                                //Ciclo para realizar la busqueda
        {
            conteo_buscar++;                                                    //Incrementa la variable de conteo
            ResultadoOperacion busqueda = _arbol.Buscar(nombre);

            _vista.MostrarConteo(conteo_buscar);                                //Mustra el valor de la variable de conteo
            _vista.MostrarResultado($"Buscar '{nombre}'", busqueda);            //Mustra el resultrado de la busqueda
            _vista.MostrarMensaje("");
        }
        _vista.MostrarMensaje("---------------------------------------------");
        _vista.MostrarMensaje("---------------------------------------------");



        ///////////////////////////////////////////////////////////////////////
        //Realizamos tres actualizaciones

        _vista.MostrarMensaje("");                                              //Salto de renglo
        _vista.MostrarMensaje("********** Actualizar 3 elementos **********");  //Mostar mensaje
        _vista.MostrarMensaje("");                                              //Salto de renglo


        int conteo_actualizar =1;                                               //Variable de conteo para mostar el orden en la consola
        
        // Primera actualizacion: nodo hoja.
        _vista.MostrarConteo(conteo_actualizar);                                //Muestra el valor de la variable de conteo
        ResultadoOperacion actualizacion1 = _arbol.Actualizar("B", "C");        //Actualizacion   

        _vista.MostrarResultado("Actualizado nodo hoja", actualizacion1);       //Mostar mensaje de actualizacion

        _vista.MostrarArbol(_arbol.Raiz);                                       //Mostar arbol
        _vista.MostrarMensaje("");                                              //Saltar renglon



        // Segunda actualizacion: nodo con un hijo.
        conteo_actualizar++;                                                    //Incrementa la variable de conteo
        _vista.MostrarConteo(conteo_actualizar);                                //Muestra el valor de la variable de conteo
        ResultadoOperacion actualizacion2 = _arbol.Actualizar("W", "Y");        //Actualizacion

        _vista.MostrarResultado("Actualizado nodo con un hijo", actualizacion2);    //Mostar mensaje de actualizacion

        _vista.MostrarArbol(_arbol.Raiz);                                        //Mostar arbol
        _vista.MostrarMensaje("");                                               //Saltar renglon



        // Tercera actualizacion: raiz.
        conteo_actualizar++;                                                    //Incrementa la variable de conteo
        _vista.MostrarConteo(conteo_actualizar);                                //Muestra el valor de la variable de conteo
        ResultadoOperacion actualizacion3 = _arbol.Actualizar("M", "O");        //Actualizacion

        _vista.MostrarResultado("Raiz actualizada", actualizacion3);            //Mostar mensaje de actualizacion

        _vista.MostrarArbol(_arbol.Raiz);                                       //Mostar arbol
        _vista.MostrarMensaje("");                                              //Saltar renglon
        _vista.MostrarMensaje("---------------------------------------------");
        _vista.MostrarMensaje("---------------------------------------------");



        ///////////////////////////////////////////////////////////////////////
        /// Realizamos tres eliminaciones
        
        _vista.MostrarMensaje("");                                              //Salto de renglo
        _vista.MostrarMensaje("********** Eliminar 3 elementos **********");    //Mostar mensaje
        _vista.MostrarMensaje("");                                              //Salto de renglo
        
        int conteo_eliminar =1;                                                 //Variable de conteo para mostar el orden en la consola

        // Primera eliminacion: nodo hoja.
        _vista.MostrarConteo(conteo_eliminar);                                  //Muestra el valor de la variable de conteo
        ResultadoOperacion eliminacion1 = _arbol.Eliminar("C");                 //Eliminacion

        _vista.MostrarResultado( "Eliminado nodo hoja", eliminacion1);          //Mostar mensaje de eliminacion
        _vista.MostrarArbol(_arbol.Raiz);                                       //Mostrar arbol
        _vista.MostrarMensaje("");                                              //Saltar renglon



        // Segunda eliminacion: nodo con un hijo.
        conteo_eliminar++;                                                      //Incrementa la variable de conteo                                                             
        _vista.MostrarConteo(conteo_eliminar);                                  //Muestra el valor de la variable de conteo
        ResultadoOperacion eliminacion2 = _arbol.Eliminar("Z");                 //Eliminacion

        _vista.MostrarResultado("Eliminado nodo con un hijo", eliminacion2);    //Mostar mensaje de eliminacion
        _vista.MostrarArbol(_arbol.Raiz);                                       //Muestra arbol
        _vista.MostrarMensaje("");                                              //Saltar renglon



        // Tercera eliminación: raiz con dos hijos.
        conteo_eliminar++;                                                      //Incrementa la variable de conteo 
        _vista.MostrarConteo(conteo_eliminar);                                  //Muestra el valor de la variable de conteo
        ResultadoOperacion eliminacion3 = _arbol.Eliminar("N");                 //Eliminacion

        _vista.MostrarResultado("Eliminada raíz con dos hijos", eliminacion3);  //Mostar mensaje de eliminacion
        _vista.MostrarArbol(_arbol.Raiz);                                       //Muestra arbol
        _vista.MostrarMensaje("---------------------------------------------");
        _vista.MostrarMensaje("---------------------------------------------");


        ///////////////////////////////////////////////////////////////////////
        /// Mostramos los cuatro recorridos.
        

        _vista.MostrarMensaje("");                                              //Salto de renglo
        _vista.MostrarMensaje("************** Recorridos **************");      //Muestra mensaje
        _vista.MostrarMensaje("");                                              //Salto de renglo

        _vista.MostrarRecorrido("Recorrido Preorden:", _arbol.Preorden());      

        _vista.MostrarRecorrido("Recorrido Inorden:", _arbol.Inorden());

        _vista.MostrarRecorrido("Recorrido Postorden:", _arbol.Postorden());

        _vista.MostrarRecorrido("Recorrido Por niveles:", _arbol.PorNiveles());


        _vista.MostrarMensaje("---------------------------------------------");
        _vista.MostrarMensaje("---------------------------------------------");


        ///////////////////////////////////////////////////////////////////////
        // Mostramos la estructura grafica del arbol.

        _vista.MostrarMensaje("");                                              //Salto de renglo
        _vista.MostrarMensaje("************** Árbol y altura **************");  //Muestra mensaje
        _vista.MostrarMensaje("");                                              //Salto de renglon

        _vista.MostrarArbol(_arbol.Raiz);

        //////////////////////////////////////////////////////////////////////
        // Mostramos la altura del arbol.
        _vista.MostrarAltura(_arbol.Altura());

        _vista.MostrarMensaje("---------------------------------------------");
        _vista.MostrarMensaje("---------------------------------------------");

    }



}
