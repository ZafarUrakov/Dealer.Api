using System.Linq;
using System.Threading.Tasks;
using Dealer.Api.Models.Groups;

namespace Dealer.Api.Services.Foundations.Groups
{
    public interface IGroupService
    {
        IQueryable<Group> RetrieveAllGroups();
        ValueTask<Group> AddGroupAsync(Group group);
    }
}