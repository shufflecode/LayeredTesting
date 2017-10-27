using System.Runtime.Serialization;
using SerializerTesting.Infrastructure;

namespace SerializerTesting.Model.FooData
{
    [TypeFileSerializableElement]
    [DataContract(Name = "Axis", Namespace = "")]
    public class Axis : IAxis
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Number { get; set; }
    }
}