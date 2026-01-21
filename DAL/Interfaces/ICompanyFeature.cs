using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICompanyFeature
    {

        List<Company> SearchCompany(string text);
        List<Company> GetWithJobs();
        Company GetWithJobs(int id);

        Company GetCompanyWithHighestJobPosted();
        Dictionary<string, int> GetCompanyOpenClosedJobCount(int companyId);
        List<Company> GetCompaniesWithOpenJobs();
        List<Company> GetCompaniesWithClosedJobs(); 
    }
}
