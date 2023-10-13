using Dealer.Api.Models.Groups;
using System.Linq;
using System.Threading.Tasks;

namespace Dealer.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public async ValueTask<Group> InsertGroupAsync(Group group) =>
            await InsertAsync(group);

        public IQueryable<Group> SelectAllGroups() =>
           SelectAll<Group>();
    }
}
