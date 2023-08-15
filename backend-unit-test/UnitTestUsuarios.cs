using backend.connection;
using backend.entidades;
using backend.servicios;

namespace backend_unit_test
{
    public class UnitTestUsuarios
    {
        public UnitTestUsuarios()
        {
            BDManager.GetInstance.ConnectionString = "workstation id=bd_maicol.mssql.somee.com;packet size=4096;user id=maicol_SQLLogin_1;pwd=6jhbpgyi5h;data source=bd_maicol.mssql.somee.com;persist security info=False;initial catalog=bd_maicol";
        }

        [Fact]
        public void Usuarios_Get_Verificar_NotNull()
        {
            var result = UsuarioServicios.ObtenerTodo<Usuarios>();
            Assert.NotNull(result);
        }

        [Fact]
        public void Usuarios_GetById_VerificarItem()
        {
            var result = UsuarioServicios.ObtenerById<Usuarios>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Usuarios_Insertar()
        {
            Usuarios usuarioTemp = new()
            {
                NombreCompleto = "Nombre Test",
                UserName = "UserName Test",
                Password = "Password Test"
            };

            var result = UsuarioServicios.InsertUsuario(usuarioTemp);
            Assert.Equal(1, result);
        }
    }
}