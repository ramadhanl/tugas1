using System;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;

namespace Chat
{
    static class Generator
    {
        private static int _type;

        private static BigInteger _m = BigInteger.Pow (2, 32);
        private static BigInteger _a = 69069;
        private static BigInteger _b = 0;
        private static BigInteger _rn = 1;

        private static Random _rnd = new Random();

        public static void Initialize (int t)
        {
            _type = t;

            if (_type == 0)
            {
                _m = BigInteger.Pow (2, 32);
                _a = 69069;
                _b = 0;
                _rn = 1;
            }
            else if (_type == 1)
            {
                _rnd = new Random ();
            }
            else
            {
                _rnd = new Random ();
            }
        }

        public static void SetLcg (BigInteger mIn, BigInteger aIn, BigInteger bIn, BigInteger rnIn)
        {
            _type = 0;

            _m = mIn;
            _a = aIn;
            _b = bIn;
            _rn = rnIn;
        }

        public static BigInteger Random (BigInteger a, BigInteger b)
        {
            BigInteger retValue;

            if (_type == 0)
            {
                retValue = a + Lcg () % (b - a + 1);
            }
            else if (_type == 1)
            {
                BigInteger count = b - a;

                BigInteger digits = 0;

                while ( (count / 10) > 0)
                {
                    count = count / 10;

                    digits++;
                }

                string entropy = Entropy();

                string retVal = "";

                while (retVal.Length < digits)
                {
                    retVal = retVal + entropy[_rnd.Next (0, entropy.Length)];
                }

                // We get the number, but we might be too high, so we do a mod
                retValue = BigInteger.Parse (retVal);

                retValue = a + (retValue % b);
            }
            else
            {
                BigInteger count = b - a;

                BigInteger digits = 0;

                while ( (count / 10) > 0)
                {
                    count = count / 10;

                    digits++;
                }

                string retVal = _rnd.Next (1000000000, 2100000000).ToString(CultureInfo.InvariantCulture);

                while (retVal.Length < digits)
                {
                    retVal = retVal + _rnd.Next (1000).ToString(CultureInfo.InvariantCulture);
                }

                // We get the number, but we might be too high, so we do a mod
                retValue = BigInteger.Parse (retVal);

                retValue = a + (retValue % b);
            }

            return retValue;
        }

        private static string Entropy ()
        {
            string entropy = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture);

            PerformanceCounter cpuCounter = new PerformanceCounter
                                                {
                                                    CategoryName = "Processor",
                                                    CounterName = "% Processor Time",
                                                    InstanceName = "_Total"
                                                };

            entropy = entropy + cpuCounter.NextValue();

            return entropy;
        }

        private static BigInteger Lcg ()
        {
            _rn = (_a * _rn + _b) % _m;
            return _rn;
        }
    }
}
