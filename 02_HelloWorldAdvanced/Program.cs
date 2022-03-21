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
		Vector3 sunPosBeforManipulations;
		Material sunMaterial;
		float cloudsOffset;
		public SolarSystemApp(ApplicationOptions opts) : base(opts) { }

		protected override async void Start()
		{
			base.Start();

			EnableGestureManipulation = true;
			EnableGestureTapped = true;

			Log.LogLevel = LogLevel.Warning;
			Log.LogMessage += l => { Debug.WriteLine(l.Level + ":  " + l.Message); };

			// Create the star (the sun here)
			
			sunNode = Scene.CreateChild();
			sunNode.Position = new Vector3(0, 0.5f, 3f);
			sunNode.SetScale(0.8f);

			var sun = sunNode.CreateComponent<Sphere>();
			sunMaterial = ResourceCache.GetMaterial("Materials/Sun.xml");
			sun.SetMaterial(sunMaterial);

			sunNode.RunActions(new RepeatForever(new RotateBy(5, deltaAngleX: 0, deltaAngleY: 100, deltaAngleZ: 0)));


			DirectionalLight.Brightness = 0;
			DirectionalLight.Node.SetDirection(new Vector3(0, 0, 0));


			ResourcePack ressouce = new ResourcePack(sunNode, ResourceCache);


			//Pas présent dans la vidéo démo
			var skyboxNode = Scene.CreateChild();
				skyboxNode.SetScale(100);
				var skybox = skyboxNode.CreateComponent<Skybox>();
				skybox.Model = CoreAssets.Models.Box;
				skybox.SetMaterial(Material.SkyboxFromImage("Textures/Space.png"));			

		}

		protected override void OnUpdate(float timeStep)
		{
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
			/* Bout de code de test
			Node test;

			test = Scene.CreateChild();
			test.Position = new Vector3(1f, -1f, 6f);
			test.SetScale(0.8f);

			var nodetest = test.CreateComponent<Sphere>();
			sunMaterial = ResourceCache.GetMaterial("Materials/Sun.xml");
			nodetest.SetMaterial(sunMaterial);

			test.Remove();


			base.OnGestureTapped();
			*/
		}
	}
}

