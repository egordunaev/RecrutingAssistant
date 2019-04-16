using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.Dto
{
    /// <summary>
    /// Класс сделки
    /// </summary>
    public class DealDto
    {
        /// <summary>
        /// Номер сделки
        /// </summary>
        public int DealID { get; set; }
        /// <summary>
        /// Номер вакансии
        /// </summary>
        public PositionDto Position { get; set; }
        /// <summary>
        /// Номер соискателя
        /// </summary>
        public JobSeekerDto Seeker { get; set; }
        /// <summary>
        /// Дата сделки
        /// </summary>
        public DateTime? DateOfDeal { get; set; }
        /// <summary>
        /// Коммиссионные
        /// </summary>
        public decimal? Commission { get; set; }
    }
}
