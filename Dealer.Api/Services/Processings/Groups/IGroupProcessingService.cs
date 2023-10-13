using System.Threading.Tasks;
using Dealer.Api.Models.Groups;

namespace Dealer.Api.Services.Processings.Groups
{
    public interface IGroupProcessingService
    {
        ValueTask<Group> EnsureGroupExistsByName(string groupName);
    }
}