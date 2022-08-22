using AutoMapper;
using Drugstore.Application.Common.Exteptions;
using Drugstore.Application.Interfaces;
using Drugstore.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Drugstore.Application.Drugs.Queries.GetDrug
{
    public class GetDrugQueryHandler :
        IRequestHandler<GetDrugQuery, DrugDegtailVm>
    {
        private readonly IDrugstoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDrugQueryHandler(
            IDrugstoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<DrugDegtailVm> Handle(
            GetDrugQuery request, CancellationToken cancellationToken)
        {
            var drug = await _dbContext.Drugs
                .FirstOrDefaultAsync(drug => drug.Id == request.Id);

            if(drug == null || drug.Id != request.Id)
            {
                throw new NotFoundExteption(nameof(Drug), request.Id);
            }

            return _mapper.Map<DrugDegtailVm>(drug);
        }
    }
}
