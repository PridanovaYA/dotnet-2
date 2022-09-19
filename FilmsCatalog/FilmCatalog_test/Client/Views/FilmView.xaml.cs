using Client.ViewModel;
using System.Windows;

namespace Сlient.Views
{
    /// <summary>
    /// Логика взаимодействия для FilmView.xaml
    /// </summary>
    public partial class FilmView : Window
    {
        //private FilmViewModel filmViewModel;
        public FilmView()
        {
            InitializeComponent();
        }
        public FilmView(FilmViewModel filmViewModel)
        {
            InitializeComponent();
            DataContext = filmViewModel;
        }

    }
}
