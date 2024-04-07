using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Kolesnikov.Application.AdvertisementUseCases.Handlers
{
    public sealed record DeleteAdvertisementQuery(Advertisement advertisement) : IRequest { }
    internal class DeleteAdvertisementHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteAdvertisementQuery>
    {
        public async Task Handle(DeleteAdvertisementQuery request, CancellationToken cancellationToken)
        {
            await unitOfWork.AdvertisementRepository.DeleteAsync(request.advertisement, cancellationToken);
            await unitOfWork.SaveAllAsync();
        }
    }
}
