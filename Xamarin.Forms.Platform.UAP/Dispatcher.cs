using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

namespace Xamarin.Forms.Platform.UWP
{
	internal class Dispatcher : IDispatcher
	{
		readonly CoreDispatcher _coreDispatcher;

		public void BeginInvokeOnMainThread(Action action)
		{
			_coreDispatcher.RunAsync(CoreDispatcherPriority.Normal, () => action()).WatchForError();
		}

		public override bool Equals(object obj)
		{
			return obj is Dispatcher dispatcher &&
				   EqualityComparer<CoreDispatcher>.Default.Equals(_coreDispatcher, dispatcher._coreDispatcher);
		}

		public override int GetHashCode()
		{
			return 736870076 + EqualityComparer<CoreDispatcher>.Default.GetHashCode(_coreDispatcher);
		}

		public Dispatcher()
		{
			_coreDispatcher = CoreApplication.GetCurrentView().Dispatcher;
		}

		public Dispatcher(CoreDispatcher coreDispatcher) 
		{
			_coreDispatcher = coreDispatcher;
		}

		bool IDispatcher.IsInvokeRequired => Device.IsInvokeRequired;
	}
}
