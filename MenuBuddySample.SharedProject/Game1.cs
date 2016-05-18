using InputHelper;
using MenuBuddy;
using Microsoft.Xna.Framework;

namespace MenuBuddySample
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	//public class Game1 : ControllerGame

#if __IOS__ || ANDROID || WINDOWS_UAP
	public class Game1 : TouchGame
#else
	public class Game1 : MouseGame
#endif
	{
#region Methods

		public Game1()
		{
			//FullScreen = true;

			var debug = new DebugInputComponent(this, ResolutionBuddy.Resolution.TransformationMatrix);
		}

		protected override void LoadContent()
		{
			base.LoadContent();
		}

		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void InitStyles()
		{
			base.InitStyles();
			//DefaultStyles.Instance().MainStyle.HasOutline = true;
			//DefaultStyles.Instance().MenuEntryStyle.HasOutline = true;
			//DefaultStyles.Instance().MenuTitleStyle.HasOutline = true;
			//DefaultStyles.Instance().MessageBoxStyle.HasOutline = true;
		}

		/// <summary>
		/// Get the set of screens needed for the main menu
		/// </summary>
		/// <returns>The gameplay screen stack.</returns>
		public override IScreen[] GetMainMenuScreenStack()
		{
			return new IScreen[] { new BackgroundScreen(), new MainMenuScreen() };
		}

#endregion //Methods
	}
}

