using System;
using Microsoft.Xna.Framework.Input.Touch;
using TouchScreenBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using ResolutionBuddy;
using MenuBuddy;
using BasicPrimitiveBuddy;

namespace MenuBuddySample
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Game
	{
		#region Properties

		GraphicsDeviceManager graphics;
		private ScreenManager _ScreenManager;

		#endregion //Properties

		#region Methods

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft;
			Resolution.Init(ref graphics);
			Content.RootDirectory = "Content";

			//create the touch manager component
			var touches = new TouchManager(this, Resolution.ScreenToGameCoord);

			//add the input helper for menus
			//var input = new TouchInputHelper(this);
			var input = new ControllerInputHelper(this);

			var gameStyle = new StyleSheet();
			gameStyle.HasOutline = true;
			var styles = new DefaultStyles(this, gameStyle);

			styles.MenuTitleFontName = @"ArialBlack72";
			styles.MenuEntryFontName = @"ArialBlack48";
			styles.MessageBoxFontName = @"ArialBlack24";
			styles.MenuSelectSoundName = @"MenuSelect";
			styles.MenuChangeSoundName = @"MenuMove";
			styles.MessageBoxBackground = @"gradient";
			styles.ButtonBackground = @"AlphaGradient";

			// Create the screen manager component.
			_ScreenManager = new ScreenManager(this, GetMainMenuScreenStack);
			_ScreenManager.ClearColor = new Color(0.1f, 0.5f, 0.1f);

			// Activate the first screens.
			_ScreenManager.AddScreen(GetMainMenuScreenStack(), null);
			_ScreenManager.SetTopScreen(new TopScreen(), null);
		}

		/// <summary>
		/// Get the set of screens needed for the main menu
		/// </summary>
		/// <returns>The gameplay screen stack.</returns>
		public IScreen[] GetMainMenuScreenStack()
		{
			return new IScreen[] { new BackgroundScreen(), new MainMenuScreen() };
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// Change Virtual Resolution
			Resolution.SetDesiredResolution(1280, 720);

			//set the desired resolution
			Resolution.SetScreenResolution(1280, 720, false);

			// TODO: Add your initialization logic here
			base.Initialize();
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
			{
				Exit();
			}

			// TODO: Add your update logic here
			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			// Clear to Black
			graphics.GraphicsDevice.Clear(_ScreenManager.ClearColor);

			// Calculate Proper Viewport according to Aspect Ratio
			Resolution.ResetViewport();

			// The real drawing happens inside the screen manager component.
			base.Draw(gameTime);
		}

		#endregion //Methods
	}
}

