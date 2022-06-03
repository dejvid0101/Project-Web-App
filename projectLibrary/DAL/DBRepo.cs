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

        public IList<Apartman> Retrieve(int id)
        {
            IList<Apartman> apts = new List<Apartman>();
            var dataSet = SqlHelper.ExecuteDataset(cs, nameof(Retrieve), id).Tables[0];
            DataRow row=dataSet.Rows[0];
            Apartman apt= new Apartman
            {
                Id = (int)row[nameof(Apartman.Id)],
                Guid = row[nameof(Apartman.Guid)].ToString(),
                CreatedAt = (DateTime)row[nameof(Apartman.CreatedAt)],
                DeletedAt = row[nameof(Apartman.DeletedAt)] as DateTime?,
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
            apts.Add(apt);
            return apts;
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
                    DeletedAt = row[nameof(Apartman.DeletedAt)] as DateTime?,
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
                
                if (a.DeletedAt == null)
                {
                    data.Add(a);
                }
                
                
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

        public void updateApt(params int[] args)
        {
            //SqlHelper.ExecuteDataset(cs, nameof(updateApt), args);

            SqlConnection c = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateApt";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = args[0];

            cmd.Parameters.Add("@TotalRooms", SqlDbType.Int).Value = args[1];

            cmd.Parameters.Add("@MaxAdults", SqlDbType.Int).Value = args[2];

            cmd.Parameters.Add("@MaxChildren", SqlDbType.Int).Value = args[3];
            cmd.Parameters.Add("@BeachDistance", SqlDbType.Int).Value = args[4];
            cmd.Connection=c;
            try

            {

                c.Open();

                cmd.ExecuteNonQuery();

            }

            catch (Exception ex)

            {

                throw ex;

            }

            finally

            {

                c.Close();

                c.Dispose();

            }

        }


        public void Save(Apartman a)
        {
            throw new NotImplementedException();
        }

        public IList<Apartman> getStatus()
        {
            var dataSet = SqlHelper.ExecuteDataset(cs, nameof(getStatus)).Tables[0];
            DataRowCollection rows = dataSet.Rows;
            IList<Apartman> data = new List<Apartman>();
            foreach (DataRow row in rows)
            {
                Apartman a = new Apartman
                {
                    Id = (int)row[nameof(Apartman.Id)],
                    Name = row[nameof(Apartman.Name)].ToString(),
                    HelperStatus = row[nameof(Apartman.HelperStatus)].ToString(),
                    DeletedAt = row[nameof(Apartman.DeletedAt)] as DateTime?
                    
                };

                a.FrontendHelperNameID = a.Name + ":" + a.Id.ToString();

                if (a.DeletedAt == null)
                {
                    data.Add(a);
                }

            }
            return data;
        }

        public void updateStatus(int idApt,int idStatus)
        {
            SqlConnection c = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = nameof(updateStatus)
            };
            cmd.Parameters.Add(nameof(idApt), SqlDbType.Int).Value = idApt;

            cmd.Parameters.Add(nameof(idStatus), SqlDbType.Int).Value = idStatus;

            cmd.Connection = c;
            try

            {

                c.Open();

                cmd.ExecuteNonQuery();

            }

            catch (Exception ex)

            {

                throw ex;

            }

            finally

            {

                c.Close();

                c.Dispose();

            }
        }

        

        public void softDeleteApt(int idApt)
        {
            SqlConnection c = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = nameof(softDeleteApt)
            };
            cmd.Parameters.Add(nameof(idApt), SqlDbType.Int).Value = idApt;

            cmd.Connection = c;
            try

            {

                c.Open();

                cmd.ExecuteNonQuery();

            }

            catch (Exception ex)

            {

                throw ex;

            }

            finally

            {

                c.Close();

                c.Dispose();

            }
        }

        public void addApt(Apartman a)
        {
            SqlConnection c = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = nameof(addApt)
            };
            cmd.Parameters.Add(nameof(a.OwnerId), SqlDbType.Int).Value = a.OwnerId;
            cmd.Parameters.Add(nameof(a.TypeId), SqlDbType.Int).Value = a.TypeId;
            cmd.Parameters.Add(nameof(a.StatusId), SqlDbType.Int).Value = 1;
            cmd.Parameters.Add(nameof(a.CityId), SqlDbType.Int).Value = a.CityId;
            cmd.Parameters.Add(nameof(a.Address), SqlDbType.NVarChar).Value = a.Address;
            cmd.Parameters.Add(nameof(a.Name), SqlDbType.NVarChar).Value = a.Name;
            cmd.Parameters.Add(nameof(a.NameEng), SqlDbType.NVarChar).Value = "x";
            cmd.Parameters.Add(nameof(a.Price), SqlDbType.Int).Value = a.Price;
            cmd.Parameters.Add(nameof(a.MaxAdults), SqlDbType.Int).Value = a.MaxAdults;
            cmd.Parameters.Add(nameof(a.MaxChildren), SqlDbType.Int).Value = a.MaxChildren;
            cmd.Parameters.Add(nameof(a.TotalRooms), SqlDbType.Int).Value = a.TotalRooms;
            cmd.Parameters.Add(nameof(a.BeachDistance), SqlDbType.Int).Value = a.BeachDistance;


            cmd.Connection = c;
            try

            {

                c.Open();

                cmd.ExecuteNonQuery();

            }

            catch (Exception ex)

            {

                throw ex;

            }

            finally

            {

                c.Close();

                c.Dispose();

            }
        }
    }
}
