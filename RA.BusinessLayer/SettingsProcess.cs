using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RA.DataAccess;

namespace RA.BusinessLayer
{
    public class SettingsProcess :ISettingsProcess
    {
        private readonly ISettingsDao settingsDao;
        public SettingsProcess()
        {
            settingsDao = new SettingsDao();
        }
        public string GetSettings()
        {
            return settingsDao.GetSettings();
        }

        public bool SetSettings(string server, string db, string user, string password)
        {
            return settingsDao.SetSettings(server, db, user, password);
        }
    }
}
