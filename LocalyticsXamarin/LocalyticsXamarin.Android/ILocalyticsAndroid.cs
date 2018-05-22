using System;
namespace LocalyticsXamarin.Android
{
    public interface ILocalyticsAndroid
    {
		void RedirectLoggingToDisk(bool writeExternally, object context);
    }
}
