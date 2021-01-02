using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using API_ProAgroSeguros.ViewModels;

namespace API_ProAgroSeguros.Controllers
{
    public class Dataaccess
    {
        string conn = DataClass.Connection;

        //Method for Login  
        public bool CheckLogin(Login user)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {

                if (string.IsNullOrWhiteSpace(user.RFC) || string.IsNullOrWhiteSpace(user.Contrasenia))
                {
                    return false;
                }
                SqlCommand cmd = new SqlCommand("select count(idUsuario) from CAt_USUARIO WHERE RFC = @RFC AND Contrasenia = @Contrasenia", connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                cmd.Parameters.AddWithValue("@RFC", user.RFC);
                cmd.Parameters.AddWithValue("@Contrasenia", user.Contrasenia);
                
                int Var = 0;
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                    Var = int.Parse(sdr[0].ToString());

                sdr.Close();
                connection.Close();

                if (Var == 1)
                    return true;
                else
                    return false;
            }

        }

    }

    public class DataClass
    {        
        public static string Connection = "Data Source=DESKTOP-K3BL506;Initial catalog=proagroseguros; user id=sa;password=Dt1h@lO";

        public static string Conn { get => Connection; }

    }

}
