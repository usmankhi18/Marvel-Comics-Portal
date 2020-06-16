using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class MarvelBLL : IDisposable
    {
        #region Variables

        DAL.DAL objDAL = new DAL.DAL();

        #endregion

        #region Methods

        public MarvelBLL()
        {
            objDAL.Open();
        }


        public int ExecuteStatement(SqlCommand pObjCommand)
        {
            try
            {
                return objDAL.ExecuteStatement(pObjCommand);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetData(SqlCommand pObjCommand)
        {
            try
            {
                return objDAL.GetData(pObjCommand);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetDataSet(SqlCommand pObjCommand)
        {
            try
            {
                return objDAL.GetDataSet(pObjCommand);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Rollback()
        {
            objDAL.Rollback();
        }

        void IDisposable.Dispose()
        {
            objDAL.Close();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
