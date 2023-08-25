using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;

namespace backend.servicios
{
    public static class CategoriaProductoServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>()
        {
            const string sql = "SELECT top 5 * FROM CATEGORIA_PRODUCTO WHERE estado_registro = 1 ORDER BY ID DESC";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T ObtenerById<T>(int id)
        {
            const string sql = "select top 5 * from categoria_producto where ID = @Id and estado_registro = 1";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }
        public static int InsertCategoriaProducto(CategoriaProducto categoriaProducto)
        {
            const string sql = "INSERT INTO [CATEGORIA_PRODUCTO]([NOMBRE]) VALUES (@NOMBRE)";
            var parameters = new DynamicParameters();
            parameters.Add("NOMBRE", categoriaProducto.Nombre, DbType.String);
            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

        public static int UpdateCategoriaProducto(CategoriaProducto categoriaProducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("NOMBRE", categoriaProducto.Nombre, DbType.String);
            parameters.Add("ID", categoriaProducto.Id, DbType.Int64);
            var result = BDManager.GetInstance.SetData("UPDATE CATEGORIA_PRODUCTO SET NOMBRE=@NOMBRE WHERE ID=@ID", parameters);
            return result;
        }

        public static void DeleteCategoriaProducto(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);
            BDManager.GetInstance.SetData("UPDATE CATEGORIA_PRODUCTO SET ESTADO_REGISTRO=0 WHERE ID=@ID", parameters);
        }
    }
}