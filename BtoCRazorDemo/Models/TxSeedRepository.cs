using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BtoCRazorDemo.Models
{
    public interface ITxSeedRepository<T>
    {
        IQueryable<T> GetAll();
        int GetTxID();
        void SetTxID(int id);
        void Save();
    }


    public class TxSeedRepository : ITxSeedRepository<TxSeed>
    {
        readonly protected BtoCDataClassesDataContext dataContext;

        public TxSeedRepository()
        {
            dataContext = new BtoCDataClassesDataContext();
        }

        public IQueryable<TxSeed> GetAll()
        {
            return dataContext.TxSeeds.AsQueryable();
        }

        public int GetTxID()
        {
            return dataContext.TxSeeds.Min(txSeed => txSeed.TxID);
        }

        public void SetTxID(int id)
        {
            dataContext.TxSeeds.Single().TxID = id;
        }

        public void Save()
        {
            dataContext.SubmitChanges();
        }
    }
}
