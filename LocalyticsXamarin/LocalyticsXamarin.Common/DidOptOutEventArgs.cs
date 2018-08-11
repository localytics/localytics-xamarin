using System;

namespace LocalyticsXamarin.Common
{
    /// <summary>
    /// Did opt out event arguments.
    /// </summary>
    public class DidOptOutEventArgs : EventArgs
    {
        /// <summary>
        /// Gets a value indicating whether the campaign was used to optout.
        /// </summary>
        /// <value><c>true</c> if opt out; otherwise, <c>false</c>.</value>
        public bool OptOut { get; private set; }
        /// <summary>
        /// Gets the campaign.
        /// </summary>
        /// <value>The campaign.</value>
        public ICampaignBase Campaign { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:LocalyticsXamarin.Common.DidOptOutEventArgs"/> class.
        /// </summary>
        /// <param name="optOut">If set to <c>true</c> opt out.</param>
        /// <param name="campaign">Campaign.</param>
        public DidOptOutEventArgs(bool optOut, ICampaignBase campaign)
        {
            this.OptOut = optOut;
            this.Campaign = campaign;
        }
    }
}
