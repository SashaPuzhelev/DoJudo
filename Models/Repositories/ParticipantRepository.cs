﻿using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DoJudo.Models.Repositories
{
    internal class ParticipantRepository : IParticipantRepository
    {
        private readonly DbDoJudo _dbDoJudo;
        public ParticipantRepository()
        {
            _dbDoJudo = DbDoJudo.GetInstance();
        }

        public bool Add(Participant entity)
        {
            try
            {
                _dbDoJudo.Participants.Add(entity);
                _dbDoJudo.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Participant entity)
        {
            try
            {
                _dbDoJudo.Participants.Remove(entity);
                _dbDoJudo.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }
        public bool DeleteItems(IEnumerable<Participant> items)
        {
            try
            {
                foreach (var item in items)
                {
                    _dbDoJudo.Participants.Remove(item);
                }
                _dbDoJudo.SaveChanges();
                return true;
            }
            catch (Exception)
            { 
                return false; 
            }
        }

        public Participant Get(int id)
        {
            throw new NotImplementedException();
        }

        public int GetAge(Participant entity)
        {
            int age = DateTime.Today.Year - entity.Birthdate.Year;
            if (DateTime.Today < entity.Birthdate.AddYears(age))
            {
                age--;
            }
            return age;
        }
        public async Task<IEnumerable<Participant>> GetAll()
        {
            return await _dbDoJudo.Participants.ToListAsync();
        }
        public Participant GetByPhone(string phone)
        {
            throw new NotImplementedException();
        }
        public bool Update(Participant entity)
        {
            try
            {
                _dbDoJudo.Participants.AddOrUpdate(entity);
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
