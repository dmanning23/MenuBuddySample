using MenuBuddy;

namespace MenuBuddySample
{
	/// <summary>
	/// The main menu screen is the first thing displayed when the game starts up.
	/// </summary>
	internal class MainMenuScreen : MenuScreen, IMainMenu
	{
		#region Initialization

		/// <summary>
		/// Constructor fills in the menu contents.
		/// </summary>
		public MainMenuScreen()
			: base("Main Menu")
		{
		}

		#endregion //Initialization

		#region Methods

		public override void LoadContent()
		{
			base.LoadContent();

			// Create our menu entries.
			var startGame = new MenuEntry("Slider Test");
			startGame.OnSelect += ((object sender, SelectedEventArgs e) =>
			{
				ScreenManager.AddScreen(new SliderTest(), null);
			});
			AddMenuEntry(startGame);

			var optionsMenuEntry = new MenuEntry("Options");
			optionsMenuEntry.OnSelect += OptionsMenuEntrySelected;
			AddMenuEntry(optionsMenuEntry);

			var touchMenuEntry = new MenuEntry("Dropdown Test");
			touchMenuEntry.OnSelect += ((obj, e) => {
				ScreenManager.AddScreen(new DropdownTest(), null);
			});
			AddMenuEntry(touchMenuEntry);

			var entry = new MenuEntry("Scroll Test");
			entry.OnSelect += ((object obj, SelectedEventArgs e) =>
			{
				ScreenManager.AddScreen(new ScrollOptionsScreen());
			});
			AddMenuEntry(entry);

			var exitMenuEntry = new MenuEntry("Exit");
			exitMenuEntry.OnSelect += OnExit;
			AddMenuEntry(exitMenuEntry);
		}

		#endregion //Methods

		#region Handle Input

		/// <summary>
		/// Event handler for when the High Scores menu entry is selected.
		/// </summary>
		private void OptionsMenuEntrySelected(object sender, SelectedEventArgs e)
		{
			//screen to adjust mic sensitivity
			ScreenManager.AddScreen(new OptionsScreen(), null);
		}

		/// <summary>
		/// Event handler for when the High Scores menu entry is selected.
		/// </summary>
		private void TouchMenuEntrySelected(object sender, SelectedEventArgs e)
		{
			
		}

		/// <summary>
		/// When the user cancels the main menu, ask if they want to exit the sample.
		/// </summary>
		protected void OnExit(object sender, SelectedEventArgs e)
		{
			const string message = "Are you sure you want to exit?";
			var confirmExitMessageBox = new MessageBoxScreen(message);
			confirmExitMessageBox.OnSelect += ConfirmExitMessageBoxAccepted;
			ScreenManager.AddScreen(confirmExitMessageBox, e.PlayerIndex);
		}

		/// <summary>
		/// Event handler for when the user selects ok on the "are you sure
		/// you want to exit" message box.
		/// </summary>
		private void ConfirmExitMessageBoxAccepted(object sender, SelectedEventArgs e)
		{
			ScreenManager.Game.Exit();
		}

		/// <summary>
		/// Ignore the cancel message from the main menu
		/// </summary>
		public override void Cancelled(object obj, SelectedEventArgs e)
		{
			//do nothing here!
		}

		#endregion
	}
}