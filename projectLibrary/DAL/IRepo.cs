using projectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectLibrary.DAL
{
    public interface IRepo
    {
        IList<Apartman> GetData2();
        IList<Tag> GetTags();
        
            Apartman Retrieve(int id);

        void Save(Apartman a);
    }
}
