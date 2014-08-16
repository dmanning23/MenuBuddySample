using MenuBuddy;
using System;
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
			MenuTitleOffset = -64.0f;

			// Create our menu entries.
			buttnutsEntry = new MenuEntry(string.Empty);
			buttnutsEntry.Selected += ButtnutsEntrySelected;
			SetMenuEntryText();
			MenuEntries.Add(buttnutsEntry);

			touchMenuEntry = new MenuEntry("Touch Menus");
			touchMenuEntry.Selected += TouchMenuEntrySelected;
			MenuEntries.Add(touchMenuEntry);

			textRectEntry = new MenuEntry("Text Rect");
			textRectEntry.Selected += RectMenuEntrySelected;
			MenuEntries.Add(textRectEntry);

			var backMenuEntry = new MenuEntry("Back");
			backMenuEntry.Selected += OnCancel;
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

		private void TouchMenuEntrySelected(object sender, EventArgs e)
		{
			ScreenManager.TouchMenus = !ScreenManager.TouchMenus;
			touchMenuEntry.Text = string.Format("Touch Menus: {0}", ScreenManager.TouchMenus);
		}

		private void RectMenuEntrySelected(object sender, EventArgs e)
		{
			TextSelectionRect = !TextSelectionRect;
			textRectEntry.Text = string.Format("Text Rect: {0}", TextSelectionRect);
		} 
		
		#endregion
	}
}