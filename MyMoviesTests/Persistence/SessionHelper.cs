using NHibernate;

namespace MyMoviesTests.Persistence
{
    internal class SessionHelper
    {
        private ISession session;

        public SessionHelper(ISession session)
        {
            this.session = session;
        }

        public void ClearAndFlush()
        {
            session.Flush();
            session.Clear();
        }
    }
}