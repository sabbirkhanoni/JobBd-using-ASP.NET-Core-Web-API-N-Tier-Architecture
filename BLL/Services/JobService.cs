using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class JobService
    {
        DataAccessFactory factory;

        public JobService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        public bool Create(JobDTO dto)
        {
            var data = MapperConfig.GetMapper().Map<Job>(dto);
            data.Status = "Open";
            return factory.JobData().Create(data);
        }

        public List<JobResponseDTO> Get()
        {
            var data = factory.JobData().Get();
            return MapperConfig.GetMapper().Map<List<JobResponseDTO>>(data);
        }

        public JobResponseDTO Get(int id)
        {
            var data = factory.JobData().Get(id);
            return MapperConfig.GetMapper().Map<JobResponseDTO>(data);
        }

        public bool Update(JobDTO dto)
        {
            var data = MapperConfig.GetMapper().Map<Job>(dto);
            data.Status = "Open";
            return factory.JobData().Update(data);
        }

        public bool Delete(int id)
        {
            return factory.JobData().Delete(id);
        }

        //Feature Services

        public List<JobDTO> Search(string keyword, string location, string status)
        {
            var data = factory.JobFeature().Search(keyword, location, status);
            return MapperConfig.GetMapper().Map<List<JobDTO>>(data);
        }

        public List<JobDTO> GetRecentJobs()
        {
            var data = factory.JobFeature().GetRecentJobs();
            return MapperConfig.GetMapper().Map<List<JobDTO>>(data);
        }

        public bool UpdateJobStatus(int id, string newStatus)
        {
            return factory.JobFeature().UpdateJobStatus(id, newStatus);
        }

        public List<JobDTO> GetJobsByStatus(string status)
        {
            var data = factory.JobFeature().GetJobsByStatus(status);
            return MapperConfig.GetMapper().Map<List<JobDTO>>(data);
        }

        public List<JobDTO> GetJobsBySalaryRange(decimal min, decimal max)
        {
            var data = factory.JobFeature().GetJobsBySalaryRange(min, max);
            return MapperConfig.GetMapper().Map<List<JobDTO>>(data);
        }

        public List<JobDTO> GetJobsByLocation(string location)
        {
            var data = factory.JobFeature().GetJobsByLocation(location);
            return MapperConfig.GetMapper().Map<List<JobDTO>>(data);
        }

        public List<JobDTO> GetJobsByCompany(int companyId)
        {
            var data = factory.JobFeature().GetJobsByCompany(companyId);
            return MapperConfig.GetMapper().Map<List<JobDTO>>(data);
        }

        public List<JobDTO> SearchByTitle(string title)
        {
            var data = factory.JobFeature().SearchByTitle(title);
            return MapperConfig.GetMapper().Map<List<JobDTO>>(data);
        }

        public List<JobDTO> SearchByDescription(string keyword)
        {
            var data = factory.JobFeature().SearchByDescription(keyword);
            return MapperConfig.GetMapper().Map<List<JobDTO>>(data);
        }

        public List<JobDTO> GetHighestSalaryJobs(int count)
        {
            var data = factory.JobFeature().GetHighestSalaryJobs(count);
            return MapperConfig.GetMapper().Map<List<JobDTO>>(data);
        }

        public List<JobDTO> GetLowestSalaryJobs(int count)
        {
            var data = factory.JobFeature().GetLowestSalaryJobs(count);
            return MapperConfig.GetMapper().Map<List<JobDTO>>(data);
        }

        public int GetApplicationCount(int jobId)
        {
            return factory.JobFeature().GetApplicationCount(jobId);
        }

        public List<JobDTO> GetJobsWithMostApplications()
        {
            var data = factory.JobFeature().GetJobsWithMostApplications();
            return MapperConfig.GetMapper().Map<List<JobDTO>>(data);
        }

        public List<ApplicationDTO> GetJobApplications(int jobId)
        {
            var data = factory.JobFeature().GetJobApplications(jobId);
            return MapperConfig.GetMapper().Map<List<ApplicationDTO>>(data);
        }

        public int GetTotalJobCount()
        {
            return factory.JobFeature().GetTotalJobCount();
        }

        public List<JobDTO> GetRecommendedJobs(int userId)
        {
            var data = factory.JobFeature().GetRecommendedJobs(userId);
            return MapperConfig.GetMapper().Map<List<JobDTO>>(data);
        }
    }
}

