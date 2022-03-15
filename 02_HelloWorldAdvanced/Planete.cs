using Urho.Actions;
using Urho.Shapes;
using Urho;


namespace SolarSystem
{
    internal class Planete
    { 
        public Node ParentNode { get; set; }
        public Material PlanetMaterial { get; set; }
        public float Taille { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Vitesse { get; set; }
        public float Revolution { get; set; }
        public Node Base { get; set; }
        public Node PlanetNode { get; set; }





        public Planete(Node parentNode, Material planetMaterial, float taille, float positionX, float positionY, float positionZ
            , float vitesse, float revolution)
        {
            ParentNode = parentNode;
            PlanetMaterial = planetMaterial;
            Taille = taille;
            X = positionX;
            Y = positionY;
            Z = positionZ;
            Vitesse = vitesse;
            Revolution = revolution;
            Init();
        }


        //definition de la base de la planete se basant sur le node d'un node pere
        public void InitBase()
        {
            Base = ParentNode.CreateChild();
            Base.SetScale(0.99f);
            Base.Position = new Vector3(0, 0, 0);

        }

        //definition des deplacements des planetes
        public void Rotations()
        {
            PlanetNode.RunActions(new RepeatForever(new RotateBy(duration: Vitesse, deltaAngleX: 0, deltaAngleY: -4, deltaAngleZ: 0)));
            Base.RunActions(new RepeatForever(new RotateBy(duration: Revolution, deltaAngleX: 0, deltaAngleY: -4, deltaAngleZ: 0)));
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
            Rotations();

            //nouvelle initialisation de la base MARCHE PAS POUR L'INSTANT
            //Base planetBase = new Base(parentNode, planetMaterial);
        }

        public void Mouvement(float vitesse, int axeX, int axeY, int axeZ)
        {
            PlanetNode.RunActions(new RepeatForever(new RotateBy(duration: vitesse, deltaAngleX: axeX, deltaAngleY: axeY, deltaAngleZ: axeZ)));
        }
    }
}