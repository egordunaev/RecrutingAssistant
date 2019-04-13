using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.DataAccess
{
    public interface ISettingsDao
    {
        string GetSettings();
        bool SetSettings(string server, string db, string user, string password);
    }
}
