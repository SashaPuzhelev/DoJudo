using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace DoJudo.Models.Repositories
{
    internal class AddressRepository : IAddressRepository
    {
        private readonly DbDoJudo _dbDoJudo;
        public AddressRepository()
        {
            _dbDoJudo = DbDoJudo.GetInstance();
        }
        public bool Add(Address entity)
        {
            try
            {
                _dbDoJudo.Addresses.Add(entity);
                _dbDoJudo.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int AddWithReturnIdAddress(Address entity)
        {
            try
            {
                _dbDoJudo.Addresses.Add(entity);
                int id = _dbDoJudo.Addresses.Find(entity).Id;
                _dbDoJudo.SaveChanges();
                return id;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool Delete(Address entity)
        {
            try
            {
                _dbDoJudo.Addresses.Remove(entity);
                _dbDoJudo.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteItems(IEnumerable<Address> items)
        {
            try
            {
                foreach (var item in items)
                {
                    _dbDoJudo.Addresses.Remove(item);
                }
                _dbDoJudo.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Address Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            return await _dbDoJudo.Addresses.ToListAsync();
        }

        public bool Update(Address entity)
        {
            try
            {
                _dbDoJudo.Addresses.AddOrUpdate(entity);
                _dbDoJudo.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
