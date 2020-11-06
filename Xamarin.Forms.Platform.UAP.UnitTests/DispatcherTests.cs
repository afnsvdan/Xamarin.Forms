using System.Threading.Tasks;
using NUnit.Framework;
using Xamarin.Forms.Platform.UWP;

namespace Xamarin.Forms.Platform.UAP.UnitTests
{
	[TestFixture(Category = "Dispatcher")]
	public class DispatcherTests
	{
		[Test]
		public async Task CoreDispatcherEquality() 
		{
			var a = await Device.InvokeOnMainThreadAsync<IDispatcher>(()=> new Dispatcher());
			var b = await Device.InvokeOnMainThreadAsync<IDispatcher>(() => new Dispatcher());

			var comparer = new DispatcherComparer();

			Assert.True(comparer.Equals(a, b));
		}
	}
}
