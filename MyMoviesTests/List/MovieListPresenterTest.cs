using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace MyMoviesTests.List
{
    internal class MovieListPresenterTest
    {
        [Test]
        public void ShouldAddAMovie()
        {
            var mockView = new Mock<IMovieListView>();
            mockView.SetupGet(v => v.Title).Returns("Star Wars");
            var movieListPresenter = new MovieListPresenter(mockView.Object);

            movieListPresenter.Add();

            mockView.VerifySet(v => v.Movies = new List<Movie>(new[] {new Movie {Title = "Star Wars"}}));
        }
    }
}