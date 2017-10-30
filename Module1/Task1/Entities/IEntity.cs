using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Entities
{
    public interface IEntity
    {
        string Name { get; set; }
        string Link { get; set; }
        string Extension { get; set; }
        EntityType Type { get; set; }
    }

    public enum EntityType
    {
        file,
        folder
    }
}
