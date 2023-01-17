using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FSESpeedProgrammingLib.Entities;

namespace Entityclass
{
    public class Tb1 : BaseClass
    {

        public long? FKTb2 { get; set; }
        public string? b { get; set; }
        public string? c { get; set; }
        public string? d { get; set; }
        public string? e { get; set; }


    }
}