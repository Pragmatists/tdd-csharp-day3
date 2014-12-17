using System.Collections.Generic;
using AllMyMovies.Model;
using AllMyMovies.Persistence;
using NHibernate;
using NUnit.Framework;

namespace MyMoviesTests.Persistence
{
    internal class MovieRepositoryTest
    {
        private const string SoundtrackTitle = "Star Wars: The Story Continues";
        private readonly SqliteConfiguration sqliteConfiguration = new SqliteConfiguration();
        private SessionHelper sessionHelper;
        private ISession session;
        private MovieRepository movieRepository;

        [SetUp]
        public void SetUp()
        {
            session = CreateTestSession();
            movieRepository = new MovieRepository(session);
        }

        private ISession CreateTestSession()
        {
            var session = sqliteConfiguration.Create(":memory:").CreateSchemaInMemory().Session;
            sessionHelper = new SessionHelper(session);
            return session;
        }

        [Test]
        public void ShouldStoreSoundtrack()
        {
            var id = session.Save(new Soundtrack(SoundtrackTitle));
            sessionHelper.ClearAndFlush();
            var loaded = session.Load<Soundtrack>(id);

            Assert.That(loaded.Title, Is.EqualTo(SoundtrackTitle));
        }

        [Test]
        public void ShouldStoreMovie()
        {
            var id = movieRepository.Save(new Movie
            {
                Title = "Star wars",
                Year = 1977,
                Soundtracks = new List<Soundtrack>(new[] {new Soundtrack(SoundtrackTitle)})
            });
            sessionHelper.ClearAndFlush();
            var loaded = movieRepository.Load(id);

            Assert.That(loaded.Title, Is.EqualTo("Star wars"));
            Assert.That(loaded.Year, Is.EqualTo(1977));
            Assert.That(loaded.Soundtracks[0].Title, Is.EqualTo(SoundtrackTitle));
        }

        [Test]
        public void ShouldFindAll()
        {
            movieRepository.Save(new Movie
            {
                Title = "Star wars",
            });
            sessionHelper.ClearAndFlush();
            movieRepository.Save(new Movie
            {
                Title = "Star trek",
            });
            new SessionHelper(session).ClearAndFlush();
            var loaded = movieRepository.FindAll();

            Assert.That(loaded[0].Title, Is.EqualTo("Star wars"));
            Assert.That(loaded[1].Title, Is.EqualTo("Star trek"));
        }

        [Test]
        public void ShouldUpdateMovie()
        {
            var movie = new Movie
            {
                Title = "Star wars",
            };
            movieRepository.Save(movie);
            sessionHelper.ClearAndFlush();
            movie.Title = "Inception";
            movieRepository.Save(movie);
            sessionHelper.ClearAndFlush();
            var updatedMovie = movieRepository.Load(movie.Id);
            Assert.That(updatedMovie.Title, Is.EqualTo("Inception"));
        }
    }
}