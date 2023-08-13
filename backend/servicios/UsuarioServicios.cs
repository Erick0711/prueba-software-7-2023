using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;

namespace backend.servicios
{
    public static class UsuarioServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>()
        {
            const string sql = "select * from USUARIOS";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T ObtenerById<T>(int id)
        {
            const string sql = "select * from USUARIOS where ID = @Id and estado_registro = 1";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }
        public static int InsertUsuario(Usuarios usuarios)
        {
            const string sql = "INSERT INTO [dbo].[USUARIOS]([USER_NAME], [NOMBRE_COMPLETO], [PASSWORD]) VALUES (@USER_NAME, @NOMBRE_COMPLETO, @PASSWORD) ";
            var parameters = new DynamicParameters();
            parameters.Add("USER_NAME", usuarios.UserName, DbType.String);
            parameters.Add("NOMBRE_COMPLETO", usuarios.NombreCompleto, DbType.String);
            parameters.Add("PASSWORD", usuarios.Password, DbType.String);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }
        public static int UpdateUsuario(Usuarios usuarios)
        {
            var parameters = new DynamicParameters();
            parameters.Add("NOMBRE_COMPLETO", usuarios.NombreCompleto, DbType.String);
            parameters.Add("PASSWORD", usuarios.Password, DbType.String);
            parameters.Add("ID", usuarios.Id, DbType.Int64);
            var result = BDManager.GetInstance.SetData("UPDATE USUARIOS SET NOMBRE_COMPLETO=@NOMBRE_COMPLETO, PASSWORD=@PASSWORD WHERE ID=@ID", parameters);
            return result;
        }

        // Eliminacion logica
        public static void DeleteUsuario(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);
            BDManager.GetInstance.SetData("UPDATE USUARIOS SET ESTADO_REGISTRO=0 WHERE ID=@ID", parameters);
        }
    }
}