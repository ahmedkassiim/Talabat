using Talabat.Domain.Entities.Order_Aggregate;
using Talabat.Domain.Specification;

namespace Talabat.Applcation.Specification.Order
{
    public class GetAllDeliveryMethodSpecification :
        Specification<DeliveryMethod, DeliveryMethod>
    {

        public GetAllDeliveryMethodSpecification()
        {
            ApplyDisableTracking();
        }
    }
}
