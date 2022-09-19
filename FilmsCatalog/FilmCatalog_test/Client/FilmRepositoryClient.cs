using Client.Properties;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    public class FilmRepositoryClient
    {
        private readonly _Client _openApiClient;

        public FilmRepositoryClient()
        {
            var httpClient = new HttpClient();
            var baseUrl = Settings.Default.OpenApiServer;
            _openApiClient = new _Client(baseUrl, httpClient);
        }

        /// <summary>
        /// Метод получения фильмов
        /// </summary>
        public Task<ICollection<Task>> GetFilmsAsync()
        {
            return _openApiClient.FilmAllAsync();
        }

        /// <summary>
        /// Метод получения фильма по идентификатору  
        /// </summary>
        /// <param name="id">Идентификатор фильма</param>
        /// <returns>Фильм</returns>
        public Task<Task> GetFilmAsync(int id)
        {
            return _openApiClient.Film3Async(id);
        }

        /// <summary>
        /// Метод добавления фильма 
        /// </summary>
        /// <param name="film">Новый фильм</param>
        public System.Threading.Tasks.Task PostFilmAsync(Task task)
        {
            return _openApiClient.FilmAsync(task);
        }

        /// <summary>
        /// Метод замены фильма
        /// </summary>
        /// <param name="film">Новый фильм</param>
        /// <param name="id">Идентификатор заменяемого фильма</param>
        public System.Threading.Tasks.Task PutFilmAsync(int id, Task task)
        {
            return _openApiClient.Film4Async(id, task);
        }

        /// <summary>
        /// Метод удаления фильма 
        /// </summary>
        /// <param name="id">Идентификатор удаляемого фильма</param>
        public System.Threading.Tasks.Task RemoveFilmAsync(int id)
        {
            return _openApiClient.Film5Async(id);
        }

        /// <summary>
        /// Метод удаления всех фильмов
        /// </summary>
        public System.Threading.Tasks.Task DeleteAllFilmAsync()
        {
            return _openApiClient.Film2Async();
        }
    }
}
