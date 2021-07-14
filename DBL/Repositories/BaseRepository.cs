using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Repositories
{
    public abstract class BaseRepository
    {
        protected string _connString;

        public BaseRepository(string connectionString)
        {
            _connString = connectionString;
        }
        public string GetAllStatementbytenantcode(string tableName, string column)
        {
            return string.Format("Select * From {0} Where {1} = @Id", tableName, column);
        }
        public string FindStatementbytenantcode(string tableName, string idColumn)
        {
            return string.Format("Select * From {0} Where {1} = @Id", tableName, idColumn);
        }
        public string DeleteStatement(string tableName, string idColumn)
        {
            return string.Format("Delete From {0} Where {1} = @Id", tableName, idColumn);
        }

        public string FindStatementraw(string tableName, string idColumn)
        {
            return string.Format("Select * From {0} Where {1} = @Id", tableName, idColumn);
        }
        public string FindStatementOne(string tableName, string idColumn, string idColumnOne)
        {
            return string.Format("Select * From {0} Where {1} = @Id and {2} = @IdOne", tableName, idColumn, idColumnOne);
        }
        public string FindStatement(string tableName, string idColumn, int top)
        {
            return string.Format("Select top {2} * From {0} Where {1} = @Id", tableName, idColumn, top);
        }

        public string GetAllStatementbystatus(string tableName, string column)
        {
            return string.Format("Select * From {0} Where {1} = @Column", tableName, column);
        }

        public string GetAllStatement(string tableName, string idColumn)
        {
            return string.Format("Select * From {0} order by {1} desc", tableName, idColumn);
        }

        public string GetAllStatement(string tableName)
        {
            return string.Format("Select * From {0}", tableName);
        }

        public string GetAllStatement(string tableName, int top)
        {
            return string.Format("Select top {1} * From {0}", tableName, top);
        }

        public string UpdateStatement(string tableName, string column, string idColumn)
        {
            return string.Format("Update {0} Set {1}=@Column Where {2} = @Id", tableName, column, idColumn);
        }

        public string UpdateTwoTableStatement(string tableName, string column, string idColumn, string idColumn1)
        {
            return string.Format("Update {0} Set {1}=@Column Where {2} = @Id and {3}=@Id1", tableName, column, idColumn, idColumn1);
        }
        public string FindStatementone(string tableName, string idColumn, string idColumnone, string idColumntwo)
        {
            return string.Format("Select * From {0} Where {1} = @Id and {2} = @Idone and {3}=@Idtwo", tableName, idColumn, idColumnone, idColumntwo);
        }
    }
}
