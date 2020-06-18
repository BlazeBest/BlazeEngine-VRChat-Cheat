using System;
using System.Collections.Generic;

namespace BlazeTools
{
    public class RandomElement
    {
        public static T GetRandomFromList<T>(List<T> list)
        {
            return list[Range(list.Count-1)];
        }

        public static int Range(int max) => Range(0, max);
        public static int Range(int min, int max)
        {
            return Instance.random.Next(min, max);
        }

        private static RandomElement Instance
        {
            get
            {
                if (rInstance == null)
                {
                    rInstance = new RandomElement();
                    rInstance.random = new Random();
                }

                return rInstance;
            }
        }

        private Random random = null;
        private static RandomElement rInstance = null;
    }
}
