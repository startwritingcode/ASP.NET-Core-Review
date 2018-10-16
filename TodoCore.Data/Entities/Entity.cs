using System;

namespace TodoCore.Data.Entities
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
