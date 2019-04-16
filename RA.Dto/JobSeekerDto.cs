using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.Dto
{
    /// <summary>
    /// Соискатель
    /// </summary>
    public class JobSeekerDto
    {
        /// <summary>
        /// Номер соискателя
        /// </summary>
        public int SeekerID { get; set; }
        /// <summary>
        /// Номер типа работы
        /// </summary>
        public TypeOfWorkDto Work { get; set; }
        /// <summary>
        /// Имя соискателя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия соискателя
        /// </summary>
        public string SecondName { get; set; }
        /// <summary>
        /// Отчество соискателя
        /// </summary>
        public string ThirdName { get; set; }
        /// <summary>
        /// Квалификация соискателя
        /// </summary>
        public string Qualification { get; set; }
        /// <summary>
        /// Предполагаемая зарплата соискателя
        /// </summary>
        public decimal? AssumedSalary { get; set; }
        /// <summary>
        /// Прочая информация о соискателе
        /// </summary>
        public string Misc { get; set; }
    }
}
