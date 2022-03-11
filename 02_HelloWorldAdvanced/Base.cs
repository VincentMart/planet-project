using System.Diagnostics;
using Windows.ApplicationModel.Core;
using Urho;
using Urho.Actions;
using Urho.SharpReality;
using Urho.Shapes;
using Urho.Resources;
using System;

namespace SolarSystem
{
    internal class Base
    {
        Node parentNode;
        Material planetMaterial;

        public Base(Node planetNode)
        {
            this.parentNode = parentNode;
            planetMaterial = RessourceCache.GetMaterial("Materials/Sun.xml");

            var basePlanet = parentNode.CreateChild();
            basePlanet.SetScale(0.99f);
            basePlanet.Position = new Vector3(0, 0, 0);
            var baseP = basePlanet.CreateComponent<Sphere>();
            baseP.SetMaterial(planetMaterial);
        } 
    }
}
