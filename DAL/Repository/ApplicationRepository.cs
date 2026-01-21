using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ApplicationRepository : IRepository<Application> , IApplicationFeature
    {
        JobBdContext db;

        public ApplicationRepository(JobBdContext db)
        {
            this.db = db;
        }

        public bool Create(Application entity)
        {
            db.Applications.Add(entity);
            db.SaveChanges();
            return true;
        }

        public Application Get(int id)
        {
            return db.Applications
                     .Include(a => a.Job)
                     .Include(a => a.JobSeeker)
                     .FirstOrDefault(a => a.Id == id);
        }

        public List<Application> Get()
        {
            return db.Applications
                     .Include(a => a.Job)
                     .Include(a => a.JobSeeker)
                     .ToList();
        }


        public bool Update(Application entity)
        {
            db.Applications.Update(entity);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var app = Get(id);
            db.Applications.Remove(app);
            db.SaveChanges();
            return true;
        }


        //Feature Methods

        public List<Job> GetJobsWithApplicationsAndUsers()
        {
            return db.Jobs
                     .Include(j => j.Applications)
                        .ThenInclude(a => a.JobSeeker)
                     .ToList();
        }


        public int GetApplicationCountByUser(int userId)
        {
            return db.Applications.Count(a => a.JobSeekerId == userId);
        }

        public int GetTotalApplications()
        {
            return db.Applications.Count();
        }


        public bool UpdateApplicationStatus(int id, string newStatus)
        {
            var app = db.Applications.Find(id);
            if (app == null) return false;

            app.Status = newStatus;
            db.SaveChanges();
            return true;
        }

        public List<Application> GetApplicationsByStatus(string status)
        {
            return db.Applications
                     .Include(a => a.JobSeeker)
                     .Include(a => a.Job)
                     .Where(a => a.Status == status)
                     .ToList();
        }

        public List<Application> GetApplicationsByJob(int jobId)
        {
            return db.Applications
                     .Include(a => a.JobSeeker)
                     .Where(a => a.JobId == jobId)
                     .ToList();
        }

        public Dictionary<string, int> GetApplicationCountStatisticsOfAJobBasedOnStatus(int jobId)
        {
            return db.Applications
                     .Where(a => a.JobId == jobId)
                     .GroupBy(a => a.Status)
                     .ToDictionary(g => g.Key, g => g.Count());
        }

        public List<Job> GetMostAppliedJobs()
        {
            return db.Jobs
                     .Include(j => j.Applications)
                     .OrderByDescending(j => j.Applications.Count)
                     .ToList();
        }
    }
}
