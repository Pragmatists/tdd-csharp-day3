using System.Collections.Generic;
using AllMyMovies.Gui;
using AllMyMovies.Model;
using AllMyMovies.Persistence;
using Moq;
using NUnit.Framework;

namespace MyMoviesTests
{
    internal class MovieListPresenterTest
    {
        private Mock<IMovieListView> mockView;
        private Mock<MovieRepository> mockRepository;
        private MovieListPresenter movieListPresenter;

        [SetUp]
        public void SetUp()
        {
            mockRepository = new Mock<MovieRepository>();
            mockView = new Mock<IMovieListView>();
            movieListPresenter = new MovieListPresenter(mockRepository.Object);
            movieListPresenter.View = mockView.Object;
        }

        [Test]
        public void ShouldLoadMoviesFromRepoOnStart()
        {
            var movies = new List<Movie>(new[] {new Movie {Title = "Star Wars"}});
            mockRepository.Setup(r => r.FindAll()).Returns(movies);

            movieListPresenter.OnLoaded();

            mockView.VerifySet(v => v.Movies = movies);
        }

        [Test]
        public void ShouldAddAMovie()
        {
            mockView.SetupGet(v => v.MovieTitle).Returns("Star Wars");

            movieListPresenter.Save();

            mockRepository.Verify(r=>r.Save(new Movie {Title = "Star Wars"}));
            VerifyViewRefreshed();
        }

        [Test]
        public void ShouldShowDetailsOfSelectedMovie()
        {
            mockView.SetupGet(v => v.SelectedMovie).Returns(new Movie {Title = "Star wars"});

            movieListPresenter.OnSelectionChanged();

            mockView.VerifySet(v=>v.MovieTitle = "Star wars");
        }

        [Test]
        public void ShouldClearDetailsWhenNoSelection()
        {
            mockView.SetupGet(v => v.SelectedMovie).Returns((Movie) null);

            movieListPresenter.OnSelectionChanged();

            mockView.VerifySet(v => v.MovieTitle = "");
        }

        [Test]
        public void ShouldUpdateMovie()
        {
            var movie = new Movie{Title = "Minority Report", Id = 15};
            mockView.SetupGet(v => v.SelectedMovie).Returns(movie);
            mockView.SetupGet(v => v.MovieTitle).Returns("Inception");

            movieListPresenter.Save();

            mockRepository.Verify(r=>r.Save(new Movie{Id=15, Title = "Inception"}));
            VerifyViewRefreshed();
        }

        private void VerifyViewRefreshed()
        {
            mockView.VerifySet(v => v.Movies = It.IsAny<IList<Movie>>());
        }
    }
}