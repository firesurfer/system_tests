using System;
using rclcs;
using NUnit.Framework;
using NUnit.Framework.Constraints;
namespace test_rclcs
{
	[TestFixture]
	public class NodeTest:AssertionHelper
	{
		RCL rcl;
		Executor executor;
		public NodeTest()
		{
			
		}

		//Before  each test we set up a new rcl object and initialise it
		[SetUp]
		protected void SetUp()
		{
			rcl = new RCL ();
			if(!rcl.IsInit)
			rcl.Init (new string[]{ });
			executor = new SingleThreadedExecutor ();
		}

		//After each test we dispose the rcl object -> Deinit the rcl
		[TearDown]
		protected void TearDown()
		{
			executor.Dispose ();
			rcl.Dispose ();

		}

		//Create a node using the using statement
		[Test]
		public void CreateNode()
		{
			using (Node testNode = new Node ("TestName")) {

			}
		}

		//Create a node and dispose it manually
		[Test]
		public void CreateNodeManualDelete()
		{
			Node testNode = new Node ("TestName");
			testNode.Dispose ();
		}

		//Spin a node in a singlethreaded executor
		[Test]
		public void SpinNode()
		{
			using (Node testNode = new Node ("TestName")) {
				executor.AddNode (testNode);
				executor.Spin (new TimeSpan (0, 0, 0, 0, 10));
			}

		}

		//Spin a node in a singlethreaded executor and dispose it manually
		[Test]
		public void SpinNodeManualDelete()
		{
			Node testNode = new Node ("TestName");
			executor.AddNode (testNode);
			executor.Spin (new TimeSpan (0, 0, 0, 0, 10));
			testNode.Dispose ();
		}
	}
}

