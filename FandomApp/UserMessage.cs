using Microsoft.EntityFrameworkCore;

namespace UserInfo{

    //This class will contain the Inbox and Outbox, which are Lists containing Message objects
    //It will be linked to the fan by the "user" field
    public class UserMessage{
        public int userID {get; set;}
        public User user {get; set;}

        public List<Message> Inbox {get; set;}
        public List<Message> Outbox {get; set;}

        //Here we have three constructors. This one is for the DBContext
        private UserMessage(){}
        //This one is for a completely new user
        public UserMessage(User user){
            this.user = user;
            Inbox = new List<Message>();
            Outbox = new List<Message>();
        }
        //This method would be used when we are taking a user from the database.
        //Because they already exist, they would have an Inbox and an Outbox already
        public UserMessage(User user, List<Message> inbox, List<Message> outbox){
            this.user = user;
            Inbox = new List<Message>();
            Outbox = new List<Message>();
            foreach(Message msg in inbox){ this.Inbox.Add(msg);}
            foreach(Message msg in outbox){ this.Outbox.Add(msg);}
        }

        public void CreateMessage(List<User> recipients, string text){
            //We check if the text is null or empty
            if(string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must be filled with text!");
            //Create the message and add it to our Outbox
            Message newMsg = new Message(this.user, recipients, text);
            Outbox.Add(newMsg);
            //Here we would add the message to the recipients Inboxes... probably will use the AddMessage method below
            //So, something like:
            foreach(User recipient in recipients){
                recipient.Messages.AddMessage(newMsg);
            }

        }

        //This message basically takes an index to extract a Message object from the Inbox
        //Afterwards, we set the bool for if the message has been read to true using MessageIsRead()
        //Finally, we return the text inside of the message. Needs validation for the index
        public string ReadMessage(int index){
            Inbox[index].MessageIsRead();
            return Inbox[index].text;
        }

        //This method will simply add a new Message object to the Inbox
        //Used for when other users send this user a message
        public void AddMessage(Message newMsg){
            this.Inbox.Add(newMsg);
        }

        //This method sorts all of the messages by alphabet (of the sender's name)
        //or by date sent (oldest or newest first)
        public void SortMessages(){}
    }
}