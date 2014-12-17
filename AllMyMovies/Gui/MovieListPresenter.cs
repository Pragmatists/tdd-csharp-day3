using AllMyMovies.Model;
using AllMyMovies.Persistence;

namespace AllMyMovies.Gui
{
    public class MovieListPresenter
    {
        private IMovieListView movieListView;
        private readonly MovieRepository movieRepository;

        public MovieListPresenter(MovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public void Save()
        {
            var movie = GetMovieToSave();
            movieRepository.Save(movie);
            RefreshMovies();
        }

        private Movie GetMovieToSave()
        {
            if (NoMovieSelected)
            {
                return new Movie {Title = movieListView.MovieTitle};
            }
            var movie = movieListView.SelectedMovie;
            movie.Title = movieListView.MovieTitle;
            return movie;
        }

        public void OnLoaded()
        {
            RefreshMovies();
        }

        private void RefreshMovies()
        {
            movieListView.Movies = movieRepository.FindAll();
        }

        public void OnSelectionChanged()
        {
            if (NoMovieSelected)
            {
                ClearDetails();
            }
            else
            {
                FillDetails(movieListView.SelectedMovie);
            }
        }

        private bool NoMovieSelected
        {
            get { return movieListView.SelectedMovie == null; }
        }

        public IMovieListView View
        {
            set { movieListView = value; }
        }

        private void FillDetails(Movie selectedMovie)
        {
            movieListView.MovieTitle = selectedMovie.Title;
        }

        private void ClearDetails()
        {
            movieListView.MovieTitle = "";
        }
    }
}