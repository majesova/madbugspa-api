using System.Collections.Generic;
using System.Linq;
using MadBugAPI.Data.Entities;

namespace MadBugAPI.Data.Repositories
{
    public class UserRepository : BaseRepository<AppUser>
    {
        public UserRepository(MadBugContext context):base(context)
        {
        }   
    }
}