using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Net;

namespace dataGeneration
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public static List<DataModel> dataList = new List<DataModel>();
        DataSourceDLL dsDll = new DataSourceDLL();
        public Dictionary<String, DataReduce> reduceMap = new Dictionary<String, DataReduce>();
        public TreeNode preNode = null;
        private void Main_Load(object sender, EventArgs e)
        {

           

            this.gb_date.Enabled = false;
            this.gb_number.Enabled = false;
            this.gb_str.Enabled = false;
            DataTypeMapping.initDataMap();
            String path = @"dataList.txt";
            
            dataList = Read(path, new DataModel());

            initCurHaveStr();


            foreach (DataModel data in dataList)
            {
                this.cbb_huihuaList.Items.Add(data);
            }

            this.cbb_huihuaList.DisplayMember = "ShowText";
            this.cbb_huihuaList.ValueMember = "Item";

        }

       

        public static List<T> Read<T>(string path,T className)
        {
            FileStream fs = null;
            List<T> modelList = new List<T>();
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                BinaryFormatter binFormat = new BinaryFormatter();//创建二进制序列化器
                if (fs.Length != 0)
                {
                    modelList = (List<T>)binFormat.Deserialize(fs);
                    fs.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return modelList;
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            String path = @"dataList.txt";
            Write(path, dataList);
        }

        public void Write<T>(string path, List<T> obj)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            //StreamWriter sw = new StreamWriter(fs);
            //开始写入
            BinaryFormatter binformat = new BinaryFormatter();
            binformat.Serialize(fs, obj);
            //清空缓冲区
            //sw.Flush();
            //关闭流
            //sw.Close();
            fs.Close();
        }




        private void btn_setting_Click(object sender, EventArgs e)
        {
            WriteLinkInfoForm form = new WriteLinkInfoForm(this);
            form.ShowDialog();


        }

        private void btn_linked_Click(object sender, EventArgs e)
        {
            if (this.cbb_huihuaList.SelectedIndex != 0)
            {
                DataModel data = (DataModel)this.cbb_huihuaList.SelectedItem;
                //GetIp ip = new GetIp();
                //string defaultIp = ip.getLocalNetInfo()[1];
                //if (ip.list.Contains(defaultIp))
                //{
                if (data == null)
                {
                    MessageBox.Show("请选择一个可以联系的对象");
                    return;
                }
                string linkResult = DBHelper.testLink(data);
                if (linkResult == "success")
                {
                    DataTable dt = dsDll.getTablesInfo(data);
                    initTableTree(dt);
                }
                else
                {
                    MessageBox.Show(linkResult);
                }
                //}
                //else
                //{
                //    MessageBox.Show("连接失败，请稍后重试。。。。");
                //}
            }

        }

        private void initTableTree(DataTable dt)
        {

            foreach (DataRow row in dt.Rows)
            {
                TreeNode node = new TreeNode();
                node.Text = row["tableName"].ToString();
                node.Tag = row;
                DataTable fieldsDt = dsDll.getTableFeildInfo(row["tableName"].ToString(), row["dbName"].ToString());
                foreach (DataRow fieldRow in fieldsDt.Rows)
                {
                    TreeNode fieldsNode = new TreeNode();
                    fieldsNode.Text = fieldRow["columnName"].ToString() + "  " + fieldRow["columnType"].ToString();
                    fieldsNode.Tag = fieldRow;
                    node.Nodes.Add(fieldsNode);
                }
                this.tv_tableList.Nodes.Add(node);
            }
            this.tv_tableList.CheckBoxes = true;
            this.tv_tableList.ExpandAll();

        }

        private void initCurData(TreeNode node) {
            if (node.Level == 1)
            {
                String curIndex = (node.Parent.Index * 10).ToString() + node.Index.ToString();

                DataRow row = (DataRow)node.Tag;
                String typeName = row["dataType"].ToString();
                String result = DataTypeMapping.getDataType(typeName);
                // int curIndex = e.Node.Index;
                //MessageBox.Show(curIndex + "");
                DataReduce item = null;
                bool flag = false;
                if (reduceMap.ContainsKey(curIndex))
                {
                    item = reduceMap[curIndex];
                }
                else
                {
                    item = new DataReduce();
                    flag = true;
                    item.SelectedType = 1;
                }

                item.Field = row["columnName"].ToString();
                item.SeqInIndex = (row["seqInIndex"].ToString() == "" ? 0 : Int32.Parse(row["seqInIndex"].ToString()));
                item.Unique = (row["unique"].ToString() == "" ? 1 : Int32.Parse(row["unique"].ToString()));
                item.Key = row["keyName"].ToString();

                if (result.Equals("Long") || result.Equals("Integer") || result.Equals("Double"))
                {
                    item.Type = "number";
                    String curColumnType = row["columnType"].ToString();
                    if (typeName == "int")
                    {
                        item.TypeMax = Int32.MaxValue;
                        item.TypeMin = Int32.MinValue;
                    }
                    else if (typeName == "tinyint")
                    {
                        item.TypeMax = 127;
                        item.TypeMin = -128;
                    }
                    else if (typeName == "bigint")
                    {
                        item.TypeMax = Int64.MaxValue;
                        item.TypeMin = Int64.MinValue;
                    }
                    else if (typeName == "smallint")
                    {
                        item.TypeMax = 32767;
                        item.TypeMin = -32768;
                    }
                    else if (typeName == "mediumint")
                    {
                        item.TypeMax = 8388607;
                        item.TypeMin = -8388608;
                    }

                    if (curColumnType.IndexOf("unsigned") >= 0)
                    {
                        this.tb_min.Text = (flag ? 0 : item.Min).ToString();
                    }
                    else
                    {
                        this.tb_min.Text = (flag ? Int32.MinValue : item.Min).ToString();
                    }
                    item.Min = Int32.Parse(this.tb_min.Text);
                    this.tb_max.Text = (flag ? Int32.MaxValue : item.Max).ToString();
                    item.Max = Int32.Parse(this.tb_max.Text);
                    this.tb_zzzNum.Text = (flag ? 1 : item.Zzz).ToString();
                    item.ZzzSum = Int32.Parse(this.tb_zzzNum.Text);
                    item.Seed = (flag ? new Random().Next(10000) : item.Seed);
                    this.tb_seed.Text = item.Seed.ToString();
                    this.gb_str.Enabled = false;
                    this.gb_date.Enabled = false;
                    this.gb_number.Enabled = true;

                }
                else if (result.Equals("String"))
                {
                    item.Type = "String";
                    String curColumnType = row["columnType"].ToString();
                    Regex rg = new Regex(".*\\(([\\d]+)\\).*", RegexOptions.IgnoreCase);
                    int val = Int32.Parse(rg.Replace(curColumnType, "$1"));
                    item.TypeMax = val;
                    this.cbb_str.SelectedIndex = (flag ? 0 : item.GenerationType);
                    this.gb_str.Enabled = true;
                    this.gb_date.Enabled = false;
                    this.gb_number.Enabled = false;
                }
                else
                {
                    item.Type = "date";
                    item.StartDate = (flag ? new DateTime(2000, 1, 1) : item.StartDate);
                    this.dtp_start.Value = item.StartDate;
                    item.EndDate = (flag ? new DateTime(2020, 1, 1) : item.EndDate);
                    this.dtp_end.Value = item.EndDate;
                    this.gb_str.Enabled = false;
                    this.gb_date.Enabled = true;
                    this.gb_number.Enabled = false;
                }
                if (reduceMap.ContainsKey(curIndex))
                {
                    reduceMap.Remove(curIndex);
                    reduceMap.Add(curIndex, item);
                }
                else
                {
                    reduceMap.Add(curIndex, item);
                }
            }
        }

        private void tv_tableList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            initCurData(e.Node);

        }

        private void tv_tableList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0 && e.Node.Checked)
            {

                TreeNodeCollection nodes = e.Node.Nodes;
                foreach (TreeNode item in nodes)
                {
                    item.Checked = true;
                }
            }
        }

        private void btn_generation_Click(object sender, EventArgs e)
        {
            TreeNodeCollection nodes = this.tv_tableList.Nodes;
            bool flag = true;
            this.tv_tableList.SelectedNode = preNode;
            this.tv_tableList.Select();
            Dictionary<String, List<DataReduce>> treeReduceMap = new Dictionary<string, List<DataReduce>>();
            foreach (TreeNode item in nodes)
            {
                if (item.Checked)
                {
                    String tableName = item.Text;
                    TreeNodeCollection childsNode = item.Nodes;
                    List<DataReduce> reduceList = new List<DataReduce>();
                    foreach(TreeNode child in childsNode){
                        if(child.Checked){
                            String curIndex = (child.Parent.Index * 10).ToString() + child.Index.ToString();
                            
                            if (!reduceMap.ContainsKey(curIndex))
                            {
                                initCurData(child);
                                reduceList.Add(reduceMap[curIndex]);
                            }
                            else 
                            {
                                reduceList.Add(reduceMap[curIndex]);
                            }


                            String preCurIndex = (preNode.Parent.Index * 10).ToString() + preNode.Index.ToString();
                            if (curIndex == preCurIndex)
                            {
                                DataReduce curTemp = reduceMap[curIndex];
                                if (curTemp.Type == "String")
                                {
                                    curTemp.GenerationType = this.cbb_str.SelectedIndex;
                                    if (curTemp.GenerationType != 0)
                                    {
                                        StrModel map = (StrModel)this.cbb_str.SelectedItem;
                                        curTemp.Generation = map.FileName;
                                    }

                                }else if(curTemp.Type == "date"){
                                    curTemp.StartDate = this.dtp_start.Value;

                                    curTemp.EndDate = this.dtp_end.Value;
                                }
                                else if (curTemp.Type == "number")
                                {
                                    DataRow tempRow = (DataRow)preNode.Tag;
                                    String curColumnType = tempRow["columnType"].ToString();

                                    if (curColumnType.IndexOf("unsigned") >= 0)
                                    {
                                        curTemp.Min = (this.tb_min.Text == "" || Int32.Parse(this.tb_min.Text) < 0 ? 0 : Int32.Parse(this.tb_min.Text));

                                    }
                                    else
                                    {
                                        curTemp.Min = (this.tb_min.Text == "" ? Int32.MinValue : Int32.Parse(this.tb_min.Text));

                                    }

                                    curTemp.Max = this.tb_max.Text == "" ? Int32.MaxValue : Int32.Parse(this.tb_max.Text);
                                    curTemp.Zzz = this.tb_zzzNum.Text == "" ? 1 : Int32.Parse(this.tb_zzzNum.Text);
                                    curTemp.Seed = (this.tb_seed.Text == "" ? curTemp.Seed : Int32.Parse(this.tb_seed.Text));
                                }
                            }
                            
                        }
                    }
                    flag = false;
                    DataRow row = (DataRow)item.Tag;
                    treeReduceMap.Add(row["tableName"].ToString(), reduceList);
                }
            }
            
            if (flag)
            {
                MessageBox.Show("请选择要生成数据的表");
                return;
            }
            dsDll.createData(Int64.Parse(this.tb_number.Text),treeReduceMap);

            MessageBox.Show("数据生成完成");
            
            this.tv_tableList.SelectedNode = preNode;
            this.tv_tableList.Select();
            
        }

        private void tb_min_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && e.KeyChar != 8) && e.KeyChar != 13)
            {

                if (e.KeyChar == 45 && (((TextBox)sender).SelectionStart != 0 || ((TextBox)sender).Text.IndexOf("-") >= 0))
                {
                    e.Handled = true;
                    //弹出信息提示
                    MessageBox.Show("商品数量只能是数字", "操作提示");
                    e.Handled = true;//表示已经处理过keypress事件
                }
            }
            
           
        }

        private void rb_rd_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            String curIndex = (this.tv_tableList.SelectedNode.Parent.Index * 10).ToString() +  this.tv_tableList.SelectedNode.Index.ToString();

            DataReduce item = reduceMap[curIndex];
            
            if (rb.Text == "随机种子" && rb.Checked == true)
            {
                item.SelectedType = 1;
            }
            else
            {
                item.SelectedType = 2;
            }

        }
        

        private void tv_tableList_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {


            if (preNode == null)
            {
                preNode = e.Node;
            }
            else { 
                if(preNode.Level == 1){
                    String curIndex = (preNode.Parent.Index * 10).ToString() + preNode.Index.ToString();
                    DataReduce item = reduceMap[curIndex];
                    DataRow row = (DataRow)preNode.Tag;
                    String dataType = row["dataType"].ToString();
                    String result = DataTypeMapping.getDataType(dataType);
                    if (result.Equals("Long") || result.Equals("Integer") || result.Equals("Double"))
                    {
                        item.Type = "number";
                        String curColumnType = row["columnType"].ToString();

                        if (curColumnType.IndexOf("unsigned") >= 0)
                        {
                            item.Min = (this.tb_min.Text == "" || Int32.Parse(this.tb_min.Text) < 0 ? 0 : Int32.Parse(this.tb_min.Text));
                            
                        }
                        else
                        {
                            item.Min = (this.tb_min.Text == "" ? Int32.MinValue : Int32.Parse(this.tb_min.Text));
                            
                        }

                        item.Max = this.tb_max.Text == "" ? Int32.MaxValue:Int32.Parse(this.tb_max.Text);
                        item.Zzz = this.tb_zzzNum.Text == "" ? 1 : Int32.Parse(this.tb_zzzNum.Text);
                        item.Seed = (this.tb_seed.Text == ""?item.Seed:Int32.Parse(this.tb_seed.Text));

                    }
                    else if (result.Equals("String"))
                    {
                        item.Type = "String";
                        
                        item.GenerationType = this.cbb_str.SelectedIndex;
                        if(item.GenerationType != 0){
                            StrModel map = (StrModel)this.cbb_str.SelectedItem;
                            item.Generation = map.FileName;
                        }
                         
                    }
                    else
                    {
                        item.Type = "date";
                        
                        item.StartDate = this.dtp_start.Value;
                        
                        item.EndDate = this.dtp_end.Value;
                        this.dtp_end.Value = item.EndDate;
                        
                    }

                }
                preNode = e.Node;
            }
            
        }

        private void tm_scheduler_Tick(object sender, EventArgs e)
        {
            String path = @"name.txt";
            List<String> nameList = Read(path,"");
            HttpHelper helper = new HttpHelper();
            HttpItem httpItem = new HttpItem();
            HttpResult temp = null;
            if(nameList.Count < 300000){
                httpItem.URL = "http://www.qmsjmfb.com/";
                temp = helper.GetHtml(httpItem);
                if (temp.StatusCode == HttpStatusCode.OK)
                {
                    HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
                    hd.LoadHtml(temp.Html);
                    HtmlNode rootNode = hd.DocumentNode;
                    HtmlNodeCollection collection = rootNode.SelectNodes("//*[@id=\"cn\"]/div[5]/ul/*");
                    foreach (HtmlNode item in collection)
                    {
                        if (!nameList.Contains(item.InnerText))
                        {
                            nameList.Add(item.InnerText);
                        }
                    }
                    Write(path, nameList);
                }
            }
           
           
            
            path = @"country.txt";

            List<String> countryList = Read(path,"");
            if(countryList.Count <= 0){
                httpItem = new HttpItem();
                httpItem.URL = "http://www.resgain.net/country.html";
                temp = helper.GetHtml(httpItem);
                if(temp.StatusCode == HttpStatusCode.OK){
                    HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
                    hd.LoadHtml(temp.Html);
                    HtmlNode rootNode = hd.DocumentNode;
                    
                    HtmlNodeCollection collection = rootNode.SelectNodes("/html/body/div[3]/div/div/div/table/tbody/*/td[3]");
                    foreach (HtmlNode item in collection)
                    {

                        if (!countryList.Contains(item.InnerText))
                        {
                            countryList.Add(item.InnerText);
                        }
                    }
                    Write(path, countryList);
                }
            }


            path = @"province.txt";

            List<String> provinceList = Read(path, "");
            if (provinceList.Count <= 0)
            {
                httpItem = new HttpItem();
                httpItem.URL = "http://www.tcmap.com.cn/";
                temp = helper.GetHtml(httpItem);
                if (temp.StatusCode == HttpStatusCode.OK)
                {
                    HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
                    hd.LoadHtml(temp.Html);
                    HtmlNode rootNode = hd.DocumentNode;

                    HtmlNodeCollection collection = rootNode.SelectNodes("/html/body/table[3]/tr/td[1]/*/b/a");
                    foreach (HtmlNode item in collection)
                    {
                        String provinceName = item.InnerText;
                        provinceName = provinceName.Substring(0,provinceName.Length - 2);

                        if (!provinceList.Contains(provinceName))
                        {
                            provinceList.Add(provinceName);
                        }
                    }
                    Write(path, provinceList);
                    List<String> cityList = new List<string>();
                    collection = rootNode.SelectNodes("/html/body/table[3]/tr/td[1]/*/a");
                    foreach(HtmlNode item  in collection){
                        cityList.Add(item.InnerText);
                    }
                    path = @"city.txt";
                    Write(path,cityList);
                }
            }

            path = @"school.txt";
            List<String> schoolList = Read(path,"");
            if(schoolList.Count <200000){
            
                httpItem = new HttpItem();
                httpItem.URL = "http://www.xuanpai.com/tool/menpai";
                temp = helper.GetHtml(httpItem);
                if(temp.StatusCode == HttpStatusCode.OK){
                    HtmlAgilityPack.HtmlDocument schoolHd = new HtmlAgilityPack.HtmlDocument();
                    schoolHd.LoadHtml(temp.Html);
                    HtmlNode choolNode = schoolHd.DocumentNode;


                    HtmlNodeCollection schoolCollection = choolNode.SelectNodes("//*[@id=\"tool_item\"]/ul/*");
                    foreach (HtmlNode item in schoolCollection)
                    {
                        if (!schoolList.Contains(item.InnerText))
                        {
                            schoolList.Add(item.InnerText);
                        }
                    }
                    Write(path, schoolList);
                }
            }

            initCurHaveStr();
        }
        private bool isExit(String name) {
            for (int i = 0; i < this.cbb_str.Items.Count;i++ )
            {
                if(this.cbb_str.GetItemText(this.cbb_str.Items[i]) == name){
                    return true;
                }
            }
            return false;
        }

        private void initCurHaveStr()
        {
            String path = @"name.txt";
            List<String> nameList = Read(path, "");
            if (nameList.Count > 0)
            {
                StrModel map = new StrModel();
                map.ShowText = "姓名";
                map.FileName = "name.txt";
                
                if (!isExit(map.ShowText))
                {
                    this.cbb_str.Items.Add(map);
                }
                
            }
            path = @"country.txt";

            List<String> countryList = Read(path, "");
            if (countryList.Count > 0)
            {
                StrModel map = new StrModel();
                map.ShowText = "国家";
                map.FileName = "country.txt";
                if (!isExit(map.ShowText))
                {
                    this.cbb_str.Items.Add(map);
                }
            }

            path = @"province.txt";

            List<String> provinceList = Read(path, "");
            if (provinceList.Count > 0)
            {
                StrModel map = new StrModel();
                map.ShowText = "省";
                map.FileName = "province.txt";
                if (!isExit(map.ShowText))
                {
                    this.cbb_str.Items.Add(map);
                }
            }

            path = @"city.txt";

            List<String> cityList = Read(path, "");
            if (cityList.Count > 0)
            {
                StrModel map = new StrModel();
                map.ShowText = "城市";
                map.FileName = "city.txt";
                if (!isExit(map.ShowText))
                {
                    this.cbb_str.Items.Add(map);
                }
            }

            path = @"school.txt";

            List<String> schoolList = Read(path, "");
            if (schoolList.Count > 0)
            {
                StrModel map = new StrModel();
                map.ShowText = "门派";
                map.FileName = "school.txt";
                if (!isExit(map.ShowText))
                {
                    this.cbb_str.Items.Add(map);
                }
            }
            this.cbb_str.DisplayMember = "showText";
            this.cbb_str.ValueMember = "Item";
            //path = @"mixed.txt";

            //List<String> mixedList = Read(path, "");
            //if (mixedList.Count > 0)
            //{
            //    this.cbb_str.Items.Add("杂七杂八");
            //}
        }


    }
}
