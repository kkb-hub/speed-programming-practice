using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entityclass
{
    public class EntytyA : BaseClass
    {

        public long? FKEntityB { get; set; }
    }
}