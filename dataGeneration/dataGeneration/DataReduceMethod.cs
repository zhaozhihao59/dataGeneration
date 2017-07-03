using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataGeneration
{
    public class DataReduceMethod
    {

        public static String reduceMap(DataReduce item,Random rd) { 
            if(item.Type == "number"){
                if (item.SelectedType == 2)
                {
                    return (item.ZzzSum + item.Zzz).ToString();
                }
                else {
                    
                    //if (item.Seed == 0)
                    //{
                        
                    //}
                    //else 
                    //{
                    //    rd = new Random(item.Seed);
                    //}
                    int max = 0;
                    int min = 0;
                    if (item.Max > item.TypeMax)
                    {
                        max = (int)item.TypeMax;
                    }
                    else {
                        max = item.Max;
                    }
                    if (item.Min < item.TypeMin)
                    {
                        min = (int)item.TypeMin;
                    }
                    else {
                        min = item.Min;
                    }

                    return rd.Next(min,max).ToString();
                }
            }
            else if (item.Type == "String")
            {
                if(item.GenerationType == 0){
                    String resultStr = System.Guid.NewGuid().ToString().Replace("-", "");
                    return resultStr.Length>item.TypeMax?resultStr.Substring(0,(int)item.TypeMax):resultStr;
                }else if(item.Generation != null && item.Generation != ""){
                    String path = @"" + item.Generation;
                    List<String> resultList = DataSourceDLL.strMap[item.Generation];
                    String resultStr = resultList[rd.Next(0,resultList.Count - 1)];
                    return resultStr.Length > item.TypeMax ? resultStr.Substring(0, (int)item.TypeMax) : resultStr;
                }
            }else if(item.Type == "date")
            {
                
                int year = rd.Next(item.StartDate.Year, item.EndDate.Year);
                int month = 0;
                int day = 0;
                if(year == item.StartDate.Year && year == item.EndDate.Year ){
                    month = rd.Next(item.StartDate.Month, item.EndDate.Month);
                    day = getDay(year, month, item, rd);
                }
                else if(year == item.StartDate.Year && year < item.EndDate.Year)
                {
                    month = rd.Next(item.StartDate.Month, 12);
                    day = getDay(year, month, item, rd);
                }
                else if (year == item.EndDate.Year && year > item.StartDate.Year)
                {
                    month = rd.Next(1, item.EndDate.Month);
                    day = getDay(year, month, item, rd);

                }
                else 
                {
                    month = rd.Next(1, 12);
                    day = getDay(year, month, item, rd);
                }
                
                String resultDate = year + "-" + month + "-" + day;
                return resultDate;
            }
            return "";
        }

        private static int getDay(int year,int month,DataReduce item,Random rd) {
            int day = 0;
            if (month == item.StartDate.Month && month == item.EndDate.Month)
            {
                day = rd.Next(item.StartDate.Day, item.EndDate.Day);
            }
            else if (month == item.StartDate.Month && month < item.EndDate.Month)
            {
                DateTime cur = new DateTime(year, month, 1);

                day = rd.Next(item.StartDate.Day, DateTime.DaysInMonth(cur.Year, cur.Month));
            }
            else if (month > item.StartDate.Month && month == item.EndDate.Month)
            {
                day = rd.Next(1, item.EndDate.Day);
            }
            else
            {
                DateTime cur = new DateTime(year, month, 1);
                day = rd.Next(1, DateTime.DaysInMonth(cur.Year, cur.Month));
            }
            return day;
        }
    }
}
