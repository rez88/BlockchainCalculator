using ITUniver.Calc.DB.Repositories;

namespace ITUniver.Calc.DB.Models
{
    public class Role: IEntity
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }
    }
}
