using System;
namespace LocalyticsSample.Shared
{
    public interface IPlatform
    {
        void RegisterEvents();
        void SetPlacesShouldDisplay(bool display);
        void SetInAppShouldDisplay(bool display);
        void SetShouldDeeplink(bool display);
    }
}
