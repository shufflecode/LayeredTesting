using System;
using SerializerTesting.Infrastructure;
using SerializerTesting.Model;

namespace SerializerTesting.Data.Repositories
{
    class MongoDbRepository : ITswDocumentRepository<TypeFile>
    {
        public void Create(TypeFile document)
        {
            throw new NotImplementedException();
        }

        public void Delete(TypeFile document)
        {
            throw new NotImplementedException();
        }

        public TypeFile Read(string filePath)
        {
            throw new NotImplementedException();
        }

        public void Update(TypeFile document)
        {
            throw new NotImplementedException();
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
