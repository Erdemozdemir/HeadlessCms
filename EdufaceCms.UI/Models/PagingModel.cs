using EdufaceCms.Entities.Concrete;
using System.Collections.Generic;

namespace EdufaceCms.UI.Models
{
    public class PagingModel
    {
        public List<EntityBase> entities;
        public bool HasPreviousPage
        {
            get { return (PageIndex > 1); }
        }
        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
    }
}
