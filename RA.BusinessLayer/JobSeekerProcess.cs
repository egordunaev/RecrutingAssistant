using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RA.Dto;

namespace RA.BusinessLayer
{
    public class JobSeekerProcess : IJobSeekerProcess
    {
        private static readonly IDictionary<int, JobSeekerDto> Seekers = new Dictionary<int, JobSeekerDto>();
        public void Add(JobSeekerDto seekerDto)
        {
            int max = Seekers.Keys.Count == 0 ? 1 : Seekers.Keys.Max(p => p) + 1;
            seekerDto.SeekerID = max;
            Seekers.Add(max, seekerDto);
        }

        public void Delete(int SeekerID)
        {
            if (Seekers.ContainsKey(SeekerID))
                Seekers.Remove(SeekerID);
        }

        public JobSeekerDto Get(int SeekerID)
        {
            return Seekers.ContainsKey(SeekerID) ? Seekers[SeekerID] : null;
        }

        public IList<JobSeekerDto> GetList()
        {
            return new List<JobSeekerDto>(Seekers.Values);
        }

        public void Update(JobSeekerDto seekerDto)
        {
            if (Seekers.ContainsKey(seekerDto.SeekerID))
                Seekers[seekerDto.SeekerID] = seekerDto;
        }
    }
}
