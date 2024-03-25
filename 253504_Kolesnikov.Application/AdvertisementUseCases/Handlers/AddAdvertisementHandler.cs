using _253504_Kolesnikov.Application.AdvertisementUseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Kolesnikov.Application.AdvertisementUseCases.Handlers
{
    public class AddAdvertisementHandler : IRequestHandler<AddAdvertisementQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddAdvertisementHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(AddAdvertisementQuery request, CancellationToken cancellationToken)
        {
            var advertisement = new Advertisement(0, request.Name, request.CreatedAt, request.Description,
                request.ImagePath, request.CarId, request.Cost);
            await _unitOfWork.AdvertisementRepository.AddAsync(advertisement, cancellationToken);
            await _unitOfWork.SaveAllAsync();
            return advertisement.Id;
        }
    }
}
