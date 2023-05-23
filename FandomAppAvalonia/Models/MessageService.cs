using UserInfo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class MessageService {

    private static MessageService? _instance;
    private FanAppContext _context = null;
    public const int Iterations = 1000;
    private MessageService(){}

    public static MessageService getInstance(){
        if(_instance is null){
            _instance = new MessageService();
        }
        return _instance;
    }

    public void setFanAppContext(FanAppContext context){
        _context = context;
    }

    public Message GetMessage(string title) {

        Message? msgFound = null;
        try
        {
            msgFound = _context.MESSAGES
            .Include(msg=>msg.Sender)
            .Include(msg=>msg.Recipients)
            .Include(msg=>msg.Timesent)
            .Where(msg=>msg.Title == title)
            .ToList()
            .First<Message>();
            
        }
        catch (Exception)
        {
            return null;
        }
        return msgFound;
    }


    public void AddMessage(Message new_message) 
    {
        using (var context = new FanAppContext())
        {
            context.MESSAGES.Attach(new_message);
            context.SaveChanges();
        }
    }

    public void EditMessage(Login login, Message updatedmessage, string oldTitle) {

        User? user = login.CurrentUser;
        if (user?.Username != updatedmessage.Sender.Username){
            throw new ArgumentException("Only the creator of this message can modify it.");
        }
        
        //Verifying that the message wasn't sent
        using (_context = new FanAppContext())
        {
            if (updatedmessage.Sent != true)
            {
                _context.MESSAGES.Attach(updatedmessage);
                _context.SaveChanges();
            } 
            else {
                throw new ArgumentException("Can't edit a message that was already sent!");
            }
        }
        //Message? msgFound = null;
        //try
        //{
        //    var query = from message in _context.MESSAGES
        //                where message.Title == oldTitle
        //                select message;
        //    msgFound = query.First();
        //    msgFound.Title = updatedmessage.Title;
        //    msgFound.Text = updatedmessage.Text;
        //    _context.MESSAGES.Update(msgFound);
        //    _context.SaveChanges();
        //}
        //catch (Exception)
        //{
        //    throw new Exception("ERROR: DB ERROR");
        //}
        
    }

}