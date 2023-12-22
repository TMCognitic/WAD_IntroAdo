using ConnexionDb.Entities;
using ConnexionDb.Repositories;
using ConnexionDb.Services;
using Microsoft.Data.SqlClient;

namespace ConnexionDb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1 Installer le package nuget : Microsoft.Data.SqlClient
            //2 Récupérer la chaine de connexion (Connection String) depuis l'explorateur d'objet Sql Server
            string connectionString = @"Data Source=BRIAREOS-AW2\SQL2022DEV;Initial Catalog=DbSlide;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

            ISectionRepository repository = new SectionService(connectionString);

            //repository.Insert(new Section() { SectionId = 1450, SectionName = "C# Ado", DelegateId = 1 });

            //foreach (Section section in repository.Get())
            //{
            //    Console.WriteLine(section.SectionName);
            //}

            //int section_id = 1450;
            //if(repository.Delete(section_id))
            //{
            //    Console.WriteLine($"La section {section_id} a été supprimée");
            //}
            //else
            //{
            //    Console.WriteLine($"Aucune section {section_id} trouvée et supprimée");
            //}

            //Section? section = repository.Get(1450);

            //if (section is not null)
            //{
            //    Console.WriteLine(section.SectionName);
            //}

            //Section section = new Section() { SectionId = 1010, SectionName = ".Net", DelegateId = 1 };
            //repository.Update(section);
        }
    }
}
