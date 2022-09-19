using System.ComponentModel;
using System.Windows;
using Client.Commands;
//using Client.Views;

namespace Client.ViewModel
{
    public class FilmViewModel : INotifyPropertyChanged
    {
        public FilmRepositoryClient _filmRepository;

        //public ObservableCollection<FilmViewModel> _Films { get; } = new ObservableCollection<FilmViewModel>();

        public Task _film;
        public int Id => _film.FilmId;
        public FilmViewModel()
        {
            _film = new Task();

            AddFilm = new Command(async commandParameter =>
            {
                if (_filmRepository == null) return;
                if (Mode == "Add")
                {
                    await _filmRepository.PostFilmAsync(_film);
                }
                else
                {
                    await _filmRepository.PutFilmAsync(_film.FilmId, _film);
                }
                var window = (Window)commandParameter;
                window.DialogResult = true;
                window.Close();
            }, null);

        }

        public async System.Threading.Tasks.Task InitializeAsync(FilmRepositoryClient filmRepository, int filmId)
        {
            _filmRepository = filmRepository;
            if (Mode == "Add")
            {
                return;
            }
            _film = await _filmRepository.GetFilmAsync(filmId);
        }

        //public async System.Threading.Tasks.Task InitializeAsync(FilmRepositoryClient filmRepository)
        //{
        //    _filmRepository = filmRepository;
        //    _film = await _filmRepository.PostFilmAsync();
        //}

        public string Name
        {
            get => _film?.Name;
            set
            {
                if (value == _film.Name)
                {
                    return;
                }

                _film.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }


        public string Genre
        {
            get => _film?.Genre;
            set
            {
                if (value == _film.Genre)
                {
                    return;
                }

                _film.Genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }

        public string Date
        {
            get => _film.Date;
            set
            {
                if (value == _film.Date)
                {
                    return;
                }

                _film.Date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public string Mode { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public Command AddFilm { get; }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
