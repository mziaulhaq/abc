using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcommerceDAL
{
    public class CategoriesInformations
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
        public string CatDescription { get; set; }
        public string CatHierarchy { get; set; }
        public int? CatParent { get; set; }
        public bool CatIsActive { get; set; }
        public int CatCreatedBy { get; set; }
        public System.DateTime CatCreatedDate { get; set; }
        public int? CatLastModifiedBy { get; set; }
        public DateTime? CatLastModifiedDate { get; set; }
        public int StoreId { get; set; }
        public long? ShowOrder { get; set; }
    }
}
