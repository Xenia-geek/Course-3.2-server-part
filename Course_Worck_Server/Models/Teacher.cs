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
    
    public partial class Teacher
    {
        public string Login { get; set; }
        public int Password { get; set; }
        public Nullable<int> IDTeacher { get; set; }
        public string Email { get; set; }
        public string AboutMe { get; set; }
    
        public virtual ListTeacher ListTeacher { get; set; }
    }
}
