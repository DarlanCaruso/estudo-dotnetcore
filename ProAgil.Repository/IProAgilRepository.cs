using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
  public interface IProAgilRepository
  {
    // General
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;

    Task<bool> SaveChangesAsync();

    // Events
    Task<Event[]> GetAllEventsAsync(bool includeSpeakers);

    Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers);

    Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers);

    // Speakers
    Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents);
    Task<Speaker> GetSpeakerById(int speakerId, bool includeEvents);
  }
}