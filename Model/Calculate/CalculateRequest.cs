using SmallestNumberTrifon.Abstraction;

namespace SmallestNumberTrifon.Model.Calculate
{
    public class CalculateRequest : Request<CalculateRequestBody>
    {
        public override CalculateRequestBody MessageBody { get; set; }
    }
}
