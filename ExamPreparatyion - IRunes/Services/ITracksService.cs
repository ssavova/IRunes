using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPreparatyion___IRunes.Services
{
    public interface ITracksService
    {
        void CreateTrack(string name, string link, decimal price, string albumId);

        void ChangePriceOfTheAlbum(string albumId);
    }
}
