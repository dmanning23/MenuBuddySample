using MenuBuddy;
using Microsoft.Xna.Framework;
using ResolutionBuddy;

namespace MenuBuddySample
{
	public class DropdownTest : WidgetScreen
	{
		public DropdownTest() : base("Dropdown Test")
		{
			CoverOtherScreens = true;
			CoveredByOtherScreens = true;
		}

		public override void LoadContent()
		{
			base.LoadContent();

			AddCancelButton();

			//create the dropdown widget
			var drop = new Dropdown<string>();
			drop.Vertical = VerticalAlignment.Center;
			drop.Horizontal = HorizontalAlignment.Center;
			drop.Size = new Vector2(350, 128);
			drop.Position = Resolution.ScreenArea.Center;

			string[] words = { "cat", "pants", "buttnuts", "cat1", "pants1", "whoa", "test1", "test2" };
			foreach (var word in words)
			{
				var dropitem = new DropdownItem<string>(word, drop)
				{
					Vertical = VerticalAlignment.Center,
					Horizontal = HorizontalAlignment.Center,
					Size = new Vector2(350, 64)
				};

				var label = new Label(word)
				{
					Vertical = VerticalAlignment.Center,
					Horizontal = HorizontalAlignment.Center
				};

				dropitem.AddItem(label);
				drop.DropdownList.Add(dropitem);
			}

			drop.SelectedItem = "buttnuts";

			AddItem(drop);
		}
	}
}
