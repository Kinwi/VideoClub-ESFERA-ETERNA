using System;
using System.Data.SqlClient;

namespace VideoClub
{
    class Program
    {
        // Cadena de Conexion con la base de datos Microsoft SQL Server(BaseDeDatos = Videoclub)
        static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-T0M5LFO\\SQLEXPRESS;Initial Catalog=Videoclub;Integrated Security=True");

        static void Main(string[] args)
        {
            // LLamada al Login
            Login();

            

        }

        // Metodo - MENU LOGIN -

        public static void Login() {

            // LOGIN VIDEOCLUB

            Console.WriteLine("LOGIN VIDEOCLUB ESFERA");
            Console.WriteLine();
            Console.WriteLine("MENU");
            Console.WriteLine("1.Iniciar Sesion");
            Console.WriteLine("2.Registrese");
            Console.WriteLine("3.Salir");
            Console.WriteLine();
            Console.WriteLine("Introduca el numero asociado a la accion");
            Console.WriteLine("Iniciar Sesion (1)-------------Registrese(2)----------Salir(3)");

            int select = Convert.ToInt32(Console.ReadLine());

            switch (select)
            {
                case 1:
                    Console.WriteLine(" LOGIN - VIDEOCLUB LA ESFERA ETERNA - ");
                    Console.Write("Introduzca su email   ");
                    string email = Console.ReadLine();
                    Console.Write("Introduzca su contraseña       ");
                    string contraseña = Console.ReadLine();
                    Usuario usuarioLogin = new Usuario(contraseña, email);

                    if ((usuarioLogin.ComprobarEmail() == true) && (usuarioLogin.ComprobarContraseña() == true))
                    {
                        Videoclub();
                    }

                    else
                    {
                        Login();
                    }

                    break;

                case 2:

                    Console.WriteLine("REGISTRESE COMO NUEVO USUARIO");
                    Console.WriteLine();
                    Console.Write("Introduzca su Nombre   ");
                    string nombreRegistro = Console.ReadLine();
                    Console.Write("Introduzca su Apellido   ");
                    string apellidoRegistro = Console.ReadLine();
                    Console.Write("Introduzca su Contraseña  ");
                    string contraseñaRegistro = Console.ReadLine();
                    Console.Write("Introduzca su Email   ");
                    string emailRegistro = Console.ReadLine();
                    Console.Write("Introduzca su Fecha De Nacimiento   ");
                    DateTime fechaNacimientoRegistro = Convert.ToDateTime(Console.ReadLine());


                    Usuario usuarioRegistro = new Usuario(nombreRegistro, apellidoRegistro,contraseñaRegistro,emailRegistro,fechaNacimientoRegistro);
                    usuarioRegistro.RegistrarUsuario();
                    break;

                case 3:
                   

                    break;

                case 4:
                  
                default:
                    Console.WriteLine("ERROR. Esta opcion no esta disponible en el Menu");
                    break;
            }






          


        }

        // METODO - MENU VIDEOCLUB -

        public static void Videoclub()
        {
                
               



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

    
