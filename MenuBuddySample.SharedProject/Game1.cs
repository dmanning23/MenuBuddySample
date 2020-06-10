using InputHelper;
using MenuBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MenuBuddySample
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	//public class Game1 : ControllerGame

#if __IOS__ || ANDROID || WINDOWS_UAP
	public class Game1 : TouchGame
#else
	public class Game1 : ControllerGame
#endif
	{
		#region Methods

		public Game1()
		{
			//FullScreen = true;

			this.Graphics.GraphicsProfile = GraphicsProfile.Reach;

#if DESKTOP
			IsMouseVisible = true;
#endif
		}

		protected override void LoadContent()
		{
			base.LoadContent();
		}

		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void InitStyles()
		{
			base.InitStyles();
			//DefaultStyles.Instance().MainStyle.HasOutline = true;
			//DefaultStyles.Instance().MenuEntryStyle.HasOutline = true;
			//DefaultStyles.Instance().MenuTitleStyle.HasOutline = true;
			//DefaultStyles.Instance().MessageBoxStyle.HasOutline = true;
		}

		/// <summary>
		/// Get the set of screens needed for the main menu
		/// </summary>
		/// <returns>The gameplay screen stack.</returns>
		public override IScreen[] GetMainMenuScreenStack()
		{
			return new IScreen[] { new BackgroundScreen(), new MainMenuScreen() };
		}

		protected override void Update(GameTime gameTime)
		{
			try
			{
				base.Update(gameTime);
			}
			catch (Exception ex)
			{
				ScreenManager.ErrorScreen(ex);
			}
		}

		protected override void Draw(GameTime gameTime)
		{
			try
			{
				base.Draw(gameTime);
			}
			catch (Exception ex)
			{
				ScreenManager.ErrorScreen(ex);
			}
		}

		#endregion //Methods
	}
}

