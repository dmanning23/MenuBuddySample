using MenuBuddy;

namespace MenuBuddySample
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : ControllerGame
	{
		#region Methods

		public Game1()
		{
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

