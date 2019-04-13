﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.Dto
{
    /// <summary>
    /// Работодатель
    /// </summary>
    public class Employer
    {
        /// <summary>
        /// Номер работодателя
        /// </summary>
        public int EmployerID { get; set; }
        /// <summary>
        /// Номер типа работы
        /// </summary>
        public int WorkID { get; set; }
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
