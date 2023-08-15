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
            // const string sql = "select * from USUARIOS";
            return BDManager.GetInstance.GetData<T>("EXEC procedure_getAllUser");//Dapper
        }

        public static T ObtenerById<T>(int id)
        {
            // const string sql = "select * from USUARIOS where ID = @Id and estado_registro = 1";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);
            var result = BDManager.GetInstance.GetDataWithParameters<T>("EXEC procedure_GetUserById @ID=@Id", parameters);

            return result.FirstOrDefault();
        }
        public static int InsertUsuario(Usuarios usuarios)
        {
            // const string sql = "INSERT INTO [dbo].[USUARIOS]([USER_NAME], [NOMBRE_COMPLETO], [PASSWORD]) VALUES (@USER_NAME, @NOMBRE_COMPLETO, @PASSWORD) ";
            const string sql = "EXEC procedure_AddUser @PARAM_USER_NAME=@USER_NAME, @PARAM_NOMBRE_COMPLETO=@NOMBRE_COMPLETO, @PARAM_PASSWORD=@PASSWORD";
            var parameters = new DynamicParameters();
            parameters.Add("USER_NAME", usuarios.UserName, DbType.String);
            parameters.Add("NOMBRE_COMPLETO", usuarios.NombreCompleto, DbType.String);
            parameters.Add("PASSWORD", usuarios.Password, DbType.String);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }
        public static int UpdateUsuario(Usuarios usuarios)
        {
            // UPDATE USUARIOS SET NOMBRE_COMPLETO=@NOMBRE_COMPLETO, PASSWORD=@PASSWORD WHERE ID=@ID
            const string sql = "EXEC procedure_EditUser @PARAM_NOMBRE_COMPLETO=@NOMBRE_COMPLETO, @PARAM_PASSWORD=@PASSWORD, @PARAM_ID=@ID";
            var parameters = new DynamicParameters();
            parameters.Add("NOMBRE_COMPLETO", usuarios.NombreCompleto, DbType.String);
            parameters.Add("PASSWORD", usuarios.Password, DbType.String);
            parameters.Add("ID", usuarios.Id, DbType.Int64);
            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

        // Eliminacion logica
        public static void DeleteUsuario(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);
            BDManager.GetInstance.SetData("EXEC procedure_DeleteUsuario @PARAM_ID=@ID", parameters);
        }
    }
}