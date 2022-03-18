using System.Diagnostics;
using Windows.ApplicationModel.Core;
using Urho;
using Urho.Actions;
using Urho.SharpReality;
using Urho.Shapes;
using Urho.Resources;
using System;
using Urho.Gui;

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
		static void Main() => CoreApplication.Run(new UrhoAppViewSource<SolarSystemApp>(new ApplicationOptions("Data")));
	}

	public class SolarSystemApp : StereoApplication
	{
		Node sunNode;
		Node bucketNode;
		Node textNode;
		Vector3 sunPosBeforManipulations;
		Material sunMaterial;
		float cloudsOffset;
		ApplicationOptions opts;
		public SolarSystemApp(ApplicationOptions opts) : base(opts) { }

		protected override async void Start()
		{
			base.Start();

			EnableGestureManipulation = true;
			EnableGestureTapped = true;

			Log.LogLevel = LogLevel.Warning;
			Log.LogMessage += l => { Debug.WriteLine(l.Level + ":  " + l.Message); };

			// Create a node for the text
			bucketNode = Scene.CreateChild();
			bucketNode.SetScale(0.1f);

			// Implement a text test
			textNode = bucketNode.CreateChild();
			var text3D = textNode.CreateComponent<Text3D>();
			text3D.HorizontalAlignment = HorizontalAlignment.Center;
			text3D.VerticalAlignment = VerticalAlignment.Center;
			text3D.ViewMask = 0x80000000; //magie noire
			text3D.Text = "Ceci est un\n TEST";
			text3D.SetFont(CoreAssets.Fonts.AnonymousPro, 26);
			text3D.SetColor(Color.Cyan);
			textNode.Translate(new Vector3(0, 3f, -0.5f));


			// Create a node for the Sun
			sunNode = Scene.CreateChild();
			sunNode.Position = new Vector3(0, 0, 8f);
			sunNode.SetScale(0.8f);

			DirectionalLight.Brightness = 0;
			DirectionalLight.Node.SetDirection(new Vector3(0, 0, 0));

			var sun = sunNode.CreateComponent<Sphere>();
			sunMaterial = ResourceCache.GetMaterial("Materials/Sun.xml");
			sun.SetMaterial(sunMaterial);



			//Nouvelle declaration de planete via classe avec methodes

			ResourcePack ressouce = new ResourcePack(Scene, ResourceCache);

			/*


			var skyboxNode = Scene.CreateChild();
				skyboxNode.SetScale(100);
				var skybox = skyboxNode.CreateComponent<Skybox>();
				skybox.Model = CoreAssets.Models.Box;
				//Skybox is usally a 6 textures joined together, see FeatureSamples/Core/23_Water sample
				skybox.SetMaterial(Material.SkyboxFromImage("Textures/Space.png"));			

			sunNode.RunActions(new RepeatForever(new RotateBy(duration: 20f, deltaAngleX: 0, deltaAngleY: -80, deltaAngleZ: 0)));
			*/
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
			test.Position = new Vector3(1f, -1f, 6f);
			test.SetScale(0.8f);

			var nodetest = test.CreateComponent<Sphere>();
			sunMaterial = ResourceCache.GetMaterial("Materials/Sun.xml");
			nodetest.SetMaterial(sunMaterial);

			test.Remove();


			base.OnGestureTapped();
		}
	}
}

/*
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
*/