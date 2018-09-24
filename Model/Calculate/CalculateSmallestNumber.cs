using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace SmallestNumberTrifon.Model.Calculate
{
    public class CalculateSmallestNumber
    {

       public List<Calculate> CalculateSmallestNumberRecursive(int limit)
        {
            return LcmRecursive(limit);
        }

        public List<Calculate> CalculateSmallestNumberNonRecursive(int limit)
        {
            return LcmNotRecursive(limit);
        }

        /// <summary>
        /// Finding the least common multiple with recursive GDC
        /// </summary>
        /// <param name="n"></param>
        /// <returns>least common multiple</returns>
        private List<Calculate> LcmRecursive(BigInteger n) 
        { 
            List<Calculate> result = new List<Calculate>();
            Calculate tempResult = new Calculate();
            //DateTime startTime = DateTime.Now;
            Stopwatch sw = Stopwatch.StartNew();
            BigInteger ans = 1;     
            for (BigInteger i = 1; i <= n; i++) 
                ans = (ans * i)/(RecursiveGcd(ans, i));
            tempResult.Result = ans;
            //DateTime stopTime = DateTime.Now;
            sw.Stop();
            //TimeSpan duration = stopTime - startTime;
            TimeSpan duration = new TimeSpan(sw.ElapsedMilliseconds);
            tempResult.Duration = duration;
            result.Add(tempResult);
            return result; 
        } 

        /// <summary>
        /// Finding the least common multiple with not recursive GDC
        /// </summary>
        /// <param name="n"></param>
        /// <returns>least common multiple</returns>
        private List<Calculate> LcmNotRecursive(BigInteger n) 
        { 
            List<Calculate> result = new List<Calculate>();
            Calculate tempResult = new Calculate();
            DateTime startTime = DateTime.Now;
            BigInteger ans = 1;     
            for (BigInteger i = 1; i <= n; i++) 
                ans = (ans * i)/(RecursiveGcd(ans, i)); 
            tempResult.Result = ans;
            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;
            tempResult.Duration = duration;
            result.Add(tempResult);
            return result; 
        } 

        /// <summary>
        /// Calculate the Greatest Common Denominator (GDC) Euclidean Algorithm Recursive
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns the GCD</returns>
        private static BigInteger RecursiveGcd(BigInteger a, BigInteger b)
        {
            if (a == 0)
                return b;
            if (b == 0)
                return a;

            return a > b ? RecursiveGcd(a % b, b) : RecursiveGcd(a, b % a);
        }


        /// <summary>
        /// Calculate the Greatest Common Denominator (GDC) Euclidean Algorithm Not Recursive
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns the GCD</returns>
        public BigInteger NotRecursiveGcd(BigInteger a, BigInteger b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            return a == 0 ? b : a;
        }
    }
}
