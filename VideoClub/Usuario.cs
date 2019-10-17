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



        public bool RegistrarUsuario()
        {


            string insertarUsuario = $"INSERT INTO Usuario (Nombre,Apellido,Contraseña,Email,FechaNacimiento) VALUES ('{Nombre}','{Apellido}','{Contraseña}','{Email}','{FechaNacimiento}')";
            SqlCommand command = new SqlCommand(insertarUsuario, connection);
            connection.Open();

            if (command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Gracias por registrarte en el Videoclub ESFERA ETERNA");
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


        public void verPeliculasDisponibles()
        {

            int edadDias = ((TimeSpan)(DateTime.Now - FechaNacimiento)).Days;
            int edadAños = edadDias / 365;


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
                if (pelicula.EdadRecomendada <= edadAños && pelicula.Estado == "D")
                {

                    Console.WriteLine();
                    Console.WriteLine("***************************************************");
                    Console.WriteLine($"Titulo----- {pelicula.Titulo} ");
                    Console.WriteLine($"Sinopsis -----{pelicula.Sinopsis} ");
                    Console.WriteLine($"Edad Recomendada -------- {pelicula.EdadRecomendada} ");
                    Console.WriteLine($"Estado --------{pelicula.Estado} ");
                    Console.WriteLine("***************************************************");
                    Console.WriteLine();
                }
            }


        }

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

            foreach (var pelicula in peliculas)
            {
                if (pelicula.EdadRecomendada <= edadAños)
                {

                    Console.WriteLine("***************************************************");
                    Console.WriteLine($"Identificador de Pelicula----- {pelicula.IDPelicula} ");
                    Console.WriteLine($"Titulo----- {pelicula.Titulo} ");
                    Console.WriteLine($"Sinopsis -----{pelicula.Sinopsis} ");
                    Console.WriteLine($"Edad Recomendada -------- {pelicula.EdadRecomendada} ");
                    Console.WriteLine($"Estado --------{pelicula.Estado} ");
                    Console.WriteLine("***************************************************");
                }
            }

            connection.Open();
            Console.WriteLine("Introduzca la pelicula a Alquilar . Ejemplo 3");
            int peliculaAlquilada = Convert.ToInt32(Console.ReadLine());
            DateTime fechaAlquiler = DateTime.Now; // Fecha Alquiler = Fecha Hoy
            string actualizarAlquiler = $"UPDATE Pelicula SET Estado = 'ND' WHERE IDPelicula = '{peliculaAlquilada}'INSERT INTO Alquiler (IdPelicula,IdUsuario,FechaInicialAlquiler) VALUES ('{peliculaAlquilada}','{iDUsuario}','{fechaAlquiler}')";
            SqlCommand command2 = new SqlCommand(actualizarAlquiler, connection);
            Console.WriteLine(command2.ExecuteNonQuery());
            connection.Close();

        }

        public void misAlquileres()
        {
            int iDUsuario = IDUsuario;

            string selectAlquileres = $"SELECT A.IdAlquiler,A.IdUsuario,A.IdPelicula,P.Titulo,A.FechaFinalAlquiler FROM Pelicula P ,Alquiler A Where P.IDPelicula = A.IdAlquiler "; 
            SqlCommand command = new SqlCommand(selectAlquileres, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Alquiler> alquileres = new List<Alquiler>();
            List<string> titulos = new List<string>();
          
            while (reader.Read())
            {   
                alquileres.Add(new Alquiler(Convert.ToInt32(reader[0].ToString()), Convert.ToInt32(reader[1].ToString()), Convert.ToInt32(reader[2].ToString())));
                // Titulo de pelicula
                titulos.Add(reader[3].ToString());
            }
            connection.Close();

            // Se muestran los alquilers del usuario con la "FechaFinalAlquiler"

            Console.WriteLine("---------------MIS ALQUILERES-----------------------");
            int a = 0;
            foreach (var alquiler in alquileres)
            {
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine($"Id Alquiler                           {alquiler.IdAlquiler}   ");
                Console.WriteLine($"ID Usuario                            {alquiler.IdPelicula}   ");
                Console.WriteLine($"ID Pelicula                           {alquiler.IdUsuario}   ");
                Console.WriteLine($"ID Titulo                             {titulos[a]}");
                Console.WriteLine($"Fecha Devolucion Pelicula             {alquiler.FechaFinalAlquiler}");
                Console.WriteLine("");
                Console.WriteLine("----------------------------------------------------------------");
                a++;
            }


            Console.WriteLine("Quieres devolver alguna pelicula?");
            int numeroPelicula = Convert.ToInt32(Console.ReadLine());

            bool alquilerEncontrado= false;
            
            for (int i = 0; i < alquileres.Count; i++)
            {
                if (alquileres[i].IdAlquiler == numeroPelicula)
                {
                    alquilerEncontrado = true;

                }
                
            }
            if (alquilerEncontrado)
            {
                string peliculaDisponible = $"Update Pelicula Set Estado = 'D' Where IDPelicula = {numeroPelicula} Update Alquiler Set FechaFinalAlquiler = '{DateTime.Now}' Where IdPelicula= {numeroPelicula}" ;
                SqlCommand command1 = new SqlCommand(peliculaDisponible, connection);
               connection.Open();

                if (command1.ExecuteNonQuery() > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("La pelicula fue devuelta al Videoclub y la fecha de devolucion fue a parar a alquileres");
                    connection.Close();
                    

                }
            }

            else
            {
                Console.WriteLine("Error. La pelicula no esta disponible en tus alquileres");


            }


        }

    }
 }






//if (FechaNacimiento.Year < 2001)
//{
//    string selectMayoresDe18 = $"SELECT  * FROM Peliculas WHERE  {FechaNacimiento.Year} < 2001";
//    SqlCommand command1 = new SqlCommand(selectMayoresDe18, connection);
//    connection.Open();
//}

//else if (FechaNacimiento.Year > 2001 && FechaNacimiento.Year < 2004)
//{

//    string selectEdadesDe16a18 = $"SELECT  * FROM Peliculas WHERE  {FechaNacimiento.Year} > 2001 AND {FechaNacimiento.Year} < 2004";
//    SqlCommand command1 = new SqlCommand(selectEdadesDe16a18, connection);
//    connection.Open();
//    SqlDataReader reader = command1.ExecuteReader();
//        List<Pelicula> peliculas = new List<Pelicula> ;

//    while (reader.Read())
//    {
//        peliculas.Add($"{reader[1].ToString()});



//        connection.Close();
//     }

// }
//else if (FechaNacimiento.Year < 2004)

//{
//    string selectEdadesMenores16 = $"SELECT  * FROM Peliculas WHERE  {FechaNacimiento.Year} > 2004";
//    SqlCommand command1 = new SqlCommand(selectEdadesMenores16, connection);
//    connection.Open();
//    SqlDataReader reader = command1.ExecuteReader();
//    while (reader.Read())
//     {
//    Console.WriteLine($"{reader[0].ToString()} {reader[1].ToString()}");

//    connection.Close();


//string selectPeliculas = $"select Alquiler.IdPelicula,Pelicula.Titulo,Alquiler.FechaFinalAlquiler FROM Alquiler INNER JOIN Pelicula ON Alquiler.IdPelicula = Pelicula.IDPelicula WHERE Alquiler.IdUsuario ='{iDUsuario}'";

//SELECT A. FROM PELICULAS P, ALQUILERES A WHERE P.ID = A.PELICULAID AND 

// Esta funciona string selectAlquileres = $"SELECT  IdAlquiler,IdPelicula,IdUsuario,FechaFinalAlquiler FROM Alquiler WHERE IdUsuario = iDUsuario"; 