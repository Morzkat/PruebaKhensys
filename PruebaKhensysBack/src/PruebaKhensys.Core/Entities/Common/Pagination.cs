using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaKhensys.Core.Entities.Common
{
    public class Pagination
    {
        public int Skip { get; set; } = 0;
        public int Limit { get; set; } = 10;
    }

}
