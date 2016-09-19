using System.Linq;
using NGDemo_Models.DBModels;
using NGDemo_Models.Models.Base;
using NGDemo_Models.Models.Demo;
using NGDemo_Repository.Base;

namespace NGDemo_Repository
{
    public class RTaiwanAir : Command
    {
        public RTaiwanAir() : base() { }

        public IQueryable<TaiwanAir> Select(SearchModel SearchModel, ref Result Result)
        {
            string sql = @"
SELECT *
FROM [dbo].[TaiwanAir]";

            return ExecuteQuery<SearchModel, TaiwanAir>(sql, SearchModel, out Result);
        }

        public int Insert(TaiwanAir DBModel, ref Result Result)
        {
            string sql = @"
INSERT INTO [dbo].[TaiwanAir]	
		([TaiwanAir_SiteName], [TaiwanAir_County], [TaiwanAir_Status])
VALUES	(@TaiwanAir_SiteName, @TaiwanAir_County, @TaiwanAir_Status)";

            return ExecuteNonQuery(sql, DBModel, out Result);
        }

        public int Update(TaiwanAir DBModel, ref Result Result)
        {
            string sql = @"
UPDATE  [dbo].[TaiwanAir]	
SET     [TaiwanAir_SiteName] = @TaiwanAir_SiteName,
        [TaiwanAir_County] = @TaiwanAir_County,
        [TaiwanAir_Status] = @TaiwanAir_Status
WHERE   [TaiwanAir_ID] = @TaiwanAir_ID";

            return ExecuteNonQuery(sql, DBModel, out Result);
        }

        public int Delete(TaiwanAir DBModel, ref Result Result)
        {
            string sql = @"
DELETE FROM [dbo].[TaiwanAir]
WHERE       [TaiwanAir_ID] = @TaiwanAir_ID";

            return ExecuteNonQuery(sql, DBModel, out Result);
        }
    }
}
