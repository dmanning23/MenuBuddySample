using InputHelper;
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

			var contextMenuTest = new MenuEntry("Context Menu Test");
			contextMenuTest.OnClick += ((object sender, ClickEventArgs e) =>
			{
				ScreenManager.AddScreen(new ContextMenuTest());
			});
			AddMenuEntry(contextMenuTest);

			var numEditTest = new MenuEntry("NumEdit Test");
			numEditTest.OnClick += ((object sender, ClickEventArgs e) =>
			{
				ScreenManager.AddScreen(new NumEditTest(), null);
			});
			AddMenuEntry(numEditTest);

			var dragdrop = new MenuEntry("DragDropButton Test");
			dragdrop.OnClick += ((object sender, ClickEventArgs e) =>
			{
				ScreenManager.AddScreen(new DragDropScreen(), null);
			});
			AddMenuEntry(dragdrop);

			//var startGame = new MenuEntry("Slider Test");
			//startGame.OnClick += ((object sender, ClickEventArgs e) =>
			//{
			//	ScreenManager.AddScreen(new SliderTest(), null);
			//});
			//AddMenuEntry(startGame);

			var optionsMenuEntry = new MenuEntry("Tree Test");
			optionsMenuEntry.OnClick += ((obj, e) =>
			{
				ScreenManager.AddScreen(new TreeTest(), null);
			});
			AddMenuEntry(optionsMenuEntry);

			//var touchMenuEntry = new MenuEntry("Dropdown Test");
			//touchMenuEntry.OnClick += ((obj, e) =>
			//{
			//	ScreenManager.AddScreen(new DropdownTest(), null);
			//});
			//AddMenuEntry(touchMenuEntry);

			var entry = new MenuEntry("Scroll Test");
			entry.OnClick += ((object obj, ClickEventArgs e) =>
			{
				ScreenManager.AddScreen(new ScrollOptionsScreen());
			});
			AddMenuEntry(entry);

			var entry2 = new MenuEntry("Big Scroll Test");
			entry2.OnClick += ((object obj, ClickEventArgs e) =>
			{
				ScreenManager.AddScreen(new BigScrollTest());
			});
			AddMenuEntry(entry2);

			var entry1 = new MenuEntry("Text Edit Test");
			entry1.OnClick += ((object obj, ClickEventArgs e) =>
			{
				ScreenManager.AddScreen(new TextEditTest());
			});
			AddMenuEntry(entry1);

			var exitMenuEntry = new MenuEntry("Exit");
			exitMenuEntry.OnClick += OnExit;
			AddMenuEntry(exitMenuEntry);
		}

		#endregion //Methods

		#region Handle Input

		/// <summary>
		/// Event handler for when the High Scores menu entry is selected.
		/// </summary>
		private void OptionsMenuEntrySelected(object sender, ClickEventArgs e)
		{
			//screen to adjust mic sensitivity
			ScreenManager.AddScreen(new OptionsScreen(), null);
		}

		/// <summary>
		/// Event handler for when the High Scores menu entry is selected.
		/// </summary>
		private void TouchMenuEntrySelected(object sender, ClickEventArgs e)
		{
		}

		/// <summary>
		/// When the user cancels the main menu, ask if they want to exit the sample.
		/// </summary>
		protected void OnExit(object sender, ClickEventArgs e)
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
		private void ConfirmExitMessageBoxAccepted(object sender, ClickEventArgs e)
		{
#if !__IOS__
			ScreenManager.Game.Exit();
#endif
		}

		/// <summary>
		/// Ignore the cancel message from the main menu
		/// </summary>
		public override void Cancelled(object obj, ClickEventArgs e)
		{
			//do nothing here!
		}

		#endregion
	}
}