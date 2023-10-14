using Dealer.Api.Models.Groups;
using System.Threading.Tasks;

namespace Dealer.Api.Services.Processings.Groups
{
    public interface IGroupProcessingService
    {
        ValueTask<Group> EnsureGroupExistsByName(string groupName);
    }
}