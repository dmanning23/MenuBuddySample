using MenuBuddy;
using Microsoft.Xna.Framework;
#if OUYA
using Ouya.Console.Api;
#endif

namespace MenuBuddySample
{
	public class DummyScreenManager : ScreenManager
	{
		#region Properties

		#endregion //Properties

		#region Methods

		/// <summary>
		/// Initializes a new instance of the <see cref="Filibuster.FilibusterScreenManager"/> class.
		/// </summary>
		/// <param name="game">Game.</param>
		public DummyScreenManager(Game game)
			: base(game)
		{
		}

		protected override void LoadContent()
		{
			//TODO: load up the styles for this game
			base.LoadContent();
		}

		/// <summary>
		/// Get the set of screens needed for the main menu
		/// </summary>
		/// <returns>The gameplay screen stack.</returns>
		public override IScreen[] GetMainMenuScreenStack()
		{
			return new IScreen[] {new BackgroundScreen(), new MainMenuScreen()};
		}

		#endregion //Methods
	}
}