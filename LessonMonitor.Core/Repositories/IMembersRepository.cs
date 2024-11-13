using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.Core.Repositories
{
    public interface IMembersRepository
    {
        Task<int> Add(Member newMember);
        Task<Member[]> Get();
    }
}
