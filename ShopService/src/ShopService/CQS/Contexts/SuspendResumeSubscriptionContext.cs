using System;
using ShopService.Conventions.CQS.Commands;

namespace ShopService.CQS.Contexts
{
    public class SuspendResumeSubscriptionContext : ICommandContext
    {
        public SuspendResumeSubscriptionContext(DateTime today)
        {
            Today = today;
        }

        public DateTime Today { get; set; }
    }
}