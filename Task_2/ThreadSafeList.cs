using System.Collections.Generic;

namespace Task2
{
    internal class ThreadSafeList
    {
        private static readonly object Ob = new object();
        private readonly List<int> list = new List<int>();

        public void Add(int item)
        {
            lock (Ob)
            {
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            }
        }

        public List<int> GetAll()
        {
            lock (Ob)
            {
                return list;
            }
        }
    }
}
