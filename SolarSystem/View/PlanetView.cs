using _07_HelloWorldWithCustomShaders.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urho;
using Urho.Shapes;

namespace _07_HelloWorldWithCustomShaders.View
{
    class PlanetView : Sphere
    {
        private Planet earth;
        private Material material;
        public Planet Earth { get => earth; set => earth = value; }
        public Material Material { get => material; set => material = value; }

        protected override string ModelResource => throw new NotImplementedException();

        public PlanetView() { }



    }
}
