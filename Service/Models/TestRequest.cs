using MediatR;

namespace Service.Models
{
    public class TestRequest : IRequest<TestResponse>
    {
        public int ChooseResponse { get; set; }
    }
}
