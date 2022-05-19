using Microsoft.ApplicationBlocks.Data;
using projectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectLibrary.DAL
{
    public class DBRepo : IRepo
    {
        public string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public Apartman Retrieve(int id)
        {
            var dataSet = SqlHelper.ExecuteDataset(cs, nameof(Retrieve), id).Tables[0];
            DataRow row=dataSet.Rows[0];
            return new Apartman
            {
                Id = (int)row[nameof(Apartman.Id)],
                Guid = row[nameof(Apartman.Guid)].ToString(),
                CreatedAt = (DateTime)row[nameof(Apartman.CreatedAt)],
                // fali nullable deletedat
                OwnerId = (int)row[nameof(Apartman.OwnerId)],
                TypeId = (int)row[nameof(Apartman.TypeId)],
                StatusId = (int)row[nameof(Apartman.StatusId)],
                CityId = (int)row[nameof(Apartman.CityId)],
                Name = row[nameof(Apartman.Name)].ToString(),
                NameEng = row[nameof(Apartman.NameEng)].ToString(),
                Address = row[nameof(Apartman.Address)].ToString(),
                Price = double.Parse(row[nameof(Apartman.Price)].ToString()),
                MaxAdults = (int)row[nameof(Apartman.MaxAdults)],
                MaxChildren = (int)row[nameof(Apartman.MaxChildren)],
                TotalRooms = (int)row[nameof(Apartman.TotalRooms)],
                BeachDistance = (int)row[nameof(Apartman.BeachDistance)]
            };
        }

        public IList<Apartman> GetData2()
        {
            var dataSet = SqlHelper.ExecuteDataset(cs, nameof(GetData2)).Tables[0];
            DataRowCollection rows = dataSet.Rows;
             IList<Apartman> data= new List<Apartman>();    
            foreach (DataRow row in rows)
            {
                Apartman a= new Apartman
                {
                    Id = (int)row[nameof(Apartman.Id)],
                    Guid = row[nameof(Apartman.Guid)].ToString(),
                    CreatedAt = (DateTime)row[nameof(Apartman.CreatedAt)],
                    // fali nullable deletedat
                    OwnerId = (int)row[nameof(Apartman.OwnerId)],
                    TypeId = (int)row[nameof(Apartman.TypeId)],
                    StatusId = (int)row[nameof(Apartman.StatusId)],
                    CityId = (int)row[nameof(Apartman.CityId)],
                    Name = row[nameof(Apartman.Name)].ToString(),
                    NameEng = row[nameof(Apartman.NameEng)].ToString(),
                    Address = row[nameof(Apartman.Address)].ToString(),
                    Price = double.Parse(row[nameof(Apartman.Price)].ToString()),
                    MaxAdults = (int)row[nameof(Apartman.MaxAdults)],
                    MaxChildren = (int)row[nameof(Apartman.MaxChildren)],
                    TotalRooms = (int)row[nameof(Apartman.TotalRooms)],
                    BeachDistance = (int)row[nameof(Apartman.BeachDistance)]
                };
                data.Add(a);
            }
            return data;
    }

        public IList<Tag> GetTags() {
            var dataSet = SqlHelper.ExecuteDataset(cs, nameof(GetTags)).Tables[0];
            DataRowCollection rows = dataSet.Rows;
            IList<Tag> data = new List<Tag>();
            foreach (DataRow row in rows)
            {
                Tag a = new Tag
                {
                    Name = row[nameof(Tag.Name)].ToString(),
                    NoOfApartments = (int)row[nameof(Tag.NoOfApartments)]

                };
                data.Add(a);
            }
            return data;

        }


        public void Save(Apartman a)
        {
            throw new NotImplementedException();
        }
    }
}
