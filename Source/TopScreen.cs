using MenuBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FontBuddyLib;
using ResolutionBuddy;

namespace MenuBuddySample
{
	/// <summary>
	/// This screen displays on top of all the other screens
	/// </summary>
	internal class TopScreen : GameScreen
	{
		#region Fields

		const float TextVelocity = 2.0f;

		/// <summary>
		/// current location of the text
		/// </summary>
		Vector2 TextLocation = Vector2.Zero;

		/// <summary>
		/// current direction the text is travelling in
		/// </summary>
		Vector2 TextDirection;

		/// <summary>
		/// thing for writing text
		/// </summary>
		FontBuddy Text;

		#endregion //Fields

		#region Initialization

		/// <summary>
		/// Constructor fills in the menu contents.
		/// </summary>
		public TopScreen()
		{
			TextDirection = new Vector2(TextVelocity, TextVelocity);
			Text = new FontBuddy();
		}

		#endregion //Initialization

		#region Methods

		public override void LoadContent()
		{
			Text.Font = ScreenManager.Game.Content.Load<SpriteFont>("ArialBlack48");
		}

		public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
		{
			base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

			//move the text
			TextLocation += TextDirection;

			//bounce the text off the walls
			if (TextLocation.X <= 0)
			{
				TextDirection.X = TextVelocity;
			}
			else if ((TextLocation.X + 128) >= Resolution.ScreenArea.Right)
			{
				TextDirection.X = -TextVelocity;
			}

			if (TextLocation.Y <= 0)
			{
				TextDirection.Y = TextVelocity;
			}
			else if ((TextLocation.Y + 128) >= Resolution.ScreenArea.Bottom)
			{
				TextDirection.Y = -TextVelocity;
			}
		}

		public override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);

			//draw the text
			ScreenManager.SpriteBatchBegin();
			Text.Write("Top Screen!!!", TextLocation, Justify.Center, 1.0f, Color.Cyan, ScreenManager.SpriteBatch, 0.0f);
			ScreenManager.SpriteBatchEnd();
		}

		#endregion
	}
}