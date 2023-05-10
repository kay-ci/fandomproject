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

    public void Add_Message(Message msg) {
        _context.FandomMessages.Add(msg);
        _context.SaveChanges();
    }

    public void Edit_Message(Message message, string new_text, string new_title) {
        var query = from msg in _context.FandomMessages
            where msg.Equals(message)
            select msg;
        var fetchedmsg = query.First<Message>();
        fetchedmsg.Text = new_text;
        fetchedmsg.Title = new_title;
        _context.SaveChanges();
    }
    public void Delete_Message(Message message) {
        _context.FandomMessages.Remove(message);
        _context.SaveChanges();
    }

    //public UserMessage GetUserMessage(User usr){
    //    var query = from u_msg in _context.FandomUserMessages
    //        where u_msg.Owner.Equals(usr)
    //        select u_msg;
    //    var fetchedUMSG = query.First<UserMessage>();
    //    return fetchedUMSG;
    //}

    //public List<Message> GetBox(User usr, bool getInbox){
    //    var query = from u_msg in _context.FandomUserMessages
    //        where u_msg.Owner.Equals(usr)
    //        select u_msg;
    //    var fetchedUMSG = query.First<UserMessage>();
    //    if(getInbox) return fetchedUMSG.Inbox;
    //    return fetchedUMSG.Outbox;
    //}

    //public void Add_UserMessage(User user){
    //    var user_message = user.Messages;
//
    //    _context.FandomUserMessages.Add(user_message);
    //    _context.SaveChanges();
    //}

    

    //public void Update_UserMessage(User user){
    //    var user_message = new UserMessage(user);
    //    var query = from u_msg in _context.FandomUserMessages
    //        where u_msg.Owner.Equals(user)
    //        select u_msg;
    //    var fetchedUMSG = query.First<UserMessage>();
    //    
    //    fetchedUMSG.Inbox = new List<Message>();
    //    fetchedUMSG.Outbox = new List<Message>();
    //    foreach(Message msg in user_message.Inbox) fetchedUMSG.Inbox.Add(msg);
    //    foreach(Message msg in user_message.Outbox) fetchedUMSG.Outbox.Add(msg);
    //    _context.SaveChanges();
    //}

    

    //public void Delete_UserMessage(UserMessage u_msg){
    //    _context.FandomUserMessages.Remove(u_msg);
    //    _context.SaveChanges();
    //}

    
}