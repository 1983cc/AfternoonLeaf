using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AfternoonLeaf.Framework.Util
{
    public class DataTableUtil
    {
        public void GenerateDataTableRanking(ref DataTable toOperateDataTable, string sortByField, string rankingField)
        {
            // group the data elements
            List<RankingGroup> rgc = new List<RankingGroup>();
            foreach (DataRow dr1 in toOperateDataTable.Rows)
            {
                RankingGroup rg = new RankingGroup();
                foreach (DataRow dr2 in toOperateDataTable.Rows)
                {
                    
                    if (dr1 != dr2 && dr2 != null)
                    {
                        if (!rg.Indecies.Contains(toOperateDataTable.Rows.IndexOf(dr1)))
                        {
                            rg.Indecies.Add(toOperateDataTable.Rows.IndexOf(dr1));
                            rg.Score = float.Parse((string)dr1[sortByField]);
                        }

                        if ((float.Parse((string)dr1[sortByField]) == float.Parse((string)dr2[sortByField]) && !rg.Indecies.Contains(toOperateDataTable.Rows.IndexOf(dr2))))
                        {
                            rg.Indecies.Add(toOperateDataTable.Rows.IndexOf(dr2));
                            rg.Score = float.Parse((string)dr2[sortByField]);
                        }                        
                    }
                    
                }
                if (!ExistsIndexcies(rgc, rg))
                    rgc.Add(rg);
            }

            List<RankingGroup> sortedRgc = rgc.OrderByDescending(t => t.Score).ToList();

            int ranking = 1;
            foreach (RankingGroup rg in sortedRgc)
            {
                foreach (int i in rg.Indecies)
                {
                    toOperateDataTable.Rows[i][rankingField] = ranking;
                }
                ranking++;
            }            
        }

        bool ExistsIndexcies(List<RankingGroup>rgc, RankingGroup rg)
        {
            foreach (RankingGroup trg in rgc)
            {
                foreach (int i in rg.Indecies)
                {
                    if (trg.Indecies.Any(t => t == i))
                        return true;
                }
            }
            return false;
        }

        internal class RankingGroup
        {
            // string sortByFiled;
            float score;
            List<int> indecies = new List<int>();
            int ranking;

            public float Score
            {
                get { return score; }
                set { score = value; }
            }

            public List<int> Indecies
            {
                get { return indecies; }
                set { indecies = value; }
            }

            public int Ranking
            {
                get { return ranking; }
                set { ranking = value; }
            }
        }
    }
}
