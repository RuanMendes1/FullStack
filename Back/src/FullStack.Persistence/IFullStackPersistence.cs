using FullStack.Domain;

namespace FullStack.Persistence
{
    public interface IFullStackPersistence
    {
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         void DeleteRange<T>(T[] entity) where T: class;

         Task<bool> SaveChangesAsync();
         Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
         Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
         Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes);

         Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string tema, bool includeEventos);
         Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
         Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);
    }
}