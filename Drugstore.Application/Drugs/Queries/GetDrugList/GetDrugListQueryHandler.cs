using AutoMapper;
using AutoMapper.QueryableExtensions;
using Drugstore.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Drugstore.Application.Drugs.Queries.GetDrugList
{
    public class GetDrugListQueryHandler
        : IRequestHandler<GetDrugListQuery, DrugListVm>
    {
        private readonly IDrugstoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDrugListQueryHandler(
            IDrugstoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<DrugListVm> Handle(
            GetDrugListQuery request, CancellationToken cancellationToken)
        {
            var drugsQuery = await _dbContext.Drugs
                .ProjectTo<DrugLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new DrugListVm { Drugs = drugsQuery };
        }
    }
}
