using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using SerializerTesting.Infrastructure;
using SerializerTesting.Model;

namespace SerializerTesting.Data.Repositories
{
    public class XmlRepository : ITswDocumentRepository<TypeFile>
    {
        public void Create(TypeFile document)
        {
            if (string.IsNullOrWhiteSpace(document.ConfigName))
                throw new NotSupportedException($"{nameof(document.ConfigName)} wird zum Speichern benötigt");

            var knownTypes = XmlHelper.GetKnownTypes(document.GetType());

            var typestoSerialize = XmlHelper.GetTypesIn(document.GetType());
            knownTypes.AddRange(typestoSerialize);

            var serializer = new DataContractSerializer(typeof(TypeFile), knownTypes);
            
            using (var stream = XmlWriter.Create(document.ConfigName))
            {
                try
                {
                    serializer.WriteObject(stream, document);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    throw;
                }
            }
        }

        public void Delete(TypeFile document)
        {
            if (!File.Exists(document.ConfigName))
                throw new FileNotFoundException($"Datei {document.ConfigName} nicht gefunden");

            try
            {
                File.Delete(document.ConfigName);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public TypeFile Read(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Datei {filePath} nicht gefunden");

            var knownTypes = XmlHelper.GetKnownTypes(typeof(TypeFile));
            var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var xs = new DataContractSerializer(typeof(TypeFile), knownTypes);

            TypeFile typeFile;
            try
            {
                typeFile = (TypeFile) xs.ReadObject(fs);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            if (typeFile != null)
                typeFile.ConfigName = filePath;

            fs.Close();
            fs.Dispose();
            return typeFile;
        }

        public void Update(TypeFile document)
        {
            if (!File.Exists(document.ConfigName))
                throw new FileNotFoundException($"Datei {document.ConfigName} nicht gefunden");

            var knownTypes = XmlHelper.GetKnownTypes(typeof(TypeFile));
            var serializer = new DataContractSerializer(typeof(TypeFile), knownTypes);
            try
            {
                using (var stream = XmlWriter.Create(document.ConfigName))
                {
                    serializer.WriteObject(stream, document);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public void Migrate(TypeFile document)
        {
            throw new NotImplementedException();
        }

        public void MigrateAll(object param)
        {
            throw new NotImplementedException();
        }
    }
}