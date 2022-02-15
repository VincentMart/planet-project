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

			//Mercure
			var baseMercury = sunNode.CreateChild();
			baseMercury.SetScale(0.99f);
			baseMercury.Position = new Vector3(0, 0, 0);
			var baseM = baseMercury.CreateComponent<Sphere>();
			baseM.SetMaterial(ResourceCache.GetMaterial("Materials/Mercury.xml"));

			var mercuryNode = baseMercury.CreateChild();
			mercuryNode.SetScale(0.2f);
			mercuryNode.Position = new Vector3(.8f, 0, 0);
			var mercury = mercuryNode.CreateComponent<Sphere>();
			mercury.SetMaterial(ResourceCache.GetMaterial("Materials/Mercury.xml"));

			//Venus
			var baseVenus = sunNode.CreateChild();
			baseVenus.SetScale(0.99f);
			baseVenus.Position = new Vector3(0, 0, 0);
			var baseV = baseVenus.CreateComponent<Sphere>();
			baseV.SetMaterial(ResourceCache.GetMaterial("Materials/Venus.xml"));

			var venusNode = baseVenus.CreateChild();
			venusNode.SetScale(0.25f);
			venusNode.Position = new Vector3(1.2f, 0, 0);
			var venus = venusNode.CreateComponent<Sphere>();
			venus.SetMaterial(ResourceCache.GetMaterial("Materials/Venus.xml"));

			//Earth
			var baseEarth = sunNode.CreateChild();
			baseEarth.SetScale(0.99f);
			baseEarth.Position = new Vector3(0, 0, 0);
			var baseE = baseEarth.CreateComponent<Sphere>();
			baseE.SetMaterial(ResourceCache.GetMaterial("Materials/Earth.xml"));

			var earthNode = baseEarth.CreateChild();
			earthNode.SetScale(0.28f);
			earthNode.Position = new Vector3(1.8f, 0, 0);
			var earth = earthNode.CreateComponent<Sphere>();
			earth.SetMaterial(ResourceCache.GetMaterial("Materials/Earth.xml"));

			//Moon
			var baseMoon = earthNode.CreateChild();
			baseMoon.SetScale(0.99f);
			baseMoon.Position = new Vector3(0, 0, 0);
			var baseMo = baseEarth.CreateComponent<Sphere>();
			baseMo.SetMaterial(ResourceCache.GetMaterial("Materials/Moon.xml"));

			var moonNode = baseMoon.CreateChild();
			moonNode.SetScale(0.28f);
			moonNode.Position = new Vector3(1f, 0, 0);
			var moon = moonNode.CreateComponent<Sphere>();
			moon.SetMaterial(ResourceCache.GetMaterial("Materials/Moon.xml"));

			//Mars
			var baseMars = sunNode.CreateChild();
			baseMars.SetScale(0.99f);
			baseMars.Position = new Vector3(0, 0, 0);
			var baseMa = baseMars.CreateComponent<Sphere>();
			baseMa.SetMaterial(ResourceCache.GetMaterial("Materials/Mars.xml"));

			var marsNode = baseMars.CreateChild();
			marsNode.SetScale(0.28f);
			marsNode.Position = new Vector3(2.4f, 0, 0);
			var mars = marsNode.CreateComponent<Sphere>();
			mars.SetMaterial(ResourceCache.GetMaterial("Materials/Mars.xml"));

			//Jupiter
			var baseJupiter = sunNode.CreateChild();
			baseJupiter.SetScale(0.99f);
			baseJupiter.Position = new Vector3(0, 0, 0);
			var baseJ = baseJupiter.CreateComponent<Sphere>();
			baseJ.SetMaterial(ResourceCache.GetMaterial("Materials/Jupiter.xml"));

			var jupiterNode = baseJupiter.CreateChild();
			jupiterNode.SetScale(0.5f);
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
			saturnNode.SetScale(0.28f);
			saturnNode.Position = new Vector3(3.6f, 0, 0);
			var saturn = saturnNode.CreateComponent<Sphere>();
			saturn.SetMaterial(ResourceCache.GetMaterial("Materials/Saturn.xml"));

			//Uranus
			var baseUranus = sunNode.CreateChild();
			baseUranus.SetScale(0.99f);
			baseUranus.Position = new Vector3(0, 0, 0);
			var baseU = baseUranus.CreateComponent<Sphere>();
			baseU.SetMaterial(ResourceCache.GetMaterial("Materials/Uranus.xml"));

			var uranusNode = baseUranus.CreateChild();
			uranusNode.SetScale(0.28f);
			uranusNode.Position = new Vector3(4.5f, 0, 0);
			var uranus = uranusNode.CreateComponent<Sphere>();
			uranus.SetMaterial(ResourceCache.GetMaterial("Materials/Uranus.xml"));

			//Neptune
			var baseNeptune = sunNode.CreateChild();
			baseNeptune.SetScale(0.99f);
			baseNeptune.Position = new Vector3(0, 0, 0);
			var baseN = baseNeptune.CreateComponent<Sphere>();
			baseN.SetMaterial(ResourceCache.GetMaterial("Materials/Neptune.xml"));

			var neptuneNode = baseNeptune.CreateChild();
			neptuneNode.SetScale(0.28f);
			neptuneNode.Position = new Vector3(6f, 0, 0);
			var neptune = neptuneNode.CreateComponent<Sphere>();
			neptune.SetMaterial(ResourceCache.GetMaterial("Materials/Neptune.xml"));


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

			mercuryNode.RunActions(new RepeatForever(new RotateBy(duration: 58.6f, deltaAngleX: 0, deltaAngleY: -720, deltaAngleZ: 0)));
			venusNode.RunActions(new RepeatForever(new RotateBy(duration: 243f, deltaAngleX: 0, deltaAngleY: -720, deltaAngleZ: 0)));
			earthNode.RunActions(new RepeatForever(new RotateBy(duration: 1f, deltaAngleX: 0, deltaAngleY: -720, deltaAngleZ: 0)));
			marsNode.RunActions(new RepeatForever(new RotateBy(duration: 25f/24, deltaAngleX: 0, deltaAngleY: -720, deltaAngleZ: 0)));
			jupiterNode.RunActions(new RepeatForever(new RotateBy(duration: 10f/24, deltaAngleX: 0, deltaAngleY: -720, deltaAngleZ: 0)));
			saturnNode.RunActions(new RepeatForever(new RotateBy(duration: 21f/48, deltaAngleX: 0, deltaAngleY: -720, deltaAngleZ: 0)));
			uranusNode.RunActions(new RepeatForever(new RotateBy(duration: 17f/24, deltaAngleX: 0, deltaAngleY: -720, deltaAngleZ: 0)));
			neptuneNode.RunActions(new RepeatForever(new RotateBy(duration: 0.671f, deltaAngleX: 0, deltaAngleY: -720, deltaAngleZ: 0)));



			baseMercury.RunActions(new RepeatForever(new RotateBy(duration: 88f/365, deltaAngleX: 0, deltaAngleY: -2, deltaAngleZ: 0)));
			baseVenus.RunActions(new RepeatForever(new RotateBy(duration: 225f/365, deltaAngleX: 0, deltaAngleY: -2, deltaAngleZ: 0)));
			baseEarth.RunActions(new RepeatForever(new RotateBy(duration: 1f, deltaAngleX: 0, deltaAngleY: -2, deltaAngleZ: 0))); // 180 s == 1 année
			baseMars.RunActions(new RepeatForever(new RotateBy(duration: 687f/365, deltaAngleX: 0, deltaAngleY: -2, deltaAngleZ: 0))); 
			baseJupiter.RunActions(new RepeatForever(new RotateBy(duration: 4300f/365, deltaAngleX: 0, deltaAngleY: -2, deltaAngleZ: 0)));
			baseSaturn.RunActions(new RepeatForever(new RotateBy(duration: 10759f/365, deltaAngleX: 0, deltaAngleY: -2, deltaAngleZ: 0)));
			baseUranus.RunActions(new RepeatForever(new RotateBy(duration: 30660f/365, deltaAngleX: 0, deltaAngleY: -2, deltaAngleZ: 0)));
			baseNeptune.RunActions(new RepeatForever(new RotateBy(duration: 60225f/365, deltaAngleX: 0, deltaAngleY: -2, deltaAngleZ: 0)));
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