using System;

namespace TDDMicroExercises.Validator
{
    internal class Validator
    {
        public static bool IsNull(String s)
        {
            if (s == null)
            {
                return true;
            }

            var counter = 0;

            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];

                if (c == CharPool.Space)
                {
                    continue;
                }
                else if (counter > 3)
                {
                    return false;
                }

                if (counter == 0)
                {
                    if (c != CharPool.LowerCaseN)
                    {
                        return false;
                    }
                }
                else if (counter == 1)
                {
                    if (c != CharPool.LowerCaseU)
                    {
                        return false;
                    }
                }
                else if ((counter == 2) || (counter == 3))
                {
                    if (c != CharPool.LowerCaseL)
                    {
                        return false;
                    }
                }

                counter++;
            }

            if ((counter == 0) || (counter == 4))
            {
                return true;
            }

            return false;
        }


        private static class CharPool
        {
            public const char Space = ' ';
            public const char LowerCaseN = 'n';
            public const char LowerCaseU = 'u';
            public const char LowerCaseL = 'l';
        }
    }
}