using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SerializerTesting.Infrastructure;

namespace SerializerTesting.Model
{
    [TypeFileSerializableElement]
    [DataContract(Name = "TypeFile", Namespace = "")]
    public class TypeFile
    {
        public TypeFile()
        {
            ConfigName = "MyDataClass";
        }

        [DataMember]
        public string ConfigName { get; set; }

        [DataMember]
        public List<IAxis> Axis { get; set; }

    }
}
