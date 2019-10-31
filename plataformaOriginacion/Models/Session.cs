using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace plataformaOriginacion.Models
{
    public class Session
    {
        public static IConfiguration Configuration { get; set; }

        public static String GetCS(Boolean opc)
        {
            if (opc)
            {
                return Configuration["CadenaConexionDB_Control"];
            }
            else
            {
                return Configuration["CadenaConexionDB"];
            }
        }

        public static bool LoginApp(LoginRequestApp datos, ref string resultado, Usuario usuario){
            try
            {

                SqlConnection con = new SqlConnection(GetCS(true));
                SqlParameter[] Parameters =
                {
                    new SqlParameter("@USUARIO", datos.username) { SqlDbType = SqlDbType.VarChar, Size = 15, Direction = ParameterDirection.Input },
                    new SqlParameter("@PASSWORD", datos.password) { SqlDbType = SqlDbType.VarChar, Size = 15, Direction = ParameterDirection.Input },
                    new SqlParameter("@ERROR", SqlDbType.VarChar, 400){ Direction = ParameterDirection.Output},
                    new SqlParameter("@VALIDO", SqlDbType.Bit) {  Direction = ParameterDirection.Output },
                    new SqlParameter("@USUARIOID",  SqlDbType.Int) { Direction = ParameterDirection.Output },
                    new SqlParameter("@PERFILUSUARIOID", SqlDbType.Int) { Direction = ParameterDirection.Output },
                    new SqlParameter("@NIVEL", SqlDbType.Int) { Direction = ParameterDirection.Output },
                    new SqlParameter("@DASHADMIN", SqlDbType.Bit) { Direction = ParameterDirection.Output },
                    new SqlParameter("@NOMBRE", SqlDbType.VarChar, 70) { Direction = ParameterDirection.Output },
                    new SqlParameter("@PORTALTESORERIA", SqlDbType.Bit) { Direction = ParameterDirection.Output },
                    new SqlParameter("@PORTALCONTROl", SqlDbType.Bit) { Direction = ParameterDirection.Output },
                    new SqlParameter("@AliasUsuario", SqlDbType.VarChar, 30) { Direction = ParameterDirection.Output },
                    new SqlParameter("@PerfiDesc", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output },
                    new SqlParameter("@CORREO", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output }
                };

                //var r = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "ValidaAcceso", Parameters);
                var r = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, Configuration["sqlServer:storedProcedureName"], Parameters);

                usuario.nombre = Parameters.First(p => p.ParameterName == "@NOMBRE").Value.ToString();
                usuario.id = Parameters.First(p => p.ParameterName == "@USUARIOID").Value.ToString();
                usuario.perfil = Parameters.First(p => p.ParameterName == "@PerfiDesc").Value.ToString();
                usuario.username = datos.username;
                resultado = Parameters.First(p => p.ParameterName == "@ERROR").Value.ToString();

                if (Parameters.First(p => p.ParameterName == "@VALIDO").Value.ToString() != "False")
                {
                    var section = Configuration.GetSection($"Perfil");
                    var perfil = section.Get<string[]>();
                    if (!perfil.Contains(Parameters.First(p => p.ParameterName == "@PERFILUSUARIOID").Value.ToString()))
                    {
                        throw new Exception("Usuario NO Autorizado");
                    }
                    else
                    {
                        return true;
                    }

                }
                else
                {
                    throw new Exception(resultado);
                }
            }
            catch (Exception ex)
            {
                resultado = ex.Message.ToString();
                return false;
            }
        }
    }
}
