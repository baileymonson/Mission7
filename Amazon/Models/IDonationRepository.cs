using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    public interface IDonationRepository
    {
        IQueryable<Donation> Donations { get; }

        void SaveDonation(Donation donation);
    }
}
