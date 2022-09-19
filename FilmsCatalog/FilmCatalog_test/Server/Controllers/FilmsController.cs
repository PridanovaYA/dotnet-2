using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Server.Models;
using Server.Repository;
using System;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    { 
        /// <summary>
        /// Репозиторий фильмов
        /// </summary>
        private readonly IRepository _filmListRepository;

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        public FilmsController(IRepository filmListRepository)
        {
            _filmListRepository = filmListRepository;
        }

        /// <summary>
        /// Получение всех фильмов
        /// </summary>
        /// <returns>All Films</returns>
        [HttpGet]
        public ActionResult<List<Films>> Get() => _filmListRepository.GetFilms();

        /// <summary>
        /// Получение фильма по идентификатору
        /// </summary>
        [HttpGet("{id:int}")]
        public ActionResult<Films> Get(int id)
        {
            try
            {
                if (id < -1)
                {
                    return NotFound();
                }
                var film = _filmListRepository.Get(id);
                return film;
            }
            catch
            {
                return Problem();
            }
        }


        /// <summary>
        /// Добавление фильма
        /// </summary>
        [HttpPost]
        public ActionResult<int> Post([FromBody] Films film)
        {

            try
            {
                return _filmListRepository.AddFilm(film);
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>
        /// Изменение параметров фильма по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="film">Новая задача</param>
        [HttpPut("{id:int}")]
        public ActionResult<int> Put(int id, [FromBody] Films film)
        {

            try
            {
                return _filmListRepository.UpdateFilm(id, film);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>
        /// Удаление всех фильмов
        /// </summary>
        [HttpDelete]
        public void Delete()
        {
            _filmListRepository.RemoveAllFilms();
        }

        /// <summary>
        /// Удаление фильма по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        [HttpDelete("{id:int}")]

        public ActionResult<int> Delete(int id)
        {
            try
            {
                return _filmListRepository.RemoveFilm(id);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            catch
            {
                return Problem();
            }
        }

    }
}
