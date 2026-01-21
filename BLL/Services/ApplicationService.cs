using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public class ApplicationService
    {
        private readonly DataAccessFactory factory;

        public ApplicationService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        //CRUD Methods

        public bool Create(ApplicationDTO dto)
        {
            var data = MapperConfig.GetMapper().Map<Application>(dto);
            data.Status = "Pending";
            return factory.ApplicationData().Create(data);
        }

        public List<ApplicationResponseDTO> Get()
        {
            var data = factory.ApplicationData().Get();
            return MapperConfig.GetMapper().Map<List<ApplicationResponseDTO>>(data);
        }

        public ApplicationResponseDTO Get(int id)
        {
            var data = factory.ApplicationData().Get(id);
            return MapperConfig.GetMapper().Map<ApplicationResponseDTO>(data);
        }

        public bool UpdateStatus(ApplicationDTO dto)
        {
            var data = MapperConfig.GetMapper().Map<Application>(dto);
            return factory.ApplicationData().Update(data);
        }

        public bool Delete(int id)
        {
            return factory.ApplicationData().Delete(id);
        }

        //Feature Methods

        public List<JobApplicationsDTO> GetJobWiseApplications()
        {
            var data = factory.ApplicationFeature().GetJobsWithApplicationsAndUsers();
            return MapperConfig.GetMapper() .Map<List<JobApplicationsDTO>>(data);
        }


        public int GetApplicationCountByUser(int userId)
        {
            return factory.ApplicationFeature().GetApplicationCountByUser(userId);
        }

        public int GetTotalApplications()
        {
            return factory.ApplicationFeature().GetTotalApplications();
        }

        public bool UpdateApplicationStatus(int id, string newStatus)
        {
            return factory.ApplicationFeature().UpdateApplicationStatus(id, newStatus);
        }

        public List<ApplicationDTO> GetApplicationsByStatus(string status)
        {
            var data = factory.ApplicationFeature().GetApplicationsByStatus(status);
            return MapperConfig.GetMapper().Map<List<ApplicationDTO>>(data);
        }

        public List<ApplicationDTO> GetApplicationsByJob(int jobId)
        {
            var data = factory.ApplicationFeature().GetApplicationsByJob(jobId);
            return MapperConfig.GetMapper().Map<List<ApplicationDTO>>(data);
        }

        public Dictionary<string, int> GetApplicationCountStatisticsOfAJobBasedOnStatus(int jobId)
        {
            return factory.ApplicationFeature().GetApplicationCountStatisticsOfAJobBasedOnStatus(jobId);
        }

        public List<JobDTO> GetMostAppliedJobs()
        {
            var data = factory.ApplicationFeature().GetMostAppliedJobs();
            return MapperConfig.GetMapper().Map<List<JobDTO>>(data);
        }
    }
}
