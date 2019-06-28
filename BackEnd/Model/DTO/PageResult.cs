﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class PageResult<T>
    {
        public int TotalRecords { get; set; }
        public List<T> Results { get; set; }
    }
}
