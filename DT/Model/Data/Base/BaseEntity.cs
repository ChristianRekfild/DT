using System.ComponentModel;

namespace DT.Model.Data.Base
{
    public class BaseEntity
    {

        private Guid _id;
        public Guid Id 
        { 
            get => _id;
            set => this._id = new Guid(); 
        }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }
    }
}
