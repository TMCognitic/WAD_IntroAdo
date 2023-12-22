using ConnexionDb.Entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnexionDb.Repositories
{
    public interface ISectionRepository
    {
        IEnumerable<Section> Get();
        Section? Get(int sectionId);
        bool Insert(Section entity);
        bool Update(Section entity);
        bool Delete(int sectionId);
    }
}
