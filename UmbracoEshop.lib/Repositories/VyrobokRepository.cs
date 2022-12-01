using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbracoEshop.lib.Repositories
{
    public class VyrobokRepository : _BaseRepository
    {
        public Page<Vyrobok> GetPage(long page, long itemsPerPage, string sortBy = "nazovVyrobku", string sortDir = "ASC", VyrobokFilter filter = null)
        {
            var sql = GetBaseQuery();
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.SearchText))
                {
                    sql.Where(GetSearchTextWhereClause(filter.SearchText), new { SearchText = filter.SearchText });
                }
            }
            sql.Append(string.Format("ORDER BY {0} {1}", sortBy, sortDir));

            return GetPage<Vyrobok>(page, itemsPerPage, sql);
        }

        public Vyrobok Get(Guid key)
        {
            var sql = GetBaseQuery().Where(GetBaseWhereClause(), new { Key = key });

            return Fetch<Vyrobok>(sql).FirstOrDefault();
        }

        public bool Save(Vyrobok dataRec)
        {
            if (IsNew(dataRec))
            {
                return Insert(dataRec);
            }
            else
            {
                return Update(dataRec);
            }
        }

        bool Insert(Vyrobok dataRec)
        {
            dataRec.pk = Guid.NewGuid();

            object result = InsertInstance(dataRec);
            if (result is Guid)
            {
                return (Guid)result == dataRec.pk;
            }

            return false;
        }

        bool Update(Vyrobok dataRec)
        {
            return UpdateInstance(dataRec);
        }

        public bool Delete(Vyrobok dataRec)
        {
            return DeleteInstance(dataRec);
        }

        Sql GetBaseQuery()
        {
            return new Sql(string.Format("SELECT * FROM {0}", Vyrobok.DbTableName));
        }

        string GetBaseWhereClause()
        {
            return string.Format("{0}.pk = @Key", Vyrobok.DbTableName);
        }
        string GetSearchTextWhereClause(string searchText)
        {
            return string.Format("{0}.producerName LIKE '%{1}%' collate Latin1_general_CI_AI OR {0}.producerDescription LIKE '%{1}%' collate Latin1_general_CI_AI OR {0}.producerWeb LIKE '%{1}%' collate Latin1_general_CI_AI", Vyrobok.DbTableName, searchText);
        }
    }


    [TableName(Vyrobok.DbTableName)]
    [PrimaryKey("pk", AutoIncrement = false)]
    public class Vyrobok : _BaseRepositoryRec
    {
        public const string DbTableName = "eshopVyrobok";
        public string KodVyrobku { get; set; }
        public string NazovVyrobku { get; set; }
        public decimal CenaVyrobku { get; set; }

        public string PopisVyrobku { get; set; }


        //public string ProducerDescription { get; set; }
        //public string ProducerWeb { get; set; }
    }

    public class VyrobokFilter
    {
        public string SearchText { get; set; }
    }
}
