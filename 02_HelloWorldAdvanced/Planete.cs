using Urho.Actions;
using Urho.Shapes;
using Urho;


namespace SolarSystem
{
    internal class Planete
    {
        private Node parentNode;
        private Material planetMaterial;

        public Planete(Node parentNode, Material planetMaterial, float taille, float position, float vitesse)
        {
            this.parentNode = parentNode;
            this.planetMaterial = planetMaterial;

            //definition de la base d'une planete se basant sur le node d'un node pere
            var basePlanet = parentNode.CreateChild();
            basePlanet.SetScale(0.99f);
            basePlanet.Position = new Vector3(0, 0, 0);
            var baseP = basePlanet.CreateComponent<Sphere>();
            baseP.SetMaterial(planetMaterial);

            //definition du node d'une planete se basant sur la base de cette derniere
            var planetNode = basePlanet.CreateChild();
            planetNode.SetScale(taille);
            planetNode.Position = new Vector3(position, 0, 0);
            var planet = planetNode.CreateComponent<Sphere>();
            planet.SetMaterial(planetMaterial);

            //definition des deplacements des planetes
            planetNode.RunActions(new RepeatForever(new RotateBy(duration: vitesse, deltaAngleX: 0, deltaAngleY: -4, deltaAngleZ: 0)));
        }
    }
}