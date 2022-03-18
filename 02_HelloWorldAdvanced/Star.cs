using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urho;
using SolarSystem;

namespace _07_HelloWorldWithCustomShaders
{
    class Star : Planete
    {
        private Scene Scene { get; set; }
        public Star(Planete parentNode = null, Scene scene, Material planetMaterial, float taille, float positionX, float positionY, float positionZ) : base(parentNode, planetMaterial, taille, positionX, positionY, positionZ)
        {
            Scene = scene;
        }

   
    }
}
