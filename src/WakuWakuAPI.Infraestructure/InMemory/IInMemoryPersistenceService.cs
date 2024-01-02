using WakuWakuAPI.Domain.Models;

namespace WakuWakuAPI.Infraestructure.InMemory;
public interface IInMemoryPersistenceService {
    IList<Goal> Goals { get; }
    IList<Category> Categories { get; }

}
