//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab1_Serv_WEB_prog
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sage
    {
        public Sage()
        {
            this.SageBooks = new HashSet<SageBook>();
        }
    
        public int IdSage { get; set; }
        public string name { get; set; }
        public Nullable<int> age { get; set; }
        public byte[] photo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<SageBook> SageBooks { get; set; }
    }
}
