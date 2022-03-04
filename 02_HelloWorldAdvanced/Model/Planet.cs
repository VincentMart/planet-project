using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urho;
using Urho.Shapes;

namespace _07_HelloWorldWithCustomShaders.Model
{
    class Planet : Component
    {

        public Material Materials { get; set; }
        public Sphere Sphere { get; set; }

        public Planet() { }

        public void Init(String materials)
        {
            var node = Node;
            Sphere = node.CreateComponent<Sphere>();
            Sphere.SetMaterial(Materials);
        }


    }
}
