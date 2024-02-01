using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class Lake : IEnumerable<int>
    {
        private int[] lake;
        private Func<char, int, StringSplitOptions, string[]> split;
        private string v;

        public Lake(params int[] rocks)
        {
            lake = rocks;
        }

        public Lake(Func<char, int, StringSplitOptions, string[]> split, string v)
        {
            this.split = split;
            this.v = v;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < lake.Length; i++)
            {
                if (i % 2 == 0)
                {
                    yield return lake[i];
                }
            }

            for (int i = lake.Length - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return lake[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
