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
            //hej
            _data.Add(value);
            return true;
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
            Model model = Get(id);
            if (model != null)
            {
                model.Id = value.Id;
                model.Artist = value.Artist;
                model.Title = value.Title;
                model.Duration = value.Duration;
                model.PublicYear = value.PublicYear;
                return true;
            }

            return false;
        }
    }
}

