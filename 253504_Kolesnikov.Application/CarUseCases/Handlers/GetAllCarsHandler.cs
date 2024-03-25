using _253504_Kolesnikov.Application.CarUseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Kolesnikov.Application.CarUseCases.Handlers
{
    public class GetAllCarsHandler : IRequestHandler<GetAllCarsQuery, List<Car>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllCarsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            return (List<Car>) await _unitOfWork.CarRepository.ListAllAsync(cancellationToken);
        }
    }
}
