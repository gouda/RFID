﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.RFID.Entities.common
{
   public class Pager
    {
        public int TotalItems { get; set; }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }

        public int EndPage { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }

        public int[] Pages { get; set; }
    }
}
