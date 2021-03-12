using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Class:IEntity
    {
        public int ClassId { get; set; }
        public short ClassN { get; set; }
        public string ClassQ { get; set; }
    }
}
