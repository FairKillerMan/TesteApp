using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Site.Server.Data;
using Site.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Site.Server.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase{
        private readonly ApplicationDbContext _db;

        public TarefaController(ApplicationDbContext db){
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tarefa>>> Get(){
            return await _db.Tarefas.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<Tarefa>> GetById(int id)
        {
            return await _db.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Tarefa tarefa)
        {
            _db.Entry(tarefa).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Tarefa tarefa){
            tarefa.DataCriacao = DateTime.Now;
            _db.Add(tarefa);
            await _db.SaveChangesAsync();
            return new CreatedAtRouteResult(nameof(GetById), new { tarefa.Id}, tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var tarefa = await _db.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
            _db.Remove(tarefa);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
