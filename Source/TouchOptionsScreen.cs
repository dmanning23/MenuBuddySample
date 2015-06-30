using MenuBuddy;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TouchScreenBuddy;

namespace MenuBuddySample
{
	/// <summary>
	/// The options screen is brought up over the top of the main menu
	/// screen, and gives the user a chance to configure the game
	/// in various hopefully useful ways.
	/// </summary>
	internal class TouchOptionsScreen : MenuScreen, IGameScreen
	{
		#region Fields

		/// <summary>
		/// menu entry to change the buttnus
		/// </summary>
		private RelativeLayoutButton buttnutsEntry;
		private int currentButtnuts = 0;
		private ITouchManager touches;

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
			base.LoadContent();

			AddCancelButton();

			touches = ScreenManager.Game.Services.GetService<ITouchManager>();
		}

		#endregion

		#region Handle Input

		public void HandleInput(HadoukInput.InputState input)
		{
			var player = new PlayerIndex();
			if (input.IsMenuCancel(null, out player))
			{
				ExitScreen();
			}
		}

		public void Click(Vector2 point)
		{
			var potion = new Image(ScreenManager.Game.Content.Load<Texture2D>("Potion3a"))
			{
				Horizontal = HorizontalAlignment.Center,
				Vertical = VerticalAlignment.Center,
				Position = point.ToPoint()
			};
			potion.Style.Transition = TransitionType.PopBottom;
			AddItem(potion);
		}

		#endregion
	}
}