using System;
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
	internal class BackgroundScreen : GameScreen
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
			TransitionOnTime = TimeSpan.FromSeconds(0.5);
			TransitionOffTime = TimeSpan.FromSeconds(0.5);

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
			_titleText.Font = ScreenManager.TitleFont;
			_titleText.ShadowOffset = new Vector2(-5.0f, 3.0f);
			_titleText.ShadowSize = 1.025f;
			_titleText.RainbowSpeed = 4.0f;

			_dannobotText.Font = ScreenManager.MenuFont;

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
		/// Updates the background screen. Unlike most screens, this should not
		/// transition off even if it has been covered by another screen: it is
		/// supposed to be covered, after all! This overload forces the
		/// coveredByOtherScreen parameter to false in order to stop the base
		/// Update method wanting to transition off.
		/// </summary>
		public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
		{
			base.Update(gameTime, otherScreenHasFocus, false);
		}

		/// <summary>
		/// Draws the background screen.
		/// </summary>
		public override void Draw(GameTime gameTime)
		{
			SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

			//Get the game time in seconds
			double time = gameTime.TotalGameTime.TotalSeconds;

			ScreenManager.SpriteBatchBegin();

			Rectangle screenFullRect = ResolutionBuddy.Resolution.ScreenArea;

			//Draw the game title!
			_titleText.ShadowColor = new Color(0.15f, 0.15f, 0.15f, TransitionAlpha);
			_titleText.Write("MenuBuddySample!!!",
			                new Vector2(ScreenRect.Center.X, ScreenRect.Center.Y * 0.05f),
			                Justify.Center,
			                1.5f,
			                new Color(0.85f, 0.85f, 0.85f, TransitionAlpha),
			                spriteBatch,
			                time);

			//draw "dannobot games"
			_dannobotText.Write("@DannobotGames",
			                   new Vector2((ScreenRect.Right * 0.97f),
			                               ((ScreenRect.Bottom) - (_dannobotText.Font.MeasureString("@DannobotGames").Y * 0.65f))),
			                   Justify.Right,
			                   0.5f,
			                   new Color(0.85f, 0.85f, 0.85f, TransitionAlpha),
			                   spriteBatch,
			                   time);

			ScreenManager.SpriteBatchEnd();
		}

		#endregion
	}
}