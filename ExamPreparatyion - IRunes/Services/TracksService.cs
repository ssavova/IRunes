using ExamPreparatyion___IRunes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamPreparatyion___IRunes.Services
{
    public class TracksService : ITracksService
    {
        private readonly IRunesDbContext db;
        public TracksService(IRunesDbContext db)
        {
            this.db = db;
        }

        public void ChangePriceOfTheAlbum(string albumId)
        {
            var searchedAlbum = this.db.Albums.Where(a => a.Id == albumId).FirstOrDefault();

            decimal currentPrice = searchedAlbum.Tracks.Sum(p => p.Price);
            decimal priceWithPromotion = currentPrice - (decimal)0.13*currentPrice;
            searchedAlbum.Price = priceWithPromotion;
            db.Albums.Update(searchedAlbum);
            db.SaveChanges();
        }

        public void CreateTrack(string name, string link, decimal price, string albumId)
        {
            
            Track track = new Track()
            {
                Name = name,
                Link = link,
                Price = price,
                AlbumId = albumId,
            };

            this.db.Tracks.Add(track);
            this.db.SaveChanges();
        }
    }
}
