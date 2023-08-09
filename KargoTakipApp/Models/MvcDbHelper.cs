using EntityLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KargoTakipApp.Models
{
    public sealed class MvcDbHelper
    {
        private static volatile AbstractDapperRepository _repositoryInstance;
        private static  object _syncRoot = new object();

        public MvcDbHelper()
        {

        }

        public static AbstractDapperRepository Repository 
        {
            get 
            {
                if( _repositoryInstance == null)
                {
                    lock(_syncRoot) 
                    {
                        if(_repositoryInstance == null) 
                        {
                            _repositoryInstance = new DapperRepository("connectionName");
                        }
                    }
                } 
                return _repositoryInstance; 
            }
        }
    }
}