using System.Collections.Generic;
using System.Text;

namespace SwapiChallenge.Shared
{
    class PagedApiResponse<T>
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<T> results { get; set; }
    }

}
