using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IJobFeature
    {
        List<Job> GetRecommendedJobs(int userId);
        List<Job> Search(string? keyword, string? location, string? status);
        List<Job> GetRecentJobs();

        bool UpdateJobStatus(int id, string newStatus);
        List<Job> GetJobsByStatus(string status);


        List<Job> GetJobsBySalaryRange(decimal min, decimal max);
        List<Job> GetJobsByLocation(string location);
        List<Job> GetJobsByCompany(int companyId);
        List<Job> SearchByTitle(string title);
        List<Job> SearchByDescription(string keyword);


        List<Job> GetHighestSalaryJobs(int count);
        List<Job> GetLowestSalaryJobs(int count);



        int GetApplicationCount(int jobId);
        List<Job> GetJobsWithMostApplications();
        List<Application> GetJobApplications(int jobId);

        int GetTotalJobCount();
    }
}
