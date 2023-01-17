using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSESpeedProgrammingLib.Entities
{
    public class BaseClass
    {
        public static List<string> PropertiesToExclude =>
            new List<string> { nameof(PK), nameof(ID), nameof(CreatedOn), nameof(UpdatedOn) };

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long? PK { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid? ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual DateTime? CreatedOn { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual DateTime? UpdatedOn { get; set; }

        public virtual DateTime? DeletedOn { get; set; }

        public virtual string CreatedByName { get; set; }

        public virtual Guid? CreatedByID { get; set; }

        public virtual string UpdatedByName { get; set; }

        public virtual Guid? UpdatedByID { get; set; }

        public virtual string DeletedByName { get; set; }

        public virtual Guid? DeletedByID { get; set; }
    }
}
