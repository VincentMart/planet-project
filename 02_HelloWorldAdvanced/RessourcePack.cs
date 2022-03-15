using System;
using Urho;
using Urho.Resources;

namespace SolarSystem
{
    internal class RessourcePack
    {
        public RessourcePack(Node sunNode, ResourceCache cache) 
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

            Planete Mercure = new Planete(sunNode, planetMaterial: mercuryMaterial, taille: 0.25f, positionX: .9f, positionY: 0f, positionZ: 0f, vitesse: 20f, revolution: -920);
            Planete Venus = new Planete(sunNode, planetMaterial: venusMaterial, taille: 0.32f, positionX: 1.3f, positionY: 0f, positionZ: 0f, vitesse: 20f, revolution: -280);
            Planete Earth = new Planete(sunNode, planetMaterial: earthMaterial, taille: 0.35f, positionX: 1.7f, positionY: 0f, positionZ: 0f, vitesse: 20f, revolution: -160);
            Planete Mars = new Planete(sunNode, planetMaterial: marsMaterial, taille: 0.29f, positionX: 2.2f, positionY: 0f, positionZ: 0f, vitesse: 20f, revolution: -48);
            Planete Jupiter = new Planete(sunNode, planetMaterial: jupiterMaterial, taille: 0.55f, positionX: 3f, positionY: 0f, positionZ: 0f, vitesse: 20f, revolution: 60);
            Planete Saturn = new Planete(sunNode, planetMaterial: saturnMaterial, taille: 0.5f, positionX: 4f, positionY: 0f, positionZ: 0f, vitesse: 20f, revolution: 72);
            Planete Uranus = new Planete(sunNode, planetMaterial: uranusMaterial, taille: 0.4f, positionX: 5.3f, positionY: 0f, positionZ: 0f, vitesse: 20f, revolution: 77);
            Planete Neptune = new Planete(sunNode, planetMaterial: neptuneMaterial, taille: 0.4f, positionX: 6.8f, positionY: 0f, positionZ: 0f, vitesse: 20f, revolution: 79);

            Mercure.Mouvement(10f, 0, 72, 0);
            Venus.Mouvement(10f, 0, 82, 0);
            Earth.Mouvement(10f, 0, -406, 0);
            Mars.Mouvement(10f, 0, -394, 0);
            Jupiter.Mouvement(10f, 0, -1098, 0);
            Saturn.Mouvement(10f, 0, -1014, 0);
            Uranus.Mouvement(10f, -676, 80, 0);
            Neptune.Mouvement(10f, 0, -648, 0);
        }
    }
}
