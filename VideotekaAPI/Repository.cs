using VideotekaAPI.Models;
namespace VideotekaAPI;

public class Repository : IRepository
{
    private readonly IConfiguration _configuration;

    public Repository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public List<Pozajmica> GetPozajmice()
    {
        using (var context = new ApiContext(_configuration))
        {
            var list = context.Pozajmicas
                .ToList();
            return list;
        }
    }
    public Pozajmica? GetPozajmicaById(int id)
    {
        using (var context = new ApiContext(_configuration))
        {
            var pozajmica = context.Pozajmicas
                .Where(a => a.Id == id)
                .FirstOrDefault();
            return pozajmica;

        }
    }
    public ResponseDetail CreatePozajmica(Pozajmica pozajmica)
    {
        try
        {
            using (var context = new ApiContext(_configuration))
            {
                context.Pozajmicas.Add(pozajmica);
                context.SaveChanges();
            }
            return new ResponseDetail(true);
        }
        catch (Exception ex)
        {
            return new ResponseDetail(false, ex.Message, ex);
        }
    }

    public ResponseDetail DeletePozajmica(int id)
    {
        try
        {
            using (var context = new ApiContext(_configuration))
            {
                var pozajmica = context.Pozajmicas.Find(id);
                if (pozajmica == null)
                    return new ResponseDetail(false, "User not found!", null);

                context.Pozajmicas.Remove(pozajmica);
                context.SaveChanges();
            }
            return new ResponseDetail(true);
        }
        catch (Exception ex)
        {
            return new ResponseDetail(false, ex.Message, ex);
        }
    }
    public ResponseDetail UpdatePozajmica(Pozajmica pozajmica)
    {
        try
        {
            using (var context = new ApiContext(_configuration))
            {
                bool isExist = context.Pozajmicas.Any(x => x.Id == pozajmica.Id);
                if (!isExist)
                    return new ResponseDetail(false, "User not found!", null);

                context.Update(pozajmica);
                context.SaveChanges();
            }
            return new ResponseDetail(true);
        }
        catch (Exception ex)
        {
            return new ResponseDetail(false, ex.Message, ex);
        }
    }
    
}