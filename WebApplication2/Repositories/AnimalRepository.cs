using System.Data.SqlClient;
using WebApplication2.Models;

namespace WebApplication2.Repositories;

public class AnimalRepository : IAnimalRepository

{
    private IConfiguration _configuration;
    
    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    
    
    public IEnumerable<Animal> GetAnimals(string orderBy = "name")
    {
        string query = $"SELECT * FROM Animals ORDER BY {orderBy}";
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        connection.Open();

        using var command = new SqlCommand(query, connection);
        var dr = command.ExecuteReader();
        var animals = new List<Animal>();
        while (dr.Read())
        {
            animals.Add(new Animal
            {
                Id = dr.GetInt32(0),
                Name = dr.GetString(1),
                Description = dr.GetString(2),
                Category = dr.GetString(3),
                Area = dr.GetString(4)
            });
        }
        return animals;
    }

    public int AddAnimal (Animal animal)
    {
        string query = "INSERT INTO Animals (IdAnimal, Name, Description, Category, Area) VALUES (@IdAnimal, @Name, @Description, @Category, @Area)";
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@IdAnimal", animal.Id);
        command.Parameters.AddWithValue("@Name", animal.Name);
        command.Parameters.AddWithValue("@Description", animal.Description);
        command.Parameters.AddWithValue("@Category", animal.Category);
        command.Parameters.AddWithValue("@Area", animal.Area);
        return command.ExecuteNonQuery();
    }

    public int UpdateAnimal (int id, Animal animal)
    {
        string query = "UPDATE Animals SET Name = @Name, Description = @Description, Category = @Category, Area = @Area WHERE IdAnimal = @Id";
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);
        command.Parameters.AddWithValue("@Name", animal.Name);
        command.Parameters.AddWithValue("@Description", animal.Description);
        command.Parameters.AddWithValue("@Category", animal.Category);
        command.Parameters.AddWithValue("@Area", animal.Area);
        return command.ExecuteNonQuery();
    }

    
   public int DeleteAnimal ( int id)
   {
       string query = "DELETE FROM Animals WHERE IdAnimal = @Id";
       using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
       connection.Open();
       using var command = new SqlCommand(query, connection);
       command.Parameters.AddWithValue("@Id", id);
       return command.ExecuteNonQuery();
   }
}