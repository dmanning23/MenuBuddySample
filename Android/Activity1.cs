using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Content;
using Microsoft.Xna.Framework;

namespace MenuBuddySample.Android
{
	[Activity(Label = "MenuBuddySample.Android", 
		MainLauncher = true,
		Icon = "@drawable/icon",
		Theme = "@style/Theme.Splash",
		AlwaysRetainTaskState = true,
		LaunchMode = LaunchMode.SingleInstance,
		ConfigurationChanges = ConfigChanges.Orientation |
			ConfigChanges.KeyboardHidden |
			ConfigChanges.Keyboard)]
	public class Activity1 : AndroidGameActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Create our OpenGL view, and display it
			Game1.Activity = this;
			var g = new Game1();
			SetContentView(g.Window);
			g.Run();
		}
	}
}


