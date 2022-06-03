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
        void softDeleteApt(int idApt);
        void updateStatus(int idApt, int idStatus);
        IList<Apartman> getStatus();
        IList<Apartman> GetData2();
        IList<Tag> GetTags();
        void addApt(Apartman a);
        void updateApt(int[] args);

        IList<Apartman> Retrieve(int id);

        void Save(Apartman a);
    }
}
