using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_AClass

{
    public class BaseClass//: IBaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long? PK { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid? ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual DateTime? CreatedOn { get; set; }

        public virtual Guid? CreatedByID { get; set; }

        [MaxLength(200)]
        public virtual string CreatedByName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual DateTime? UpdatedOn { get; set; }

        public virtual Guid? UpdatedByID { get; set; }

        [MaxLength(200)]
        public virtual string UpdatedByName { get; set; }

        public virtual DateTime? DeletedOn { get; set; }

        public virtual Guid? DeletedByID { get; set; }

        [MaxLength(200)]
        public virtual string DeletedByName { get; set; }
    }
}
