using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserInfo{

    //This class will contain the Inbox and Outbox, which are Lists containing Message objects
    //It will be linked to the fan by the "user" field
    public class UserMessage
    {
        public int UserMessageId {get; set;}
        
        [ForeignKey("userID")]
        public User Owner {get; set;}
        public List<Message> Inbox {get; set;} = new();
        public List<Message> Outbox {get; set;} = new();

        //Here we have two constructors. This one is for the DBContext
        private UserMessage(){}
        //This one is for a completely new user
        public UserMessage(User owner){
            this.Owner = owner;
            //Inbox = new List<Message>();
            //Outbox = new List<Message>();
        }
            //We check if the text is null or empty
        //public Message CreateMessage(string text, string title, List<UserMessage>? recipients = null, UserMessage? recipient = null){
        //    if(string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must be filled with text!");
        //    if(recipients != null){
        //        //Create the message and add it to our Outbox
        //        Message newMsg = new Message(this.Owner.Messages, recipients, text, title);
        //        Outbox.Add(newMsg);
        //        //Here we would add the message to the recipients Inboxes
        //        foreach(UserMessage recip in recipients){
        //            recip.AddMessage(newMsg);
        //        }
        //        return newMsg;
        //    }else if(recipient != null){
        //        Message newMsg = new Message(this.Owner.Messages, recipient, text, title);
        //        Outbox.Add(newMsg);
        //        //Here we would add the message to the recipient's Inbox
        //        recipient.AddMessage(newMsg);
        //        return newMsg;
        //    }else {
        //        throw new ArgumentException("ERROR, both recipient and recipients are null. How did we get here?");
        //    }
//
        //}

        //This message basically takes an index to extract a Message object from the Inbox
        //Afterwards, we set the bool for if the message has been read to true using MessageIsRead()
        //Finally, we return the text inside of the message. Needs validation for the index
        public string ReadMessage(int index){
            if(index >= this.Inbox.Count){
                throw new ArgumentException("ERROR, index given is larger than amount of messages this user has in their Inbox");
            }
            Inbox[index].MarkAsRead();
            return Inbox[index].Text;
        }

        //This method will simply add a new Message object to the Inbox
        //Used for when other users send this user a message
        public void AddInboxMessage(Message message)
        {
            if (!message.Recipients.Contains(this.Owner))
            {
                throw new ArgumentException("The user is not a recipient. Can't add to Inbox");
            }
            this.Inbox?.Add(message);
        }


        public void AddOutboxMessage(Message message)
        {
            if (message.Sender != this.Owner){
                throw new ArgumentException("The message was not sent by this user. Can't add to Outbox");
            }
            this.Outbox?.Add(message);
        }

        //This method sorts all of the messages by their title in alphabetical order
        //or by date sent (oldest or newest first)
        //public void SortMessages(bool sortInbox, bool sortByDate, bool newestFirst){
//
        //    if(sortInbox){
        //        if(sortByDate && newestFirst){
        //            //This will sort out the list of messages by newest to oldest
        //            Inbox.Sort((x, y) => DateTime.Compare(x.Timesent, y.Timesent));
        //        }else if(sortByDate && newestFirst == false){
        //            //This will sort out the list of messages by oldest to newest
        //            Inbox.Sort((x, y) => DateTime.Compare(y.Timesent, x.Timesent));
        //        }else {
        //            //This will sort out the list of messages by title in alphabetical order
        //            Inbox.Sort((x, y) => String.Compare(x.Title, y.Title));
        //        }
        //    }else {
        //        if(sortByDate && newestFirst){
        //            //This will sort out the list of messages by newest to oldest
        //            Outbox.Sort((x, y) => DateTime.Compare(x.Timesent, y.Timesent));
        //        }else if(sortByDate && newestFirst == false){
        //            //This will sort out the list of messages by oldest to newest
        //            Outbox.Sort((x, y) => DateTime.Compare(y.Timesent, x.Timesent));
        //        }else {
        //            //This will sort out the list of messages by title in alphabetical order
        //            Outbox.Sort((x, y) => String.Compare(x.Title, y.Title));
        //        }
        //    }
//
        //}
        
        public override bool Equals(object? obj){
            var item = obj as UserMessage;
            if(ReferenceEquals(item, this)){
                return true;
            }
            if(item == null){
                return false;
            }
            return (
                this.Owner == item.Owner &&
                this.Inbox.SequenceEqual(item.Inbox) &&
                this.Outbox.SequenceEqual(item.Outbox)
            );
        }
    }
}