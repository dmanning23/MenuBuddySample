using MenuBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MenuBuddySample
{
	/// <summary>
	/// The options screen is brought up over the top of the main menu
	/// screen, and gives the user a chance to configure the game
	/// in various hopefully useful ways.
	/// </summary>
	internal class OptionsScreen : MenuScreen
	{
		#region Fields

		/// <summary>
		/// menu entry to change the buttnus
		/// </summary>
		private readonly MenuEntry buttnutsEntry;
		private int currentButtnuts = 0;

		#endregion

		#region Initialization

		/// <summary>
		/// Constructor.
		/// </summary>
		public OptionsScreen()
			: base("Options")
		{
			// Create our menu entries.
			buttnutsEntry = new MenuEntry(string.Empty);

			SetMenuEntryText();

			var backMenuEntry = new MenuEntry("Back");

			// Hook up menu event handlers.
			buttnutsEntry.Selected += ButtnutsEntrySelected;
			backMenuEntry.Selected += OnCancel;

			// Add entries to the menu.
			MenuEntries.Add(buttnutsEntry);
			MenuEntries.Add(backMenuEntry);
		}

		/// <summary>
		/// Fills in the latest values for the options screen menu text.
		/// </summary>
		private void SetMenuEntryText()
		{
			buttnutsEntry.Text = string.Format("buttnuts: {0}", currentButtnuts.ToString());
		}

		#endregion

		#region Handle Input

		/// <summary>
		/// Event handler for when the buttnuts selection menu entry is selected.
		/// </summary>
		private void ButtnutsEntrySelected(object sender, PlayerIndexEventArgs e)
		{
			//increment the mic
			currentButtnuts++;

			SetMenuEntryText();
		}
		
		#endregion
	}
}