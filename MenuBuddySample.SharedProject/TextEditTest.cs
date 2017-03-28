using MenuBuddy;
using Microsoft.Xna.Framework;
using ResolutionBuddy;

namespace MenuBuddySample
{
	public class TextEditTest : WidgetScreen
	{
		public TextEditTest() : base("TextEditTest")
		{
			CoverOtherScreens = true;
			CoveredByOtherScreens = true;
		}

		public override void LoadContent()
		{
			base.LoadContent();

			AddCancelButton();

			//create the dropdown widget
			var drop = new TextEdit();
			drop.Vertical = VerticalAlignment.Center;
			drop.Horizontal = HorizontalAlignment.Right;
			drop.Size = new Vector2(350, 128);
			drop.Position = Resolution.ScreenArea.Center;

			AddItem(drop);
		}
	}
}
