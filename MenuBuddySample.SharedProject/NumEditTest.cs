using MenuBuddy;
using Microsoft.Xna.Framework;
using ResolutionBuddy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuBuddySample
{
	public class NumEditTest : WidgetScreen
	{
		public NumEditTest() : base("NumEditTest")
		{
			CoverOtherScreens = true;
			CoveredByOtherScreens = true;
		}

		public override void LoadContent()
		{
			base.LoadContent();

			AddCancelButton();

			//create the dropdown widget
			var drop = new NumEdit();
			drop.Vertical = VerticalAlignment.Center;
			drop.Horizontal = HorizontalAlignment.Right;
			drop.Size = new Vector2(350, 128);
			drop.Position = Resolution.ScreenArea.Center;

			AddItem(drop);
		}
	}
}
