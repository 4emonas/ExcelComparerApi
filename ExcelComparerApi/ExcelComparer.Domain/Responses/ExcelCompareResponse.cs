using ExcelCompareNuget.Compare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelComparer.Domain.Responses
{
    public class ExcelCompareResponse
    {
        public ExcelCompareResponse(CompareResponse result)
        {
            Result = result;
        }

        public CompareResponse Result { get; set; }
    }
}
