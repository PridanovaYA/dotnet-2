using Server.Models;
using System.Collections.Generic;

namespace Server.Repository
{
    public interface IRepository
    {
        /// <summary>
        /// Мeтод добавления фильма 
        /// </summary>
        /// <param name="film">Фильм</param>
        ///<returns>Идентификатор фильма</returns>
        public int AddFilm(Films film);

        /// <summary>
        /// Мeтод получения всех фильмов 
        /// </summary>
        List<Films> GetFilms();

        /// <summary>
        /// Мeтод удаления всех фильмов
        /// </summary>
        void RemoveAllFilms();

        /// <summary>
        /// Мeтод удаления фильма по ее идентификатору
        /// </summary>
        /// <param name="id">Идентификатор фильма</param>
        /// <returns>Идентификатор фильма</returns>
        int RemoveFilm(int id);

        /// <summary>
        /// Мeтод изменения фильма по ее идентификатору
        /// </summary>
        /// <param name="id">Идентификатор фильма</param>
        /// <param name="newFilm">Измененный фильм</param>
        int UpdateFilm(int id, Films newFilm);

        /// <summary>
        /// Метод записи в файл
        /// </summary>
        void WriteToFile();

        /// <summary>
        /// Мeтод получения фильма по ее идентификатору
        /// </summary>
        /// <param name="id">Идентификатор фильма</param>
        /// <returns>Задача</returns>
        Films Get(int id);

    }
}
