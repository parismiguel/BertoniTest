using BertoniTest.Library.Models;
using BertoniTest.Library.Helpers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace BertoniTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppSettings AppSettings;

        public HomeController(IOptions<AppSettings> appSettings)
        {
            AppSettings = appSettings.Value;
        }

        public async Task<IActionResult> Index()
        {
            List<Album> albums = await GetAlbumsCollectionAsync();

            ViewData["Albums"] = new SelectList(albums, "Id", "Title");

            return View();
        }

        public ActionResult Vue()
        {
            return View();
        }

        public async Task<List<Album>> GetAlbumsCollectionAsync()
        {
            List<Album> output = new List<Album>();

            try
            {
                Response albums = await Api.WebRequestAsync(AppSettings.AlbumsUrl, Enums.HttpMethod.GET);

                output = JsonConvert.DeserializeObject<List<Album>>(albums.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return output;
        }

        public async Task<List<Photo>> GetPhotos(int albumId)
        {
            List<Photo> output = new List<Photo>();

            try
            {
                Response photos = await Api.WebRequestAsync(AppSettings.PhotosUrl, Enums.HttpMethod.GET);

                output = JsonConvert.DeserializeObject<List<Photo>>(photos.Message)
                                .Where(x=>x.AlbumId== albumId).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return output;
        }

        public async Task<List<Comment>> GetComments(int photoId)
        {
            List<Comment> output = new List<Comment>();

            try
            {
                Response comment = await Api.WebRequestAsync(AppSettings.ComentsUrl, Enums.HttpMethod.GET);

                output = JsonConvert.DeserializeObject<List<Comment>>(comment.Message)
                                .Where(x => x.PostId == photoId).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return output;
        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
