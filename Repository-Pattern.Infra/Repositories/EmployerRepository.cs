using Dapper;
using Repository_Pattern.Domain.Entities;
using Repository_Pattern.Domain.Repositories;
using Repository_Pattern.Infra.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository_Pattern.Infra.Repositories
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly IDB _db;

        public EmployerRepository(IDB db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Employer>> GetAll()
        {
            var sql = "SELECT * FROM EMPLOYER";

             using(var dbCon = _db.GetConnection())
            {
                var employer = await dbCon.QueryAsync<Employer>(sql);
                return employer;
            }
        }

        public async Task<Employer> GetById(Guid id)
        {
            var sql = "SELECT * FROM EMPLOYER WHERE id=@id";

            using (var dbCon = _db.GetConnection())
            {
                var employer = await dbCon.QueryAsync<Employer>(sql, new { id });
                return employer.FirstOrDefault();
            }
        }

        public void Add(Employer employer)
        {
            var sql = "	INSERT INTO [dbo].[Employer]          " +
                        "	           ([Id]					  " +
                        "	           ,[Name]					  " +
                        "	           ,[Email]					  " +
                        "	           ,[Document])				  " +
                        "	     VALUES							  " +
                        "	           (@Id						  " +
                        "	           ,@Name					  " +
                        "	           ,@Email 					  " +
                        "	           ,@Document)				  ";

            using (var dbCon = _db.GetConnection())
            {
                dbCon.Execute(sql, new
                {
                    @Id = employer.Id,
                    Name = employer.Name,
                    Email = employer.Email,
                    Document = employer.Document
                });
            }
        }

        public void Update(Employer employer)
        {
            var sql = "   UPDATE [dbo].[Employer] SET    " +
                        "          [Name]= @Name			   " +
                        "         ,[Email] =  @Email	   " +
                        "         ,[Document] = @Document  " +
                        "    WHERE [Id] =@Id			   ";

            using (var dbCon = _db.GetConnection())
            {
                dbCon.Execute(sql, new
                {
                    @Id = employer.Id,
                    @Name = employer.Name,
                    @Email = employer.Email,
                    @Document = employer.Document
                });
            }
        }
        public void Delete(Guid id)
        {
            var sql = "DELETE FROM [dbo].[Employer] Where Id=@Id";

            using (var Dbcon = _db.GetConnection())
            {
                Dbcon.Execute(sql, new { id });
            }
        }

    }
}
