using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListApplication.Data
{
    public interface IEntity
    {

    }

    public interface IEntity<TId> : IEntity
    {
        TId Id { get; set; }
    }


    public interface IBaseDbEntity : IEntity<int>
    {
    
    }
}
