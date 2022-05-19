using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectLibrary.DAL
{
    public class RepoFactory
    {
        public static DBRepo GetRepo()
        {
            DBRepo repo = new DBRepo();
            return repo;
        }
    }
}
