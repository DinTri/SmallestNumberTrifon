using System.Linq;
using SmallestNumberTrifon.Contracts;
using SmallestNumberTrifon.Model;
using SmallestNumberTrifon.Model.Settings;

namespace SmallestNumberTrifon.Services
{
    public class SettingService : ISettings
    {
        private readonly Settings _settings;
        private readonly SimpleNumberContext _context;

        public SettingService(SimpleNumberContext context)
        {
            _settings = new Settings();
            _context = context;
        }
        
        public bool AddLimit(int id,int limit)
        {
            _settings.Limit = limit;
            _settings.Id = id;
            _context.Settingses.Add(new Settings{Limit = _settings.Limit, Id = _settings.Id});
            _context.SaveChanges();
            return _settings.Limit != 0;
        }

        public int GetLimit()
        {
            return int.TryParse(_context.Settingses.LastOrDefault()?.Limit.ToString(), out var retvalue) ? retvalue : 0;
        }
    }
}
