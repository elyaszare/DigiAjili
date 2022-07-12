using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace BlogManagement.Infrastructure.Configuration
{
    internal class BlogPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new()
            {
                {
                    "Blog",
                    new List<PermissionDto>
                    {
                        new(BlogPermissions.CreateArticle, "CreateArticle"),
                        new(BlogPermissions.EditArticle, "EditArticle"),
                        new(BlogPermissions.ListArticles, "ListArticles"),
                        new(BlogPermissions.SearchArticle, "SearchArticle")
                    }
                }
            };
        }
    }
}
