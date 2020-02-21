using ExamPreparatyion___IRunes.Services;

using Microsoft.EntityFrameworkCore;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPreparatyion___IRunes
{
    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IAlbumsService, AlbumsService>();
            serviceCollection.Add<ITracksService, TracksService>();
        }

        public void Configure(IList<Route> routeTable)
        {
            var db = new IRunesDbContext();
            db.Database.Migrate();
        }
    }
}
