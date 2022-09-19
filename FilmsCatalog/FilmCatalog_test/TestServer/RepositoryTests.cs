using Microsoft.AspNetCore.Mvc.Testing;
using Server;
using Server.Models;
using Server.Repository;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;

namespace ServerTest
{
    internal class RepositoryTests
    {
        public class FilmsRepositoryTests
        {
            [Fact]
            public void InsertFilms()
            {
                var Film = new Films
                {
                    _id = "test1",
                    _film_title = "Зеленая миля",
                    _film_genre = "драма",
                    _film_date = "1999",
                };
                CRepository repository = new();
                //Assert.Equal(Film, repository.InsertFilms(Film));
                //Assert.Null(repository.InsertFilms(Film));
                repository.DeleteFilmsById("test1");
            }

            [Fact]
            public void GetById()
            {
                var Film = new Films
                {
                    _id = "test2",
                    _film_title = "Зеленая миля",
                    _film_genre = "драма",
                    _film_date = "1999",
                };
                CRepository repository = new();
                repository.InsertFilms(Film);
                Assert.Equal(Film, repository.GetById("test2"));
                repository.DeleteFilmsById("test2");
                Assert.Null(repository.GetById("test2"));
            }

            [Fact]
            public void DeleteFilmsById()
            {
                var Film = new Films
                {
                    _id = "test3",
                    _film_title = "Зеленая миля",
                    _film_genre = "драма",
                    _film_date = "1999",
                };
                CRepository repository = new();
                repository.InsertFilms(Film);
                Assert.Equal(Film, repository.DeleteFilmsById("test3"));
                Assert.Null(repository.DeleteFilmsById("test3"));
            }

            [Fact]
            public void ChangeById()
            {
                var Film = new Films
                {
                    _id = "test4",
                    _film_title = "Зеленая миля",
                    _film_genre = "драма",
                    _film_date = "1999",
                };
                CRepository repository = new();
                repository.InsertFilms(Film);
                Film._film_date = "3000";
                Assert.Equal(Film, repository.ChangeDateFilmById("test4", "3000"));
                repository.DeleteFilmsById("testATM");
                Assert.Null(repository.ChangeDateFilmById("test4", "3000"));
            }

            [Fact]
            public void GetAllFilms()
            {
                var Film1 = new Films
                {
                    _id = "test1",
                    _film_title = "Зеленая миля",
                    _film_genre = "драма",
                    _film_date = "1999",
                };
                var Film2 = new Films
                {
                    _id = "test2",
                    _film_title = "Зеленая миля",
                    _film_genre = "драма",
                    _film_date = "1999",
                };
                var expectedList = new List<Films>();
                CRepository repository = new();

                repository.InsertFilms(Film1);
                expectedList.Add(Film1);

                repository.InsertFilms(Film2);
                expectedList.Add(Film2);

                Assert.Equal(expectedList, repository.GetAllFilms());
                repository.DeleteFilmsById("test1");
                repository.DeleteFilmsById("test2");

                expectedList.Clear();
                Assert.Equal(expectedList, repository.GetAllFilms());
            }
        }
    }
}
