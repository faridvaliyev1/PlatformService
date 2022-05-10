using PlatformService.Models;

namespace PlatformService.Data{
    public class PlatformRepo : IPlatformRepo
    {
        private AppDbContext _context;

        public PlatformRepo(AppDbContext context){
            _context=context;
        }
        public void CreatePlatform(Platform platform)
        {
           if(platform==null)
                throw new ArgumentNullException(nameof(platform));
            
            _context.Platforms.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int Id)
        {
            return _context.Platforms.First(p=>p.Id==Id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }
    }
}