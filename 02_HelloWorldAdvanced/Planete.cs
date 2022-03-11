﻿using Urho.Actions;
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

<<<<<<< HEAD

        public Planete(Node parentNode, Material planetMaterial, float taille, float positionX, float positionY, float positionZ
            , float vitesse, float revolution)
=======
        public Planete(Node parentNode, Material planetMaterial)
>>>>>>> 01796109407dacfba9efcf71738d774e8ebfa2f1
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

<<<<<<< HEAD
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
=======
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
>>>>>>> 01796109407dacfba9efcf71738d774e8ebfa2f1
        }
    }
}