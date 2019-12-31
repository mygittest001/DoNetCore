using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NewsPublish.Model.Request
{
    public class AddNewsClassify
    {
        public string Name { get; set; }
        public int Sort { get; set; }
        public string Remark { get; set; }
    }
}