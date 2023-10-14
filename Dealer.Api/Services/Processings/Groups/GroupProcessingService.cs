using Dealer.Api.Brokers.DateTimes;
using Dealer.Api.Brokers.Loggings;
using Dealer.Api.Models.Groups;
using Dealer.Api.Services.Foundations.Groups;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dealer.Api.Services.Processings.Groups
{
    public class GroupProcessingService : IGroupProcessingService
    {
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly IGroupService groupService;
        private readonly ILoggingBroker loggingBroker;

        public GroupProcessingService(
            IGroupService groupService,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.groupService = groupService;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Group> EnsureGroupExistsByName(string groupName)
        {
            var maybeGroup = RetriveGroupByName(groupName);

            return maybeGroup is null
                ? await AddGroupAsync(groupName)
                : maybeGroup;
        }

        private Group RetriveGroupByName(string groupName)
        {
            var allGroups = groupService.RetrieveAllGroups();

            return allGroups.FirstOrDefault(storageGroup =>
                storageGroup.GroupName == groupName);
        }

        private async Task<Group> AddGroupAsync(string groupName)
        {
            var group = new Group
            {
                GroupId = Guid.NewGuid(),
                GroupName = groupName
            };

            return await groupService.AddGroupAsync(group);
        }
    }
}