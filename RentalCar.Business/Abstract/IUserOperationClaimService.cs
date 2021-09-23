using RentalCar.Core.Utilities.Results;

namespace RentalCar.Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IResult AddDefaultClaim(int userId);
    }
}
