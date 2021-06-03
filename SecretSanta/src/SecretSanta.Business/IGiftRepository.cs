using SecretSanta.Data;
using System.Collections.Generic;

namespace SecretSanta.Business
{
    public interface IGiftRepository
    {
        Gift? GetItem(int id);
        
        bool Remove(int id);
        
        Gift Create(Gift item);
        
        void Save(Gift item);
        
        ICollection<Gift> List();
    }
}
