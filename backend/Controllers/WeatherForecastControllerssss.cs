// using Microsoft.AspNetCore.Mvc;
// using backend.connection;
// using backend.entidades;
// using backend.servicios;
// namespace backend.Controllers;

// [ApiController]
// [Route("[controller]")]
// public class WeatherForecastController : ControllerBase
// {
//     private static readonly string[] Summaries = new[]
//     {
//         "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//     };

//     private readonly ILogger<WeatherForecastController> _logger;

//     public WeatherForecastController(ILogger<WeatherForecastController> logger)
//     {
//         _logger = logger;
//         BDManager.GetInstance.ConnectionString = "workstation id=bd_maicol.mssql.somee.com;packet size=4096;user id=maicol_SQLLogin_1;pwd=6jhbpgyi5h;data source=bd_maicol.mssql.somee.com;persist security info=False;initial catalog=bd_maicol";
//     }

//     // [HttpGet(Name = "GetWeatherForecast")]
//     // public IEnumerable<WeatherForecast> Get()
//     // {
//     //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//     //     {
//     //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//     //         TemperatureC = Random.Shared.Next(-20, 55),
//     //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//     //     })
//     //     .ToArray();
//     // }
//     [HttpGet(Name = "GetCategoria")]
//     public IActionResult GetCategoria(){
//         try
//         {
//             var result = CategoriaProductoServicios.ObtenerTodo<CategoriaProducto>();
//             return Ok(result);
//         }
//         catch (Exception er)
//         {
//             return StatusCode(500, er.Message);
//         }
//     }
// }
