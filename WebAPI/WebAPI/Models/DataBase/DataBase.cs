using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace WebAPI.Models.DataBase
{
    public class DataBase
    {
        private NpgsqlConnection _con;
        private NpgsqlCommand _command;
        private DataTable _dataTable;
        private string _cadena;
        private int _cantidadRegistros;

        public DataBase()
        {
            CrearStringConexion();
        }

        public int cantidadRegistros
        {
            get { return _cantidadRegistros; }
        }

<<<<<<< HEAD
=======
        private void LecturaArchivo()
        {
            string archivoPath = HttpContext.Current.Request.PhysicalApplicationPath + "config.ini";

            if (!File.Exists(archivoPath))
                throw new ArgumentException("Error al encontrar el archivo: config.ini");

            try
            {
                using (var stream = new StreamReader(archivoPath))
                {
                    string linea = "";

                    while ((linea = stream.ReadLine()) != null)
                    {
                        if (linea.Length < 1 || linea.StartsWith("#"))
                        {
                            continue;
                        }

                        int posicionDelimitador = linea.IndexOf('=');

                        if (posicionDelimitador != -1)
                        {
                            string identificador = linea.Substring(0, posicionDelimitador);
                            string contenido = linea.Substring(posicionDelimitador + 1);

                            _data.Add(identificador, contenido);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Error al procesar el archivo de configuración");
            }
        }
>>>>>>> Develop

        /// <summary>
        ///  Busca el string de conexión a la base de datos en el archivo web.config, dicho string se llama "postgrestring"
        /// </summary>
        private void CrearStringConexion()
        {
            _cadena = ConfigurationManager.ConnectionStrings["postgrestring"].ConnectionString;
        }

        private bool IsConnected()
        {
            if (_con == null)
                return false;

            if (_con.State == System.Data.ConnectionState.Open)
                return true;

            return false;
        }

        public bool Conectar()
        {
            try
            {
                _con = new NpgsqlConnection(_cadena);
                _con.Open();
                return true;
            }
            catch (NpgsqlException e)
            {   
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Desconectar()
        {
            if (_con != null && IsConnected())
                _con.Close();
        }

        /// <summary>
        /// Ejecutar el StoredProcedure con un valor de retorno (ResultSet), habilita el uso de las funciones "GetInt, GetString, etc" y devuelve un objeto DataTable.
        /// </summary>
        public DataTable EjecutarReader()
        {

            try
            {
                if (!IsConnected())
                    return null;

                _dataTable = new DataTable();

                _dataTable.Load(_command.ExecuteReader());

                Desconectar();

                _cantidadRegistros = _dataTable.Rows.Count;

            }
            catch(NpgsqlException exc)
            {
                Desconectar();
                throw new ArgumentNullException("Error al ejecutar el StoredProcedure "+exc);
            }
            catch (Exception)
            {
                Desconectar();
                throw;
            }

            return _dataTable;
              
        }


        /// <summary>
        /// Ejecutar el StoredProcedure sin valor de retorno (ResultSet), devuelve el número de filas afectadas.
        /// </summary>
        public int EjecutarQuery()
        {
            try
            {
                if (!IsConnected())
                    return 0;

                int filasAfectadas = _command.ExecuteNonQuery();

                Desconectar();

                return filasAfectadas;
            }
            catch (NpgsqlException exc)
            {
                Desconectar();
                throw new ArgumentNullException("Error al ejecutar el StoredProcedure " + exc);
            }
            catch (Exception)
            {
                Desconectar();
                throw;
            }
        }

        /// <summary>
        /// Crea el comando para ejecutar el StoredProcedure, Ejemplo: StoredProcedure("nombreSP(@param)")
        /// </summary>
        public NpgsqlCommand StoredProcedure(string sp)
        {
            try
            {
                if (!IsConnected())
                    return null;

                
                _command = new NpgsqlCommand("select * from "+sp, _con);
            }
            catch (NpgsqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            return _command;
        }


        public void AgregarParametro(string nombre, object valor)
        {
            try
            {
                _command.Parameters.AddWithValue("@" + nombre, valor);
            }
            catch (NpgsqlException)
            {
                throw;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public int GetInt(int fila, int columna)
        {
            try
            {
                int intItem = Convert.ToInt32(_dataTable.Rows[fila][columna]);

                return intItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch (OverflowException)
            {
                throw new OverflowException();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public char GetChar(int fila, int columna)
        {
            try
            {
                char charItem = Convert.ToChar(_dataTable.Rows[fila][columna]);

                return charItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public string GetString(int fila, int columna)
        {
            try
            {
                string stringItem = Convert.ToString(_dataTable.Rows[fila][columna]);

                return stringItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public double GetDouble(int fila, int columna)
        {
            try
            {
                double doubleItem = Convert.ToDouble(_dataTable.Rows[fila][columna]);

                return doubleItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch (OverflowException)
            {
                throw new OverflowException();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public bool GetBool(int fila, int columna)
        {
            try
            {
                bool boolItem = Convert.ToBoolean(_dataTable.Rows[fila][columna]);

                return boolItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public DateTime GetDateTime(int fila, int columna)
        {
            try
            {
                DateTime dateItem = Convert.ToDateTime(_dataTable.Rows[fila][columna]);

                return dateItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }




    }
}