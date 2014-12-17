namespace AllMyMovies.Model
{
    public class Soundtrack
    {
        protected Soundtrack()
        {
        }

        public Soundtrack(string title)
        {
            this.title = title;
        }

        private string title;
        public virtual string Title
        {
            get { return title; }
            set { title = value; }
        }

        public virtual long Id { get; set; }
    }
}