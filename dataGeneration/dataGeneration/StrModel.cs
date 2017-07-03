using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataGeneration
{
   public class StrModel
    {
        private String showText;

        public String ShowText
        {
            get { return showText; }
            set { showText = value; }
        }

       private String fileName;

       public String FileName
       {
           get { return fileName; }
           set { fileName = value; }
       }
    }
}
