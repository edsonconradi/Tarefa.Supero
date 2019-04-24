using Infra.Data.Context;
using Infra.Data.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Infra.WebApi.Controllers
{
    public class TarefaController : ApiController
    {
        private MvcContext db = new MvcContext();

        // GET api/Tarefa
        public IQueryable<Tarefa> GetTarefas()
        {          
                
            return db.Tarefas;          
        }

        // GET api/Tarefa/5
        [ResponseType(typeof(Tarefa))]
        public IHttpActionResult GetTarefa(int id)
        {
            Tarefa Tarefa = db.Tarefas.Find(id);
            if (Tarefa == null)
            {
                return NotFound();
            }

            return Ok(Tarefa);
        }

        // PUT api/Tarefa/5
        public IHttpActionResult PutTarefa(int id, Tarefa tarefa)
        {

            if (id != tarefa.Id)
            {
                return BadRequest();
            }

            db.Entry(tarefa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Tarefa
        [ResponseType(typeof(Tarefa))]
        public IHttpActionResult PostTarefa(Tarefa tarefa)
        {

            db.Tarefas.Add(tarefa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tarefa.Id }, tarefa);
        }

        // DELETE api/Tarefa/5
        [ResponseType(typeof(Tarefa))]
        public IHttpActionResult DeleteTarefa(int id)
        {
            Tarefa tarefa = db.Tarefas.Find(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            db.Tarefas.Remove(tarefa);
            db.SaveChanges();

            return Ok(tarefa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TarefaExists(int id)
        {
            return db.Tarefas.Count(e => e.Id == id) > 0;
        }

    }
}
