using System;
using rclcs;
using builtin_interfaces.msg;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace test_rclcs
{
	[TestFixture]
	public class PublisherTest
	{
		RCL rcl;
		Executor executor;
		Node node;

		//Before  each test we set up a new rcl object and initialise it
		[SetUp]
		protected void SetUp()
		{
			rcl = new RCL ();
			if(!rcl.IsInit)
				rcl.Init (new string[]{ });
			executor = new SingleThreadedExecutor ();
			node = new Node ("TestNode");
			executor.AddNode (node);
			executor.Spin (new TimeSpan (0, 0, 0, 0, 10));
		}

		//After each test we dispose the rcl object -> Deinit the rcl
		[TearDown]
		protected void TearDown()
		{
			node.Dispose ();
			executor.Dispose ();
			rcl.Dispose ();

		}

		//Create publisher with the builtin time msg
		[Test]
		public void CreatePublisher()
		{
			using (Publisher<builtin_interfaces.msg.Time> publisher = new Publisher<Time> (node, "TestTopic")) {
				
			}
		}

		//Create publisher with the builtin time msg and set a custom qos profile
		[Test]
		public void CreatePublisherWithCustomQos()
		{
			using (Publisher<builtin_interfaces.msg.Time> publisher = new Publisher<Time> (node, "TestTopic", rmw_qos_profile_t.rmw_qos_profile_sensor_data)) {
				Assert.AreEqual (publisher.QOSProfile ,rmw_qos_profile_t.rmw_qos_profile_sensor_data);
				Assert.IsNotNull (publisher.NativeWrapper);
				Assert.IsNotNull (publisher.NativePublisher);
			}
		}


		//Publish message and recieve it
		[Test, Timeout(2000)]
		public void PublishMessage()
		{
			
			using (Publisher<builtin_interfaces.msg.Time> publisher = node.CreatePublisher<Time>("TestTopic")) {
				builtin_interfaces.msg.Time test_msg = new builtin_interfaces.msg.Time ();
				test_msg.nanosec = 10;
				test_msg.sec = 100;
				bool recieved = false;

				using (Subscription<builtin_interfaces.msg.Time> subscription = node.CreateSubscription<Time>("TestTopic")) {
					subscription.MessageRecieved += (object sender, MessageRecievedEventArgs<builtin_interfaces.msg.Time> e) => 
					{
						recieved = true;
						Assert.AreEqual(e.Message.nanosec ,test_msg.nanosec);
						Assert.AreEqual(e.Message.sec ,test_msg.sec);
					};
					Assert.IsTrue(publisher.Publish (test_msg));
					test_msg.Dispose ();
					while (!recieved) {
						System.Threading.Thread.Sleep (10);
					}
					Assert.IsTrue(recieved);
				}
			}
		}
		//Check for handling of null values
		[Test]
		public void PublishNull()
		{
			using (Publisher<builtin_interfaces.msg.Time> publisher = node.CreatePublisher<Time> ("TestTopic")) {
				Func<builtin_interfaces.msg.Time, bool> publish_delegate = new Func<builtin_interfaces.msg.Time,bool> (publisher.Publish);
				Assert.Throws<ArgumentNullException>(() => publish_delegate(null));

			}
		}


	}
}

