using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformLabs
{
    public static class Math
    {
        public static long Lcm(long a, long b)
        {
            return (a * b) / Gcd(a, b);
        }

        public static long Gcd(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
