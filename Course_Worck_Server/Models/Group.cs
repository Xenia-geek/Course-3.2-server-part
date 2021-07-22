//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Course_Worck_Server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Group()
        {
            this.ListLabTeachers = new HashSet<ListLabTeacher>();
            this.ListStudents = new HashSet<ListStudent>();
            this.PlansPasses = new HashSet<PlansPass>();
        }
    
        public int IDGroup { get; set; }
        public int NumberGroup { get; set; }
        public string IDSpeciality { get; set; }
        public Nullable<int> IDSubGroup { get; set; }
        public Nullable<int> IDCource { get; set; }
    
        public virtual Cource Cource { get; set; }
        public virtual Speciality Speciality { get; set; }
        public virtual SubGroup SubGroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListLabTeacher> ListLabTeachers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListStudent> ListStudents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlansPass> PlansPasses { get; set; }
    }
}
