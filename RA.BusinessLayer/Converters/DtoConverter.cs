using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RA.Dto;
using RA.DataAccess.Entities;
using RA.DataAccess;

namespace RA.BusinessLayer.Converters
{
    /// <summary>
    /// Конвертер.
    /// </summary>
    public class DtoConverter
    {
        //
        // DEAL
        //
        public static  DealDto Convert(Deal deal)
        {
            if (deal == null)
                return null;
            DealDto dealDto = new DealDto();
            dealDto.DealID = deal.DealID;
            dealDto.DateOfDeal = deal.DateOfDeal;
            dealDto.Commission = deal.Commission;
            dealDto.Position = Convert(DaoFactory.GetPositionDao().Get(deal.PositionID));
            dealDto.Seeker = Convert(DaoFactory.GetJobSeekerDao().Get(deal.SeekerID));
            return dealDto;
        }
        public static Deal Convert(DealDto dealDto)
        {
            if (dealDto == null)
                return null;
            Deal deal = new Deal();
            deal.DealID = dealDto.DealID;
            deal.DateOfDeal = dealDto.DateOfDeal;
            deal.Commission = dealDto.Commission;
            deal.PositionID = dealDto.Position.PositionID;
            deal.SeekerID = dealDto.Seeker.SeekerID;
            return deal;
        }
        public static IList<DealDto> Convert(IList<Deal> deals)
        {
            if (deals == null)
                return null;
            IList<DealDto> dealDtos = new List<DealDto>();
            foreach(var deal in deals)
            {
                dealDtos.Add(Convert(deal));
            }
            return dealDtos;
        }
        //
        // EMPLOYER
        //
        public static EmployerDto Convert(Employer employer)
        {
            if (employer == null)
                return null;
            EmployerDto employerDto = new EmployerDto();
            employerDto.EmployerID = employer.EmployerID;
            employerDto.Name = employer.Name;
            employerDto.Address = employer.Address;
            employerDto.PhoneNumber = employer.PhoneNumber;
            employerDto.Work = Convert(DaoFactory.GetTypeOfWorkDao().Get(employer.WorkID));
            return employerDto;
        }
        public static Employer Convert(EmployerDto employerDto)
        {
            if (employerDto == null)
                return null;
            Employer employer = new Employer();
            employer.EmployerID = employerDto.EmployerID;
            employer.Name = employerDto.Name;
            employer.Address = employerDto.Address;
            employer.PhoneNumber = employerDto.PhoneNumber;
            employer.WorkID = employerDto.Work.WorkID;
            return employer;
        }
        public static IList<EmployerDto> Convert(IList<Employer> employers)
        {
            if (employers == null)
                return null;
            IList<EmployerDto> employerDtos = new List<EmployerDto>();
            foreach (var employer in employers)
            {
                employerDtos.Add(Convert(employer));
            }
            return employerDtos;
        }
        //
        // JOBSEEKER
        //
        public static JobSeekerDto Convert(JobSeeker seeker)
        {
            if (seeker == null)
                return null;
            JobSeekerDto seekerDto = new JobSeekerDto();
            seekerDto.SeekerID = seeker.SeekerID;
            seekerDto.FirstName = seeker.FirstName;
            seekerDto.SecondName = seeker.SecondName;
            seekerDto.ThirdName = seeker.ThirdName;
            seekerDto.Qualification = seeker.Qualification;
            seekerDto.AssumedSalary = seeker.AssumedSalary;
            seekerDto.Misc = seeker.Misc;
            seekerDto.Work = Convert(DaoFactory.GetTypeOfWorkDao().Get(seeker.WorkID));
            return seekerDto;
        }
        public static JobSeeker Convert(JobSeekerDto seekerDto)
        {
            if (seekerDto == null)
                return null;
            JobSeeker seeker = new JobSeeker();
            seeker.SeekerID = seekerDto.SeekerID;
            seeker.FirstName = seekerDto.FirstName;
            seeker.SecondName = seekerDto.SecondName;
            seeker.ThirdName = seekerDto.ThirdName;
            seeker.Qualification = seekerDto.Qualification;
            seeker.AssumedSalary = seekerDto.AssumedSalary;
            seeker.Misc = seekerDto.Misc;
            seeker.WorkID = seekerDto.Work.WorkID;
            return seeker;

        }
        public static IList<JobSeekerDto> Convert(IList<JobSeeker> seekers)
        {
            if (seekers == null)
                return null;
            IList<JobSeekerDto> seekerDtos = new List<JobSeekerDto>();
            foreach(var seeker in seekers)
            {
                seekerDtos.Add(Convert(seeker));
            }
            return seekerDtos;
        }
        //
        // POSITION
        //
        public static PositionDto Convert(Position position)
        {
            if (position == null)
                return null;
            PositionDto positionDto = new PositionDto();
            positionDto.PositionID = position.PositionID;
            positionDto.PositionName = position.PositionName;
            positionDto.IsOpen = position.IsOpen;
            positionDto.Salary = position.Salary;
            positionDto.employer = Convert(DaoFactory.GetEmployerDao().Get(position.EmployerID));
            return positionDto;
        }
        public static Position Convert(PositionDto positionDto)
        {
            if (positionDto == null)
                return null;
            Position position = new Position();
            position.PositionID = positionDto.PositionID;
            position.PositionName = positionDto.PositionName;
            position.IsOpen = positionDto.IsOpen;
            position.Salary = positionDto.Salary;
            position.EmployerID = positionDto.employer.EmployerID;
            return position;
        }
        public static IList<PositionDto> Convert(IList<Position> positions)
        {
            if (positions == null)
                return null;
            IList<PositionDto> positionDtos = new List<PositionDto>();
            foreach(var position in positions)
            {
                positionDtos.Add(Convert(position));
            }
            return positionDtos;
        }
        //
        // TYPE OF WORK
        //
        public static TypeOfWorkDto Convert(TypeOfWork work)
        {
            if (work == null)
                return null;
            TypeOfWorkDto workDto = new TypeOfWorkDto();
            workDto.WorkID = work.WorkID;
            workDto.Name = work.Name;
            return workDto;
        }
        public static TypeOfWork Convert(TypeOfWorkDto workDto)
        {
            if (workDto == null)
                return null;
            TypeOfWork work = new TypeOfWork();
            work.WorkID = workDto.WorkID;
            work.Name = workDto.Name;
            return work;
        }
        public static IList<TypeOfWorkDto> Convert(IList<TypeOfWork> works)
        {
            if (works == null)
                return null;
            IList<TypeOfWorkDto> workDtos = new List<TypeOfWorkDto>();
            foreach(var work in works)
            {
                workDtos.Add(Convert(work));
            }
            return workDtos;
        }
        //
        // Report Item
        //
        private static ReportItemDto Convert(Report report)
        {
            if (report == null) { return null; }
            ReportItemDto reportdto = new ReportItemDto
            {
                date = report.date.ToString(),
                count = report.count,
                commission=report.commission
            };
            return reportdto;
        }
        public static IList<ReportItemDto> Convert(IEnumerable<Report> reports)
        {
            if (reports == null) { return null; }
            IList<ReportItemDto> ReportsDto = new List<ReportItemDto>();
            foreach (var r in reports)
            {
                ReportsDto.Add(Convert(r));
            }
            return ReportsDto;
        }
    }
}
