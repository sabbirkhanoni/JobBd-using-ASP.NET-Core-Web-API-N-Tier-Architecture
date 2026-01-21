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
    public class CompanyService
    {
        DataAccessFactory factory;

        public CompanyService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        public bool Create(CompanyDTO dto)
        {
            var data = MapperConfig.GetMapper().Map<Company>(dto);
            return factory.CompanyData().Create(data);
        }

        public List<CompanyDTO> Get()
        {
            var data = factory.CompanyData().Get();
            return MapperConfig.GetMapper().Map<List<CompanyDTO>>(data);
        }

        public CompanyDTO Get(int id)
        {
            var data = factory.CompanyData().Get(id);
            return MapperConfig.GetMapper().Map<CompanyDTO>(data);
        }

        public bool Update(CompanyDTO dto)
        {
            var data = MapperConfig.GetMapper().Map<Company>(dto);
            return factory.CompanyData().Update(data);
        }

        public bool Delete(int id)
        {
            return factory.CompanyData().Delete(id);
        }

        //Feature Service

        public List<CompanyJobDTO> GetWithJobs()
        {
            var data = factory.CompanyFeature().GetWithJobs();
            return MapperConfig.GetMapper().Map<List<CompanyJobDTO>>(data);
        }

        public CompanyDTO GetCompanyWithHighestJobPosted()
        {
            var data = factory.CompanyFeature().GetCompanyWithHighestJobPosted();
            return MapperConfig.GetMapper().Map<CompanyDTO>(data);
        }

        public Dictionary<string, int> GetCompanyOpenClosedJobCount(int companyId)
        {
            return factory.CompanyFeature()
                          .GetCompanyOpenClosedJobCount(companyId);
        }

        public List<CompanyDTO> GetCompaniesWithOpenJobs()
        {
            var data = factory.CompanyFeature().GetCompaniesWithOpenJobs();
            return MapperConfig.GetMapper().Map<List<CompanyDTO>>(data);
        }

        public List<CompanyDTO> GetCompaniesWithClosedJobs()
        {
            var data = factory.CompanyFeature().GetCompaniesWithClosedJobs();
            return MapperConfig.GetMapper().Map<List<CompanyDTO>>(data);
        }

        public List<CompanyDTO> SearchCompany(string text)
        {
            var data = factory.CompanyFeature().SearchCompany(text);
            return MapperConfig.GetMapper().Map<List<CompanyDTO>>(data);
        }
    }
}
