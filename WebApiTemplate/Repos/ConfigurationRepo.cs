using WebApiTemplate.DataAccess;
using WebApiTemplate.Infrastructure;

namespace WebApiTemplate.Repos;

public class ConfigurationRepo(AppConfiguration config, Db db) : BaseRepo(config, db)
{
    
}
