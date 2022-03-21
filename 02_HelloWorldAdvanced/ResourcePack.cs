using System;
using Urho;
using Urho.Resources;

namespace SolarSystem
{
    internal class ResourcePack
    {
        public ResourcePack(Node parentNode, ResourceCache cache) 
        {
            //Création de toutes les planètes
            Material mercuryMaterial = cache.GetMaterial("Materials/Mercury.xml");
            Material venusMaterial = cache.GetMaterial("Materials/Venus.xml");
            Material earthMaterial = cache.GetMaterial("Materials/Earth.xml");
            Material marsMaterial = cache.GetMaterial("Materials/Mars.xml");
            Material jupiterMaterial = cache.GetMaterial("Materials/Jupiter.xml");
            Material saturnMaterial = cache.GetMaterial("Materials/Saturn.xml");
            Material uranusMaterial = cache.GetMaterial("Materials/Uranus.xml");
            Material neptuneMaterial = cache.GetMaterial("Materials/Neptune.xml");

            Planete Mercure = new Planete(parentNode, planetMaterial: mercuryMaterial, taille: 0.25f, positionX: 0.9f, positionY: 0f, positionZ: 1f, "Mercure");
            Planete Venus = new Planete(parentNode, planetMaterial: venusMaterial, taille: 0.32f, positionX: 1.3f, positionY: 0f, positionZ: 3f, "Venus");
            Planete Earth = new Planete(parentNode, planetMaterial: earthMaterial, taille: 0.35f, positionX: 1.7f, positionY: 0f, positionZ: 8f, "Terre");
            Planete Mars = new Planete(parentNode, planetMaterial: marsMaterial, taille: 0.29f, positionX: 2.2f, positionY: 0f, positionZ: -3f, "Mars");
            Planete Jupiter = new Planete(parentNode, planetMaterial: jupiterMaterial, taille: 0.55f, positionX: 3, positionY: 0f, positionZ: 6f, "Jupiter");
            Planete Saturn = new Planete(parentNode, planetMaterial: saturnMaterial, taille: 0.5f, positionX: -3.5f, positionY: 0f, positionZ: -4f, "Saturne");
            Planete Uranus = new Planete(parentNode, planetMaterial: uranusMaterial, taille: 0.4f, positionX: -4f, positionY: 0f, positionZ: -1f, "Uranus");
            Planete Neptune = new Planete(parentNode, planetMaterial: neptuneMaterial, taille: 0.4f, positionX: 4.5f, positionY: 0f, positionZ: -9f, "Neptune");



            Mercure.Rotation(5f, 0, 72, 0);
            Venus.Rotation(15f, 0, 82, 0);
            Earth.Rotation(7f, 0, -406, 0);
            Mars.Rotation(7f, 0, -394, 0);
            Jupiter.Rotation(20f, 0, -1098, 0);
            Saturn.Rotation(20f, 0, -1014, 0);
            Uranus.Rotation(25f, -676, 80, 0);
            Neptune.Rotation(25f, 0, -648, 0);

            Mercure.Revolution(5f, 0, -920, 0);
            Venus.Revolution(10f, 0, -280, 0);
            Earth.Revolution(12f, 0, -160, 0);
            Mars.Revolution(24f, 0, -48, 0);
            Jupiter.Revolution(35f, 0, -60, 0);
            Saturn.Revolution(47f, 0, -72, 0);
            Uranus.Revolution(59f, 0, -77, 0);
            Neptune.Revolution(71f, 0, -79, 0);
        }
    }
}
