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

    public class SessionEventArgs : EventArgs
    {
        public bool First { get; private set; }
        public bool Upgrade { get; private set; }
        public bool Resume { get; private set; }

        public SessionEventArgs(bool isFirst, bool isUpgrade, bool isResume)
        {
            First = isFirst;
            Upgrade = isUpgrade;
            Resume = isResume;
        }

        public override string ToString()
        {
            return string.Format("First:{0} Upgrade:{1} Resume:{2}", First, Upgrade, Resume);
        }
    }

    /// <summary>
    /// Localytics session did open event arguments.
    /// </summary>
    public class LocalyticsSessionDidOpenEventArgs : SessionEventArgs, ILocalyticsSessionOpenEventArgs
    {
        public LocalyticsSessionDidOpenEventArgs(bool isFirst, bool isUpgrade, bool isResume)
            : base(isFirst, isUpgrade, isResume)
        {
        }
    }

    /// <summary>
    /// Localytics session will open event arguments.
    /// </summary>
    public class LocalyticsSessionWillOpenEventArgs : SessionEventArgs, ILocalyticsSessionOpenEventArgs
    {
        public LocalyticsSessionWillOpenEventArgs(bool isFirst, bool isUpgrade, bool isResume)
                    : base(isFirst, isUpgrade, isResume)
        {
        }
    }

    /// <summary>
    /// Localytics did tag event event arguments.
    /// </summary>
    public class LocalyticsDidTagEventEventArgs : EventArgs
    {
        /// <value>Gets the Event name</value>
        public string EventName { get; private set; }
        /// <value>Gets the attributes.</value>
        public IDictionary<string, string> Attributes { get; private set; }
        /// <value>Gets the customer value(Optional).</value>
        public double? CustomerValue { get; private set; }

        public static LocalyticsDidTagEventEventArgs CreateUsingDictionary(string name,
                                              System.Collections.IDictionary attribs, double? value)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var key in attribs.Keys)
            {
                dictionary.Add(key.ToString(), attribs[key].ToString());
            }
            return new LocalyticsDidTagEventEventArgs(name, value, dictionary);
        }
        public LocalyticsDidTagEventEventArgs(string name, double? value,
                                              IDictionary<string, string> attribs
                                              )
        {
            EventName = name;
            Attributes = attribs;
            CustomerValue = value;
        }

        public override string ToString()
        {
            if (Attributes == null)
            {
                return string.Format("EventName:{0} customerValue:{1} Attributes:(null)", EventName, CustomerValue);
            }
            else {
                return string.Format("EventName:{0} customerValue:{1} Attributes:{2}", EventName, CustomerValue, Attributes.ToString());
            }
        }
    }


    public delegate void LocalyticsDidTagDelegate(object sender, LocalyticsDidTagEventEventArgs eventArgs);
    public delegate void LocalyticsSessionDidOpenDelegate(object sender, LocalyticsSessionDidOpenEventArgs eventArgs);
    public delegate void LocalyticsSessionWillOpenDelegate(object sender, LocalyticsSessionWillOpenEventArgs eventArgs);
 }
