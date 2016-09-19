using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGDemo_Models.Models.Base
{
    public class Base_Response : Result
    {

        public int CurrentPage { get; set; }

        public long Total { get; set; }

        public object Data { get; set; }
    }
}
