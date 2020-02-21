using ExamPreparatyion___IRunes.Services;
using ExamPreparatyion___IRunes.ViewModels.Tracks;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamPreparatyion___IRunes.Controllers
{
    public class TracksController:Controller
    {
        private readonly IRunesDbContext db;

        private readonly ITracksService tracksService;
        public TracksController(IRunesDbContext db,ITracksService tracksService)
        {
            this.db = db;
            this.tracksService = tracksService;
        }
        public HttpResponse Create(string albumId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new TracksViewModel()
            {
                AlbumId = albumId
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(CreateInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Name?.Length < 4 || input.Name.Length>20)
            {
                return this.Error("The name of the song must be at least 4 characters and at most 20.");
            }

            if (input.Price < 0)
            {
                return this.Error("Price cannto be negative value!");
            }

            this.tracksService.CreateTrack(input.Name,input.Link,input.Price,input.AlbumId);
            this.tracksService.ChangePriceOfTheAlbum(input.AlbumId);
            return this.Redirect("/Albums/Details?id=" + input.AlbumId);
        }

        public HttpResponse Details(string albumId,string trackId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.db.Tracks.Where(t => t.Id == trackId)
                .Select(m => new TracksDetailsViewModel
            {
                AlbumId = m.AlbumId,
                Name = m.Name,
                Price = m.Price,
                Link = m.Link
            }).FirstOrDefault();

            return this.View(viewModel);
        }

    }
}
