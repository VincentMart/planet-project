
using System.Diagnostics;
using Windows.ApplicationModel.Core;
using Urho;
using Urho.Actions;
using Urho.SharpReality;
using Urho.Shapes;
using Urho.Resources;
using System;

namespace SolarSystem
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
			DirectionalLight.Node.SetDirection(new Vector3(0, 0, 0));

			var sun = sunNode.CreateComponent<Sphere>();
			sunMaterial = ResourceCache.GetMaterial("Materials/Sun.xml");
			sun.SetMaterial(sunMaterial);

			//Nouvelle planete via classe
			Material mercuryMaterial = ResourceCache.GetMaterial("Materials/Mercury.xml");
			Planete MercureV2 = new Planete(sunNode, mercuryMaterial, 0.9f, 0f, 0f, 15f, 10f, 100f);

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
			

			sunNode.RunActions(new RepeatForever(new RotateBy(duration: 20f, deltaAngleX: 0, deltaAngleY: -80, deltaAngleZ: 0)));

			mercuryNode.RunActions(new RepeatForever(new RotateBy(duration: 10f, deltaAngleX: 0, deltaAngleY: 72, deltaAngleZ: 0)));
			venusNode.RunActions(new RepeatForever(new RotateBy(duration: 10f, deltaAngleX: 0, deltaAngleY: 82, deltaAngleZ: 0)));
			earthNode.RunActions(new RepeatForever(new RotateBy(duration: 10f, deltaAngleX: 0, deltaAngleY: -406, deltaAngleZ: 0)));
			marsNode.RunActions(new RepeatForever(new RotateBy(duration: 10f, deltaAngleX: 0, deltaAngleY: -394, deltaAngleZ: 0)));
			jupiterNode.RunActions(new RepeatForever(new RotateBy(duration: 10f, deltaAngleX: 0, deltaAngleY: -1098, deltaAngleZ: 0)));
			saturnNode.RunActions(new RepeatForever(new RotateBy(duration: 10f, deltaAngleX: 0, deltaAngleY: -1014, deltaAngleZ: 0)));
			uranusNode.RunActions(new RepeatForever(new RotateBy(duration: 10f, deltaAngleX: -676, deltaAngleY: 80, deltaAngleZ: 0)));
			neptuneNode.RunActions(new RepeatForever(new RotateBy(duration: 10f, deltaAngleX: 0, deltaAngleY: -648, deltaAngleZ: 0)));


			baseMercury.RunActions(new RepeatForever(new RotateBy(duration: 20f, deltaAngleX: 0, deltaAngleY: -920, deltaAngleZ: 0)));
			baseVenus.RunActions(new RepeatForever(new RotateBy(duration: 20f, deltaAngleX: 0, deltaAngleY: -280, deltaAngleZ: 0)));
			baseEarth.RunActions(new RepeatForever(new RotateBy(duration: 20f, deltaAngleX: 0, deltaAngleY: -160, deltaAngleZ: 0)));
			baseMars.RunActions(new RepeatForever(new RotateBy(duration: 20f, deltaAngleX: 0, deltaAngleY: -48, deltaAngleZ: 0)));
			baseJupiter.RunActions(new RepeatForever(new RotateBy(duration: 20f, deltaAngleX: 0, deltaAngleY: 60, deltaAngleZ: 0)));
			baseSaturn.RunActions(new RepeatForever(new RotateBy(duration: 20f, deltaAngleX: 0, deltaAngleY: 72, deltaAngleZ: 0)));
			baseUranus.RunActions(new RepeatForever(new RotateBy(duration: 20f, deltaAngleX: 0, deltaAngleY: 77, deltaAngleZ: 0)));
			baseNeptune.RunActions(new RepeatForever(new RotateBy(duration: 20f, deltaAngleX: 0, deltaAngleY: 79, deltaAngleZ: 0)));
		}

		protected override void OnUpdate(float timeStep)
		{
			// Move clouds via CloudsOffset (defined in the material.xml and used in the PS)
			cloudsOffset += 0.00005f;
			sunMaterial.SetShaderParameter("CloudsOffset", new Vector2(cloudsOffset, 0));
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

		/*public void GestionPlanete(Node node)												//
		{																					//
			Sphere newnode = node.CreateComponent<Sphere>();								//
			newnode.SetScale(0.8f);															//	Test
			sunMaterial = ResourceCache.GetMaterial("Materials/Sun.xml");					//
			sun.SetMaterial(sunMaterial);													//
		}*/																					//

		public override void OnGestureDoubleTapped()
		{
			sunNode.Scale *= 1.2f;
		}

		public override void OnGestureTapped()
		{
			//Nouvelle planete via classe
			Node test;

			test = Scene.CreateChild();
			test.Position = new Vector3(0, 0, 6f);
			test.SetScale(0.8f);

			var nodetest = test.CreateComponent<Sphere>();
			sunMaterial = ResourceCache.GetMaterial("Materials/Sun.xml");
			nodetest.SetMaterial(sunMaterial);


			base.OnGestureTapped();
		}
	}
}