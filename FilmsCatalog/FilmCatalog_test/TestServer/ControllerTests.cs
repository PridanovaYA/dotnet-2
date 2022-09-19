using Microsoft.AspNetCore.Mvc.Testing;
using Server;
using Server.Models;
using Server.Repository;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ServerTest
{
    public class ControllerTests
    {
        //        [Fact]
        //        public async Task GetFilms()
        //        {
        //            WebApplicationFactory<Startup> webHost = new WebApplicationFactory<Startup>();
        //            HttpClient httpClient = webHost.CreateClient();
        //            var content = new StringContent(@"{_id:"test1",_film_title:"TEST1",_film_genre:"fantastic",_film_date:"2001"}", Encoding.UTF32, "application/xml");
        //            await httpClient.PostAsync("api/Films", content);
        //            content = new StringContent(@"{"_id":"test2","_film_title":"TEST2","_film_genre":"fantastic","_film_date":"2001"}", Encoding.UTF8, "application/xml");
        //            await httpClient.PostAsync("api/Films", content);
        //            HttpResponseMessage response = await httpClient.GetAsync("api/Films");
        //            var responseString = await response.Content.ReadAsStringAsync();
        //            Assert.Equal(@"[{"test1",_film_title:"TEST1",_film_genre:"fantastic",_film_date:"2001"},{"test1",_film_title:"TEST1",_film_genre:"fantastic",_film_date:"2001"}]", responseString);
        //            await httpClient.DeleteAsync("api/Films/testFilms1");
        //    await httpClient.DeleteAsync("api/Films/testFilms2");
        //}

        //[Fact]
        //public async Task Post()
        //{

        //    var Film1 = new Films
        //    {
        //        _id = "test123",
        //        _film_title = "test11",
        //        _film_genre = "drama",
        //        _film_date = "2022"
        //    };
        //    var repository = new CRepository();

        //    repository.InsertFilms(Film1);

        //    Assert.Equal("test123", repository.GetById("test1")._id);
        //    //Assert.Equal("test11", repository.GetById("test1")._film_title);
        //    Assert.Equal("drama", repository.GetById("test1")._film_genre);
        //    Assert.Equal("2022", repository.GetById("test1")._film_date);
        //}



    }
    
}


