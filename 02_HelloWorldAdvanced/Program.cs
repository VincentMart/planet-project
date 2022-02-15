using System;
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
			sunNode.Position = new Vector3(0, 0, 4f);
			sunNode.SetScale(0.5f);

			DirectionalLight.Brightness = 0;
			DirectionalLight.Node.SetDirection(new Vector3(0, 0, 0));            //-1, 0, 0.5f

			var sun = sunNode.CreateComponent<Sphere>();
			sunMaterial = ResourceCache.GetMaterial("Materials/Sun.xml");
			sun.SetMaterial(sunMaterial);

			var moonNode = sunNode.CreateChild();
			moonNode.SetScale(0.27f);
			moonNode.Position = new Vector3(1.2f, 0, 0);
			var moon = moonNode.CreateComponent<Sphere>();
			moon.SetMaterial(ResourceCache.GetMaterial("Materials/Moon.xml"));*/

			//Mercure
			var baseMercury = sunNode.CreateChild();
			baseMercury.SetScale(0.99f);
			baseMercury.Position = new Vector3(0, 0, 0);
			var baseM = baseMercury.CreateComponent<Sphere>();
			baseM.SetMaterial(ResourceCache.GetMaterial("Materials/Jupiter.xml"));

			var mercuryNode = baseMercury.CreateChild();
			mercuryNode.SetScale(0.5f);
			mercuryNode.Position = new Vector3(1.2f, 0, 0);
			var mercury = mercuryNode.CreateComponent<Sphere>();
			mercury.SetMaterial(ResourceCache.GetMaterial("Materials/Mercury.xml"));

			//Venus
			var baseVenus = sunNode.CreateChild();
			baseVenus.SetScale(0.99f);
			baseVenus.Position = new Vector3(0, 0, 0);
			var baseV = baseVenus.CreateComponent<Sphere>();
			baseV.SetMaterial(ResourceCache.GetMaterial("Materials/Jupiter.xml"));

			var venusNode = baseMercury.CreateChild();
			venusNode.SetScale(0.5f);
			venusNode.Position = new Vector3(1.5f, 0, 0);
			var venus = venusNode.CreateComponent<Sphere>();
			venus.SetMaterial(ResourceCache.GetMaterial("Materials/Mercury.xml"));

			//Jupiter
			var baseJupiter = sunNode.CreateChild();
			baseJupiter.SetScale(0.99f);
			baseJupiter.Position = new Vector3(0, 0, 0);
			var baseJ = baseJupiter.CreateComponent<Sphere>();
			baseJ.SetMaterial(ResourceCache.GetMaterial("Materials/Jupiter.xml"));

			var earthNode = sunNode.CreateChild();
			earthNode.SetScale(1f);
			earthNode.Position = new Vector3(2f, 0, 0);
			var earth = earthNode.CreateComponent<Sphere>();
			earth.SetMaterial(ResourceCache.GetMaterial("Materials/Jupiter.xml"));

			// HolographicDisplay api is available in >=10.0.15063
			// var display = Windows.Graphics.Holographic.HolographicDisplay.GetDefault();
			// bool isHoloLens = display != null && !display.IsOpaque;
			//Since the display is opaque - we can display a skybox with stars
			var skyboxNode = Scene.CreateChild();
				skyboxNode.SetScale(100);
				var skybox = skyboxNode.CreateComponent<Skybox>();
				skybox.Model = CoreAssets.Models.Box;
				//Skybox is usally a 6 textures joined together, see FeatureSamples/Core/23_Water sample
				skybox.SetMaterial(Material.SkyboxFromImage("Textures/Space.png"));
			

			// Run a few actions to spin the Earth, the Moon and the clouds.
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