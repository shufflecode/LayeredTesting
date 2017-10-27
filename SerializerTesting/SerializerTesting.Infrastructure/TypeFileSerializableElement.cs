using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializerTesting.Infrastructure
{
    /// <summary>
    ///     Bezeichnet eine im Typefile enthaltene Klasse (Hilfe zum entdecken von Klassen mittels Reflection)
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TypeFileSerializableElement : Attribute
    {
    }
}
