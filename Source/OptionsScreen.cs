using MenuBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

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
		private MenuEntry buttnutsEntry;
		private int currentButtnuts = 0;

		MenuEntry touchMenuEntry;
		MenuEntry textRectEntry;

		#endregion

		#region Initialization

		/// <summary>
		/// Constructor.
		/// </summary>
		public OptionsScreen()
			: base("Options")
		{
			MenuTitleOffset = new Point(0, -64);
		}

		public override void LoadContent()
		{
			base.LoadContent();

			// Create our menu entries.
			buttnutsEntry = new MenuEntry(Style, string.Empty);
			buttnutsEntry.Selected += ButtnutsEntrySelected;
			SetMenuEntryText();
			AddMenuEntry(buttnutsEntry);

			touchMenuEntry = new MenuEntry(Style, "Touch Menus");
			AddMenuEntry(touchMenuEntry);

			textRectEntry = new MenuEntry(Style, "Text Rect");
			AddMenuEntry(textRectEntry);

			var backMenuEntry = new MenuEntry(Style, "Back");
			backMenuEntry.Selected += OnCancel;
			AddMenuEntry(backMenuEntry);
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