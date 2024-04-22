using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Services;

public class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _animalRepository;
    
    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public IEnumerable<Animal> GetAnimals(string param)
    {
        if ( string.IsNullOrEmpty(param) )
        {
            throw new ArgumentException("Invalid parameter");
        }
        return _animalRepository.GetAnimals(param);
    }

    public int AddAnimal(Animal animal)
    {
        if ( animal == null )
        {
            throw new ArgumentException("Invalid parameter");
        }
        return _animalRepository.AddAnimal(animal);
    }

    public int UpdateAnimal(int id, Animal animal)
    {
        if ( animal == null )
        {
            throw new ArgumentException("Invalid parameter");
        }
        return _animalRepository.UpdateAnimal(id, animal);
    }

    public int DeleteAnimal(int id)
    {
        return _animalRepository.DeleteAnimal(id);
    }
}