using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using ModelLib;

namespace DR_Rest.Managers
{
    public interface IManager
    {
        IEnumerable<Model> Get();

        Model Get(int id);

        IEnumerable<Model> GetFromSubstring(string s);

        IEnumerable<Model> GetWithFilter(FilterItem filter);

        bool Create(Model value);

        bool Update(int id, Model value);

        Model Delete(int id);




    }
}
