using AllMyMovies.Model;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace AllMyMovies.Persistence
{
    public class MovieMapping : ClassMapping<Movie> 
    {
        public MovieMapping()
        {
            Id(m => m.Id, m=>m.Generator(Generators.Identity));
            Property(m=>m.Title);
            Property(m=>m.Year);
            Bag(m => m.Soundtracks, c => c.Cascade(Cascade.All), r => r.OneToMany());
        }
    }
}