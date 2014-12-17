using AllMyMovies.Model;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace AllMyMovies.Persistence
{
    public class SqliteConfiguration
    {
        private Configuration configuration;
        private ISession session;

        public ISession Session
        {
            get { return session; }
        }

        public SqliteConfiguration Create(string databaseName)
        {
            configuration = new Configuration();
            configuration.DataBaseIntegration(db =>
                                                  {
                                                      db.Driver<SQLite20Driver>();
                                                      db.Dialect<SQLiteDialect>();
                                                      db.ConnectionProvider<DriverConnectionProvider>();
                                                      db.ConnectionString = "Data Source=" + databaseName + ";";
                                                      db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                                                      db.ConnectionReleaseMode = ConnectionReleaseMode.OnClose;
                                                      db.LogFormattedSql = true;
                                                      db.LogSqlInConsole = true;
                                                  });
            configuration.AddMapping(CreateMappings());
            var sessionFactory = configuration.BuildSessionFactory();
            session = sessionFactory.OpenSession();
            return this;
        }

        private static HbmMapping CreateMappings()
        {
            var modelMapper = new ModelMapper();
            modelMapper.AddMapping<MovieMapping>();
            modelMapper.AddMapping<SoundtrackMapping>();
            return modelMapper.CompileMappingFor(new[] {typeof (Movie), typeof(Soundtrack)});
        }

        public SqliteConfiguration CreateSchemaInMemory()
        {
            new SchemaExport(configuration).Execute(true, true, false, session.Connection, null);
            return this;
        }

        public SqliteConfiguration UpdateSchema()
        {
            new SchemaUpdate(configuration).Execute(false, true);
            return this;
        }
    }
}