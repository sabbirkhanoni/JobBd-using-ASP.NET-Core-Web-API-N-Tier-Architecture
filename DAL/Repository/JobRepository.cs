using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class JobRepository : IRepository<Job>, IJobFeature
    {
        JobBdContext db;

        public JobRepository(JobBdContext db)
        {
            this.db = db;
        }

        public Job Get(int id)
        {
            return db.Jobs.Find(id);
        }

        public List<Job> Get()
        {
            return db.Jobs.ToList();
        }

        public bool Create(Job entity)
        {
            db.Jobs.Add(entity);
            db.SaveChanges();
            return true;
        }

        public bool Update(Job entity)
        {
            db.Jobs.Update(entity);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var job = Get(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return true;
        }

        //Feature Methods



        public List<Job> Search(string? keyword, string? location, string? status)
        {
            var query = db.Jobs.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(j => j.Title.Contains(keyword));

            if (!string.IsNullOrEmpty(location))
                query = query.Where(j => j.Location == location);

            if (!string.IsNullOrEmpty(status))
                query = query.Where(j => j.Status == status);

            return query.Include(j => j.Company).ToList();
        }


        public List<Job> GetRecentJobs()
        {
            return db.Jobs
                     .Include(j => j.Company)
                     .OrderByDescending(j => j.Id)
                     .Take(10)
                     .ToList();
        }



        public bool UpdateJobStatus(int id, string newStatus)
        {
            var job = db.Jobs.Find(id);
            if (job == null) return false;
            job.Status = newStatus;
            db.SaveChanges();
            return true;
        }

        public List<Job> GetJobsByStatus(string status)
        {
            return db.Jobs.Where(j => j.Status == status).ToList();
        }

        public List<Job> GetJobsBySalaryRange(decimal min, decimal max)
        {
            return db.Jobs.Where(j => j.Salary >= min && j.Salary <= max).ToList();
        }

        public List<Job> GetJobsByLocation(string location)
        {
            return db.Jobs.Where(j => j.Location == location).ToList();
        }

        public List<Job> GetJobsByCompany(int companyId)
        {
            return db.Jobs.Where(j => j.CompanyId == companyId).ToList();
        }

        public List<Job> SearchByTitle(string title)
        {
            return db.Jobs.Where(j => j.Title.Contains(title)).ToList();
        }

        public List<Job> SearchByDescription(string keyword)
        {
            return db.Jobs.Where(j => j.Description.Contains(keyword)).ToList();
        }

        public List<Job> GetHighestSalaryJobs(int count)
        {
            return db.Jobs.OrderByDescending(j => j.Salary).Take(count).ToList();
        }

        public List<Job> GetLowestSalaryJobs(int count)
        {
            return db.Jobs.OrderBy(j => j.Salary).Take(count).ToList();
        }


        public int GetApplicationCount(int jobId)
        {
            return db.Applications.Count(a => a.JobId == jobId);
        }

        public List<Job> GetJobsWithMostApplications()
        {
            return db.Jobs
                     .Include(j => j.Applications)
                     .OrderByDescending(j => j.Applications.Count)
                     .ToList();
        }

        public List<Application> GetJobApplications(int jobId)
        {
            return db.Applications
                     .Where(a => a.JobId == jobId)
                     .Include(a => a.JobSeeker)
                     .ToList();
        }

        public int GetTotalJobCount()
        {
            return db.Jobs.Count();
        }

        public List<Job> GetRecommendedJobs(int userId)
        {
            // last applied job
            var lastAppliedJob = db.Applications
                                   .Where(a => a.JobSeekerId == userId)
                                   .OrderByDescending(a => a.AppliedDate)
                                   .Select(a => a.Job)
                                   .FirstOrDefault();

            if (lastAppliedJob == null)
                return new List<Job>();

            // split title
            var keywords = lastAppliedJob.Title.Split(' ');

            // already applied jobs
            var appliedJobIds = db.Applications
                                  .Where(a => a.JobSeekerId == userId)
                                  .Select(a => a.JobId)
                                  .ToList();

            // 4. Recommend jobs
            var recommendedJobs = db.Jobs
                                    .Where(j => j.Status == "Open"
                                                && keywords.Any(k => j.Title.Contains(k))
                                                && !appliedJobIds.Contains(j.Id))
                                    .ToList();

            return recommendedJobs;
        }
    }
}
