using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace AnnexMigration.Annexes
{
    public class AnnexManager : DomainService
    {
        private readonly IRepository<Annex, Guid> annexRepository;

        public AnnexManager(IRepository<Annex, Guid> AnnexRepository) //注入默认的仓储
        {
            annexRepository = AnnexRepository;
        }

        public async Task<Annex> CreateAnnex(Annex annex)
        {
            await annexRepository.InsertAsync(annex);
            //使用仓储中的方法
            return annex;
        }
    }

}
