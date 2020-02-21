using SIS.MvcFramework;
using System;
using System.Threading.Tasks;

namespace ExamPreparatyion___IRunes
{
    public static class Program
    {
        public static async Task Main()
        {
            await WebHost.StartAsync(new Startup());
        }
    }
}
