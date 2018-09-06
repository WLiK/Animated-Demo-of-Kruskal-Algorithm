using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WpfApplication1
{
    class kruskal
    {
        /// <summary>
        /// 由于动画所需结点不多，因此采取邻接矩阵存储图，并按一定概率随机生成边及权重
        /// </summary>
        protected int[,] Map;
        /// <summary>
        /// num表示结点的个数
        /// </summary>
        protected int num;
        public int []fa;//fa数组运用并查集判断结点是否已相连
        protected int[] resultx;
        private int[] tempx;
        protected int[] resulty;
        private int[] tempy;
        protected int[] resultw;
        private int[] tempw;
        protected int[] delx;
        protected int[] dely;
        protected int[] delw;
        protected int cnt;
        protected int delcnt;
        public kruskal()
        {
            num = 5;
            fa = new int[5];
            for (int i = 0; i < num; i++)
                fa[i] = i;
        }
        public virtual int findfa(int x)
        {
            if ( fa[x]!= x)
                fa[x] = findfa(fa[x]);
            return fa[x];
        }
        /// <summary>
        /// 初始化图
        /// </summary>
        public virtual void init()
        {
            var rand = new Random();
            Map = new int[num, num];
            for(int i=0;i<num;i++)
                for(int j=0;j<i;j++)
                {
                    if (i == 0 && j == 0)
                    {
                        Map[i,j] = 0;
                    }
                    else
                    {
                        ///<summary>
                        /// 按60%比率生成1~10的权值，否则无边的情况生成图
                        /// </summary>
                        int value = rand.Next(1, 100);
                        if (value <= 40)
                        {
                            Map[i,j] = 0;
                        }
                        else
                        {
                            Map[i,j] = rand.Next(1, 10);
                        }
                    }
                }
        }
        public void swap(int i,int j)
        {
            int tempi = tempx[i];
            int tempj = tempy[i];
            int tempW = tempw[i];
            tempx[i] = tempx[j];
            tempy[i] = tempy[j];
            tempw[i] = tempw[j];
            tempx[j] = tempi;
            tempy[j] = tempj;
            tempw[j] = tempW;
        }

        public void work()
        {
            tempx = new int[num * num];
            tempy = new int[num * num];
            tempw = new int[num * num];
            resultx = new int[num * num];
            resultw = new int[num * num];
            resulty = new int[num * num];
            delx = new int[num * num];
            delw = new int[num * num];
            dely = new int[num * num];
            cnt = 0;
            delcnt = 0;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < i; j++)
                {
                    if (Map[i,j]>0)
                    {
                        tempx[cnt] = i;
                        tempy[cnt] = j;
                        tempw[cnt++] = Map[i,j];
                    }
                }
            for(int i=0;i< cnt;i++)
                for (int j = i+1; j < cnt; j++)
                {
                    int a = tempw[i];
                    int b = tempw[j];
                    if(a>b)
                    {
                        swap(i, j);
                    }
                }
            int cns = 0;
            for (int k = 0; k < cnt; k++)
            {
                int X = findfa(tempx[k]);
                int Y = findfa(tempy[k]);
                if (X != Y)
                {
                    fa[X] = Y;
                    resultx[cns] = tempx[k];
                    resulty[cns] = tempy[k];
                    resultw[cns++] = tempw[k];
                }
            }
        }
    }
}
