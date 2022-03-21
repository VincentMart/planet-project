using Urho.Actions;
using Urho.Shapes;
using Urho;
using Urho.Gui;

namespace SolarSystem
{
    internal class Planete : Node
    { 
        public Node ParentNode { get; set; }
        public Material PlanetMaterial { get; set; }
        public float Taille { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public Node Base { get; set; }
        public Node PlanetNode { get; set; }
        public Node TexteNode { get; set; }
        public string PlanetName { get; set; }
        //Node nécessaire pour le texte: une sorte de PlanetNode auquel on n'applique pas de rotation
        public Node ExtraNode { get; set; }







        public Planete(Node parentNode, Material planetMaterial, float taille, float positionX, float positionY, float positionZ, string planetName)
        {
            ParentNode = parentNode;
            PlanetMaterial = planetMaterial;
            Taille = taille;
            X = positionX;
            Y = positionY;
            Z = positionZ;
            PlanetName = planetName;
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
        public virtual void Init()
        {
            InitBase();
            PlanetNode = Base.CreateChild();
            PlanetNode.SetScale(Taille);
            PlanetNode.Position = new Vector3(X, Y, Z);
            ExtraNode = Base.CreateChild();
            ExtraNode.SetScale(Taille);
            ExtraNode.Position = new Vector3(X, Y, Z);
            var planet = PlanetNode.CreateComponent<Sphere>();
            planet.SetMaterial(PlanetMaterial);

            TexteNode = ExtraNode.CreateChild();
            var text3D = TexteNode.CreateComponent<Text3D>();
            text3D.HorizontalAlignment = HorizontalAlignment.Center;
            text3D.VerticalAlignment = VerticalAlignment.Center;
            text3D.ViewMask = 0x80000000; //magie noire
            text3D.Text = PlanetName;
            text3D.SetFont(CoreAssets.Fonts.AnonymousPro, 30);
            text3D.SetColor(Color.White);
            TexteNode.Translate(new Vector3(0, 1f, 0));


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