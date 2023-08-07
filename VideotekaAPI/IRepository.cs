using VideotekaAPI.Models;

namespace VideotekaAPI;

public interface IRepository
{
    public List<Pozajmica> GetPozajmice();
    public Pozajmica? GetPozajmicaById(int id);
    public ResponseDetail CreatePozajmica(Pozajmica user);
    public ResponseDetail DeletePozajmica(int id);
    public ResponseDetail UpdatePozajmica(Pozajmica user);
}
