using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityAclass
{
    public class EntytyA : BaseClass
    {

        public long? FKEntityB { get; set; }
    }
}