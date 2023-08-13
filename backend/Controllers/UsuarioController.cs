using backend.connection;
using backend.entidades;
using backend.servicios;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{   
    private readonly IConfiguration _configuration;
    private readonly string? connectionString;


    public UsuarioController(IConfiguration configuration)
    {
        _configuration = configuration;
        connectionString = _configuration["SqlConnectionString:DefaultConnection"];
        BDManager.GetInstance.ConnectionString = connectionString;
    }

    [HttpGet]
    [Route("GetAllUser")]
    public IActionResult GetAllUser()
    {
        try
        {
            var result = UsuarioServicios.ObtenerTodo<Usuarios>();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet]
    [Route("GetUserById")]
    public IActionResult GetUserById([FromQuery] int id)
    {
        try
        {
            var result = UsuarioServicios.ObtenerById<Usuarios>(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    [Route("AddUser")]
    public IActionResult AddUser(Usuarios usuario)
    {
        try
        {
            var result = UsuarioServicios.InsertUsuario(usuario);
            return Ok(result);
        }
        catch (Exception err)
        {
            return StatusCode(500, err.Message);
        }
    }

    [HttpPost]
    [Route("EditUser")]
    public IActionResult EditUser(Usuarios usuario)
    {
        try
        {
            var result = UsuarioServicios.UpdateUsuario(usuario);
            return Ok(result);
        }
        catch (Exception err)
        {
            return StatusCode(500, err.Message);
        }
    }

    [HttpPut]
    [Route("EliminarUsuario")]
    public IActionResult EliminarUsuario([FromQuery] int id)
    {
        try
        {
            UsuarioServicios.DeleteUsuario(id);
            return Ok("Se dio de baja al usuario correctamente.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
