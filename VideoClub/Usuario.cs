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

        public string FechaNacimiento { get; set; }

        // Constructor vacio de Usuario (Por si es necesario utilizar en un futuro)

        public Usuario()
        {

        }

        public Usuario(string contraseña, string email)
        {
            Contraseña = contraseña;
            Email = email;
        }

        // Constructor con todos los atributos de Usuario
        public Usuario(int iDUsuario, string nombre, string apellido, string contraseña, string email, string fechaNacimiento)
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
            string buscarEmail = $"SELECT  * FROM Usuario WHERE Email= '{Email}'";
            SqlCommand command = new SqlCommand(buscarEmail, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return true;
                
            }
            else
            {
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
                    return true;

                }
                else
                {
                    return false;
                }

            }
    }
 }
    

