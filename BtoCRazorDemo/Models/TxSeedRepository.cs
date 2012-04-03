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
        readonly protected B2CDbEntities dbEntities;

        public TxSeedRepository()
        {
            dbEntities = new B2CDbEntities();
        }

        public IQueryable<TxSeed> GetAll()
        {
            return dbEntities.TxSeeds.AsQueryable();
        }

        public int GetTxID()
        {
            return dbEntities.TxSeeds.Min(txSeed => txSeed.TxID);
        }

        public void SetTxID(int id)
        {
            dbEntities.TxSeeds.Single().TxID = id;
        }

        public void Save()
        {
            dbEntities.SaveChanges(System.Data.Objects.SaveOptions.None);
        }
    }
}
