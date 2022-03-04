using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urho;
using Urho.Gui;
using Urho.SharpReality;

namespace _07_HelloWorldWithCustomShaders.Model
{
    public class AnimatingScene
    {
        Scene scene;

        void CreateScene()
        {
            scene = new Scene();
            scene.CreateComponent<Octree>();

            var zoneNode = scene.CreateChild("Zone");
            var zone = zoneNode.CreateComponent<Zone>();
            zone.SetBoundingBox(new BoundingBox(-1000.0f, 1000.0f));
            zone.AmbientColor = new Color(0.05f, 0.1f, 0.15f);
            zone.FogColor = new Color(0.1f, 0.2f, 0.3f);
            zone.FogStart = 10;
            zone.FogEnd = 100;
        }

    }
}
