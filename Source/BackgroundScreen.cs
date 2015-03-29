using System;
using ResolutionBuddy;
using FontBuddyLib;
using MenuBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MenuBuddySample
{
	/// <summary>
	/// The background screen sits behind all the other menu screens.
	/// It draws a background image that remains fixed in place regardless
	/// of whatever transitions the screens on top of it may be doing.
	/// </summary>
	internal class BackgroundScreen : Screen
	{
		#region Member Variables

		private readonly FontBuddy _dannobotText;

		private readonly RainbowTextBuddy _titleText;

		#endregion //Member Variables

		#region Initialization

		/// <summary>
		/// Constructor.
		/// </summary>
		public BackgroundScreen()
		{
			Transition.OnTime = TimeSpan.FromSeconds(0.5);
			Transition.OffTime = TimeSpan.FromSeconds(0.5);

			_titleText = new RainbowTextBuddy();
			_dannobotText = new FontBuddy();
		}

		/// <summary>
		/// Loads graphics content for this screen. The background texture is quite
		/// big, so we use our own local ContentManager to load it. This allows us
		/// to unload before going from the menus into the game itself, wheras if we
		/// used the shared ContentManager provided by the Game class, the content
		/// would remain loaded forever.
		/// </summary>
		public override void LoadContent()
		{
			_titleText.Font = ScreenManager.Game.Content.Load<SpriteFont>("ArialBlack48");
			_titleText.ShadowOffset = new Vector2(-5.0f, 3.0f);
			_titleText.ShadowSize = 1.025f;
			_titleText.RainbowSpeed = 4.0f;

			_dannobotText.Font = ScreenManager.Game.Content.Load<SpriteFont>("ArialBlack24");

			base.LoadContent();
		}

		/// <summary>
		/// Unloads graphics content for this screen.
		/// </summary>
		public override void UnloadContent()
		{
		}

		#endregion

		#region Update and Draw

		/// <summary>
		/// Draws the background screen.
		/// </summary>
		public override void Draw(GameTime gameTime)
		{
			SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

			ScreenManager.SpriteBatchBegin();

			Rectangle screenFullRect = ResolutionBuddy.Resolution.ScreenArea;

			//Draw the game title!
			_titleText.ShadowColor = new Color(0.15f, 0.15f, 0.15f, Transition.Alpha);
			_titleText.Write("MenuBuddySample!!!",
							new Vector2(Resolution.TitleSafeArea.Center.X, Resolution.TitleSafeArea.Center.Y * 0.05f),
			                Justify.Center,
			                1.5f,
			                new Color(0.85f, 0.85f, 0.85f, Transition.Alpha),
			                spriteBatch,
			                Time);

			//draw "dannobot games"
			_dannobotText.Write("@DannobotGames",
							   new Vector2((Resolution.TitleSafeArea.Right * 0.97f),
										   ((Resolution.TitleSafeArea.Bottom) - (_dannobotText.Font.MeasureString("@DannobotGames").Y * 0.65f))),
			                   Justify.Right,
			                   0.5f,
			                   new Color(0.85f, 0.85f, 0.85f, Transition.Alpha),
			                   spriteBatch,
							   Time);

			ScreenManager.SpriteBatchEnd();
		}

		#endregion
	}
}