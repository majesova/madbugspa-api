using System.Collections.Generic;
using System.Linq;
using MadBugAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MadBugAPI.Data.Repositories
{
    public class BugRepository: BaseRepository<Bug>
    {
        public BugRepository(MadBugContext context):base(context)
        {
          
        }

        public List<Bug> GetByUserId(string userId){
            return _context.Bugs.Where(x=>x.UserId==userId).ToList();
        }


    }

}