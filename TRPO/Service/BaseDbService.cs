using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO.Data;

namespace TRPO.Service
{
    public class BaseDbService
    {
        private BaseDbService()
        {
            context = new AppDbContext();
        }

        static BaseDbService? instance;
        public static BaseDbService Instance
        {
            get
            {
                if(instance==null)
                    instance = new BaseDbService();
                return instance;
            }
        }

        AppDbContext context;
        public AppDbContext Context => context;
    }
}
