using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ClsConexion
    {

        public ClsConexion()
        {

        }
        public static SqlConnection abrirConexion()
        {
            SqlConnection miConexion = new SqlConnection();

            try
            {
                miConexion.ConnectionString 
                    = "server=alvaro-salvador.database.windows.net;database=alvaroDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;";

                miConexion.Open();

            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return miConexion;
        }


        public static void cerrarConexion(ref SqlConnection miConexion)
        {
            miConexion.Close();
        }
        



        // HACER EN CASA

    }
}
