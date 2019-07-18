using System.Threading;
using System.Threading.Tasks;

namespace MenuBuddySample
{
	public class DropdownTestWithDelay : DropdownTest
	{
		public DropdownTestWithDelay() : base()
		{
		}

		public override void LoadContent()
		{
			Thread.Sleep(5000);

			base.LoadContent();
		}
	}
}
