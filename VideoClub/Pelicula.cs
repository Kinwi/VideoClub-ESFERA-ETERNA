using System;
using System.Collections.Generic;
using System.Text;

namespace VideoClub
{
    class Pelicula
    {
        //Atributos de Pelicula con Getters y Setters

        public int IDPelicula { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis{ get; set; }

        public int EdadRecomendada { get; set; }
        public string Estado { get; set; }

        //Constructor de Pelicula con todos los atributos
        public Pelicula(int iDPelicula, string titulo, string sinopsis, int edadRecomendada, string estado)
        {
            IDPelicula = iDPelicula;
            Titulo = titulo;
            Sinopsis = sinopsis;
            EdadRecomendada = edadRecomendada;
            Estado = estado;
        }

        // Constructor por defecto de Pelicula (Por si hiciera falta)

        public Pelicula()
        {

        }
        

    }

    // Posibles metodos a utilizar
}
