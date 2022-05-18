using System;

namespace _0_Framework.Domain
{
    //Just for fun😑
    //for do not doplicated property!
    //استفاده بهینه
    public class EntityBase
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }

        public EntityBase()
        {
            CreationDate = DateTime.Now;
        }
    }
}
