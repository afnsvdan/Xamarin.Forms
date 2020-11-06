using NUnit.Framework;

namespace Xamarin.Forms.Core.UnitTests
{
	[TestFixture(Category = "Dispatcher")]
	public class DispatcherTests 
	{
		[Test]
		public void FallbackDispatchersAreAllEqual() 
		{
			IDispatcher a = new FallbackDispatcher();
			IDispatcher b = new FallbackDispatcher();

			var comparer = new DispatcherComparer();

			Assert.True(comparer.Equals(a, b));
		}

		[Test]
		public void NullDispatchersAreNotEqual()
		{
			IDispatcher a = null;
			IDispatcher b = null;

			var comparer = new DispatcherComparer();

			Assert.False(comparer.Equals(a, b));
		}
	}
}
