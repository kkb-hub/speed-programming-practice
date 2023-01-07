using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PCWBSClass
{
    public class PCWBS : BaseClass
    {

        public long? FKParent { get; set; }
        public long? FKTestCode { get; set; }
        public string? CODE { get; set; }
    }
}