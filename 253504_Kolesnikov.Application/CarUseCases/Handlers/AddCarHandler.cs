using _253504_Kolesnikov.Application.CarUseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Kolesnikov.Application.CarUseCases.Handlers
{
    public class AddCarHandler : IRequestHandler<AddCarQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddCarHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(AddCarQuery request, CancellationToken cancellationToken)
        {
            var car = new Car(0, request.Name, request.Country, request.Description, request.Year);
            await _unitOfWork.CarRepository.AddAsync(car, cancellationToken);
            await _unitOfWork.SaveAllAsync();
            return car.Id;
        }
    }
}
