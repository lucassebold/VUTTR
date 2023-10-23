using Azure;
using VUTTR.Domain.DTO;
using VUTTR.Domain.Entities.Tags;
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

        public List<ToolDto> List(List<string> tags)
        {

            var lista = new List<ToolDto>();
            try
            {
                var query = $@"SELECT DISTINCT t.*
                              FROM dbo.Tool t
                              INNER JOIN dbo.Tag tag
                              ON t.Codigo = tag.CodigoTool";

                if (tags.Count > 0)
                    query += " WHERE tag.Nome IN @Tags";
                var queryResult = _dbContext.ExecuteQuery<ToolDto>(query, new { Tags = tags }).ToList();

                var queryTags = $@"SELECT tags.Nome, tags.CodigoTool
                                    FROM dbo.Tag tags";
                var tagsResult = _dbContext.ExecuteQuery<TagsDTO>(queryTags, new { Tags = tags }).ToList();

                queryResult.ForEach(item =>
                {
                    if (!item.Equals(null))
                    {
                        item.Tags = new List<string>();
                        if (!lista.Contains(item))
                            lista.Add(item);

                        if (!tagsResult.Equals(null) && tagsResult.Any())
                        {
                            var nomeTags = tagsResult.Where(t => t.CodigoTool == item.Codigo).Select(x => x.Nome);
                            item.Tags.AddRange(nomeTags);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return lista;
        }

        public void Create(ToolRequest tool)
        {
            try
            {
                var codigoTool = Guid.NewGuid();
                var query = @" INSERT 
                            INTO dbo.Tool
                            (Title, Link, Description, Codigo)
                            VALUES
                            (@p0, @p1, @p2, @p3)";
                _dbContext.Execute(query, new { p0 = tool.Title, p1 = tool.Link, p2 = tool.Description, p3 = codigoTool });

                tool.Tags.ForEach(tag =>
                {
                    var queryTag = @" INSERT 
                                    INTO dbo.Tag
                                    (Nome, CodigoTool)
                                    VALUES
                                    (@p0, @p1)";
                    _dbContext.Execute(queryTag, new { p0 = tag, p1 = codigoTool });
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void Delete (ToolRequest tool)
        {
            var query = @"DELETE
                          FROM dbo.Tool  
                          WHERE Id = @p0";
            _dbContext.Execute(query, new { p0 = tool.Id });
        }
    }
}
