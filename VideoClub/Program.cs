using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

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

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                       LOGIN VIDEOCLUB ESFERA");
            Console.WriteLine();
            Console.WriteLine("                                                MENU");
            Console.WriteLine("                                          1.Iniciar Sesion");
            Console.WriteLine("                                           2.Registrese");
            Console.WriteLine("                                              3.Salir");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                               Introduca el numero asociado a la accion");
            Console.WriteLine("                     Iniciar Sesion (1)-------------Registrese(2)----------Salir(3)");

            int select = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (select)
            {
                case 1:

                    // Expresion para validar que la estructura de un email es correcta

                    String expresion;
                    expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("                                   LOGIN                        ");
                    Console.WriteLine();
                    Console.Write("          Introduzca su email   ");
                    string email = Console.ReadLine();

                    // Validacion de la estructura del email
                    if (Regex.IsMatch(email, expresion))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("                                                       El email tiene la estructura correcta");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Clear();
                        Login();
                    }
                    Console.WriteLine("");
                    Console.Write("         Introduzca su contraseña       ");
                    
                    string contraseña = Console.ReadLine();
                  
                    
                    Usuario usuarioLogin = new Usuario(contraseña, email);
                    Console.Clear();
                    usuarioLogin = usuarioLogin.ComprobarEmailContraseña();

                    if (usuarioLogin != null)
                    {
                        Console.Clear();
                        Videoclub(usuarioLogin);
                    }

                    else
                    {
                        Login();
                    }

                    break;

                case 2:

                    Console.WriteLine();
                    Console.WriteLine("REGISTRESE COMO NUEVO USUARIO");
                    Console.WriteLine();
                    Console.Write("Introduzca su Nombre  ------------------------------------ ");
                    string nombreRegistro = Console.ReadLine();
                    Console.Write("Introduzca su Apellido -----------------------------------  ");
                    string apellidoRegistro = Console.ReadLine();
                    Console.Write("Introduzca su Contraseña --------------------------------- ");
                    string contraseñaRegistro = Console.ReadLine();
                    Console.Write("Introduzca su Email  ------------------------------------- ");
                    string emailRegistro = Console.ReadLine();
                    Console.Write("Introduzca su Fecha De Nacimiento  ------------------------ ");
                    DateTime fechaNacimientoRegistro = Convert.ToDateTime(Console.ReadLine());


                    Usuario usuarioRegistro = new Usuario(nombreRegistro, apellidoRegistro,contraseñaRegistro,emailRegistro,fechaNacimientoRegistro);
                    usuarioRegistro.RegistrarUsuario();
                    Console.Clear();
                    Login();
                    break;

                case 3:
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("********************************************************************");
                    Console.WriteLine("********************************************************************");
                    Console.WriteLine("Gracias por utilizar la aplicacion ----Videoclub ESFERA ETERNA---------");
                    Console.WriteLine("********************************************************************");
                    Console.WriteLine("********************************************************************");
                    break;
                    
                default:
                    Console.WriteLine("ERROR. Esta opcion no esta disponible en el Menu");
                    Console.Clear();
                    Login();
                    break;
            }






          


        }

        // METODO - MENU VIDEOCLUB -

        public static void Videoclub(Usuario usuarioLogin)
        {





            // MENU VIDEOCLUB
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                          Bienvenido a el VIDEOCLUB ESFERA ETERNA");
                Console.WriteLine("");
                Console.WriteLine("                                          MENU");
                Console.WriteLine("                             1.Ver Peliculas Disponibles");
                Console.WriteLine("                                 2.Alquilar Pelicula");
                Console.WriteLine("                                   3.Mis Alquileres");
                Console.WriteLine("                                        4.Logout");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("                               Introduca el numero asociado a la accion");
                Console.WriteLine();
                Console.WriteLine("  Ver Peliculas Disponibles (1)-------------AlquilarPeliculas(2)----------Mis Alquileres(3)--------Logout(4)");
            int select = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (select)
             {
                case 1:

                    string salir = "";
                    do { 
                    Console.WriteLine($"PELICULAS SELECCIONADAS PARA TI ");
                    usuarioLogin.verPeliculasDisponibles();
                    Console.Clear();
                    Videoclub(usuarioLogin);
                    while(salir)

                    break;
                case 2:
                    usuarioLogin.alquilarPelicula(); // Metodo para alquilar pelicula
                    break;

                case 3:
                    usuarioLogin.misAlquileres(); // Metodo para visualizar peliculas alquiladas
                    break;

                case 4:
                    // LOGOUT . Te redirije a la pantalla del Login
                    Login();
                    break;

                default:
                    Console.WriteLine("ERROR. Esta opcion no esta disponible en el Menu");
                    Console.Clear();
                    Videoclub(usuarioLogin);
                    break;
             }

        }
            


    }
}

    
