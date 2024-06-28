using MediatR;
using Service.Models;

namespace Service.Handlers
{
    public class TestHandler : IRequestHandler<TestRequest, TestResponse>
    {
        public Task<TestResponse> Handle(TestRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            if (request.ChooseResponse == 1)
            {
                return Task.FromResult(new TestResponse { Response = "Você escolheu o número 1" });
            }
            else
            {
                return Task.FromResult(new TestResponse { Response = "Você escolheu um número diferente de 1" });
            }
        }
    }
}
