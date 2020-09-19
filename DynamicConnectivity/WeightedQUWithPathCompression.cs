using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Algorithms.DynamicConnectivity
{
    /// <summary>
    /// In weightedQuickUnion, we always put the smaller tree underneath the larger tree.
    /// Difference b/w QuickUnion And WeightedQuickUnion? 
    /// 100 sites, 88union() operations.
    /// In Quick-Union the average distance to root is 5.11
    /// In Weighted Quick-Union the average distance to root is 1.52
    /// Weighted QuickUnion with Path Compression is almost linear.
    /// </summary>
    class WeightedQUWithPathCompression
    {
        private int[] id;
        private int[] sz;
        public WeightedQUWithPathCompression(int N)
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
            while (i != id[i])
            {
                id[i] = id[id[i]]; // path compression
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
            if (i == j) return;
            if (sz[i]< sz[j]) //size array gives number of trees rooted at that item
            {
                id[i] = j;
                sz[j] += sz[i];
            }
            else
            {
                id[j] = i;
                sz[i] += sz[j];
            }
            id[i] = j;
        }
    }
}
