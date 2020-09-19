using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.DynamicConnectivity
{
    class QuickUnion
    {
        private int[] id;
        public QuickUnion(int N)
        {
            id = new int[N];
            for (int i = 0; i < N; i++)
            {
                id[i] = i;
            }
        }
        /// <summary>
        /// Chase parent pointers untill reach root 
        /// (depth of i array accesses)
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private int root(int i)
        {
            while (i != id [i])
            {
                i = id[i];
            }
            return i;
        }
        public Boolean connected(int p, int q)
        {
            return (root(p) == root(q));
        }
        /// <summary>
        /// Change root of p to point to root of q
        /// (depth of p and q array accesses)
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public void union(int p, int q)
        {
            int i = root(p);
            int j = root(q);
            id[i] = j;
        }
    }
}
