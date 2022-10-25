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
        int AddReservation(Reservation r);
        IList<int> GetTaggedApts(int id);
        IList<Apartman> IndexFilter(Apartman a);
        IList<Generic> GetImages(int ApartmentId);
        IList<Generic> GetTagType();
        void AddTag(Generic tg);
        void DeleteTag(string tg);
        void softDeleteApt(int idApt);
        void updateStatus(int idApt, int idStatus);
        IList<Apartman> getStatus();
        IList<Apartman> GetData2();
        IList<Generic> getOwners();
        IList<Generic> GetCities();

        IList<Tag> GetTags();
        Tag GetTag(int id);
        void addApt(Apartman a);
        void updateApt(int[] args);

        IList<Apartman> Retrieve(int id);

        void Save(Apartman a);
    }
}
