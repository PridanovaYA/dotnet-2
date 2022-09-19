using System.Collections.ObjectModel;
using System.ComponentModel;
using Client.Commands;
using System.Linq;
using System.Runtime.CompilerServices;
using Сlient.Views;

namespace Client.ViewModel
{
    public class MainFilmViewModel : INotifyPropertyChanged
    {
        private FilmRepositoryClient _filmRepository;
        public ObservableCollection<FilmViewModel> _Films { get; } = new ObservableCollection<FilmViewModel>();

        private FilmViewModel _selectFilm;
        public FilmViewModel SelectedFilm
        {
            get => _selectFilm;
            set
            {
                if (value == _selectFilm)
                {
                    return;
                }

                _selectFilm = value;
                OnPropertyChanged(nameof(SelectedFilm));
            }
        }

        public MainFilmViewModel()
        {
            AddFilmCommand = new Command(async _ =>
            {
                FilmViewModel filmViewModel = new FilmViewModel();
                int id = filmViewModel.Id;
                filmViewModel.Mode = "Add";
                await filmViewModel.InitializeAsync(_filmRepository, id);
                FilmView filmView = new FilmView(filmViewModel);
                if (filmView.ShowDialog() == true)
                {
                    _Films.Clear();
                    await InitializeAsync();
                }
            }, null);

            UpdateFilmCommand = new Command(_ =>
            {
                if (SelectedFilm != null)
                {
                    FilmViewModel filmViewModel = _Films.Single(tv => tv.Id == SelectedFilm.Id);
                    filmViewModel.Mode = "Update";
                    FilmView filmView = new FilmView(filmViewModel);
                    filmView.ShowDialog();
                }
            }, null);

            RemoveFilmCommand = new Command(async _ =>
            {
                if (SelectedFilm != null)
                {
                    await _filmRepository.RemoveFilmAsync(SelectedFilm.Id);
                    _Films.Remove(SelectedFilm);
                }
            }, null);

            RemoveAllFilmCommand = new Command(async _ =>
            {
                await _filmRepository.DeleteAllFilmAsync();
                _Films.Clear();
            }, null);

        }

        public async System.Threading.Tasks.Task InitializeAsync()
        {
            _filmRepository = new FilmRepositoryClient();

            var films = await _filmRepository.GetFilmsAsync();
            foreach (var film in films)
            {
                FilmViewModel filmViewModel = new FilmViewModel();
                filmViewModel.Mode = "Update";
                await filmViewModel.InitializeAsync(_filmRepository, film.FilmId);
                _Films.Add(filmViewModel);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Command AddFilmCommand { get; }
        public Command UpdateFilmCommand { get; }
        public Command RemoveFilmCommand { get; }
        public Command RemoveAllFilmCommand { get; }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private System.Collections.IEnumerable films;

        public System.Collections.IEnumerable Films { get => films; set => SetProperty(ref films, value); }
    }
}
