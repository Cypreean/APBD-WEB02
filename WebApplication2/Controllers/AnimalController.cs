using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    private readonly IAnimalService _animalService;
    
    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }
    
    
    [HttpGet]
    public ActionResult<IEnumerable<Animal>> GetAnimals([FromQuery] string orderBy = "name")
    {
        try
        {
            var animals = _animalService.GetAnimals(orderBy);
            return Ok(animals);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<Animal>> AddAnimal([FromBody] Animal animal)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var addedAnimal =  _animalService.AddAnimal(animal);
            return Ok(addedAnimal);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut]
       public async Task<ActionResult<Animal>> UpdateAnimal([FromQuery] int id, [FromBody] Animal animal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
    
            try
            {
                var updatedAnimal =  _animalService.UpdateAnimal(id, animal);
                return Ok(updatedAnimal);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
       [HttpDelete]
       public async Task<ActionResult<Animal>> DeleteAnimal([FromQuery] int id)
       {
              try
              {
                var deletedAnimal =  _animalService.DeleteAnimal(id);
                return Ok(deletedAnimal);
              }
              catch (ArgumentException ex)
              {
                return BadRequest(ex.Message);
              }
       }
    
   
}