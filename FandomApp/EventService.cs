using UserInfo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class EventService
{
    private FanAppContext _context = null!;
    public EventService() 
    {
    }

    public void setLibraryContext(FanAppContext context) 
    {
        _context = context;
    }
    
}