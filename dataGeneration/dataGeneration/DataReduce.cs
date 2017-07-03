using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataGeneration
{
    [Serializable]
    public class DataReduce
    {
        private String type;

        public String Type
        {
            get { return type; }
            set { type = value; }
        }
        private String key;

        private String field;

        public String Field
        {
            get { return field; }
            set { field = value; }
        }

        public String Key
        {
            get { return key; }
            set { key = value; }
        }
        private int unique;

        public int Unique
        {
            get { return unique; }
            set { unique = value; }
        }
       
        private String reduceMethod;

        public String ReduceMethod
        {
            get { return reduceMethod; }
            set { reduceMethod = value; }
        }

        private Int32 min;

        public Int32 Min
        {
            get { return min; }
            set { min = value; }
        }


        private Int32 max;

        public Int32 Max
        {
            get { return max; }
            set { max = value; }
        }
        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        private Int64 zzz;

        public Int64 Zzz
        {
            get { return zzz; }
            set { zzz = value; }
        }
        private Int32 generationType;

        public Int32 GenerationType
        {
            get { return generationType; }
            set { generationType = value; }
        }

        private Int32 seed;

        public Int32 Seed
        {
            get { return seed; }
            set { seed = value; }
        }
        private Int64 zzzSum;

        public Int64 ZzzSum
        {
            get { return zzzSum; }
            set { zzzSum = value; }
        }

        private int selectedType;

        public int SelectedType
        {
            get { return selectedType; }
            set { selectedType = value; }
        }

        private Int64 typeMax;

        public Int64 TypeMax
        {
            get { return typeMax; }
            set { typeMax = value; }
        }

        private Int64 typeMin;

        public Int64 TypeMin
        {
            get { return typeMin; }
            set { typeMin = value; }
        }

        private Int32 seqInIndex;

        public Int32 SeqInIndex
        {
            get { return seqInIndex; }
            set { seqInIndex = value; }
        }

        private String generation;

        public String Generation
        {
            get { return generation; }
            set { generation = value; }
        }
        
    }
}
