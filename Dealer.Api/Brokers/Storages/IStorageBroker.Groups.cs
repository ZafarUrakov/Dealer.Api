using Dealer.Api.Models.Applicants;
using Dealer.Api.Models.Groups;
using System.Linq;
using System.Threading.Tasks;

namespace Dealer.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Group> InsertGroupAsync(Group group);
        IQueryable<Group> SelectAllGroups();
    }
}
