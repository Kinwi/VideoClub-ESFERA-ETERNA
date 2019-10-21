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
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                                       LOGIN VIDEOCLUB ESFERA");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                                                MENU");
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                          1.Iniciar Sesion");
            Console.WriteLine();
            Console.WriteLine("                                           2.Registrese");
            Console.WriteLine();
            Console.WriteLine("                                              3.Salir");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("              *Introduzca el numero asociado a cada accion. Ejemplo : Ver Peliculas Disponibles (1)");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            

            int select;
            try
            {
                  select = Convert.ToInt32(Console.ReadLine());
                Console.Clear(); ;
                switch (select)
                {
                    case 1:

                        // Expresion para validar que la estructura de un email es correcta

                        String expresion;
                        expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("                                   LOGIN                        ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("          Introduzca su email   ");
                        Console.ResetColor();
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
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("         Introduzca su contraseña       ");
                        Console.ResetColor();

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
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERROR. Usuario / Contraseña   Incorrectos");
                            Console.ResetColor();
                            Console.WriteLine();
                            Console.Clear();
                            Login();
                        }

                        break;

                    case 2:

                        // Expresion para validar que la estructura de un email es correcta

                        String expresion1;
                        expresion1 = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("REGISTRESE COMO NUEVO USUARIO");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Introduzca su Nombre  ------------------------------------ ");
                        Console.ResetColor();
                        string nombreRegistro = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Introduzca su Apellido -----------------------------------  ");
                        Console.ResetColor();
                        string apellidoRegistro = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Introduzca su Contraseña --------------------------------- ");
                        Console.ResetColor();
                        string contraseñaRegistro = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Introduzca su Email  ------------------------------------- ");
                        Console.ResetColor();


                        //Validar estructura de Email con Regex
                        string emailRegistro = Console.ReadLine();
                        if (Regex.IsMatch(emailRegistro, expresion1))
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" El email tiene la estructura correcta");
                            Console.WriteLine();
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" ERROR!!!! El Email no tiene la estructura correcta");
                            Console.ResetColor();
                            Console.ReadKey();
                            Console.Clear();
                            Login();

                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Introduzca su Fecha De Nacimiento  ------------------------ ");
                        Console.ResetColor();
                        // Captura la excepcion "FormatException" de Datetime "fechaNacimientoRegistro"

                        try
                        {
                            DateTime fechaNacimientoRegistro = Convert.ToDateTime(Console.ReadLine());

                            Usuario usuarioRegistro = new Usuario(nombreRegistro, apellidoRegistro, contraseñaRegistro, emailRegistro, fechaNacimientoRegistro);
                            usuarioRegistro.RegistrarUsuario();
                            Console.Clear();
                            Login();

                        }
                        catch (FormatException)

                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine();
                            Console.WriteLine("ERROR!!!! No introduzca fechas con valores incorrectos. ");
                            Console.WriteLine("Pulse cualquier tecla para volver al --MENU LOGIN--");
                            Console.WriteLine();
                            Console.ResetColor();
                            Console.ReadKey();
                            Console.Clear();
                            Login();
                        }

                        break;

                    case 3:
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("********************************************************************");
                        Console.WriteLine("********************************************************************");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Gracias por utilizar la aplicacion ----Videoclub ESFERA ETERNA------");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("********************************************************************");
                        Console.WriteLine("********************************************************************");
                        Console.ResetColor();
                        break;

                    default:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR. Esta opcion no esta disponible en el Menu");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        Login();
                        break;
                }

            }
            catch (Exception)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR!!!!. No hay ninguna accion al menu asociada a una letra o palabra");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
                Login();
            }


            }

            // METODO - MENU VIDEOCLUB -

            public static void Videoclub(Usuario usuarioLogin)
        {

            // MENU VIDEOCLUB

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("                             Bienvenido a el VIDEOCLUB ESFERA ETERNA");
                Console.WriteLine();
                Console.WriteLine("");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("                                            MENU");
                Console.WriteLine();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("                                  1.Ver Listado de  Peliculas");
                Console.WriteLine();
                Console.WriteLine("                                    2.Alquilar Pelicula");
                Console.WriteLine();
                Console.WriteLine("                                     3.Mis Alquileres");
                Console.WriteLine();
                Console.WriteLine("                                         4.Logout");
                Console.ResetColor();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("        *Introduzca el numero asociado a cada accion. Ejemplo : Ver Peliculas Disponibles (1)");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                int select = Convert.ToInt32(Console.ReadLine());
                //Console.Clear();


            switch (select)
             {
                case 1:
                    
                    // 1. VER PELICULAS DISPONIBLES
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("LISTADO PELICULAS VIDEOCLUB - ESFERA ETERNA -");
                    Console.ResetColor();
                    usuarioLogin.verListadoPeliculas(usuarioLogin);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Pulse cualquier tecla para volver al - Menu Videoclub ESFERA ETERNA");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                    Videoclub(usuarioLogin);
             
                    break;
                case 2:

                    // 2. ALQUILAR PELICULA
                    Console.Clear();
                    usuarioLogin.alquilarPelicula(); // Metodo para alquilar pelicula
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    Console.WriteLine("Pulse 0 para -Volver al Menu del Videoclub   Pulse Cualquier otra tecla para - Alquilar Pelicula -"  );
                    int volverMenu = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();
                    if (volverMenu == 0)
                    {
                        Console.Clear();
                        Videoclub(usuarioLogin);

                    }
                    if (volverMenu ==1)
                    {
                        connection.Open();
                        Console.WriteLine("Introduzca la pelicula a Alquilar . Ejemplo 3");
                        int peliculaAlquilada = Convert.ToInt32(Console.ReadLine());
                        DateTime fechaAlquiler = DateTime.Now; // Fecha Alquiler = Fecha Hoy
                        string actualizarAlquiler = $"UPDATE Pelicula SET Estado = 'ND' WHERE IDPelicula = '{peliculaAlquilada}'INSERT INTO Alquiler (IdPelicula,IdUsuario,FechaInicialAlquiler) VALUES ('{peliculaAlquilada}','{usuarioLogin.IDUsuario}','{fechaAlquiler}')";
                        SqlCommand command2 = new SqlCommand(actualizarAlquiler, connection);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("$Ha alquilado la pelicula +  {peliculaAlquilada} + del catalogo ");
                        Console.ResetColor();
                        connection.Close();
                    }

                   

                    break;

                case 3:
                    // 3. MIS ALQUILERES
                    Console.Clear();
                    usuarioLogin.misAlquileres(usuarioLogin); // Metodo para visualizar peliculas alquiladas
                    break;

                case 4:
                    // LOGOUT . Te redirije a la pantalla del Login
                    Console.Clear();
                    Login();
                    break;

                default:
                    //Console.WriteLine("ERROR. Esta opcion no esta disponible en el Menu");
                    Console.Clear();
                    Videoclub(usuarioLogin);
                    break;
             }

        }
            


    }
}

    
