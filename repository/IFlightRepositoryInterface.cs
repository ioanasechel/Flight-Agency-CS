using Flight_Agency.model;

namespace Flight_Agency.repository
{
    public interface IFlightRepositoryInterface : IRepository<int, Flight>
    {
        //TODO :  implement methods

        Flight findOne(int ticketFlightId);
    }
}