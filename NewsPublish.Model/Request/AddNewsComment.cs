using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPublish.Model.Request
{
    public class AddNewsComment
    {
        public int NewsId { get; set; }
        public string Contents { get; set; }
    }
}
