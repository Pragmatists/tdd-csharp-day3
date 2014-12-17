using AllMyMovies.Model;
using NHibernate.Mapping.ByCode.Conformist;

namespace AllMyMovies.Persistence
{
    public class SoundtrackMapping : ClassMapping<Soundtrack>
    {
        public SoundtrackMapping()
        {
            Id(s=>s.Id);
            Property(s=>s.Title);
        }
    }
}