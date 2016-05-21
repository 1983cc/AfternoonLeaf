using AfternoonLeaf.Framework.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable testTable = new DataTable();
            testTable.Columns.Add("Name");
            testTable.Columns.Add("Score");
            testTable.Columns.Add("Ranking");

            DataRow dr1 = testTable.NewRow();
            dr1["Name"] = "张三";
            dr1["Score"] = 0;
            testTable.Rows.Add(dr1);

            DataRow dr2 = testTable.NewRow();
            dr2["Name"] = "李四";
            dr2["Score"] = 3;
            testTable.Rows.Add(dr2);

            DataRow dr3 = testTable.NewRow();
            dr3["Name"] = "王五";
            dr3["Score"] = 3;
            testTable.Rows.Add(dr3);

            DataRow dr4 = testTable.NewRow();
            dr4["Name"] = "赵六";
            dr4["Score"] = 0;
            testTable.Rows.Add(dr4);

            DataRow dr5 = testTable.NewRow();
            dr5["Name"] = "牛七";
            dr5["Score"] = 0;
            testTable.Rows.Add(dr5);

            DataTableUtil u1 = new DataTableUtil();
            u1.GenerateDataTableRanking(ref testTable, "Score", "Ranking");
        }
    }
}
