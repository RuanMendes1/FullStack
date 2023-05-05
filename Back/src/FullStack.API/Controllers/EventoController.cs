using FullStack.API.Data;
using FullStack.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FullStack.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{

    private readonly DataContext _context;

    public EventoController(DataContext context)
    {
        this._context = context;

    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _context.Eventos;
    }


    [HttpGet("{id}")]
    public Evento GetById(int id)
    {
        return _context.Eventos.FirstOrDefault(
            evento => evento.EventoId == id
        );
    }

    [HttpPost]
    public string Post()
    {
        return "exemplo post";
    }

    [HttpPut("{id}")]
    public string Put(int id)
    {
        return $"exemplo put com id = {id}";
    }

    [HttpDelete("{id}")]
    public string Delete(int id)
    {
        return $"exemplo delete com id = {id}";
    }
}
