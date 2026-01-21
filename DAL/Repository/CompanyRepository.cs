using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class CompanyRepository
        : IRepository<Company>, ICompanyFeature
    {
        JobBdContext db;

        public CompanyRepository(JobBdContext db)
        {
            this.db = db;
        }

        // CRUD Methods
        public bool Create(Company entity)
        {
            db.Companies.Add(entity);
            return db.SaveChanges() > 0;
        }

        public List<Company> Get()
        {
            return db.Companies.ToList();
        }

        public Company Get(int id)
        {
            return db.Companies.Find(id);
        }

        public bool Update(Company entity)
        {
            var ex = Get(entity.Id);
            db.Entry(ex).CurrentValues.SetValues(entity);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            if(ex != null) db.Companies.Remove(ex);
            return db.SaveChanges() > 0;
        }

        //Feature methods

        public List<Company> SearchCompany(string text)
        {
            return db.Companies
                     .Where(c =>
                         c.CompanyName.Contains(text) ||
                         c.Description.Contains(text) ||
                         c.Location.Contains(text))
                     .ToList();
        }

        public List<Company> GetWithJobs()
        {
            return db.Companies
                     .Include(c => c.Jobs)
                     .ToList();
        }

        public Company GetWithJobs(int id)
        {
            return db.Companies
                     .Include(c => c.Jobs)
                     .FirstOrDefault(c => c.Id == id);
        }

        public Company GetCompanyWithHighestJobPosted()
        {
            return db.Companies
                     .OrderByDescending(c => c.Jobs.Count)
                     .FirstOrDefault();
        }

        public Dictionary<string, int> GetCompanyOpenClosedJobCount(int companyId)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            var openJobs = (from j in db.Jobs
                            where j.CompanyId == companyId
                                  && j.Status == "Open"
                            select j).Count();

            var closedJobs = (from j in db.Jobs
                              where j.CompanyId == companyId
                                    && j.Status == "Closed"
                              select j).Count();

            result.Add("Open", openJobs);
            result.Add("Closed", closedJobs);

            return result;
        }


        public List<Company> GetCompaniesWithOpenJobs()
        {
            return db.Companies
                     .Where(c => c.Jobs.Any(j => j.Status == "Open"))
                     .ToList();
        }

        public List<Company> GetCompaniesWithClosedJobs()
        {
            return db.Companies
                     .Where(c => c.Jobs.Any(j => j.Status == "Closed"))
                     .ToList();
        }

    }
}
