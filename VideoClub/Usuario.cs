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

        // Constructor vacio de Usuario (Por si es necesario utilizar en un futuro)

        public Usuario()
        {

        }

        // Constructor para Insertar Usuarios en la base de datos (No lleva atributo "IdUsuario" al ser este autoincrementable en BBDD)
        public Usuario(string nombre, string apellido, string contraseña, string email, DateTime fechaNacimiento) { 
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

        public bool ComprobarEmail()
        {
            string buscarEmail = $"SELECT  * FROM Usuario WHERE Email = '{Email}'";
            SqlCommand command = new SqlCommand(buscarEmail, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                connection.Close();
                return true;
                
            }
            else
            {
                connection.Close();
                return false;
            }

            
        }
            
            public bool ComprobarContraseña()
           {
                string buscarContraseña = $"SELECT  * FROM Usuario WHERE Contraseña = '{Contraseña}'";
                SqlCommand command = new SqlCommand(buscarContraseña, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                connection.Close();
                return true;

                }
                else
                {
                connection.Close();
                return false;
                }

            }

            public bool RegistrarUsuario()
            {


                    string insertarUsuario = $"INSERT INTO Usuario (Nombre,Apellido,Contraseña,Email,FechaNacimiento) VALUES ('{Nombre}','{Apellido}','{Contraseña}','{Email}','{FechaNacimiento}')";
                    SqlCommand command = new SqlCommand(insertarUsuario, connection);
                    connection.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("El cliente se ha introducido correctamente");
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


            public void verPeliculasDisponibles(DateTime FechaNacimiento)
            {
                Console.WriteLine("Peliculas Disponibles");
                Console.WriteLine();
                 DateTime fechaNacimiento = Convert.ToDateTime(Console.ReadLine());
                 int edadDias = ((TimeSpan)(DateTime.Now - fechaNacimiento)).Days;
                 int edadAños = edadDias / 365;

                string selectPeliculas = $"SELECT  * FROM Peliculas" ;
                SqlCommand command = new SqlCommand(selectPeliculas, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                 List<Pelicula> peliculas = new List<Pelicula>();

                 while (reader.Read())
                 {
                  peliculas.Add(new Pelicula(Convert.ToInt32(reader[0].ToString()),reader[1].ToString(),reader[2].ToString(),Convert.ToInt32(reader[3].ToString()),reader[4].ToString()));
                 connection.Close();
                 }

                foreach (var pelicula in peliculas)
                {
                     if (pelicula.EdadRecomendada == edadAños)
                     {
                        Console.WriteLine("***************************************************");
                        Console.WriteLine($"Titulo {pelicula.Titulo} ");
                        Console.WriteLine($"Titulo {pelicula.Sinopsis} ");
                        Console.WriteLine($"Titulo {pelicula.EdadRecomendada} ");
                        Console.WriteLine($"Titulo {pelicula.Estado} ");
                        Console.WriteLine("***************************************************");
                      }
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