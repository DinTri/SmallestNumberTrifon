using System.Collections.Generic;
using SmallestNumberTrifon.Contracts;
using SmallestNumberTrifon.Model;
using SmallestNumberTrifon.Model.Calculate;

namespace SmallestNumberTrifon.Services
{
    public class CalculationService : ICalculate
    {
        private readonly CalculateSmallestNumber _calculate;
        
        private readonly SimpleNumberContext _context;

        public CalculationService(SimpleNumberContext context)
        {
            _context = context;
            _calculate = new CalculateSmallestNumber();
        }

        public List<Calculate> RecursiveCalculateSmallestNumber(int limit)
        {
            //var l = _context.Calculates.Find(id);
            return _calculate.CalculateSmallestNumberNonRecursive(limit);
        }

        public List<Calculate> NonRecursiveCalculateSmallestNumber(int limit)
        {
            //var l =_context.Calculates.Find(id);
            return _calculate.CalculateSmallestNumberNonRecursive(limit);
        }
    }
}
