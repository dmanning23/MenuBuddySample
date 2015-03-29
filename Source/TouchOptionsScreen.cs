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
	internal class TouchOptionsScreen : MenuScreen
	{
		#region Fields

		/// <summary>
		/// menu entry to change the buttnus
		/// </summary>
		private ImageButton buttnutsEntry;
		private int currentButtnuts = 0;

		#endregion

		#region Initialization

		/// <summary>
		/// Constructor.
		/// </summary>
		public TouchOptionsScreen()
			: base("Touch Options")
		{
			MenuTitleOffset = new Point(0, -64);
		}

		public override void LoadContent()
		{
			// Create our menu entries.
			buttnutsEntry = new ImageButton(Style, string.Empty);
			buttnutsEntry.Selected += ButtnutsEntrySelected;
			SetMenuEntryText();
			buttnutsEntry.Rect = new Rectangle(32, 32, 256, 128);
			buttnutsEntry.Image.Texture = ScreenManager.Game.Content.Load<Texture2D>("Potion3a");
			AddItem(buttnutsEntry);

			var touchMenuEntry = new ImageButton(Style, "Touch this menu");
			touchMenuEntry.Rect = new Rectangle(700, 400, 300, 300);
			touchMenuEntry.Image.Texture = ScreenManager.Game.Content.Load<Texture2D>("Potion3a");
			AddItem(touchMenuEntry);

			var backMenuEntry = new Button(Style, "Back");
			backMenuEntry.Selected += OnCancel;
			backMenuEntry.Rect = new Rectangle(300, 512, 128, 128);
			AddItem(backMenuEntry);

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