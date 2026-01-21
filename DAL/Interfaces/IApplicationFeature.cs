using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IApplicationFeature
    {

        List<Job> GetJobsWithApplicationsAndUsers();
        int GetApplicationCountByUser(int userId);
        int GetTotalApplications();


        bool UpdateApplicationStatus(int id, string newStatus);

        List<Application> GetApplicationsByStatus(string status);


        List<Application> GetApplicationsByJob(int jobId);

        Dictionary<string, int> GetApplicationCountStatisticsOfAJobBasedOnStatus(int jobId);

        List<Job> GetMostAppliedJobs();
    }
}
