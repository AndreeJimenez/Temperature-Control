using System;
using System.Threading.Tasks;

namespace TemperatureControlApp.Extensions
{
    public static class VisitorExtensions
    {
		public static async void SafeFireAndForget(this Task visitor,
												   bool returnToCallingContext,
												   Action<Exception> onException = null)
		{
			try
			{
				await visitor.ConfigureAwait(returnToCallingContext);
			}
			catch (Exception ex) when (onException != null)
			{
				onException(ex);
			}
		}
	}
}
