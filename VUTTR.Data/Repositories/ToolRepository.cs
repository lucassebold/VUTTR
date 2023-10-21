using VUTTR.Domain.DTO;
using VUTTR.Domain.Interfaces.Repositories;

namespace VUTTR.Data.Repositories
{
    public class ToolRepository : IToolRepository
    {
        private readonly DbContext _dbContext;
        public ToolRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ToolDto> List(string tag)
        {
            var lista = new List<ToolDto>();
            try
            {
                var query = $@"SELECT * 
                            FROM dbo.Tool tool
                            INNER JOIN dbo.Tag tag
                            ON tag.Name = @Tag
                            WHERE tool.Id = tag.ToolId";
        
                lista = _dbContext.ExecuteQuery<ToolDto>(query, new { Tag = tag }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return lista;
        }
    }
}
