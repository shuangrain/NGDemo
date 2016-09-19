using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGDemo_Models.Models.Base
{
    public class Base_Login
    {
        /// <summary>
        /// 帳號
        /// </summary>
        [Required]
        public string Account { set; get; }

        /// <summary>
        /// 密碼
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
