using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;

namespace backend.servicios
{
    public static class ProductoServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>()
        {
            const string sql = "select top 5 * from PRODUCTO ORDER BY ID DESC";
            // SELECT TOP 5 PRODUCTO.ID,PRODUCTO.NOMBRE, CATEGORIA_PRODUCTO.NOMBRE FROM PRODUCTO INNER JOIN CATEGORIA_PRODUCTO ON CATEGORIA_PRODUCTO.ID=PRODUCTO.ID_CATEGORIA ORDER BY PRODUCTO.ID DESC
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T ObtenerById<T>(int id)
        {
            const string sql = "select top 5 * from PRODUCTO where ID = @Id and estado_registro = 1";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        public static int InsertProducto(Producto producto)
        {
            const string sql = "INSERT INTO [dbo].[PRODUCTO]([NOMBRE], [ID_CATEGORIA]) VALUES (@NOMBRE, @ID_CATEGORIA)";
            var parameters = new DynamicParameters();
            parameters.Add("NOMBRE", producto.Nombre, DbType.String);
            parameters.Add("ID_CATEGORIA", producto.IdCategoria, DbType.Int64);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

        public static int UpdateProducto(Producto producto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("NOMBRE", producto.Nombre, DbType.String);
            parameters.Add("ID_CATEGORIA", producto.IdCategoria, DbType.String);
            parameters.Add("ID", producto.Id, DbType.Int64);
            var result = BDManager.GetInstance.SetData("UPDATE PRODUCTO SET NOMBRE=@NOMBRE, ID_CATEGORIA=@ID_CATEGORIA WHERE ID=@ID", parameters);
            return result;
        }

        public static void DeleteProducto(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);
            BDManager.GetInstance.SetData("UPDATE PRODUCTO SET ESTADO_REGISTRO=0 WHERE ID=@ID", parameters);
        }
    }
}