using System;
namespace LocalyticsXamarin.Android
{
    public interface ILocalyticsAndroid
    {
		void RedirectLoggingToDisk(bool writeExternally, object context);
    }

	public sealed class InboxRefreshImplementation
    {
        IInboxRefreshListenerImplementor implementor = new IInboxRefreshListenerImplementor();
        public void SetCallback(Action<object[]> inboxCampaignsDelegate)
        {
            implementor.SetCallback(inboxCampaignsDelegate);
        }
    }
}
