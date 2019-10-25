using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
  public class ProAgilRepository : IProAgilRepository
  {
    private ProAgilContext _context { get; }

    public ProAgilRepository(ProAgilContext context)
    {
      _context = context;
    }

    #region General
    public void Add<T>(T entity) where T : class
    {
      _context.Add(entity);
    }

    public void Update<T>(T entity) where T : class
    {
      _context.Update(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
      _context.Remove(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
      return (await _context.SaveChangesAsync()) > 0;
    }

    #endregion

    #region Events
    public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
    {
      IQueryable<Event> query = _context.Events
        .Include(c => c.Lots)
        .Include(c => c.SocialMedias);

      if (includeSpeakers)
      {
        query = query
            .Include(se => se.SpeakerEvents)
            .ThenInclude(s => s.Speaker);
      }

      query = query.OrderByDescending(c => c.Date);

      return await query.ToArrayAsync();
    }

    public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers)
    {
      IQueryable<Event> query = _context.Events
        .Include(c => c.Lots)
        .Include(c => c.SocialMedias);

      if (includeSpeakers)
      {
        query = query
            .Include(se => se.SpeakerEvents)
            .ThenInclude(s => s.Speaker);
      }

      query = query.OrderByDescending(c => c.Date)
        .Where(c => c.Theme.ToLower().Contains(theme.ToLower()));

      return await query.ToArrayAsync();
    }

    public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers)
    {
      IQueryable<Event> query = _context.Events
        .Include(c => c.Lots)
        .Include(c => c.SocialMedias);

      if (includeSpeakers)
      {
        query = query
            .Include(se => se.SpeakerEvents)
            .ThenInclude(s => s.Speaker);
      }

      query = query.OrderByDescending(c => c.Date)
        .Where(c => c.Id == eventId);

      return await query.FirstOrDefaultAsync();
    }
    #endregion

    #region Speakers
    public async Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents = false)
    {
      IQueryable<Speaker> query = _context.Speakers
       .Include(c => c.SocialMedia);

      if (includeEvents)
      {
        query = query
            .Include(se => se.SpeakerEvents)
            .ThenInclude(e => e.Event);
      }

      query = query.OrderByDescending(c => c.Name)
        .Where(c => c.Name.ToLower().Contains(name.ToLower()));

      return await query.ToArrayAsync();
    }

    public async Task<Speaker> GetSpeakerById(int speakerId, bool includeEvents = false)
    {
      IQueryable<Speaker> query = _context.Speakers
        .Include(c => c.SocialMedia);

      if (includeEvents)
      {
        query = query
            .Include(se => se.SpeakerEvents)
            .ThenInclude(e => e.Event);
      }

      query = query.OrderByDescending(c => c.Name)
        .Where(c => c.Id == speakerId);

      return await query.FirstOrDefaultAsync();
    }
    #endregion
  }
}