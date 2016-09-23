using System;
using NUnit.Framework.Constraints;
using NUnit.Framework;

using rclcs;
namespace test_rclcs
{
	[TestFixture]
	public class RCLInitTest:AssertionHelper
	{
		[Test]
		public void CreateAndDelete()
		{
			using (RCL rcl = new RCL ()) 
			{
				Assert.IsNotNull (rcl);

				Action<string[]> init_delegate = new Action<string[]> (rcl.Init);
				Assert.DoesNotThrow (() => init_delegate(new string[]{}));
				Assert.Throws<ArgumentNullException> (() => init_delegate (null));
			}
		
		}
		[Test]
		public void CreateAndDeleteManual()
		{

			RCL rcl = new RCL ();

			Action<string[]> init_delegate = new Action<string[]> (rcl.Init);
			Assert.DoesNotThrow (() => init_delegate(new string[]{}));
			Assert.Throws<ArgumentNullException> (() => init_delegate (null));

			rcl.Dispose ();

		}
	}
}

