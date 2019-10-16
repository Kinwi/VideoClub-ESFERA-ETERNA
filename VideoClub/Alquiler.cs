using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace VideoClub
{
    class Alquiler
    {
       
        
        // Atributos , Getters y Setters de Alquiler

        public int IdAlquiler{ get; set; }
        public int IdPelicula { get; set; }
        public int IdUsuario { get; set; }

        public DateTime FechaInicialAlquiler { get; set; }

        public DateTime FechaFinalAlquiler { get; set; }


        // Constructor por defecto de Alquiler 

        public Alquiler(){
        }
        
        // Constructor con todos los argumentos de Alquiler

        public Alquiler(int idAlquiler, int idPelicula, int idUsuario, DateTime fechaInicialAlquiler, DateTime fechaFinalAlquiler)
        {
            IdAlquiler = idAlquiler;
            IdPelicula = idPelicula;
            IdUsuario = idUsuario;
            FechaInicialAlquiler = fechaInicialAlquiler;
            FechaFinalAlquiler = fechaFinalAlquiler;
        }
    }

    // Espacio para los posibles metodos de la clase Alquiler
}
