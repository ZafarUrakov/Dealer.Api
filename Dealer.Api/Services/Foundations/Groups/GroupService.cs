using System;
using System.Linq;
using System.Threading.Tasks;
using Dealer.Api.Brokers.Storages;
using Dealer.Api.Models.Groups;

namespace Dealer.Api.Services.Foundations.Groups
{
    public class GroupService : IGroupService
    {
        private readonly IStorageBroker storageBroker;

        public GroupService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<Group> AddGroupAsync(Group group) =>
            await this.storageBroker.InsertGroupAsync(group);

        public IQueryable<Group> RetrieveAllGroups() =>
            this.storageBroker.SelectAllGroups();
    }
}