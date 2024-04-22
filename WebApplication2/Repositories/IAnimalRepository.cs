using WebApplication2.Models;

namespace WebApplication2.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals(string param);
    int AddAnimal(Animal animal);
    int UpdateAnimal(int id, Animal animal);
    int DeleteAnimal(int id);
    
  
}