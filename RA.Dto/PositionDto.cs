using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.Dto
{
    /// <summary>
    /// Вакансия
    /// </summary>
    public class PositionDto
    {
        /// <summary>
        /// Номер вакансии
        /// </summary>
        public int PositionID { get; set; }
        /// <summary>
        /// Номер работодателя
        /// </summary>
        public int EmployerID { get; set; }
        /// <summary>
        /// Название вакансии
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// Открытость вакансии
        /// </summary>
        public string IsOpen { get; set; }
        /// <summary>
        /// Зарплата вакансии
        /// </summary>
        public decimal? Salary { get; set; }

    }
}
