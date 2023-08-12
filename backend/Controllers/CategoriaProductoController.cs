using backend.connection;
using backend.entidades;
using backend.servicios;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaProductoController : ControllerBase
{   
    private readonly IConfiguration _configuration;
    private readonly string connectionString;

    public CategoriaProductoController(IConfiguration configuration){
        _configuration = configuration;
        connectionString = _configuration[""];
        BDManager.GetInstance.ConnectionString = connectionString;
    }

    [HttpGet]

    public IActionResult Get(){
        try
        {
            var result = CategoriaProductoServicios.ObtenerTodo<CategoriaProducto>();
            return Ok(result);
        }
        catch (Exception er)
        {
            return StatusCode(500, er.Message);
        }
    }
}
