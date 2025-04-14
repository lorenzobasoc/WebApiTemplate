using WebApiTemplate.DataAccess;
using WebApiTemplate.Infrastructure;

namespace WebApiTemplate.Repos;

public class BaseRepo(AppConfiguration config, Db db)
{
    protected readonly AppConfiguration _config = config;
    protected readonly Db _db = db;
}
