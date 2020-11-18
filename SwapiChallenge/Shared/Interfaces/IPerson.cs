using System;
using System.Collections.Generic;
using System.Text;

namespace SwapiChallenge.Shared.Interfaces
{
    public interface IPerson
    {

        public string name { get;  }
        public string height { get;  }
        public string mass { get;  }
        public string hair_color { get;  }
        public string skin_color { get; }
        public string eye_color { get; }
        public string birth_year { get;  }
        public string gender { get; }
        public DateTime created { get;  }
        public DateTime edited { get;  }
        public string url { get;  }

    }
}
