using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLib;

namespace DR_Rest.Managers
{
    public class ManagerDB : IManager
    {
        private readonly ModelContext _data;

        public ManagerDB(ModelContext context)
        {
            _data = context;
        }
        public bool Create(Model value)
        {
            try
            {
                value.Id = 0;
                _data.DR.Add(value);
                _data.SaveChanges();
                return true;
             

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Model Delete(int id)
        {
            Model model = Get(id);
            _data.Remove(model);
            return model;
        }

        public IEnumerable<Model> Get()
        {
            return _data.DR;
        }

        public Model Get(int id)
        {
            return _data.DR.Find(id);

            throw new KeyNotFoundException();
        }

        public IEnumerable<Model> GetFromSubstring(string s)
        {
            return _data.DR.Where(i => i.Title.ToLower().Contains(s.ToLower()));
        }

        public IEnumerable<Model> GetWithFilter(FilterItem filter)
        {
            if (filter.LowYear > 0 && filter.HighYear == 0)
            {
                return _data.DR.Where(i => i.PublicYear >= filter.LowYear);
            }
            else if (filter.HighYear > filter.LowYear)
            {
                return _data.DR.Where(i => i.PublicYear >= filter.LowYear && i.PublicYear <= filter.HighYear);
            }
            else
            {
                return _data.DR;
            }
        }

        public bool Update(int id, Model value)
        {
            value.Id = id;
            _data.DR.Update(value);
            _data.SaveChanges();
            return true;
        }
    }
}

