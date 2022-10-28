using System;
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

        public Working(int n1, int n2)
        {
            this.n1_y = n1;
            this.n2_x = n2;
        }

        private void newList()
        {
            data = new double[n2_x];

            for (int i = 0; i < n2_x; ++i)
                data[i] = 0.01 * i * (i % 3 - 1);
        }

        public double sequential()
        {
            newList();
            var sw = Stopwatch.StartNew();
            for(int r = 0; r < repeats; ++r)
                for (int j = 0; j < n1_y; ++j)
                {
                    for (int i = 1; i < n2_x - 1; ++i)
                    {
                        double sum = data[i];
                        if (i > 0)
                            sum += data[i - 1];
                        if (i < n2_x - 1)
                            sum += data[i + 1];
                        data[i] = sum;
                    }
                }
            sw.Stop();
            return sw.ElapsedMilliseconds / repeats;
        }

        public double parallel()
        {
            newList();

            int limit = 2 * n1_y + n2_x - 2;

            var sw = Stopwatch.StartNew();
            for (int r = 0; r < repeats; ++r) 
                for (int v = 1; v <= limit; ++v)
                {
                    int botLim = v - 2 * n1_y + 2;
                    botLim = botLim > 1? botLim : 1;
                    botLim = botLim < n2_x ? botLim : n2_x;
                    int topLim = v < n2_x? v : n2_x;
                    topLim += 1;
                    Parallel.ForEach(BetterEnumerable.SteppedRange(botLim, topLim, 2), i =>
                    {
                        double sum = data[i - 1];
                        if (i > 1)
                            sum += data[i - 2];
                        if (i < n2_x )
                            sum += data[i];
                        data[i - 1] = sum;
                    }
                    );
                }
            sw.Stop();
            return sw.ElapsedMilliseconds / repeats;
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
