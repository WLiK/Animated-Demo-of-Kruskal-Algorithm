using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
namespace WpfApplication1
{
    
    
    class prim
    {
        protected int[,] Map;
        protected int[,] low;
        public int[,] usededge;
        protected int num;
        protected int newnum;
        protected int deletenum;
        protected int[,] newedge;
        protected int[,] deleteedge;

        public prim()
        {
            num = 5;
            usededge = new int[num, 2];
            newedge=new int [num,2];
            deleteedge = new int[num, 2];
        }
        public virtual void init()
        {
            var rand = new Random();
            Map = new int[num, num];
            for (int i = 0; i < num; i++)
                for (int j = 0; j < num; j++)
                    Map[i, j] = 11;
                    for (int i = 0; i < num; i++)
                for (int j = 0; j < i; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        Map[i, j] = 11;
                    }
                    else
                    {

                        int value = rand.Next(1, 100);
                        if (value <= 40)
                        {
                            Map[i, j] = 11;
                        }
                        else
                        {
                            Map[i, j] = rand.Next(1, 10);
                            Map[j, i] = Map[i, j];
                        }
                    }
                }
            low = new int[num, 2];
            for (int i = 0; i < 5; i++)
            {
                low[i, 1] = Map[4, i];
                low[i, 0] = 4;
            }
        }

        public void work(int cnt)
        {
            int lowest = 11;
            int record=-1;
            newnum = 0;
            deletenum = 0;
            for (int i = 0; i < 5; i++)
                {
                    if (low[i, 1] < lowest&&low[i,1]!=0)
                    {
                        lowest = low[i, 1];
                        record = i;
                    }
                }
            low[record, 1] = 0;
 
                usededge[cnt, 0] = low[record, 0];
                usededge[cnt, 1] = record;
               
                for(int i=0;i<5;i++)
                {
                    if(Map[record,i]<low[i,1])
                    {
                    deleteedge[deletenum, 1] = i;
                    deleteedge[deletenum++, 0] = record;
                    low[i, 1] = Map[record, i];
                    low[i, 0] = record;
                    newedge[newnum, 1] = i;
                    newedge[newnum++, 0] = record;
                    
                     }
                }
               

        }


    }
    
}
