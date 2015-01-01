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
	internal class TouchOptionsScreen : TouchScreen
	{
		#region Fields

		/// <summary>
		/// menu entry to change the buttnus
		/// </summary>
		private TouchEntry buttnutsEntry;
		private int currentButtnuts = 0;

		#endregion

		#region Initialization

		/// <summary>
		/// Constructor.
		/// </summary>
		public TouchOptionsScreen()
			: base("Touch Options")
		{
			MenuTitleOffset = -64.0f;
		}

		public override void LoadContent()
		{
			// Create our menu entries.
			buttnutsEntry = new TouchEntry(string.Empty);
			buttnutsEntry.Selected += ButtnutsEntrySelected;
			SetMenuEntryText();
			buttnutsEntry.ButtonRect = new Rectangle(32, 32, 256, 128);
			buttnutsEntry.Image = ScreenManager.Game.Content.Load<Texture2D>("Potion3a");
			Entries.Add(buttnutsEntry);

			var touchMenuEntry = new TouchEntry("Touch this menu");
			touchMenuEntry.ButtonRect = new Rectangle(256, 128, 256, 128);
			Entries.Add(touchMenuEntry);

			var backMenuEntry = new TouchEntry("Back");
			backMenuEntry.Selected += OnCancel;
			backMenuEntry.ButtonRect = new Rectangle(300, 512, 128, 128);
			backMenuEntry.Image = ScreenManager.Game.Content.Load<Texture2D>("BackButton");
			Entries.Add(backMenuEntry);

			base.LoadContent();
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