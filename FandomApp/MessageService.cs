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

    public Message GetMessage(int MessageId){
        var query = from msg in _context.FandomMessages
            where msg.Id == MessageId
            select msg;
        var fetchedmsg = query.First<Message>();
        return fetchedmsg;
    }

    public UserMessage GetUserMessage(User usr){
        var query = from u_msg in _context.FandomUserMessages
            where u_msg.user == usr
            select u_msg;
        var fetchedUMSG = query.First<UserMessage>();
        return fetchedUMSG;
    }

    public List<Message> GetBox(User usr, bool getInbox){
        var query = from u_msg in _context.FandomUserMessages
            where u_msg.user == usr
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

    public void Add_Message(UserMessage sender, List<UserMessage> recipients, string text, string title){
        var msg = new Message(sender, recipients, text, title);

        _context.FandomMessages.Add(msg);
        _context.SaveChanges();
    }

    public void Edit_Message(Message message){
        var text = message.Text;
        var title = message.Title;
        var query = from msg in _context.FandomMessages
            where msg.Title == title
            select msg;
        var fetchedmsg = query.First<Message>();
        fetchedmsg.Text = text;
        fetchedmsg.Title = title;
        _context.SaveChanges();
    }

    public void Delete_Message(Message msg){
        _context.FandomMessages.Remove(msg);
        _context.SaveChanges();
    }
}