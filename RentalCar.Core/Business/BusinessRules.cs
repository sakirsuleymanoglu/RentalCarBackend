using RentalCar.Core.Utilities.Results;

namespace RentalCar.Core.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] results)
        {
            foreach (var result in results)
            {
                if (!result.Success)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
