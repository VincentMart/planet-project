using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urho;
using Urho.Actions;

namespace _07_HelloWorldWithCustomShaders.Modele
{
    class LunarSystem : Node
    {
        private Planet earth;
        private Planet moon;
        private float duration;
        private float deltaY;

        public Planet Earth { get; set; }
        public Planet Moon { get; set; }
        public float Duration { get; set; }
        public float DeltaY { get; set; }

        public LunarSystem(Planet earth, Planet moon)
        {
            Earth = earth;
            Moon = moon;
            Duration = duration;
            DeltaY = deltaY;
        }

        public void rotation()
        {
            earth.rotation(earth.Duration, earth.DeltaY);
            moon.rotation(moon.Duration, moon.DeltaY);

        }

        
    }
}
