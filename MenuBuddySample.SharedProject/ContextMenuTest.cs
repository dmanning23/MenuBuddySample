using InputHelper;
using MenuBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ResolutionBuddy;

namespace MenuBuddySample
{
	public class ContextMenuTest : WidgetScreen
	{
		public ContextMenuTest() : base("ContextMenuTest")
		{
			CoverOtherScreens = true;
			CoveredByOtherScreens = true;
		}

		public override void LoadContent()
		{
			base.LoadContent();

			//add a label with directions
			AddItem(new Label("Click anywhere to pop up a context menu", FontSize.Small)
			{
				Horizontal = HorizontalAlignment.Center,
				Vertical = VerticalAlignment.Center,
				Position = Resolution.TitleSafeArea.Center
			});

			var clicker = new RelativeLayoutButton()
			{
				Size = Resolution.ScreenArea.Size.ToVector2(),
				Horizontal = HorizontalAlignment.Left,
				Vertical = VerticalAlignment.Top,
				Position = Point.Zero
			};
			clicker.OnClick += PopupMenu;
			AddItem(clicker);

		}

		public void PopupMenu(object obj, ClickEventArgs e)
		{
			var hamburger = new ContextMenu(e.Position);
			hamburger.AddItem(ScreenManager.Game.Content.Load<Texture2D>(@"icons\save"), "Save", Ok);
			hamburger.AddItem(ScreenManager.Game.Content.Load<Texture2D>(@"icons\undo"), "Undo", Ok);
			hamburger.AddItem(ScreenManager.Game.Content.Load<Texture2D>(@"icons\redo"), "Redo", Ok);
			hamburger.AddItem(ScreenManager.Game.Content.Load<Texture2D>(@"icons\copy"), "Copy", Ok);
			hamburger.AddItem(ScreenManager.Game.Content.Load<Texture2D>(@"icons\paste"), "Paste", Ok);
			hamburger.AddItem(null, "catpants", Ok);
			hamburger.AddItem(null, "buttnuts", Ok);
			hamburger.AddItem(ScreenManager.Game.Content.Load<Texture2D>(@"icons\pasteSpecial"), "PasteSpecial", Ok);
			hamburger.AddItem(ScreenManager.Game.Content.Load<Texture2D>(@"icons\leftright"), "Mirror", Ok);
			hamburger.AddItem(ScreenManager.Game.Content.Load<Texture2D>(@"icons\unkey"), "UnKey", Ok);
			ScreenManager.AddScreen(hamburger);
		}

		private void Ok(object obj, ClickEventArgs e)
		{
			ScreenManager.AddScreen(new OkScreen("selected something"));
		}
	}
}
