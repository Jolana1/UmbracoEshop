using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbracoEshop.lib.Repositories
{
    public class VyrobcaRepository : _BaseRepository
    {
        public Page<Vyrobca> GetPage(long page, long itemsPerPage, string sortBy = "nazovVyrobcu", string sortDir = "ASC", VyrobcaFilter filter = null)
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

            return GetPage<Vyrobca>(page, itemsPerPage, sql);
        }

        public Vyrobca Get(Guid key)
        {
            var sql = GetBaseQuery().Where(GetBaseWhereClause(), new { Key = key });

            return Fetch<Vyrobca>(sql).FirstOrDefault();
        }

        public bool Save(Vyrobca dataRec)
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

        bool Insert(Vyrobca dataRec)
        {
            dataRec.pk = Guid.NewGuid();

            object result = InsertInstance(dataRec);
            if (result is Guid)
            {
                return (Guid)result == dataRec.pk;
            }

            return false;
        }

        bool Update(Vyrobca dataRec)
        {
            return UpdateInstance(dataRec);
        }

        public bool Delete(Vyrobca dataRec)
        {
            return DeleteInstance(dataRec);
        }

        Sql GetBaseQuery()
        {
            return new Sql(string.Format("SELECT * FROM {0}", Vyrobca.DbTableName));
        }

        string GetBaseWhereClause()
        {
            return string.Format("{0}.pk = @Key", Vyrobca.DbTableName);
        }
        string GetSearchTextWhereClause(string searchText)
        {
            return string.Format("{0}.producerName LIKE '%{1}%' collate Latin1_general_CI_AI OR {0}.producerDescription LIKE '%{1}%' collate Latin1_general_CI_AI OR {0}.producerWeb LIKE '%{1}%' collate Latin1_general_CI_AI", Vyrobca.DbTableName, searchText);
        }
    }


    [TableName(Vyrobca.DbTableName)]
    [PrimaryKey("pk", AutoIncrement = false)]
    public class Vyrobca : _BaseRepositoryRec
    {
        public const string DbTableName = "eshopVyrobca";

        public string NazovVyrobcu { get; set; }
        //public string ProducerDescription { get; set; }
        //public string ProducerWeb { get; set; }
    }

    public class VyrobcaFilter
    {
        public string SearchText { get; set; }
    }
}
