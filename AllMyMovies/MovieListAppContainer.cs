using AllMyMovies.Gui;
using AllMyMovies.Persistence;

namespace AllMyMovies
{
    public class MovieListAppContainer
    {
        public MainWindow ResolveMainWindow()
        {
            var movieListPresenter = ResolveMovieListPresenter();
            var mainWindow = new MainWindow(movieListPresenter);
            movieListPresenter.View = mainWindow;
            return mainWindow;
        }

        private MovieListPresenter ResolveMovieListPresenter()
        {
            return new MovieListPresenter(ResolveMovieRepository());
        }

        private MovieRepository ResolveMovieRepository()
        {
            return new MovieRepository(new SqliteConfiguration().Create("movies.db").UpdateSchema().Session);
        }
    }
}