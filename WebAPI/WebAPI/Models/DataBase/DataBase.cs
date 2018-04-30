using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAPI.Models.DataBase
{
    public class DataBase
    {
        private NpgsqlConnection _con;
        private NpgsqlCommand _command;
        private DataTable _dataTable;

        private bool isConnected()
        {
            try
            {
                if (_con.State == System.Data.ConnectionState.Open)
                    return true;

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool conectar()
        {
            try
            {
                string cadena = "Server=localhost;Port=5432;User Id=admin_copamundial;Database=copamundial; Password=copamundial;";
                _con = new NpgsqlConnection(cadena);
                _con.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void desconectar()
        {
            if (_con != null && isConnected())
                _con.Close();
        }

        public DataTable EjecutarReader()
        {
            if (!isConnected())
                return null;

            try
            {
                _dataTable = new DataTable();

                _dataTable.Load(_command.ExecuteReader());

                desconectar();
            }
            catch (Exception)
            {
                desconectar();
                return null;
            }

            return _dataTable;
              
        }

        public int EjecutarQuery()
        {
            try
            {
                if (!isConnected())
                    return 0;

                int filasAfectadas = _command.ExecuteNonQuery();

                desconectar();

                return filasAfectadas;
            }
            catch (Exception)
            {
                desconectar();
                return 0;
            }
        }

        public NpgsqlCommand crearComando(string comando)
        {
            try
            {
                if (!isConnected())
                    return null;

                _command = new NpgsqlCommand(comando, _con);
            }
            catch (Exception)
            {
                return null;
            }

            return _command;
        }


    }
}