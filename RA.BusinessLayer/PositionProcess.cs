using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RA.Dto;

namespace RA.BusinessLayer
{
    public class PositionProcess : IPositionProcess
    {
        private static readonly IDictionary<int, PositionDto> Positions = new Dictionary<int, PositionDto>();
        public void Add(PositionDto position)
        {
            int max = Positions.Keys.Count == 0 ? 1 : Positions.Keys.Max(p => p) + 1;
            position.PositionID = max;
            Positions.Add(max, position);
        }

        public void Delete(int PositionID)
        {
            if (Positions.ContainsKey(PositionID))
                Positions.Remove(PositionID);
        }

        public PositionDto Get(int PositionID)
        {
            return Positions.ContainsKey(PositionID) ? Positions[PositionID] : null;
        }

        public IList<PositionDto> GetList()
        {
            return new List<PositionDto>(Positions.Values);
        }

        public IList<PositionDto> SearchPosition(string PositionName, string Employer)
        {
            throw new NotImplementedException();
        }

        public void Update(PositionDto position)
        {
            if (Positions.ContainsKey(position.PositionID))
                Positions[position.PositionID] = position;
        }
    }
}
