using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models
{
    internal class CodeContribution
    {

        Buddy Buddy { get; set; }

        DateTime Date { get; set; }

        int ContributionValue { get; set; }

        public CodeContribution(Buddy buddy, DateTime date, int contributionValue)
        {
            Buddy = buddy;
            Date = date;
            ContributionValue = contributionValue;
        }
    }
}
