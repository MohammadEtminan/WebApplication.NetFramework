using System;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IPageGroupRepository : IDisposable
    {
        IEnumerable<PageGroup> GetAllGroups();
        PageGroup GetGroupById(int groupId);
        bool InsertGroup(PageGroup pageGroup);
        bool UpdateGroup(PageGroup pageGroup);
        bool DeleteGroup(PageGroup pageGroup);
        bool DeleteGroup(int groupId);
        IEnumerable<ShowGroupViewModel> GetGroupsForView();
        void Save();
    }
}