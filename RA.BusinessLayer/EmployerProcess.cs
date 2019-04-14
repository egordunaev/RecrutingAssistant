using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RA.Dto;

namespace RA.BusinessLayer
{
    public class EmployerProcess : IEmployerProcess
    {
        private static readonly IDictionary<int, EmployerDto> Employers = new Dictionary<int, EmployerDto>();
        public void Add(EmployerDto employer)
        {
            int max = Employers.Keys.Count == 0 ? 1 : Employers.Keys.Max(p => p) + 1;
            employer.EmployerID = max;
            Employers.Add(max, employer);
        }

        public void Delete(int EmployerID)
        {
            if (Employers.ContainsKey(EmployerID))
                Employers.Remove(EmployerID);
        }

        public EmployerDto Get(int EmployerID)
        {
            return Employers.ContainsKey(EmployerID) ? Employers[EmployerID] : null;
        }

        public IList<EmployerDto> GetList()
        {
            return new List<EmployerDto>(Employers.Values);
        }

        public void Update(EmployerDto employer)
        {
            if (Employers.ContainsKey(employer.EmployerID))
                Employers[employer.EmployerID] = employer;
        }
    }
}
