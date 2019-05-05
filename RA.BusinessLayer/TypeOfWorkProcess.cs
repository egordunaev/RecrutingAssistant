using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RA.Dto;

namespace RA.BusinessLayer
{
    public class TypeOfWorkProcess : ITypeOfWorkProcess
    {
        private static readonly IDictionary<int, TypeOfWorkDto> Works = new Dictionary<int, TypeOfWorkDto>();
        public void Add(TypeOfWorkDto workDto)
        {
            int max = Works.Keys.Count == 0 ? 1 : Works.Keys.Max(p => p) + 1;
            workDto.WorkID = max;
            Works.Add(max, workDto);
        }

        public void Delete(int WorkID)
        {
            if (Works.ContainsKey(WorkID))
                Works.Remove(WorkID);
        }

        public TypeOfWorkDto Get(int WorkID)
        {
            return Works.ContainsKey(WorkID) ? Works[WorkID] : null;
        }

        public IList<TypeOfWorkDto> GetList()
        {
            return new List<TypeOfWorkDto>(Works.Values);
        }

        public IList<TypeOfWorkDto> SearchWork(string TypeOfWork)
        {
            throw new NotImplementedException();
        }

        public void Update(TypeOfWorkDto workDto)
        {
            if (Works.ContainsKey(workDto.WorkID))
                Works[workDto.WorkID] = workDto;
        }
    }
}
