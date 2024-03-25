using _253504_Kolesnikov.Application.AdvertisementUseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Kolesnikov.Application.AdvertisementUseCases.Handlers
{
    public class GetAdvertisementsByCarHandler : IRequestHandler<GetAdvertisementsByCarQuery, List<Advertisement>>
    {
        private IUnitOfWork _unitOfWork;
        public GetAdvertisementsByCarHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Advertisement>> Handle(GetAdvertisementsByCarQuery request, CancellationToken cancellationToken)
        {
            return (List<Advertisement>)await _unitOfWork.AdvertisementRepository
                .ListAsync((advertisement) => advertisement.CarId == request.CarId, cancellationToken);
        }
    }
}
