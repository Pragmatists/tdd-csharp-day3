using System.Collections.Generic;
using AllMyMovies.Model;
using NHibernate;

namespace AllMyMovies.Persistence
{
    public class MovieRepository
    {
        private readonly ISession session;

        public MovieRepository()
        {
        }

        public MovieRepository(ISession session)
        {
            this.session = session;
        }

        public virtual Movie Load(long id)
        {
            return session.Load<Movie>(id);
        }

        public virtual long Save(Movie movie)
        {
            using (var transaction = session.BeginTransaction())
            {
                var id = (long) session.Save(movie);
                transaction.Commit();
                return id;
            }
        }

        public virtual IList<Movie> FindAll()
        {
            return session.QueryOver<Movie>().List<Movie>();
        }
    }
}