using Urho;
using Urho.Shapes;

namespace SolarSystem
{
    internal class Base
    {
        private Node baseNode;
        private Material baseMaterial;

        public Base(Node baseNode, Material baseMaterial)
        {
            this.baseNode = baseNode;
            this.baseMaterial = baseMaterial;

            var basePlanet = baseNode.CreateChild();
            basePlanet.SetScale(0.99f);
            basePlanet.Position = new Vector3(0, 0, 0);
            var baseP = basePlanet.CreateComponent<Sphere>();
            baseP.SetMaterial(baseMaterial);
        }
    }
}
