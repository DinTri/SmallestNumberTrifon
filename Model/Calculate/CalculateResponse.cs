using SmallestNumberTrifon.Abstraction;

namespace SmallestNumberTrifon.Model.Calculate
{
    public class CalculateResponse : Response<CalculateResponseBody>
    {
        public override CalculateResponseBody MessageBody { get; set; }
    }
}
