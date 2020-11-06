using System.Collections.Generic;

namespace Xamarin.Forms
{
	public class DispatcherComparer : IEqualityComparer<IDispatcher>
	{
		public bool Equals(IDispatcher x, IDispatcher y)
		{
			if (x == null || y == null)
			{
				return false;
			}

			if (x is FallbackDispatcher && y is FallbackDispatcher)
			{
				// This is the single-window, single UI thread scenario of old; these dispatchers
				// are, by definition, using the same UI thread
				return true;
			}

			return x.Equals(y);
		}

		public int GetHashCode(IDispatcher obj)
		{
			return obj.GetHashCode();
		}
	}
}
