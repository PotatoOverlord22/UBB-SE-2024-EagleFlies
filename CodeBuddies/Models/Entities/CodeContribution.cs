using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Models.Entities
{
    internal class CodeContribution
    {
        private long contributor;

        public long Contributor
        {
            get { return contributor; }
            set { contributor = value; }
        }

        private DateTime contributionDate;

        public DateTime ContributionDate
        {
            get { return contributionDate; }
            set { contributionDate = value; }
        }

        private int contributionValue;

        public int ContributionValue
        {
            get { return contributionValue; }
            set { contributionValue = value; }
        }

        public CodeContribution(long contributor, DateTime date, int contributionValue)
        {
            Contributor = contributor;
            ContributionDate = date;
            ContributionValue = contributionValue;
        }
    }
}
