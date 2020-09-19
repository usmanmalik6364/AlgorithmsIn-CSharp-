using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicConnectivity
{
    /// <summary>
    /// Eager Approach, can lead to quadratic time for larger problems.
    /// QuickFind algorithm analysis
    /// Initialise -> O(N)
    /// Union -> O(N)
    /// Find -> O(1)
    /// </summary>
    class QuickFindUF
    {
        private int[] id;
        public QuickFindUF(int N)
        {
            id = new int[N];
            for (int i = 0; i < N; i++)
            {
                id[i] = i;
            }
        }
        public Boolean connected(int p, int q)
        {
            return (id[p] == id[q]);
        }
        public void union(int p, int q)
        {
            int pid = id[p];
            int qid = id[q];
            for (int i = 0; i < id.Length; i++)
            {
                if(id[i]==pid)
                {
                    id[i] = qid;
                }
            }
        }
    }
}
