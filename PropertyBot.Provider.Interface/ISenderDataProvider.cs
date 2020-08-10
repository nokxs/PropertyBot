using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crawler.Interface
{
    public interface ISenderDataProvider
    {
        void Init();

        Task Add<TUser>(TUser user);

        IEnumerable<TUser> GetAll<TUser>();

        bool Contains<TUser>(Func<TUser, bool> compareFunc);
    }
}
