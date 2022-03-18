using Urho.Actions;
using Urho.Shapes;
using Urho;


namespace SolarSystem
{
    internal class Planete : Node
    { 
        public Planete ParentNode { get; set; }
        public Material PlanetMaterial { get; set; }
        public float Taille { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public Node Base { get; set; }
        public Node PlanetNode { get; set; }





        public Planete(Planete parentNode, Material planetMaterial, float taille, float positionX, float positionY, float positionZ)
        {
            ParentNode = parentNode;
            PlanetMaterial = planetMaterial;
            Taille = taille;
            X = positionX;
            Y = positionY;
            Z = positionZ;
            Init();
        }



        //definition de la base de la planete se basant sur le node d'un node pere
        public void InitBase()
        {
            Base = ParentNode.CreateChild();
            Base.SetScale(0.99f);
            Base.Position = new Vector3(0, 0, 0);

        }       

        //definition du node de la planete se basant sur la base de cette derniere
        public void Init()
        {
            InitBase();
            PlanetNode = Base.CreateChild();
            PlanetNode.SetScale(Taille);
            PlanetNode.Position = new Vector3(X, Y, Z);
            var planet = PlanetNode.CreateComponent<Sphere>();
            planet.SetMaterial(PlanetMaterial);

            //nouvelle initialisation de la base MARCHE PAS POUR L'INSTANT
            //Base planetBase = new Base(parentNode, planetMaterial);
        }

        public void Rotation(float vitesse, int axeX, int axeY, int axeZ)
        {
            PlanetNode.RunActions(new RepeatForever(new RotateBy(duration: vitesse, deltaAngleX: axeX, deltaAngleY: axeY, deltaAngleZ: axeZ)));
        }

        public void Revolution(float vitesse, int axeX, int axeY, int axeZ)
        {
            Base.RunActions(new RepeatForever(new RotateBy(duration: vitesse, deltaAngleX: axeX, deltaAngleY: axeY, deltaAngleZ: axeZ)));
        }
    }
}