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
    
    public partial class StudentPass
    {
        public int IDStudentPass { get; set; }
        public Nullable<int> IDStudent { get; set; }
        public Nullable<int> IDTeacher { get; set; }
        public Nullable<int> IDLab { get; set; }
        public Nullable<int> PassedQuantity { get; set; }
    
        public virtual ListLab ListLab { get; set; }
        public virtual ListStudent ListStudent { get; set; }
        public virtual ListTeacher ListTeacher { get; set; }
    }
}
