using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Talabat.Domain.Entities.Basket;
using Talabat.Domain.Interfaces;

namespace Talabat.APIs.Controllers
{

    [Authorize]
    public class PaymentController : BaseApiController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet("{basketId}")]
        public async Task<ActionResult<CustomerBasket>> CreatePaymentIntent(string basketId)
        {
            var basket = await _paymentService.CreateOrUpdatePaymentIntentAsync(basketId);
            if (basket == null) return BadRequest();
            return Ok(basket);
        }

        [HttpPost("webhook")]
        [AllowAnonymous]
        public async Task<IActionResult> Webhook()
        {
            Console.WriteLine("Webhook received");

            var json = await new StreamReader(HttpContext.Request.Body)
                .ReadToEndAsync();

            var stripeSignature = Request.Headers["Stripe-Signature"];

            var webhookSecret = "whsec_507da8b71043aa4b6da9274389ad2a69dd4f17338e160dfc3c90bb194d555621"; /*_configuration["Stripe:WebhookSecret"];*/
            var stripeEvent = EventUtility.ConstructEvent(
                json,
                stripeSignature,
                webhookSecret
            );
            Console.WriteLine($"Event: {stripeEvent.Type}");

            var paymentIntent =
                stripeEvent.Data.Object as PaymentIntent;
            if (paymentIntent == null)
                return BadRequest();
            if (stripeEvent.Type == "payment_intent.succeeded")
            {

                await _paymentService.UpdateOrderStatus(paymentIntent.Id, true);
                Console.WriteLine(
         $"PaymentIntent: {paymentIntent?.Id}");
            }

            else if (stripeEvent.Type == "payment_intent.payment_failed")
            {

                await _paymentService.UpdateOrderStatus(paymentIntent.Id, false);
            }

            return Ok();

        }

    }
}
