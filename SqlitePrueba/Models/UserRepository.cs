using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlitePrueba.Models
{
    public class UserRepository
    {
        private SQLiteConnection con;


        private static UserRepository instancia;
        public static UserRepository Instancia
        {
            get{
                if (instancia == null)
                    throw new Exception("Debe llamar al inicializador");
                return instancia;
            }

       }

        public static void Incializador(String filename)
        {
            if (filename == null)
                throw new ArgumentException();
            if (instancia != null)
                instancia.con.Close();

            instancia = new UserRepository(filename); 
            
        }

        private UserRepository(String dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<User>();
        }

        public String EstadoMensaje;
        public int AddNewUser(string name, string lastname, byte[] imageProfile)
        {
            int result = 0;
            try
            {
                result = con.Insert(new User() { 
                                               Name=name,
                                                LastName=lastname,  
                                                ImageProfile=imageProfile,
                });                         
                EstadoMensaje = string.Format("Cantidad de filas afectadas: {0}", result);
            }
            catch (Exception e)
            {

                EstadoMensaje = e.Message;
            }
            return result;
        }

        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return con.Table<User>();
            }
            catch (Exception e)
            {

                EstadoMensaje = e.Message;
            }
            return System.Linq.Enumerable.Empty<User>();
        }

        public int DeleteUser()
        {

            int result = 0;
            try
            {
                
                 con.Query<User>("Delete From User");
                
                EstadoMensaje = string.Format("Cantidad de filas afectadas: {0}", result);
            }
            catch (Exception e)
            {

                EstadoMensaje = e.Message;
            }
            return result;
        }

    }
}
