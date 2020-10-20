using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Helpers
{
    public class SincroHelper
    {
        public SqlConnection conexionsql;
        //public void CadenaConexionsql()
        //{
        //    conexionsql = new SqlConnection("Data Source=192.168.1.113,7433;Initial Catalog=supermio;Persist Security Info=True;User ID=l.sanchez;Password=Team0103;User Instance=False");
        //}
        public DataSet SqlConsulta(String SQL)
        {
            SqlConnection sqlconn = new SqlConnection("Data Source=45.71.180.58,7744;Initial Catalog=Pae_dev;Persist Security Info=True;User ID=sa;Password=cafe123.;User Instance=False");
            SqlCommand comando = new SqlCommand(SQL, sqlconn);
            comando.CommandTimeout = 0;
            SqlDataAdapter datos = new SqlDataAdapter(comando);
            DataSet tabla = new DataSet();
            try
            {
                sqlconn.Open();
                datos.Fill(tabla);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                sqlconn.Close();
                comando.Dispose();
            }
            return tabla;
        }
        public int SqlProcedimiento(string SQL)
        {
            int registrossql = 0;
            SqlConnection conexionsql = new SqlConnection("Data Source=45.71.180.58,7744;Initial Catalog=Pae_dev;Persist Security Info=True;User ID=sa;Password=cafe123.;User Instance=False");
            conexionsql.Open();
            SqlCommand comandosql = conexionsql.CreateCommand();
            comandosql.CommandTimeout = 0;
            SqlTransaction transactionsql = conexionsql.BeginTransaction();

            try
            {
                comandosql.Transaction = transactionsql;
                comandosql.CommandText = SQL;
                registrossql = comandosql.ExecuteNonQuery();

                transactionsql.Commit();
            }
            catch (Exception) // atrapa la excepcion que hereden de System.Exception
            {
                transactionsql.Rollback();
                registrossql = 0;
            }
            finally  // se ejecuta si se produce o no una excepcion 
            {
                conexionsql.Close();
                comandosql.Dispose();
            }

            return registrossql;
        }

        //public bool AbriConexionsql()
        //{
        //    try
        //    {
        //        conexionsql.Open();
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        return false;
        //        throw ex;
        //    }
        //}

        //public bool CerrarConexionsql()
        //{
        //    try
        //    {
        //        conexionsql.Close();
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        return false;
        //        throw ex;
        //    }

        //}
    }
}
