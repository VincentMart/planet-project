﻿using System;
using System.Diagnostics;
using Windows.ApplicationModel.Core;
using Urho;
using Urho.Actions;
using Urho.SharpReality;
using Urho.Shapes;
using Urho.Resources;

namespace _07_HelloWorldWithCustomShaders
{
	/// <summary>
	/// Windows Holographic application using SharpDX.
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// Defines the entry point of the application.
		/// </summary>
		[MTAThread]
		static void Main() => CoreApplication.Run(new UrhoAppViewSource<HelloWorldApplication>(new ApplicationOptions("Data")));
	}

	public class HelloWorldApplication : StereoApplication
	{
		Node sunNode;
		Vector3 sunPosBeforManipulations;
		Vector3 earthPosBeforManipulations;
		Material sunMaterial;
		float cloudsOffset;

		public HelloWorldApplication(ApplicationOptions opts) : base(opts) { }

		protected override async void Start()
		{
			base.Start();

			EnableGestureManipulation = true;
			EnableGestureTapped = true;

			Log.LogLevel = LogLevel.Warning;
			Log.LogMessage += l => { Debug.WriteLine(l.Level + ":  " + l.Message); };

			// Create a node for the Sun
			sunNode = Scene.CreateChild();
			sunNode.Position = new Vector3(0, 0, 8f);
			sunNode.SetScale(0.8f);

			DirectionalLight.Brightness = 0;
			DirectionalLight.Node.SetDirection(new Vector3(0, 0, 0));            //-1, 0, 0.5f

			var sun = sunNode.CreateComponent<Sphere>();
			sunMaterial = ResourceCache.GetMaterial("Materials/Sun.xml");
			sun.SetMaterial(sunMaterial);

			//Mercure
			var baseMercury = sunNode.CreateChild();
			baseMercury.SetScale(0.99f);
			baseMercury.Position = new Vector3(0, 0, 0);
			var baseM = baseMercury.CreateComponent<Sphere>();
			baseM.SetMaterial(ResourceCache.GetMaterial("Materials/Mercury.xml"));

			var mercuryNode = baseMercury.CreateChild();
			mercuryNode.SetScale(0.25f);
			mercuryNode.Position = new Vector3(.9f, 0, 0);
			var mercury = mercuryNode.CreateComponent<Sphere>();
			mercury.SetMaterial(ResourceCache.GetMaterial("Materials/Mercury.xml"));

			//Venus
			var baseVenus = sunNode.CreateChild();
			baseVenus.SetScale(0.99f);
			baseVenus.Position = new Vector3(0, 0, 0);
			var baseV = baseVenus.CreateComponent<Sphere>();
			baseV.SetMaterial(ResourceCache.GetMaterial("Materials/Venus.xml"));

			var venusNode = baseVenus.CreateChild();
			venusNode.SetScale(0.32f);
			venusNode.Position = new Vector3(1.3f, 0, 0);
			var venus = venusNode.CreateComponent<Sphere>();
			venus.SetMaterial(ResourceCache.GetMaterial("Materials/Venus.xml"));

			//Earth
			var baseEarth = sunNode.CreateChild();
			baseEarth.SetScale(0.99f);
			baseEarth.Position = new Vector3(0, 0, 0);
			var baseE = baseEarth.CreateComponent<Sphere>();
			baseE.SetMaterial(ResourceCache.GetMaterial("Materials/Earth.xml"));

			var earthNode = baseEarth.CreateChild();
			earthNode.SetScale(0.35f);
			earthNode.Position = new Vector3(1.7f, 0, 0);
			var earth = earthNode.CreateComponent<Sphere>();
			earth.SetMaterial(ResourceCache.GetMaterial("Materials/Earth.xml"));

			//Mars
			var baseMars = sunNode.CreateChild();
			baseMars.SetScale(0.99f);
			baseMars.Position = new Vector3(0, 0, 0);
			var baseMa = baseMars.CreateComponent<Sphere>();
			baseMa.SetMaterial(ResourceCache.GetMaterial("Materials/Mars.xml"));

			var marsNode = baseMars.CreateChild();
			marsNode.SetScale(0.29f);
			marsNode.Position = new Vector3(2.2f, 0, 0);
			var mars = marsNode.CreateComponent<Sphere>();
			mars.SetMaterial(ResourceCache.GetMaterial("Materials/Mars.xml"));

			//Jupiter
			var baseJupiter = sunNode.CreateChild();
			baseJupiter.SetScale(0.99f);
			baseJupiter.Position = new Vector3(0, 0, 0);
			var baseJ = baseJupiter.CreateComponent<Sphere>();
			baseJ.SetMaterial(ResourceCache.GetMaterial("Materials/Jupiter.xml"));

			var jupiterNode = baseJupiter.CreateChild();
			jupiterNode.SetScale(.55f);
			jupiterNode.Position = new Vector3(3f, 0, 0);
			var jupiter = jupiterNode.CreateComponent<Sphere>();
			jupiter.SetMaterial(ResourceCache.GetMaterial("Materials/Jupiter.xml"));

			//Saturn
			var baseSaturn = sunNode.CreateChild();
			baseSaturn.SetScale(0.99f);
			baseSaturn.Position = new Vector3(0, 0, 0);
			var baseS = baseSaturn.CreateComponent<Sphere>();
			baseS.SetMaterial(ResourceCache.GetMaterial("Materials/Saturn.xml"));

			var saturnNode = baseSaturn.CreateChild();
			saturnNode.SetScale(.50f);
			saturnNode.Position = new Vector3(4f, 0, 0);
			var saturn = saturnNode.CreateComponent<Sphere>();
			saturn.SetMaterial(ResourceCache.GetMaterial("Materials/Saturn.xml"));

			//Uranus
			var baseUranus = sunNode.CreateChild();
			baseUranus.SetScale(0.99f);
			baseUranus.Position = new Vector3(0, 0, 0);
			var baseU = baseUranus.CreateComponent<Sphere>();
			baseU.SetMaterial(ResourceCache.GetMaterial("Materials/Uranus.xml"));

			var uranusNode = baseUranus.CreateChild();
			uranusNode.SetScale(.4f);
			uranusNode.Position = new Vector3(5f, 0, 0);
			var uranus = uranusNode.CreateComponent<Sphere>();
			uranus.SetMaterial(ResourceCache.GetMaterial("Materials/Uranus.xml"));

			//Neptune
			var baseNeptune = sunNode.CreateChild();
			baseNeptune.SetScale(0.99f);
			baseNeptune.Position = new Vector3(0, 0, 0);
			var baseN = baseNeptune.CreateComponent<Sphere>();
			baseN.SetMaterial(ResourceCache.GetMaterial("Materials/Neptune.xml"));

			var neptuneNode = baseNeptune.CreateChild();
			neptuneNode.SetScale(.4f);
			neptuneNode.Position = new Vector3(6f, 0, 0);
			var neptune = neptuneNode.CreateComponent<Sphere>();
			neptune.SetMaterial(ResourceCache.GetMaterial("Materials/Neptune.xml"));


			var skyboxNode = Scene.CreateChild();
				skyboxNode.SetScale(100);
				var skybox = skyboxNode.CreateComponent<Skybox>();
				skybox.Model = CoreAssets.Models.Box;
				//Skybox is usally a 6 textures joined together, see FeatureSamples/Core/23_Water sample
				skybox.SetMaterial(Material.SkyboxFromImage("Textures/Space.png"));
			

			sunNode.RunActions(new RepeatForever(new RotateBy(duration: 1f, deltaAngleX: 0, deltaAngleY: -4, deltaAngleZ: 0)));
		}

		protected override void OnUpdate(float timeStep)
		{
			// Move clouds via CloudsOffset (defined in the material.xml and used in the PS)
			cloudsOffset += 0.00005f;
			sunMaterial.SetShaderParameter("CloudsOffset", new Vector2(cloudsOffset, 0));      
																							   //NOTE: this could be done via SetShaderParameterAnimation
		}

		// For HL optical stabilization (optional)
		public override Vector3 FocusWorldPoint => sunNode.WorldPosition;

		public override void OnGestureManipulationStarted()
		{
			sunPosBeforManipulations = sunNode.Position;
		}

		public override void OnGestureManipulationUpdated(Vector3 relativeHandPosition)
		{
			sunNode.Position = relativeHandPosition + sunPosBeforManipulations;
		}

		public override void OnGestureDoubleTapped()
		{
			sunNode.Scale *= 1.2f;
		}
	}
}