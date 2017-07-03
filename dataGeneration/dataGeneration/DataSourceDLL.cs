using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace dataGeneration
{
   public class DataSourceDLL
    {
       public static Dictionary<String, List<String>> strMap = new Dictionary<string, List<string>>();
        public DataTable getTablesInfo(DataModel model) {
            string sql = string.Format("select o.TABLE_NAME as 'tableName',o.TABLE_COMMENT as 'tableComment' from information_schema.`TABLES` o where o.TABLE_SCHEMA = '{0}'", model.DbName);
            DataTable dt = DBHelper.getDataTable(sql);
            dt.Columns.Add("className");
            dt.Columns.Add("dbName");
            foreach(DataRow row in dt.Rows){
                string className = row["tableName"].ToString();
                
                row["className"] = convertFeildName(className,true);
                row["dbName"] = model.DbName;
            }
            return dt;

        }


        public DataTable getTableFeildInfo(string tableName,string dbName) {
            string sql = string.Format("select o.COLUMN_NAME as 'columnName',o.DATA_TYPE as 'dataType',o.COLUMN_COMMENT as 'comment',o.COLUMN_TYPE as 'columnType' from information_schema.`COLUMNS` o where  o.TABLE_NAME = '{0}' and o.TABLE_SCHEMA = '{1}'", tableName, dbName);
            
            DataTable dt = DBHelper.getDataTable(sql);
            sql = String.Format("show index from {0}",tableName);
            DataTable indexDt = DBHelper.getDataTable(sql);
            Dictionary<String, DataRow> indexMap = new Dictionary<string, DataRow>();
            foreach(DataRow row in indexDt.Rows){
                indexMap.Add(row["Column_name"].ToString(),row);
            }
            dt.Columns.Add("fieldName");
            dt.Columns.Add("unique");
            dt.Columns.Add("keyName");
            dt.Columns.Add("seqInIndex");
            foreach (DataRow row in dt.Rows)
            {
                string dbFeild = row["columnName"].ToString();
                
                row["fieldName"] = convertFeildName(dbFeild,false);
                if(indexMap.ContainsKey(dbFeild)){
                    row["unique"] = indexMap[dbFeild]["Non_unique"];
                    row["keyName"] = indexMap[dbFeild]["Key_name"];
                    row["seqInIndex"] = indexMap[dbFeild]["Seq_in_index"];
                }
            }
            return dt;
        }

        public string convertFeildName(string str,bool flag) {

            str = str.ToLower();
            StringBuilder sb = new StringBuilder();
            char[] charArr = str.ToCharArray();
            if (charArr[1] == '_')
            {
                for (int i = 1; i < charArr.Length; i++)
                {
                    if (charArr[i] == '_')
                    {
                        if (charArr[i + 1] >= 65 && charArr[i + 1] < 91)
                        {
                            sb.Append(charArr[i + 1]);
                        }
                        else if (charArr[i + 1] >= 97 && charArr[i + 1] < 123)
                        {
                            sb.Append((char)(charArr[i + 1] - 32));
                        }
                        i++;
                    }
                    else
                    {
                        sb.Append(charArr[i]);
                    }
                }
            }
            else
            {
                if ((charArr[0] >= 65 && charArr[0] < 91) || !flag)
                {
                    sb.Append(charArr[0]);
                }
                else if (charArr[0] >= 97 && charArr[0] < 123 && flag)
                {
                    sb.Append((char)(charArr[0] - 32));
                }
                for (int i = 1; i < charArr.Length; i++)
                {
                    if (charArr[i] == '_')
                    {
                        if (charArr[i + 1] >= 65 && charArr[i + 1] < 91)
                        {
                            sb.Append(charArr[i + 1]);
                        }
                        else if (charArr[i + 1] >= 97 && charArr[i + 1] < 123)
                        {
                            sb.Append((char)(charArr[i + 1] - 32));
                        }
                        else {
                            sb.Append(charArr[i + 1]);
                        }
                        i++;
                    }
                    else
                    {
                        sb.Append(charArr[i]);
                    }
                }
            }
            return sb.ToString();
        }

        public void createData(long number,Dictionary<String, List<DataReduce>> treeReduceMap)
        {
            foreach(String key in treeReduceMap.Keys){
                List<DataReduce> curList = treeReduceMap[key];
               
                DataReduce removePri = null;
                Dictionary<String, List<DataReduce>> uniqueMap = new Dictionary<string, List<DataReduce>>();
                Dictionary<String,HashSet<int>> hashCodeMap = new Dictionary<string,HashSet<int>>();
                Dictionary<String, Random> rdMap = new Dictionary<String, Random>();
                foreach(DataReduce item in curList){
                    if (item.Key == "PRIMARY")
                    {
                        removePri = item;
                        continue;
                    }
                    if(item.Unique == 0){
                        if (uniqueMap.ContainsKey(item.Key))
                        {
                            List<DataReduce> uniqueList = uniqueMap[item.Key];
                            uniqueList.Add(item);
                        }
                        else {
                            List<DataReduce> uniqueList = new List<DataReduce>(20);
                            uniqueList.Add(item);
                            uniqueMap.Add(item.Key, uniqueList);
                            hashCodeMap.Add(item.Key,new HashSet<int>());
                        }
                    }
                    if(item.GenerationType != 0){
                        String path = @"" + item.Generation;
                        if (strMap.ContainsKey(item.Generation))
                        {
                            strMap.Remove(item.Generation);
                            strMap.Add(item.Generation, MainForm.Read(path, ""));
                        }
                        else {
                            strMap.Add(item.Generation, MainForm.Read(path, ""));
                        }
                    }
                    rdMap.Add(item.Field,new Random());
                }
                curList.Remove(removePri);

                List<Dictionary<String, String>> reduceReduceList = new List<Dictionary<string, string>>();
                
                for (int i = 0; i < number;i++ )
                {
                    bool flag = true;
                    Dictionary<String, String> temp = new Dictionary<string, string>();
                    foreach(DataReduce reduce in curList){
                        
                        if (uniqueMap.Count > 0 && flag)
                        {
                            foreach(String indexKey in uniqueMap.Keys){
                                List<DataReduce> uniqueList = uniqueMap[indexKey];
                                HashSet<int> hashCodeSet = hashCodeMap[indexKey];
                                while(true)
                                {
                        
                                    StringBuilder tempSb = new StringBuilder();
                                    foreach(DataReduce item in uniqueList ){
                                        item.Zzz = i + 1;
                                        
                                        String resultStr = DataReduceMethod.reduceMap(item,rdMap[item.Field]);
                                        if(temp.ContainsKey(item.Field)){
                                            temp.Remove(item.Field);
                                            temp.Add(item.Field, resultStr);
                                        }else{
                                            temp.Add(item.Field, resultStr);
                                        }
                                        tempSb.Append(resultStr);
                                    }
                                    String hashCodeStr = tempSb.ToString();
                                    if(!hashCodeSet.Contains(hashCodeStr.GetHashCode())){
                                        hashCodeSet.Add(hashCodeStr.GetHashCode());
                                        break;
                                    }
                                }
                            }
                            flag = false;
                        }

                        if (!temp.ContainsKey(reduce.Field))
                        {
                            reduce.Zzz = i + 1;
                            String resultStr = DataReduceMethod.reduceMap(reduce,rdMap[reduce.Field]);
                            temp.Add(reduce.Field,resultStr);
                        }

                    }
                    reduceReduceList.Add(temp);
                    if(reduceReduceList.Count == 10000 || i == number - 1){
                        insertVal(key,curList,reduceReduceList);
                        reduceReduceList.Clear();
                    }
                    

                }
            }
        }

        public void insertVal(String tableName,List<DataReduce> fieldList,List<Dictionary<String,String>> resultList) {

            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " ).Append(tableName);
            sb.Append("(");
            foreach(DataReduce item in fieldList){
                sb.Append("`").Append(item.Field).Append("`,");
            }
            sb.Remove(sb.Length - 1,1);
            sb.Append(") values(");
            foreach( Dictionary<String,String> item in resultList){
                foreach(DataReduce temp in fieldList){
                    sb.Append("'").Append(item[temp.Field]).Append("',");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("),(");
            }
            sb.Remove(sb.Length - 2,2);
            DBHelper.insertDataTable(sb.ToString());

        }
    }
}
