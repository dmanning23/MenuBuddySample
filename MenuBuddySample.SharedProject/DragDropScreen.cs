using MenuBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuBuddySample
{
	public class DragDropScreen : WidgetScreen
	{
		public DragDropScreen() : base("DragDrop test")
		{
			CoverOtherScreens = true;
			CoveredByOtherScreens = true;
		}

		public override void LoadContent()
		{
			base.LoadContent();

			var potion = this.ScreenManager.Game.Content.Load<Texture2D>("Potion3a");
			var image = new Image(potion)
			{
				Horizontal = HorizontalAlignment.Center,
				Vertical = VerticalAlignment.Center
			};

			var button = new DragDropButton()
			{
				Position = new Point(200, 100),
				Size = image.Rect.Size.ToVector2(),
				Horizontal = HorizontalAlignment.Center,
				Vertical  = VerticalAlignment.Center
			};
			button.AddItem(image);

			AddItem(button);
		}
	}
}
