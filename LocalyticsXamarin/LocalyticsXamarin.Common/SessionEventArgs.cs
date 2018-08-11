using System;
using System.Collections.Generic;

namespace LocalyticsXamarin.Common
{
    /// <summary>
    /// Localytics session open event arguments common to will open and did open events.
    /// </summary>
    public interface ILocalyticsSessionOpenEventArgs
    {
        /// <value>Gets the value whether this is the first session</value>
        bool First { get; }
        /// <value>Gets the value whether this is the first session following an upgrade</value>
        bool Upgrade { get; }
        /// <value>Gets the value whether this is not a new session but a session pending close was resumed.</value>
        bool Resume { get; }

    }

    /// <summary>
    /// Localytics session did open event arguments.
    /// </summary>
    public interface LocalyticsSessionDidOpenEventArgs : ILocalyticsSessionOpenEventArgs
    {
    }

    /// <summary>
    /// Localytics session will open event arguments.
    /// </summary>
    public interface LocalyticsSessionWillOpenEventArgs : ILocalyticsSessionOpenEventArgs
    {
    }

    /// <summary>
    /// Localytics did tag event event arguments.
    /// </summary>
    public interface LocalyticsDidTagEventEventArgs //: EventArgs
    {
        /// <value>Gets the Event name</value>
        string EventName { get; }
        /// <value>Gets the attributes.</value>
        IDictionary<string, string> Attributes { get; }
        /// <value>Gets the customer value(Optional).</value>
        double? CustomerValue { get; }
    }
}
