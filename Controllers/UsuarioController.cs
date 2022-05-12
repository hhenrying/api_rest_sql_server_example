using API_REST_SQLSERVER.Context;
using API_REST_SQLSERVER.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_REST_SQLSERVER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public AppDbContext Context { get; }

        public UsuarioController(AppDbContext context)
        {
            Context = context;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<usuario> Get()
        {
            return Context.usuario.ToList();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public  usuario Get(int id)
        {
            var user = Context.usuario.FirstOrDefault(p => p.id == id);
            return user;
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult Post([FromBody] usuario user)
        {
            try
            {
                Context.usuario.Add(user);
                Context.SaveChanges();

                return Ok();
            }catch(Exception ex)
            {
                return BadRequest();
            }
            
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] usuario user)
        {
            try
            {
                if (user.id == id)
                {
                    Context.Entry(user).State = EntityState.Modified;
                    Context.SaveChanges();

                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var user = Context.usuario.FirstOrDefault(p => p.id == id);

                if(user != null)
                {
                    Context.usuario.Remove(user);
                    Context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return  BadRequest();
                }

            }catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
