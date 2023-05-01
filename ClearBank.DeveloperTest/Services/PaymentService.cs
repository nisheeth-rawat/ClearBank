using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Interface;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountService _accountService;
        private readonly IValidatePaymentService _validatePaymentService;

        public PaymentService(
            IAccountService accountService,
            IValidatePaymentService validatePaymentService
        )
        {
            _accountService = accountService;
            _validatePaymentService = validatePaymentService;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var account = _accountService.GetAccount(request.DebtorAccountNumber);

            var validationResult = _validatePaymentService.ValidatePaymentRequest(request, account);

            if (validationResult)
            {
                _accountService.DebitAndUpdate(request.Amount);
            }

            return new MakePaymentResult() { Success = validationResult };
        }
    }
}
