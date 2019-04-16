using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.Dto
{
    /// <summary>
    /// Работодатель
    /// </summary>
    public class EmployerDto
    {
        /// <summary>
        /// Номер работодателя
        /// </summary>
        public int EmployerID { get; set; }
        /// <summary>
        /// Номер типа работы
        /// </summary>
        public TypeOfWorkDto Work { get; set; }
        /// <summary>
        /// Имя работодателя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Адрес работодателя
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Номер телефона работодателя
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
