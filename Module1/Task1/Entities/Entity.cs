using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Entities
{
    public class Entity : IEntity
    {
        public string Name { get; set; }
        public string CurrentDerictory { get; set; }
        public string Link { get; set; }
        public string Extension { get; set; }
        public EntityType Type { get; set; }
        public int Status { get; set; }

        public Entity(string _link, EntityType _type)
        {
            Name = Path.GetFileName(_link);
            CurrentDerictory = Path.GetDirectoryName(_link);
            Link = _link;
            Extension = Path.GetExtension(_link);
            Type = _type;
        }
    }
}
