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
            var query = from message in _context.FandomMessages
                        where message.Title == title
                        select message;
            msgFound = query.First();
        }
        catch (Exception)
        {
            return null;
        }
        return msgFound;
    }

    public void AddMessage(Message new_message) {

        if (GetMessage(new_message.Title) == null)
        {
            _context.FandomMessages.Add(new_message);
            _context.SaveChanges();
        }
    }

    public void EditMessage(Login login, Message updatedmessage) {

        User? user = login.CurrentUser;
        if (user?.Username != updatedmessage.Sender.Username)
        {
            throw new ArgumentException("Only the creator of this message can modify it.");
        }
        
        //Verifying that the message wasnt sent
        if (updatedmessage.Sent != true)
        {
            _context.FandomMessages.Update(updatedmessage);
            _context.SaveChanges();
        } else {
            throw new ArgumentException("Can't edit a message that was already sent!");
        }
    }

}