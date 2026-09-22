using Talabat.Domain.Specification;
namespace Talabat.Applcation.Specification.Order
{
    public class GetOrderByPaymentIntentSpecification : Specification<Domain.Entities.Order_Aggregate.Order,
        Domain.Entities.Order_Aggregate.Order>
    {

        public GetOrderByPaymentIntentSpecification(string paymentIntent)
        {
            AddCriteria(O => O.PaymentIntentId == paymentIntent);
        }
    }
}
