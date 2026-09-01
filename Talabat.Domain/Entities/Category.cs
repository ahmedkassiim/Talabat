using System;
using System.Collections.Generic;
using System.Text;

namespace Talabat.Domain.Entities
{
    public class Category :BaseEntity
    {
        public string Name { get; set; } = default!;
    }
}
