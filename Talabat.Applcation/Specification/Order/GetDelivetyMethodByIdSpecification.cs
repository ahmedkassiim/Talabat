using Talabat.Domain.Entities.Order_Aggregate;

namespace Talabat.Applcation.Specification.Order
{
    public class GetDelivetyMethodByIdSpecification :
        Domain.Specification.Specification<DeliveryMethod, DeliveryMethod>
    {

        public GetDelivetyMethodByIdSpecification(int deliveryMethodId)
        {
            AddCriteria(D => D.Id == deliveryMethodId);
        }
    }
}
