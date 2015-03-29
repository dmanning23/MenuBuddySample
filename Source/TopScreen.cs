using FontBuddyLib;
using MenuBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ResolutionBuddy;

namespace MenuBuddySample
{
	/// <summary>
	/// This screen displays on top of all the other screens
	/// </summary>
	internal class TopScreen : Screen
	{
		#region Fields

		const float TextVelocity = 2.0f;

		/// <summary>
		/// current location of the text
		/// </summary>
		Vector2 _textLocation = Vector2.Zero;

		/// <summary>
		/// current direction the text is travelling in
		/// </summary>
		Vector2 _textDirection;

		/// <summary>
		/// thing for writing text
		/// </summary>
		readonly FontBuddy _text;

		#endregion //Fields

		#region Initialization

		/// <summary>
		/// Constructor fills in the menu contents.
		/// </summary>
		public TopScreen():base("top")
		{
			_textDirection = new Vector2(TextVelocity, TextVelocity);
			_text = new FontBuddy();
		}

		#endregion //Initialization

		#region Methods

		public override void LoadContent()
		{
			base.LoadContent();
			_text.Font = ScreenManager.Game.Content.Load<SpriteFont>("ArialBlack48");
		}

		public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
		{
			base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

			//move the text
			_textLocation += _textDirection;

			//bounce the text off the walls
			if (_textLocation.X <= 0)
			{
				_textDirection.X = TextVelocity;
			}
			else if ((_textLocation.X + 128) >= Resolution.ScreenArea.Right)
			{
				_textDirection.X = -TextVelocity;
			}

			if (_textLocation.Y <= 0)
			{
				_textDirection.Y = TextVelocity;
			}
			else if ((_textLocation.Y + 128) >= Resolution.ScreenArea.Bottom)
			{
				_textDirection.Y = -TextVelocity;
			}
		}

		public override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);

			//draw the text
			ScreenManager.SpriteBatchBegin();
			_text.Write("Top Screen!!!", _textLocation, Justify.Center, 1.0f, Color.Cyan, ScreenManager.SpriteBatch, Time);
			ScreenManager.SpriteBatchEnd();
		}

		#endregion
	}
}