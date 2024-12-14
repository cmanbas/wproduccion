using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OracleClient;
using ACDATA;

namespace ACORACLE
{
    public static class UseracumerService
    {


        public static string connectionString = "";
        public static string usuario = "";
        public static string password = "";
        public static int filasvalida = 0;
        public static int iduser = 0;
        public static string mensaje ="";

        public static UserAcuComDTO  GetAllUsersByusuariopassword()
        {
            UserAcuComDTO users = new UserAcuComDTO();

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    OracleCommand cmd = new OracleCommand(@" SELECT usr_cod ,
usr_login ,
usr_alias ,
usr_passwordenc ,
usr_nombre ,
usr_administrador ,
usr_estado ,
usr_fechacreacion ,
usr_observacion ,
  DECODE(USR_ADMINISTRADOR,
              '1', 'ADMINISTRADOR',
              '2', 'CON ACCESO',
              '3', 'FINANZAS',
              '4', 'KAM',
              'DESCONOCIDO') AS USR_ADMINISTRADOR_DESC,DECODE(USR_ESTADO,
              'S', 'ACTIVO',
              'N', 'BLOQUEADO',
              'DESCONOCIDO') AS USR_ESTADO_DESC  FROM T_USER_ACUCOM   WHERE USR_LOGIN = :USR_LOGIN AND USR_PASSWORDENC = :USR_PASSWORD_ENC  order by USR_NOMBRE ", conn);

                    cmd.Parameters.Add(new OracleParameter("USR_LOGIN", usuario));
                    cmd.Parameters.Add(new OracleParameter("USR_PASSWORD_ENC", password));

                    conn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        filasvalida = 1;

                        users.usr_cod = Convert.ToInt32(reader["USR_COD"]);
                        users.usr_login = reader["USR_LOGIN"].ToString();
                        users.usr_alias = reader["USR_ALIAS"].ToString();
                        users.usr_passwordenc = reader["USR_PASSWORDENC"].ToString();
                        users.usr_nombre = reader["USR_NOMBRE"].ToString().ToUpper();
                        users.usr_administrador = reader["USR_ADMINISTRADOR"].ToString();
                        users.usr_estado = reader["USR_ESTADO"].ToString();
                        users.usr_fechacreacion = Convert.ToDateTime(reader["USR_FECHACREACION"]);
                        users.usr_observacion = reader["USR_OBSERVACION"].ToString();
                        users.usr_administrador_desc = reader["USR_ADMINISTRADOR_DESC"].ToString();
                        users.usr_estado_desc = reader["USR_ESTADO_DESC"].ToString();
                    }
 



                    
                }
                return users;
            }
            catch (Exception ex)
            {
                filasvalida = -1;
                mensaje = ex.Message.ToString();
            
                return users;
            }
        }
        public static List<UserAcuComDTO> GetAllUsers()
        {
            filasvalida = 0;
            List<UserAcuComDTO> users = new List<UserAcuComDTO>();

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    OracleCommand cmd = new OracleCommand(@" SELECT T_USER_ACUCOM.*, DECODE(USR_ADMINISTRADOR,
              '1', 'ADMINISTRADOR',
              '2', 'CON ACCESO',
              '3', 'FINANZAS',
              '4', 'KAM',
              'DESCONOCIDO') AS USR_ADMINISTRADOR_DESC,DECODE(USR_ESTADO,
              'S', 'ACTIVO',
              'N', 'BLOQUEADO',
              'DESCONOCIDO') AS USR_ESTADO_DESC  FROM T_USER_ACUCOM order by USR_NOMBRE ", conn);
                    conn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add(new UserAcuComDTO
                        {
                            usr_cod = Convert.ToInt32(reader["USR_COD"]),
                            usr_login = reader["USR_LOGIN"].ToString(),
                            usr_alias = reader["USR_ALIAS"].ToString(),
                            usr_passwordenc = reader["USR_PASSWORDENC"].ToString(),
                            usr_nombre = reader["USR_NOMBRE"].ToString().ToUpper(),
                            usr_administrador = reader["USR_ADMINISTRADOR"].ToString(),
                            usr_estado = reader["USR_ESTADO"].ToString(),
                            usr_fechacreacion = Convert.ToDateTime(reader["USR_FECHACREACION"]),
                            usr_observacion = reader["USR_OBSERVACION"].ToString(),
                            usr_administrador_desc = reader["USR_ADMINISTRADOR_DESC"].ToString(),
                            usr_estado_desc = reader["USR_ESTADO_DESC"].ToString()
                        });
                        filasvalida = 1;
                    }
                }
                return users;
            } 
            catch (Exception ex)
            {

                List<UserAcuComDTO> Salida = new List<UserAcuComDTO>();
                return Salida;
            }
        }
        public static bool CreateUser(UserAcuComDTO user)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                OracleTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    OracleCommand cmd = new OracleCommand("INSERT INTO T_USER_ACUCOM  ( USR_COD, USR_LOGIN, USR_ALIAS, USR_PASSWORDENC, USR_NOMBRE, USR_ADMINISTRADOR, USR_ESTADO, USR_OBSERVACION) " +
                        "                                 VALUES (SEQ_T_USER_ACUCOM.NEXTVAL,  :USR_LOGIN, :USR_ALIAS, :USR_PASSWORDENC, :USR_NOMBRE, :USR_ADMINISTRADOR, :USR_ESTADO, :USR_OBSERVACION)", conn);
                    cmd.Transaction = transaction;
                    cmd.Parameters.Add(new OracleParameter("USR_LOGIN", user.usr_login));
                    cmd.Parameters.Add(new OracleParameter("USR_ALIAS", user.usr_alias));
                    cmd.Parameters.Add(new OracleParameter("USR_PASSWORDENC", user.usr_passwordenc));
                    cmd.Parameters.Add(new OracleParameter("USR_NOMBRE", user.usr_nombre));
                    cmd.Parameters.Add(new OracleParameter("USR_ADMINISTRADOR", user.usr_administrador));
                    cmd.Parameters.Add(new OracleParameter("USR_ESTADO", user.usr_estado));
                    cmd.Parameters.Add(new OracleParameter("USR_OBSERVACION", user.usr_observacion));
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    // Log the exception (ex) here
                    return false;
                }
            }
        }
        public static bool UpdateUser(UserAcuComDTO user)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                OracleTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    OracleCommand cmd = new OracleCommand("UPDATE T_USER_ACUCOM  SET USR_LOGIN = :USR_LOGIN, USR_ALIAS = :USR_ALIAS,   USR_NOMBRE = :USR_NOMBRE, USR_ADMINISTRADOR = :USR_ADMINISTRADOR, USR_ESTADO = :USR_ESTADO, USR_OBSERVACION = :USR_OBSERVACION WHERE USR_COD = :USR_COD", conn);
                    cmd.Transaction = transaction;
                    cmd.Parameters.Add(new OracleParameter("USR_LOGIN", user.usr_login));
                    cmd.Parameters.Add(new OracleParameter("USR_ALIAS", user.usr_alias));
   
                    cmd.Parameters.Add(new OracleParameter("USR_NOMBRE", user.usr_nombre));
                    cmd.Parameters.Add(new OracleParameter("USR_ADMINISTRADOR", user.usr_administrador));
                    cmd.Parameters.Add(new OracleParameter("USR_ESTADO", user.usr_estado));
                    cmd.Parameters.Add(new OracleParameter("USR_OBSERVACION", user.usr_observacion));
                    cmd.Parameters.Add(new OracleParameter("USR_COD", user.usr_cod));
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    // Log the exception (ex) here
                    return false;
                }
            }
        }
        public static bool DeleteUser(int usr_cod)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                OracleTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    OracleCommand cmd = new OracleCommand("DELETE FROM T_USER_ACUMER WHERE USR_COD = :USR_COD", conn);
                    cmd.Transaction = transaction;
                    cmd.Parameters.Add(new OracleParameter("USR_COD", usr_cod));
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    // Log the exception (ex) here
                    return false;
                }
            }
        }
        public static bool UpdateUserPassword(int usr_cod, string newPassword)
        {
            filasvalida = 0;

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                OracleTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    OracleCommand cmd = new OracleCommand("UPDATE T_USER_ACUCOM SET USR_PASSWORDENC = :USR_PASSWORDENC WHERE USR_COD = :USR_COD", conn);
                    cmd.Transaction = transaction;
                    cmd.Parameters.Add(new OracleParameter("USR_PASSWORDENC", newPassword));
                    cmd.Parameters.Add(new OracleParameter("USR_COD", usr_cod));
                    cmd.ExecuteNonQuery();
                    filasvalida = 1;
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    filasvalida = -1;
                    transaction?.Rollback();
                    mensaje = ex.Message.ToString();
                    return false;
                }
            }
        }
        public static UserAcuComDTO GetAllUsersByID()
        {
            UserAcuComDTO users = new UserAcuComDTO();

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    OracleCommand cmd = new OracleCommand(@" SELECT usr_cod ,
usr_login ,
usr_alias ,
usr_passwordenc ,
usr_nombre ,
usr_administrador ,
usr_estado ,
usr_fechacreacion ,
usr_observacion ,
  DECODE(USR_ADMINISTRADOR,
              '1', 'ADMINISTRADOR',
              '2', 'CON ACCESO',
              '3', 'FINANZAS',
              '4', 'KAM',
              'DESCONOCIDO') AS USR_ADMINISTRADOR_DESC,DECODE(USR_ESTADO,
              'S', 'ACTIVO',
              'N', 'BLOQUEADO',
              'DESCONOCIDO') AS USR_ESTADO_DESC  FROM T_USER_ACUCOM   WHERE   usr_cod = :usr_cod  order by USR_NOMBRE ", conn);

                    cmd.Parameters.Add(new OracleParameter("USR_COD", iduser));
 

                    conn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        filasvalida = 1;

                        users.usr_cod = Convert.ToInt32(reader["USR_COD"]);
                        users.usr_login = reader["USR_LOGIN"].ToString();
                        users.usr_alias = reader["USR_ALIAS"].ToString();
                        users.usr_passwordenc = reader["USR_PASSWORDENC"].ToString();
                        users.usr_nombre = reader["USR_NOMBRE"].ToString().ToUpper();
                        users.usr_administrador = reader["USR_ADMINISTRADOR"].ToString();
                        users.usr_estado = reader["USR_ESTADO"].ToString();
                        users.usr_fechacreacion = Convert.ToDateTime(reader["USR_FECHACREACION"]);
                        users.usr_observacion = reader["USR_OBSERVACION"].ToString();
                        users.usr_administrador_desc = reader["USR_ADMINISTRADOR_DESC"].ToString();
                        users.usr_estado_desc = reader["USR_ESTADO_DESC"].ToString();
                    }





                }
                return users;
            }
            catch (Exception ex)
            {
                filasvalida = -1;
                mensaje = ex.Message.ToString();

                return users;
            }
        }
       

    }
}