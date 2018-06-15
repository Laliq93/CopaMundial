using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    public abstract class DAO
    {
        private NpgsqlConnection _con;
        private NpgsqlCommand _command;
        private DataTable _dataTable;
        private string _cadena;
        private int _cantidadRegistros;

        public DAO ( )
        {
            CrearStringConexion ( );
        }

        public int cantidadRegistros
        {
            get { return _cantidadRegistros; }
        }

        public NpgsqlCommand Command { get => _command; set => _command = value; }
        public NpgsqlConnection Con { get => _con; set => _con = value; }
        public DataTable DataTable { get => _dataTable; set => _dataTable = value; }
        public string Cadena { get => _cadena; set => _cadena = value; }

        /// <summary>
        ///  Busca el string de conexión a la base de datos en el archivo web.config, dicho string se llama "postgrestring"
        /// </summary>
        private void CrearStringConexion ( )
        {
            Cadena = ConfigurationManager.ConnectionStrings [ "postgrestring" ].ConnectionString;
        }

        private bool IsConnected ( )
        {
            if (Con == null)
                return false;

            if (Con.State == System.Data.ConnectionState.Open)
                return true;

            return false;
        }

        public bool Conectar ( )
        {
            try
            {
                Con = new NpgsqlConnection ( Cadena );
                Con.Open ( );
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

        public void Desconectar ( )
        {
            if (Con != null && IsConnected ( ))
                Con.Close ( );
        }

        /// <summary>
        /// Ejecutar el StoredProcedure con un valor de retorno (ResultSet), habilita el uso de las funciones "GetInt, GetString, etc" y devuelve un objeto DataTable.
        /// </summary>
        public DataTable EjecutarReader ( )
        {

            try
            {
                if (!IsConnected ( ))
                    return null;

                DataTable = new DataTable ( );

                DataTable.Load ( Command.ExecuteReader ( ) );

                Desconectar ( );

                _cantidadRegistros = DataTable.Rows.Count;

            }
            catch (NpgsqlException exc)
            {
                Desconectar ( );
                throw new ArgumentNullException ( "Error al ejecutar el StoredProcedure " + exc );
            }
            catch (Exception)
            {
                Desconectar ( );
                throw;
            }

            return DataTable;

        }


        /// <summary>
        /// Ejecutar el StoredProcedure sin valor de retorno (ResultSet), devuelve el número de filas afectadas.
        /// </summary>
        public int EjecutarQuery ( )
        {
            try
            {
                if (!IsConnected ( ))
                    return 0;

                int filasAfectadas = Command.ExecuteNonQuery ( );

                Desconectar ( );

                return filasAfectadas;
            }
            catch (NpgsqlException exc)
            {
                Desconectar ( );
                throw new ArgumentNullException ( "Error al ejecutar el StoredProcedure " + exc );
            }
            catch (Exception)
            {
                Desconectar ( );
                throw;
            }
        }

        /// <summary>
        /// Crea el comando para ejecutar el StoredProcedure, Ejemplo: StoredProcedure("nombreSP(@param)")
        /// </summary>
        public NpgsqlCommand StoredProcedure ( string sp )
        {
            try
            {
                if (!IsConnected ( ))
                    return null;


                Command = new NpgsqlCommand ( "select * from " + sp, Con );
            }
            catch (NpgsqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            return Command;
        }


        public void AgregarParametro ( string nombre, object valor )
        {
            try
            {
                Command.Parameters.AddWithValue ( "@" + nombre, valor );
            }
            catch (NpgsqlException e)
            {
                throw e;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException ( );
            }
            catch (Exception)
            {
                throw new Exception ( );
            }
        }
        public int GetInt ( int fila, int columna )
        {
            try
            {
                int intItem = Convert.ToInt32 ( DataTable.Rows [ fila ] [ columna ] );

                return intItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException ( );
            }
            catch (FormatException)
            {
                throw new FormatException ( );
            }
            catch (OverflowException)
            {
                throw new OverflowException ( );
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException ( );
            }
            catch (Exception)
            {
                throw new Exception ( );
            }
        }

        public char GetChar ( int fila, int columna )
        {
            try
            {
                char charItem = Convert.ToChar ( DataTable.Rows [ fila ] [ columna ] );

                return charItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException ( );
            }
            catch (FormatException)
            {
                throw new FormatException ( );
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException ( );
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException ( );
            }
            catch (Exception)
            {
                throw new Exception ( );
            }
        }

        public string GetString ( int fila, int columna )
        {
            try
            {
                string stringItem = Convert.ToString ( DataTable.Rows [ fila ] [ columna ] );

                return stringItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException ( );
            }
            catch (FormatException)
            {
                throw new FormatException ( );
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException ( );
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException ( );
            }
            catch (Exception)
            {
                throw new Exception ( );
            }
        }

        public double GetDouble ( int fila, int columna )
        {
            try
            {
                double doubleItem = Convert.ToDouble ( DataTable.Rows [ fila ] [ columna ] );

                return doubleItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException ( );
            }
            catch (FormatException)
            {
                throw new FormatException ( );
            }
            catch (OverflowException)
            {
                throw new OverflowException ( );
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException ( );
            }
            catch (Exception)
            {
                throw new Exception ( );
            }
        }

        public bool GetBool ( int fila, int columna )
        {
            try
            {
                bool boolItem = Convert.ToBoolean ( DataTable.Rows [ fila ] [ columna ] );

                return boolItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException ( );
            }
            catch (FormatException)
            {
                throw new FormatException ( );
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException ( );
            }
            catch (Exception)
            {
                throw new Exception ( );
            }
        }

        public DateTime GetDateTime ( int fila, int columna )
        {
            try
            {
                DateTime dateItem = Convert.ToDateTime ( DataTable.Rows [ fila ] [ columna ] );

                return dateItem;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException ( );
            }
            catch (FormatException)
            {
                throw new FormatException ( );
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException ( );
            }
            catch (Exception)
            {
                throw new Exception ( );
            }
        }




    }
}
