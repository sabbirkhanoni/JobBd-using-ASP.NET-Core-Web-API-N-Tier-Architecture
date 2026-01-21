using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repository;

namespace DAL
{
    public class DataAccessFactory
    {
        JobBdContext db;

        public DataAccessFactory(JobBdContext db)
        {
            this.db = db;
        }

        public IRepository<User> UserData()
        {
            return new UserRepository(db);
        }

        public IUserFeature UserFeature()
        {
            return new UserRepository(db);
        }

        public IAuthFeature AuthFeature()
        {
            return new AuthRepository(db);
        }


        public IRepository<Company> CompanyData()
        {
            return new CompanyRepository(db);
        }

        public ICompanyFeature CompanyFeature()
        {
            return new CompanyRepository(db);
        }

        public IRepository<Job> JobData()
        {
            return new JobRepository(db);
        }

        public IJobFeature JobFeature()
        {
            return new JobRepository(db);
        }

        public IRepository<Application> ApplicationData()
        {
            return new ApplicationRepository(db);
        }

        public IApplicationFeature ApplicationFeature()
        {
            return new ApplicationRepository(db);
        }


    }
}
