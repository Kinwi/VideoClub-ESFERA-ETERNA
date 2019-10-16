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

            public bool RegistrarUsuario() {


            string insertarUsuario = $"INSERT INTO Usuario (Nombre,Apellido,Contraseña,Email,FechaNacimiento) VALUES ('{Nombre}','{Apellido}','{Contraseña}','{Email}','{FechaNacimiento}')";
            SqlCommand command = new SqlCommand(insertarUsuario, connection);
            connection.Open();

            if (command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("El clinte se ha introducido correctamente");
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



    }
}
 
    

