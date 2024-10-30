using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Курсовая_работа_4_семестр
{
    class Backpack
    {
        public int Count;

        public int mycomp;

        public Dictionary<int, List<question>> q = new Dictionary<int, List<question>>();

        public List<question> list = new List<question>();
        
        public int Complexity;

        public void Sortt()
        {
            question temp;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i].count > list[j].count)
                    {
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }

        public Backpack(int _myprice, int _maxW)
        {
            mycomp = Complexity;
            
            Count = _maxW;
            Complexity = _myprice;
        }


        public bool CheckQuest(int median, Dictionary<int, List<question>> dic)
        {
            if(dic.ContainsKey(median) && dic[median].Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        Random rnd = new Random();
        public void AddQuest(ref Dictionary<int, List<question>> dic,int median)
        {
            int g = rnd.Next(0, dic[median].Count);


                list.Add(dic[median][g]);
                Complexity -= dic[median][g].complexity;
                dic[median].Remove(dic[median][g]);
            if(dic[median].Count == 0)
            {
                dic.Remove(median);
            }
            
            
        }

        

        
        

        public void Sort(ref Dictionary<int, List<question>> dic)
        {

            int median = 0;

            for (int i = Count; i >= 1; i--)
            {
                median = Complexity / i;
                if (median <= Complexity)
                {
                    if (median == 1)
                    {
                        for (int _i = median; _i <= 9; _i++)
                        {
                            if (CheckQuest(_i,dic))
                            {
                                AddQuest(ref dic, _i);
                                break;
                            }
                        }
                    }
                    else
                    {

                        for (int j = median; j >= 1; j--)
                        {
                            if (CheckQuest(j,dic))
                            {
                                AddQuest(ref dic, j);
                                break;
                            } 
                            if(j==1)
                            {
                                for (int _j = median; _j <= 9; _j++)
                                {
                                    if (CheckQuest(_j,dic))
                                    {
                                        AddQuest(ref dic, _j);
                                        break;
                                    }
                                }
                            }

                        }              
                    }
                }                
            }
            Sort2(ref q, median );
        }

        public int COM()
        {
            int c = 0;
            for (int i = 0; i < list.Count; i++)
            {
                c += list[i].complexity;
            }
            return c;
        }

        public void Sort2(ref Dictionary<int, List<question>> dic, int Count)
        {
            Complexity = Count;
            for (int i = Count; i >= 1; i--)
            {
                int median = Complexity / i;
                if (median <= Complexity)
                {
                    if (median == 1)
                    {
                        for (int _i = median; _i <= 9; _i++)
                        {
                            if (CheckQuest(_i, dic))
                            {
                                AddQuest(ref dic, _i);
                                return;
                            }
                        }
                    }
                    else
                    {

                        for (int j = median; j >= 1; j--)
                        {
                            if (CheckQuest(j, dic))
                            {
                                AddQuest(ref dic, j);
                                break;
                            }
                            if (j == 1)
                            {
                                for (int _j = median; _j <= 9; _j++)
                                {
                                    if (CheckQuest(_j, dic))
                                    {
                                        AddQuest(ref dic, _j);
                                        break;
                                    }
                                }
                            }

                        }

                    }
                }
            }

            
        }




    }
}
