using WakuWakuAPI.Domain.Models;

namespace WakuWakuAPI.Infraestructure.InMemory;
public class InMemoryPersistanceService : IInMemoryPersistenceService
{
    public IList<Category> Categories { get; set; }
    public IList<Goal> Goals { get; set; }

    public InMemoryPersistanceService()
    {
        /*
        Categories = new List<Category> {
                new Category("Language", "Category related to languages."),
                new Category("Musical Instrument", "Category related to musical instruments."),
                new Category("Programming Language", "Category related to programming languages."),
                new Category("Sports", "Category related to sports."),
                new Category("Science", "Category related to scientific disciplines."),
                new Category("Art", "Category related to visual and performing arts."),
                new Category("History", "Category related to historical events and periods."),
                new Category("Technology", "Category related to technological advancements."),
                new Category("Travel", "Category related to travel and exploration."),
                new Category("Health", "Category related to health and wellness."),
                new Category("Fashion", "Category related to clothing and style."),
                new Category("Food", "Category related to culinary delights."),
                new Category("Education", "Category related to learning and academia."),
                new Category("Nature", "Category related to the natural world."),
                new Category("Entertainment", "Category related to entertainment and media."),
                new Category("Business", "Category related to commerce and entrepreneurship."),
                new Category("Hobbies", "Category related to personal interests and pastimes."),
                new Category("Fitness", "Category related to physical fitness and exercise."),
                new Category("Pets", "Category related to animals and pets."),
                new Category("Home and Garden", "Category related to home improvement and gardening.")
            };

        Goals = new List<Goal> {
                new Goal("Aprender a programar en C#", DateTime.Today, new DateTime(2023, 12, 31), "En progreso"),
                new Goal("Obtener certificación de desarrollo web", DateTime.Today, new DateTime(2024, 7, 29), "Planificado"),
                new Goal("Correr un maratón", DateTime.Today, new DateTime(2023, 11, 30), "En espera"),
                new Goal("Aprender a tocar un instrumento", DateTime.Today, new DateTime(2024, 6, 30), "Planificado"),
                new Goal("Contribuir a un proyecto de código abierto", DateTime.Today, new DateTime(2023, 12, 31), "En progreso"),
             };
        */
    }
}
