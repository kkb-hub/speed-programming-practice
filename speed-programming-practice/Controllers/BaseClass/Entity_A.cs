using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity_AClass
{
    public class Entity_A : BaseClass
    {

        public long? FKEntityB { get; set; }
        public string BBB { get; set; }
        public string CCC { get; set; }
        public string DDD { get; set; }
    }
}