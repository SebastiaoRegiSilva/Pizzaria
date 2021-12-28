using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {
        }
        // GET all action
        [HttpGet]
        public ActionResult<List<PizzaModel>> GetAll()
        {
            return PizzaService.GetAll();

        }
        
        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<PizzaModel> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if(pizza == null)
                return NotFound();

            return pizza;    
        }
        
        // POST action
        [HttpPost]
        public IActionResult Create(PizzaModel pizza)
        {            
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, PizzaModel pizza)
        {
            if (id != pizza.Id)
                return BadRequest();

            var existingPizza = PizzaService.Get(id);
            if(existingPizza is null)
                 return NotFound();

            PizzaService.Update(pizza);           
            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           var pizza = PizzaService.Get(id);
            if (pizza is null)
                return NotFound();

            PizzaService.Delete(id);
            return NoContent();
        }
    }
}