using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace VideoClub
{

    class Usuario
    {

        // Cadena de Conexion con la base de datos Microsoft SQL Server(BaseDeDatos = Videoclub)
        static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-T0M5LFO\\SQLEXPRESS;Initial Catalog=Videoclub;Integrated Security=True");

        // Atributos , Getters y Setters de Usuario
        public int IDUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contraseña { get; set; }

        public string Email { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public Usuario(DateTime fechaNacimiento)
        {
            FechaNacimiento = fechaNacimiento;
        }


        // Constructor vacio de Usuario (Por si es necesario utilizar en un futuro)

        public Usuario()
        {

        }

        // Constructor para Insertar Usuarios en la base de datos (No lleva atributo "IdUsuario" al ser este autoincrementable en BBDD)
        public Usuario(string nombre, string apellido, string contraseña, string email, DateTime fechaNacimiento)
        {
            Nombre = nombre;
            Apellido = apellido;
            Contraseña = contraseña;
            Email = email;
            FechaNacimiento = fechaNacimiento;
        }



        // Cosntructor utilizado para Login con solo dos atributos (Contraseña , Email)
        public Usuario(string contraseña, string email)
        {

            Contraseña = contraseña;
            Email = email;
        }

        // Constructor con todos los atributos de Usuario
        public Usuario(int iDUsuario, string nombre, string apellido, string contraseña, string email, DateTime fechaNacimiento)
        {
            IDUsuario = iDUsuario;
            Nombre = nombre;
            Apellido = apellido;
            Contraseña = contraseña;
            Email = email;
            FechaNacimiento = fechaNacimiento;
        }


        // Espacio para los diferentes Metodos de Usuario

        public Usuario ComprobarEmailContraseña()
        {
            string validarEmailContraseña = $"SELECT  * FROM Usuario WHERE Email = '{Email}' AND Contraseña = '{Contraseña}'";
            SqlCommand command = new SqlCommand(validarEmailContraseña, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Usuario usuario1;

            if (reader.Read())
            {
                usuario1 = new Usuario(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), Convert.ToDateTime(reader[5].ToString()));

                connection.Close();
                return usuario1;

            }
            else
            {
                connection.Close();
                return null;
            }
        }


        // METODO PARA -- REGISTRAR USUARIO
        public bool RegistrarUsuario()
        {

            string insertarUsuario = $"INSERT INTO Usuario (Nombre,Apellido,Contraseña,Email,FechaNacimiento) VALUES ('{Nombre}','{Apellido}','{Contraseña}','{Email}','{FechaNacimiento}')";
            SqlCommand command = new SqlCommand(insertarUsuario, connection);
            connection.Open();

            if (command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Gracias por registrarte en el Videoclub ESFERA ETERNA");
                Console.ResetColor();
                Console.ReadKey();
                connection.Close();
                return true;
            }
            else

            {
                Console.WriteLine("No se ha introducido el cliente");
                connection.Close();
                return false;
            }



        }

        // METODO - VER LISTADO DE PELICULAS (MENU OPCION 1)

        public void verListadoPeliculas(Usuario usuario)
        {
            // Calculo de la Edad del usuario a traves de la clase "Time Span"

            int edadDias = ((TimeSpan)(DateTime.Now - FechaNacimiento)).Days;
            int edadAños = edadDias / 365;
            Console.WriteLine();
            Console.WriteLine($" Este es el listado de peliculas de  {usuario.Nombre}   {usuario.Apellido}   de  {edadAños}");
            Console.WriteLine();

            string selectPeliculas = $"SELECT  * FROM Pelicula";
            SqlCommand command = new SqlCommand(selectPeliculas, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Pelicula> peliculas = new List<Pelicula>();

            while (reader.Read())
            {
                peliculas.Add(new Pelicula(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), Convert.ToInt32(reader[3].ToString()), reader[4].ToString()));
            }
            connection.Close();


            foreach (var pelicula in peliculas)
            {
                if (pelicula.EdadRecomendada <= edadAños)
                {

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("***************************************************");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"Titulo");
                    Console.ResetColor();
                    Console.WriteLine($"-------{pelicula.Titulo}");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"Sinopsis");
                    Console.ResetColor();
                    Console.WriteLine($" -------{pelicula.Sinopsis} ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"Edad Recomendada");
                    Console.ResetColor();
                    Console.WriteLine($"-------- {pelicula.EdadRecomendada} ");
                    Console.ResetColor();
                    Console.Write("Estado "); if (pelicula.Estado.ToString().Contains("ND")) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\t ALQUILADA"); Console.ResetColor(); } else { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\t DISPONIBLE"); Console.ResetColor(); };
                    Console.WriteLine();
                }
            }


        }

        // METODO ALQUILAR PELICULA . Listado de peliculas disponibles para el usuario (OPCION 2)
        public void alquilarPelicula()
        {

            int iDUsuario = IDUsuario;

            int edadDias = ((TimeSpan)(DateTime.Now - FechaNacimiento)).Days;
            int edadAños = edadDias / 365;


            string selectPeliculas = $"SELECT  * FROM Pelicula WHERE Estado ='D'";
            SqlCommand command = new SqlCommand(selectPeliculas, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Pelicula> peliculas = new List<Pelicula>();

            while (reader.Read())
            {
                peliculas.Add(new Pelicula(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), Convert.ToInt32(reader[3].ToString()), reader[4].ToString()));

            }
            connection.Close();

            // Se muestran las peliculas "Estado" = D y que entran en los parametros de la  "Edad Recomendada" del Usuario

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("PELICULAS PARA ALQUILAR");
            Console.ResetColor();
            Console.WriteLine();

            foreach (var pelicula in peliculas)
            {
                if (pelicula.EdadRecomendada <= edadAños) // Se filtran las peliculas por edad (Peliculas para la edad menor igual a 
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("***************************************************");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"Id Pelicula");
                    Console.ResetColor();
                    Console.WriteLine($"---------------- {pelicula.IDPelicula} ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"Titulo");
                    Console.ResetColor();
                    Console.WriteLine($"--------------------- {pelicula.Titulo} ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"Sinopsis ");
                    Console.ResetColor();
                    Console.WriteLine($"-----{pelicula.Sinopsis} ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"Edad Recomendada");
                    Console.ResetColor();
                    Console.WriteLine($" {pelicula.EdadRecomendada} ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"Estado ");
                    Console.ResetColor();
                    Console.WriteLine($"--------{pelicula.Estado} ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("***************************************************");
                    Console.ResetColor();
                }
            }



        }

        // METOPO PARA VER LOS ALQUILERES YA REALIZADOS     OPCION 3 MENU VIDEOCLUB ESFERA ETERNA
        public void misAlquileres(Usuario usuarioLogin)
        {
            int iDUsuario = IDUsuario;

            string selectAlquileres = $"SELECT A.IdAlquiler,A.IdUsuario,A.IdPelicula,P.Titulo,A.FechaInicialAlquiler FROM Pelicula P ,Alquiler A Where P.IDPelicula = A.IdAlquiler ";
            SqlCommand command = new SqlCommand(selectAlquileres, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Alquiler> alquileres = new List<Alquiler>();
            List<string> titulos = new List<string>();

            while (reader.Read())
            {
                alquileres.Add(new Alquiler(Convert.ToInt32(reader[0].ToString()), Convert.ToInt32(reader[1].ToString()), Convert.ToInt32(reader[2].ToString()), Convert.ToDateTime(reader[4].ToString())));
                // Titulo de pelicula
                titulos.Add(reader[3].ToString());
            }
            connection.Close();

            // Se muestran los alquilers del usuario con la "FechaFinalAlquiler"
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("      MIS ALQUILERES          ");
            Console.ResetColor();
            int a = 0;
            foreach (var alquiler in alquileres)
            {
                DateTime fechaInicialAlquiler = alquiler.FechaInicialAlquiler;
                DateTime fechaFinalAlquiler = DateTime.Now;
                TimeSpan intervaloDias = fechaFinalAlquiler - fechaInicialAlquiler;
                int dias = intervaloDias.Days;

                if (dias >= 4)
                {

                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("---------------------------------------------------------------");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"Id Alquiler");
                    Console.ResetColor();
                    Console.WriteLine($" --------------{alquiler.IdAlquiler}");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"ID Usuario");
                    Console.ResetColor();
                    Console.WriteLine($" --------------{alquiler.IdPelicula}");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"ID Pelicula");
                    Console.ResetColor();
                    Console.WriteLine($" --------------{alquiler.IdUsuario}");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"ID Titulo");
                    Console.ResetColor();
                    Console.WriteLine($" --------------{titulos[a]}");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"Fecha alquiler");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" --------------{alquiler.FechaInicialAlquiler}");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.ResetColor();

                }
                else
                {

                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("---------------------------------------------------------------");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"Id Alquiler");
                    Console.ResetColor();
                    Console.WriteLine($"--------------{alquiler.IdAlquiler}   ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"ID Usuario");
                    Console.ResetColor();
                    Console.WriteLine($"---------------{alquiler.IdPelicula}");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"ID Pelicula");
                    Console.ResetColor();
                    Console.WriteLine($"---------------{alquiler.IdUsuario}");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"ID Titulo");
                    Console.ResetColor();
                    Console.WriteLine($"-----------------{titulos[a]}");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"Fecha alquiler");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"        EN FECHA------{alquiler.FechaInicialAlquiler}");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.ResetColor();

                }
                a++;
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Pulse 0 VOLVER LOGIN----Pulse 1 para - Volver al Menu del Videoclub ---Pulse 2 para - DEVOLVER PELICULA - *");
            Console.ResetColor();
            Console.WriteLine();

            int opcion = Convert.ToInt32(Console.ReadLine());

            if (opcion == 0)
            {
                Console.Clear();
                Program.Login();
            }
            else if (opcion == 1)
            {
                Console.Clear();
               Program.Videoclub(usuarioLogin);

            }

            else if (opcion == 2)
            {
               
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Quieres devolver alguna pelicula?");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();
            }

            int numeroPelicula = Convert.ToInt32(Console.ReadLine());

            bool alquilerEncontrado = false;

            for (int i = 0; i < alquileres.Count; i++)
            {
                if (alquileres[i].IdAlquiler == numeroPelicula)
                {
                    alquilerEncontrado = true;

                }

            }
            if (alquilerEncontrado)
            {
                string peliculaDisponible = $"Update Pelicula Set Estado = 'D' Where IDPelicula = {numeroPelicula} Update Alquiler Set FechaFinalAlquiler = '{DateTime.Now}' Where IdPelicula= {numeroPelicula}";
                SqlCommand command1 = new SqlCommand(peliculaDisponible, connection);
                connection.Open();

                if (command1.ExecuteNonQuery() > 0)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"La pelicula de Id {numeroPelicula} fue devuelta al Videoclub el dia {DateTime.Now}");
                    Console.ResetColor();
                    misAlquileres(usuarioLogin);
                    connection.Close();


                }


                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error. La pelicula no esta disponible en tus alquileres");
                    Console.ResetColor();
                    Console.WriteLine();
                    misAlquileres(usuarioLogin);


                }
            }





            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error.La opcion escogida no esta disponible");
                Console.ResetColor();
                Console.WriteLine();


            }
        }
    }

 } 

 






