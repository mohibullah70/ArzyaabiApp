//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EZKARAPP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class taskhil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public taskhil()
        {
            this.arzyaabis = new HashSet<arzyaabi>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string fname { get; set; }
        public string gfname { get; set; }
        public string bast { get; set; }
        public string qadamasli { get; set; }
        public string qadampeli { get; set; }
        public string taqaroribtidayi { get; set; }
        public string rooz { get; set; }
        public string maah { get; set; }
        public string saal { get; set; }
        public string inwaanbast { get; set; }
        public string reyasatmarboot { get; set; }
        public string mooyinat { get; set; }
        public string markaziwalayati { get; set; }
        public string mamoorkaarkon { get; set; }
        public string jinsiyat { get; set; }
        public string darajatahseel { get; set; }
        public string reshtatahseel { get; set; }
        public string maash { get; set; }
        public string roobamoqarari { get; set; }
        public string saalmoqarari { get; set; }
        public string poorkhaali { get; set; }
        public string saaltawalood { get; set; }
        public string roobarzyaabi { get; set; }
        public string arzyaabiimtehaani { get; set; }
        public string roobarzyaabiimtehaani { get; set; }
        public string tarikharzyaabi { get; set; }
        public string shoomratamaas { get; set; }
        public string nawimaash { get; set; }
        public string meeqdarmaash { get; set; }
        public string tarikhakhzmaash { get; set; }
        public string maahakhzmaash { get; set; }
        public string molahezat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<arzyaabi> arzyaabis { get; set; }
    }
}
