using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace dataAccessSinEntity
{
    public class Barrio
    {

        public DataSet getData(int? idBarrio, string nombreBarrio, int Operacion)
        {
            string mvarDBConnection = ConfigurationManager.ConnectionStrings["bdColegio"].ToString();

            DataSet ds = new DataSet();
            SqlConnection LaConexion = null;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlTransaction LaTransaccion = null;
            

            try
            {
                //seguimos con la conexion
                LaConexion = new SqlConnection();
                //asignamos a la conexión la cadena de conexión que declaramos anteriormente
                LaConexion.ConnectionString = mvarDBConnection;
                //se abre la conexión
                LaConexion.Open();
                LaTransaccion = LaConexion.BeginTransaction(IsolationLevel.Serializable);
                SqlCommand comando = new SqlCommand("spBarrios", LaConexion, LaTransaccion);
                //se indica al tipo de comando que es de tipo procedimiento almacenado
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idBarrio",idBarrio);
                comando.Parameters.AddWithValue("@nombreBarrio",nombreBarrio);
                comando.Parameters.AddWithValue("@Operacion",Operacion);
                comando.ExecuteNonQuery();

                da.SelectCommand = comando;
                da.Fill(ds);

                return ds;
            }
             catch (Exception)
            {
             
             }
            return ds;
        }
       public DataSet setData(int? idBarrio, string nombreBarrio, int Operacion)
        {
           
            DataSet ds = new DataSet("selects");
            string mvarDBConnection = ConfigurationManager.ConnectionStrings["bdColegio"].ToString();
            SqlConnection LaConexion = null;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlTransaction LaTransaccion = null;
            

            try
            {
                //seguimos con la conexion
                LaConexion = new SqlConnection();
                //asignamos a la conexión la cadena de conexión que declaramos anteriormente
                LaConexion.ConnectionString = mvarDBConnection;
                //se abre la conexión
                LaConexion.Open();
                LaTransaccion = LaConexion.BeginTransaction(IsolationLevel.Serializable);
                SqlCommand comando = new SqlCommand("spBarrios", LaConexion, LaTransaccion);
                //se indica al tipo de comando que es de tipo procedimiento almacenado
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idBarrio",idBarrio);
                comando.Parameters.AddWithValue("@nombreBarrio",nombreBarrio);
                comando.Parameters.AddWithValue("@Operacion",Operacion);
                comando.ExecuteNonQuery();

                da.SelectCommand = comando;
                da.Fill(ds);

                return ds;
            }
             catch (Exception)
            {
             
             }
            return ds;
        }
  
    }
}
