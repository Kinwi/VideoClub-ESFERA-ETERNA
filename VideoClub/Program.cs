using System;
using System.Data.SqlClient;

namespace VideoClub
{
    class Program
    {
        // Cadena de Conexion con la base de datos Microsoft SQL Server(BaseDeDatos = Videoclub)
        static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-T0M5LFO\\SQLEXPRESS;Initial Catalog=Videoclub;Integrated Security=True");

        public static void Videoclub()
        {
                
                // LOGIN VIDEOCLUB

                Console.WriteLine("VIDEOCLUB LA ESFERA ETERNA");
                Console.Write("Introduzca su Usuario          ");
                string usuario = Console.ReadLine();
                Console.Write("Introduzca su contraseña       ");
                string contraseña = Console.ReadLine();

               
                
                // MENU VIDEOCLUB
                
                Console.WriteLine("BienvenidO a el VIDEOCLUB ESFERA ETERNA");
                Console.WriteLine("");
                Console.WriteLine("MENU");
                Console.WriteLine("1.Ver Peliculas Disponibles");
                Console.WriteLine("2.Alquilar Pelicula");
                Console.WriteLine("3.Mis Alquileres");
                Console.WriteLine("4.Logout");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Introduzca el NUMERO asociado a la accion deL MENU");
                int select = Convert.ToInt32(Console.ReadLine());

        switch (select)
        {
            case 1:
                //verPelicularDisponibles(); // Metodo para que el usuario vea las peliculas disponibles
                break;
            case 2:
                //alquilarPelicula(); // Metodo para alquilar pelicula
                break;

            case 3:
                //misAquileres(); // Metodo para visualizar peliculas alquiladas
                break;

            case 4:
                //logout; //Metodo para realizar el logout
                break;

            default:
                Console.WriteLine("ERROR. Esta opcion no esta disponible en el Menu");
                break;
        }


      }
            


    }
}

    
