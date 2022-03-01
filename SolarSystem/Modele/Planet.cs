using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urho;
using Urho.Actions;

namespace _07_HelloWorldWithCustomShaders.Modele
{
    class Planet : Node
    {
        private float scale;
        private Vector3 vector;
        private float duration, deltaY;
        private Node reference;

        public float Scale { get; set; }
        public Vector3 Vector { get; set; }
        public float Duration { get; set; }
        public float DeltaY { get; set; }
        public Node Reference { get; set; }


        
        public Planet(float scale, float x, float y, float z, float duration, float deltaY)
        {
            Scale = scale;
            Vector = new Vector3(x, y, z);
            Duration = duration;
            DeltaY = deltaY;
        }

        public void rotation(float duration, float deltaY)
        {
            this.RunActions(new RepeatForever(new RotateBy(duration, deltaY)));
        }




    }
}
