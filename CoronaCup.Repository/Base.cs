using System;
namespace Agrisol.Repository.SqlServer
{
    public class RepositoryBase : IDisposable 
    { 
        public DatabaseConnection _db { get; } 
        public RepositoryBase() 
        { 
            _db = new DatabaseConnection(extraFieldsInTable());
        } 
        public RepositoryBase(DatabaseConnection db) 
        {
            _db = new DatabaseConnection(db, extraFieldsInTable()); UserId = db.ExtraFieldsInTable.UserId;
        } 
        private int _userId; 
        public int UserId 
        { 
            get { return _userId; } 
            set { _userId = value; 
                  _db.ExtraFieldsInTable.UserId = value;
            } 
        } 
        private ExtraFieldsInTable extraFieldsInTable() => new ExtraFieldsInTable(this);
        #region Dispose 		
        public void Dispose()         
        {             
            Dispose(true);             
            GC.SuppressFinalize(this);         
        }          
        protected virtual void Dispose(bool disposing)         
        {             
            if (disposing)             
            {                 
                _db.Dispose();             
            }         
        }          
        ~RepositoryBase()         
        {             
            Dispose(false);         
        } 		
        #endregion 	
    } 
}