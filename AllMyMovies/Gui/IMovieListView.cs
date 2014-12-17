using System.Collections.Generic;
using AllMyMovies.Model;

namespace AllMyMovies.Gui
{
    public interface IMovieListView
    {
        string MovieTitle { get; set; }
        IList<Movie> Movies { set; }
        Movie SelectedMovie { get; }
    }
}