using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGDemo_Models.Models.Base
{
    public class Result
    {
        public bool Success { get; set; }

        public object Message { get; set; }

        public Result()
        {
            Success = true;
            Message = "";
        }
    }
}
