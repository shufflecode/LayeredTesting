using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializerTesting.Infrastructure
{
    /// <summary>
    ///     Zwichenschicht, um keine Abhängigkeit mit Mongo / Namespace in der TestSoftware zu haben
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITswDocumentRepository<T>
    {
        /// <summary>
        ///     Schreibt das dokument vom Typ <see cref="T" /> in das Repository
        /// </summary>
        /// <param name="document"></param>
        void Create(T document);

        /// <summary>
        ///     löscht das Dokument aus dem Repository
        /// </summary>
        /// <param name="document">das zu löschende Dokument</param>
        void Delete(T document);

        /// <summary>
        ///     Liest ein Dokument vom Typ <see cref="T" /> aus dem Repository
        /// </summary>
        /// <param name="filePath">der Identifier anhand dessen das Dokument im Repo gesucht werden soll</param>
        /// <returns></returns>
        T Read(string filePath);


        /// <summary>
        ///     Updated das übergebene Dokument im Repository
        /// </summary>
        /// <param name="document"></param>
        void Update(T document);

        /// <summary>
        /// Migriert das gegebene Dokument
        /// </summary>
        /// <param name="document">das zu migrierende Dokument</param>
        void Migrate(T document);

        /// <summary>
        /// Führt für alle Dokumente des Typs die Funktion Migrate aus und Speichert Sie neu ab
        /// </summary>
        /// <param name="param">Informationen die zum Updaten aller Dokumente benötigt werden</param>
        void MigrateAll(object param);
    }
}
