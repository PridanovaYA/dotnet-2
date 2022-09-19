using Microsoft.Extensions.Configuration;
using Server.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Server.Repository
{
    public class CRepository : IRepository
    {
        /// <summary>
        /// Название файла хранения
        /// </summary>
        //public readonly string _storageFileName = "film.xml";
        //object locker = new object();
        
        private readonly List<Films> _films;

        /// <summary>
        /// Файл хранения
        /// </summary>
        public CRepository(IConfiguration configuration = null)
        {
            //if (configuration != null)
            //{
            //    "film.xml" = configuration.GetValue<string>("Server");
            //}

            if (!File.Exists("film.xml"))
            {
                _films = new List<Films>();
                return;
            }
            var xmlSerializer = new XmlSerializer(typeof(List<Films>));
            using var fileReader = new FileStream("film.xml", FileMode.Open);
            _films = (List<Films>)xmlSerializer.Deserialize(fileReader);
        }

        /// <summary>
        /// Метод записи в файл
        /// </summary>
        public void WriteToFile()
        {
            lock (locker)
            {
                var xmlSerializer = new XmlSerializer(typeof(List<Films>));
                using FileStream fileWriter = new FileStream("film.xml", FileMode.Create);
                xmlSerializer.Serialize(fileWriter, _films);
            }
        }
        object locker = new object();

        /// <summary>
        /// Мeтод получения фильма по ее идентификатору
        /// </summary>
        /// <param name="id">Идентификатор фильма</param>
        /// <returns>Задача</returns>
        public Films Get(int id) => _films.FirstOrDefault(p => p.FilmId == id);

        /// <summary>
        /// Мeтод добавления фильма
        /// </summary>
        /// <param name="film">Фильм</param>
        ///<returns>Идентификатор фильма</returns>
        public int AddFilm(Films film)
        {
            if (film.FilmId == default)
            {
                if (_films.Count == 0)
                {
                    film.FilmId = 1;
                    _films.Add(film);
                }
                else
                {
                    film.FilmId = _films.Max(t => t.FilmId) + 1;
                    _films.Add(film);
                }
            }
            else
            {
                if (_films.FindIndex(t => t.FilmId == film.FilmId) == -1)
                {
                    _films.Add(film);
                }
                else
                {
                    throw new Exception("This ID already exists");
                }
            }
            return film.FilmId;
        }

        /// <summary>
        /// Мeтод удаления всех фильмов
        /// </summary>

        public void RemoveAllFilms()
        {
            _films.RemoveRange(0, _films.Count);
        }

        /// <summary>
        /// Мeтод получения всех фильмов
        /// </summary>
        public List<Films> GetFilms()
        {
            return _films;
        }

        /// <summary>
        /// Мeтод удаления фильма по ее идентификатору
        /// </summary>
        /// <param name="id">Идентификатор фильма</param>
        /// <returns>Идентификатор фильма</returns>
        public int RemoveFilm(int id)
        {
            var deletedFilm = Get(id);
            _films.Remove(deletedFilm);
            return id;
        }

        /// <summary>
        /// Мeтод изменения фильма по ее идентификатору
        /// </summary>
        /// <param name="id">Идентификатор фильма</param>
        /// <param name="newFilm">Измененная фильма</param>
        public int UpdateFilm(int id, Films newFilm)
        {
            var filmIndex = _films.FindIndex(p => p.FilmId == id);
            _films[filmIndex] = newFilm;
            return id;
        }
    }
}
