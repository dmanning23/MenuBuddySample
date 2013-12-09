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
			: base(game,
				"ArialBlack48",
			       "ArialBlack48",
			       "ArialBlack24",
			       "menu move",
			       "menu select")
		{
		}

		/// <summary>
		/// Get the set of screens needed for the main menu
		/// </summary>
		/// <returns>The gameplay screen stack.</returns>
		public override GameScreen[] GetMainMenuScreenStack()
		{
			return new GameScreen[] {new BackgroundScreen(), new MainMenuScreen()};
		}

		public override void Initialize()
		{
			base.Initialize();
		}

		#endregion //Methods
	}
}