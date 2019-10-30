using System.Collections.Generic;
using System.Linq;
using MadBugAPI.Data.Entities;

namespace MadBugAPI.Data.Repositories
{
    public class BugRepository
    {
        private readonly MadBugContext _context;
        public BugRepository(MadBugContext context)
        {
            _context = context;
        }

        public void Insert(Bug bug){
            _context.Bugs.Add(bug);
        }

        public List<Bug> GetAll(){
            return _context.Bugs.ToList();
        }

    }

}