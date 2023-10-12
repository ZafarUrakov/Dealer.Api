using System;
using System.Linq;
using System.Threading.Tasks;
using Dealer.Api.Models.Groups;

namespace Dealer.Api.Services.Foundations.Groups
{
    public class GroupService : IGroupService
    {
        public IQueryable<Group> RetrieveAllGroups()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Group> AddGroupAsync(Group group)
        {
            throw new NotImplementedException();
        }
    }
}