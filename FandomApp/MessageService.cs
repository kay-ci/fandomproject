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

    public void setLibraryContext(FanAppContext context){
        _context = context;
    }

    public Message GetMessage(Message mesg){
        var query = from msg in _context.FandomMessages
            where msg.Equals(mesg)
            select msg;
        var fetchedmsg = query.First<Message>();
        return fetchedmsg;
    }

    public UserMessage GetUserMessage(User usr){
        var query = from u_msg in _context.FandomUserMessages
            where u_msg.user.Equals(usr)
            select u_msg;
        var fetchedUMSG = query.First<UserMessage>();
        return fetchedUMSG;
    }

    public List<Message> GetBox(User usr, bool getInbox){
        var query = from u_msg in _context.FandomUserMessages
            where u_msg.user.Equals(usr)
            select u_msg;
        var fetchedUMSG = query.First<UserMessage>();
        if(getInbox) return fetchedUMSG.Inbox;
        return fetchedUMSG.Outbox;
    }

    public void Add_UserMessage(User user){
        var user_message = new UserMessage(user);

        _context.FandomUserMessages.Add(user_message);
        _context.SaveChanges();
    }

    public void Add_Message(Message msg){
        _context.FandomMessages.Add(msg);
        _context.SaveChanges();
    }

    public void Edit_Message(Message message, string new_text, string new_title){
        var query = from msg in _context.FandomMessages
            where msg.Equals(message)
            select msg;
        var fetchedmsg = query.First<Message>();
        fetchedmsg.Text = new_text;
        fetchedmsg.Title = new_title;
        _context.SaveChanges();
    }

    public void Delete_Message(Message message){
        var query = from msg in _context.FandomMessages
            where msg.Equals(message)
            select msg;
        var fetchedmsg = query.First<Message>();
        _context.FandomMessages.Remove(fetchedmsg);
        _context.SaveChanges();
    }
}