using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urho;

namespace _07_HelloWorldWithCustomShaders.Model
{
    class System : Zone
    {
        LinkedList<Node> ListPlanet { get; set; }

        public System() { }

        public void addPlanet(Node node)
        {
            ListPlanet.AddLast(node);
        }


    }
}
