using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SerializerTesting.Infrastructure;

namespace SerializerTesting.Data
{
    public static class XmlHelper
    {
        /// <summary>
        ///     Ermittelt Serialisierbare Typen (mit <see cref="TypeFileSerializableElement" />) getaggte Klassen aus der
        ///     Bibliothek des Übergebenen Typs
        /// </summary>
        /// <returns>liste mit Serialisierbar</returns>
        public static List<Type> GetKnownTypes(Type type)
        {
            try
            {
                var items = Assembly.GetAssembly(type).GetTypes()
                    .Where(
                        o => o != null && o.IsClass &&
                             o.GetCustomAttributes(typeof(TypeFileSerializableElement)).Any());

                var enumerable = items as Type[] ?? items.ToArray();
                var temp = enumerable.ToList();
                return temp;
            }
            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }
        }

        /// <summary>
        ///     Ermittelt die verwendeten Typen aus einer KLasse
        /// </summary>
        /// <param name="document">Das TypeFile für das die Klassen ermittelt werden sollen</param>
        /// <returns><see cref="List{T}" />mit <see cref="Type" /></returns>
        public static List<Type> GetTypesIn(Type document)
        {
            var types = new List<Type>();
            types.Add(document);
            var myTypes = GetSubTypesOf(document, types);
            return myTypes;
        }

        private static List<Type> GetSubTypesOf(Type document, List<Type> types)
        {
            var properties = document.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(
                    p => !p.PropertyType.IsPrimitive &&
                         !p.PropertyType.IsGenericType &&
                         p.PropertyType != typeof(string));


            foreach (var propertyInfo in properties)
            {
                if (types.Contains(propertyInfo.PropertyType)) continue;

                types.Add(propertyInfo.PropertyType);
                GetSubTypesOf(propertyInfo.PropertyType, types);
            }
            return types;
        }
    }
}