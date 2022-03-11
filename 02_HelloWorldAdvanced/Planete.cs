using Urho.Actions;
using Urho.Shapes;
using Urho;


namespace SolarSystem
{
    internal class Planete
    {
        private Node parentNode;
        private Material planetMaterial;
        private Node planetNode;

        public Planete(Node parentNode, Material planetMaterial, float taille)
        {
            this.parentNode = parentNode;
            this.planetMaterial = planetMaterial;

            //nouvelle initialisation de la base
            Base planetBase = new Base(parentNode, planetMaterial);
            //definition de la base d'une planete se basant sur le node d'un node pere
            var basePlanet = parentNode.CreateChild();
            basePlanet.SetScale(0.99f);
            basePlanet.Position = new Vector3(0, 0, 0);
            var baseP = basePlanet.CreateComponent<Sphere>();
            baseP.SetMaterial(planetMaterial);

            //definition du node d'une planete se basant sur la base de cette derniere
            var planetNode = basePlanet.CreateChild();
            planetNode.SetScale(10f);
            planetNode.Position = new Vector3(5f, 0, 0);
            var planet = planetNode.CreateComponent<Sphere>();
            planet.SetMaterial(planetMaterial);
        }

        public void Mouvement(float vitesse, int axeX, int axeY, int axeZ)
        {
            planetNode.RunActions(new RepeatForever(new RotateBy(duration: vitesse, deltaAngleX: axeX, deltaAngleY: axeY, deltaAngleZ: axeZ)));
        }
    }
}