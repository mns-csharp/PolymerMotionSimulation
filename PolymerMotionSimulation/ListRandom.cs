using System;
using System.Collections.Generic;
using System.Text;

namespace PolymerMotionSimulation
{
    public class ListRandom<T>
    {
        private static Random rng = new Random();

        public static List<T> GetSubListFromStartToEnd(List<T> oldList, int endIndex)
        {
            if (oldList.Count <= endIndex)
            {
                throw new Exception("[newListSize] must be smaller than [oldList.Count]");
            }
            List<T> subList = oldList.GetRange(0, endIndex);
            return subList;
        }

        public static List<T> GetSubListFromMiddleToMiddle(List<T> oldList, int startIndex, int endIndex)
        {
            if (oldList.Count < (endIndex-startIndex))
            {
                throw new Exception("[newListSize] must be smaller than [oldList.Count]");
            }
            List<T> subList = oldList.GetRange(startIndex, endIndex);
            return subList;
        }

        public static List<T> GetSubListFromMiddleToEnd(List<T> oldList, int startIndex)
        {
            List<T> subList = oldList.GetRange(startIndex, oldList.Count - startIndex);
            return subList;
        }

        public static void Shuffle(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static List<T> GetRandomList(List<T> oldList, int minIndex, int maxIndex)
        {
            int itmsCount = maxIndex - minIndex + 1;
            if (oldList.Count < itmsCount)
            {
                throw new Exception("[newListSize] must be smaller than [oldList.Count]");
            }

            List<T> newList = new List<T>();

            Random random = new Random();
            int index = -99;
            for (int i = minIndex; i <= maxIndex; i++)
            {
                index = random.Next(minIndex, maxIndex);
                newList.Add(oldList[index]);
            }

            return newList;
        }

        public static List<T> GetRandomList2(List<T> oldList, int startIndex, int newListItemCount)
        {            
            if (oldList.Count < newListItemCount)
            {
                throw new Exception("[newListSize] must be smaller than [oldList.Count]");
            }

            int maxIndex = startIndex + newListItemCount;

            List<T> newList = new List<T>();

            Random random = new Random();
            int index = -99;
            for (int i = startIndex; i < maxIndex; i++)
            {
                index = random.Next(startIndex, maxIndex);
                newList.Add(oldList[index]);
            }

            return newList;
        }
    }
}
