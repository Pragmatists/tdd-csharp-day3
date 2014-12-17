using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using AllMyMovies.Gui;
using AllMyMovies.Model;
using AllMyMovies.Persistence;

namespace AllMyMovies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMovieListView
    {
        private MovieListPresenter movieListPresenter;

        public MainWindow(MovieListPresenter movieListPresenter)
        {
            InitializeComponent();
            this.movieListPresenter = movieListPresenter;
        }

        public string MovieTitle
        {
            get { return titleTextBox.Text; }
            set { titleTextBox.Text = value; }
        }

        public IList<Movie> Movies
        {
            set { moviesListBox.ItemsSource = value; }
        }

        public Movie SelectedMovie
        {
            get { return (Movie) moviesListBox.SelectedItem; }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            movieListPresenter.Save();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            movieListPresenter.OnLoaded();
        }

        private void moviesListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            movieListPresenter.OnSelectionChanged();
        }
    }
}
