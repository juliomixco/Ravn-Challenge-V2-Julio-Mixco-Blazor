using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwapiChallenge.Shared.Interfaces
{
    public interface ISwapiService
    {
         Task<IEnumerable<Person>> GetPeopleAsync(int page);
    }
}
