using System;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IPageRepository : IDisposable
    {
        IEnumerable<Page> GetAllPage();
        Page GetPageById(int pageId);
        bool InsertPage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(Page page);
        bool DeletePage(int pageId);
        IEnumerable<Page> TopNews(int take = 4);
        IEnumerable<Page> PagesInSlider();
        IEnumerable<Page> LastNews(int take = 4);
        IEnumerable<Page> ShowPageByGroupId(int groupId);
        IEnumerable<Page> SearchPage(string search);
        void Save();
    }
}
