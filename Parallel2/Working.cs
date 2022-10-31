using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel2
{
    internal class Working
    {
        private readonly int repeats = 100;

        int n1_y, n2_x;
        double[] data;
        double[] copy;

        public Working(int n1, int n2)
        {
            this.n1_y = n1;
            this.n2_x = n2;
        }

        private void newList()
        {
            copy = data;

            data = new double[n2_x];

            for (int i = 0; i < n2_x; ++i)
            {
                int index = i + 1;
                data[i] = 1;
            }
        }

        public double sequential()
        {
            newList();
            var sw = Stopwatch.StartNew();
            for (int j = 0; j < n1_y; ++j)
            {
                for (int i = 0; i < n2_x; ++i)
                    count(i);
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public double parallel()
        {
            newList();

            int limit = 2 * n1_y + n2_x - 2;

            List<ConcurrentQueue<int>> space = new List<ConcurrentQueue<int>>();

            for (int v = 1; v <= limit; ++v)
            {
                ConcurrentQueue<int> ints = new ConcurrentQueue<int>();
                int start = v % 2 == 0 ? 2 : 1;
                for (int i = start; i <= n2_x; i += 2)
                {
                    int j = (v - i + 2) / 2;
                    if (j < 1 || j > n1_y)
                        continue;
                    int index = i - 1;
                    ints.Enqueue(index);
                }
                space.Add(ints);
            }

            var sw = Stopwatch.StartNew();
            Thread[] threads = new Thread[]
{
                    new Thread(() => parallel(space)),
                    new Thread(() => parallel(space)),
                    new Thread(() => parallel(space)),
                    new Thread(() => parallel(space))
};
            foreach (var thread in threads)
                thread.Start();
            foreach (var thread in threads)
                thread.Join();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public bool check()
        {
            for (int i = 0; i < n2_x; ++i)
                if (data[i] != copy[i])
                    return false;
            return true;
        }
        public void parallel(List<ConcurrentQueue<int>> list)
        {
            foreach(var queue in list)
                while(queue.Count > 0)
                {
                    queue.TryDequeue(out int index);
                    count(index);
                }
        }
        public void count(int i)
        {
            double sum = data[i];
            if (i > 0)
                sum += data[i - 1];
            if (i < n2_x - 1)
                sum += data[i + 1];
            data[i] = sum;
        }
    }

    public static class BetterEnumerable
    {
        public static IEnumerable<int> SteppedRange(int fromInclusive, int toExclusive, int step)
        {
            for (var i = fromInclusive; i < toExclusive; i += step)
            {
                yield return i;
            }
        }
    }
}
