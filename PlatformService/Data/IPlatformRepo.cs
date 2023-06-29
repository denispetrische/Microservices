using PlatformService.Models;
using System.Collections.Generic;

namespace PlatformService.Data
{
    public interface IPlatformRepo
    {
        bool SaveChanges();
        IEnumerable<Platform> GetAll();
        Platform GetPlatformById(int id);
        void CreatePlatform(Platform platform);
    }
}
