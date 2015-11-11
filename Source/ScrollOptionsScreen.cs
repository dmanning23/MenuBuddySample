using MenuBuddy;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TouchScreenBuddy;
using HadoukInput;

namespace MenuBuddySample
{
	/// <summary>
	/// The options screen is brought up over the top of the main menu
	/// screen, and gives the user a chance to configure the game
	/// in various hopefully useful ways.
	/// </summary>
	internal class ScrollOptionsScreen : MenuScreen
	{
		#region Fields

		private ScrollLayout _layout;

		private const float _scrollDelta = 5f;

		#endregion

		#region Initialization

		/// <summary>
		/// Constructor.
		/// </summary>
		public ScrollOptionsScreen()
			: base("Scroll Layout Test")
		{
			MenuTitleOffset = new Point(0, -64);
		}

		public override void LoadContent()
		{
			base.LoadContent();

			AddCancelButton();

			//add the scroll options
			var scroll = new MenuEntry("Scroll Up");
			scroll.Selected += ((object obj, PlayerIndexEventArgs e) =>
			{
				var scrollPos = _layout.ScrollPosition;
				scrollPos.Y -= _scrollDelta;
				_layout.ScrollPosition = scrollPos;
			});
			AddMenuEntry(scroll);

			scroll = new MenuEntry("Scroll Down");
			scroll.Selected += ((object obj, PlayerIndexEventArgs e) =>
			{
				var scrollPos = _layout.ScrollPosition;
				scrollPos.Y += _scrollDelta;
				_layout.ScrollPosition = scrollPos;
            });
			AddMenuEntry(scroll);

			scroll = new MenuEntry("Scroll Left");
			scroll.Selected += ((object obj, PlayerIndexEventArgs e) =>
			{
				var scrollPos = _layout.ScrollPosition;
				scrollPos.X -= _scrollDelta;
				_layout.ScrollPosition = scrollPos;
			});
			AddMenuEntry(scroll);

			scroll = new MenuEntry("Scroll Right");
			scroll.Selected += ((object obj, PlayerIndexEventArgs e) =>
			{
				var scrollPos = _layout.ScrollPosition;
				scrollPos.X += _scrollDelta;
				_layout.ScrollPosition = scrollPos;
			});
			AddMenuEntry(scroll);

			//create the stack layout and add some labels
			var stack = new StackLayout()
			{
				Alignment = StackAlignment.Top,
				Horizontal = HorizontalAlignment.Left,
				Vertical = VerticalAlignment.Top
			};

			var label = new Label("buttnuts");
            var button = new RelativeLayoutButton()
			{
				Style = DefaultStyles.Instance().MessageBoxStyle,
			};
			button.Style.HasOutline = true;
			button.Style.HasBackground = false;
			button.Size = new Vector2(label.Rect.Width, label.Rect.Height);
			button.AddItem(label);
			button.Selected += ((object obj, PlayerIndexEventArgs e) =>
			{
				ExitScreen();
			});
			stack.AddItem(button);

			label = new Label("catpants");
			button = new RelativeLayoutButton()
			{
				Style = DefaultStyles.Instance().MessageBoxStyle,
			};
			button.Style.HasOutline = true;
			button.Style.HasBackground = false;
			button.Size = new Vector2(label.Rect.Width, label.Rect.Height);
			button.AddItem(label);
			button.Selected += ((object obj, PlayerIndexEventArgs e) =>
			{
				ExitScreen();
			});
			stack.AddItem(button);

			label = new Label("foo");
			button = new RelativeLayoutButton()
			{
				Style = DefaultStyles.Instance().MessageBoxStyle,
			};
			button.Style.HasOutline = true;
			button.Style.HasBackground = false;
			button.Size = new Vector2(label.Rect.Width, label.Rect.Height);
			button.AddItem(label);
			button.Selected += ((object obj, PlayerIndexEventArgs e) =>
			{
				ExitScreen();
			});
			stack.AddItem(button);

			label = new Label("bleh");
			button = new RelativeLayoutButton()
			{
				Style = DefaultStyles.Instance().MessageBoxStyle,
			};
			button.Style.HasOutline = true;
			button.Style.HasBackground = false;
			button.Size = new Vector2(label.Rect.Width, label.Rect.Height);
			button.AddItem(label);
			button.Selected += ((object obj, PlayerIndexEventArgs e) =>
			{
				ExitScreen();
			});
			stack.AddItem(button);

			//create the scroll layout and add the stack
			_layout = new ScrollLayout()
			{
				Horizontal = HorizontalAlignment.Right,
				Vertical = VerticalAlignment.Bottom,
                Size = new Vector2(label.Rect.Width, label.Rect.Height)
			};
			_layout.Position = new Point(ResolutionBuddy.Resolution.ScreenArea.Right, ResolutionBuddy.Resolution.ScreenArea.Bottom);

			_layout.AddItem(stack);
			AddItem(_layout);
		}

		#endregion
	}
}