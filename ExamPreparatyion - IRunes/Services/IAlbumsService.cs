using System;
using System.Collections.Generic;
using ExamPreparatyion___IRunes.Models;
using ExamPreparatyion___IRunes.ViewModels.Albums;

namespace ExamPreparatyion___IRunes.Services
{
    public interface IAlbumsService
    {
        void Create(string name, string cover);

        IEnumerable<AlbumInfoViewModel> GetAll();

        AlbumDetailsViewModel GetDetails(string id);
    }
}
