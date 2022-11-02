using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Parallel2
{
    internal class Working
    {
        private readonly int repeats = 1;

        int n1_y, n2_x;
        double[] data;
        double[] copy;

        public Working(int n1, int n2)
        {
            this.n1_y = n1;
            this.n2_x = n2;
            copy = data = new double[0];
        }

        private void newList()
        {
            copy = data;

            data = new double[n2_x];

            for (int i = 0; i < n2_x; ++i)
            {
                int index = i + 1;
                data[i] = 1 * (index % 3 - 1);
            }
        }

        public double sequential()
        {
            newList();
            var sw = Stopwatch.StartNew();
            for (int r = 0; r < repeats; ++r)
                for (int j = 0; j < n1_y; ++j)
                    for (int i = 0; i < n2_x; ++i)
                        count(i);
            sw.Stop();
            return sw.ElapsedMilliseconds / repeats;
        }

        public double parallel()
        {
            newList();

            int limit = 2 * n1_y + n2_x - 2;

            List<List<int>> space = new List<List<int>>();

            for (int v = 1; v <= limit; ++v)
            {
                List<int> ints = new List<int>();
                int start = v % 2 == 0 ? 2 : 1;
                for (int i = start; i <= n2_x; i += 2)
                {
                    int j = (v - i + 2) / 2;
                    if (j < 1 || j > n1_y)
                        continue;
                    int index = i - 1;
                    ints.Add(index);
                }
                space.Add(ints);
            }

            var sw = Stopwatch.StartNew();
            for (int r = 0; r < repeats; ++r) 
                foreach (var ints in space)
                {
                    var partitioner = Partitioner.Create(ints);
                    Parallel.ForEach(partitioner, (index, loopState) => count(index));
                }
            sw.Stop();
            return sw.ElapsedMilliseconds / repeats;
        }

        public bool check()
        {
            for (int i = 0; i < n2_x; ++i)
                if (data[i] != copy[i])
                    return false;
            return true;
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
}
