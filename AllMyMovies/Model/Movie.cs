using System.Collections.Generic;

namespace AllMyMovies.Model
{
    public class Movie
    {
        public virtual string Title { get; set; }

        public virtual long Id { get; set; }

        public virtual int Year { get; set; }

        public virtual IList<Soundtrack> Soundtracks { get; set; }

        public virtual bool Equals(Movie other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Title, Title) && other.Id == Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Movie)) return false;
            return Equals((Movie) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Title != null ? Title.GetHashCode() : 0)*397) ^ Id.GetHashCode();
            }
        }

        public override string ToString()
        {
            return Title;
        }
    }
}