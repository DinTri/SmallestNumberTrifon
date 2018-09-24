using System.Collections.Generic;
using SmallestNumberTrifon.Model.Calculate;

namespace SmallestNumberTrifon.Contracts
{
    public interface ICalculate
    {
        List<Calculate> RecursiveCalculateSmallestNumber(int limit);
        List<Calculate> NonRecursiveCalculateSmallestNumber(int limit);
    }
}
