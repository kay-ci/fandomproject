using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserInfo{

    //This class will contain the Inbox and Outbox, which are Lists containing Message objects
    //It will be linked to the fan by the "user" field
    public class UserMessage{
        public int userID {get; set;}
        public User user {get; set;}

        [InverseProperty("Recipients")]
        public List<Message> Inbox {get; set;}
        [InverseProperty("Sender")]
        public List<Message> Outbox {get; set;}

        //Here we have two constructors. This one is for the DBContext
        private UserMessage(){}
        //This one is for a completely new user
        public UserMessage(User user){
            this.user = user;
            Inbox = new List<Message>();
            Outbox = new List<Message>();
        }
        public void CreateMessage(List<UserMessage> recipients, string text, string title){
            //We check if the text is null or empty
            if(string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must be filled with text!");
            //Create the message and add it to our Outbox
            Message newMsg = new Message(this.user.Messages, recipients, text, title);
            Outbox.Add(newMsg);
            //Here we would add the message to the recipients Inboxes... probably will use the AddMessage method below
            //So, something like:
            foreach(UserMessage recipient in recipients){
                recipient.AddMessage(newMsg);
            }

        }

        //This message basically takes an index to extract a Message object from the Inbox
        //Afterwards, we set the bool for if the message has been read to true using MessageIsRead()
        //Finally, we return the text inside of the message. Needs validation for the index
        public string ReadMessage(int index){
            if(index >= this.Inbox.Count){
                throw new ArgumentException("ERROR, index given is larger than amount of messages this user has in their Inbox");
            }
            Inbox[index].MessageIsRead();
            return Inbox[index].Text;
        }

        //This method will simply add a new Message object to the Inbox
        //Used for when other users send this user a message
        public void AddMessage(Message newMsg){
            this.Inbox.Add(newMsg);
        }

        //This method sorts all of the messages by their title in alphabetical order
        //or by date sent (oldest or newest first)
        public void SortMessages(bool sortInbox, bool sortByDate, bool newestFirst){

            if(sortInbox){
                if(sortByDate && newestFirst){
                    //This will sort out the list of messages by newest to oldest
                    Inbox.Sort((x, y) => DateTime.Compare(x.Timesent, y.Timesent));
                }else if(sortByDate && newestFirst == false){
                    //This will sort out the list of messages by oldest to newest
                    Inbox.Sort((x, y) => DateTime.Compare(y.Timesent, x.Timesent));
                }else {
                    //This will sort out the list of messages by title in alphabetical order
                    Inbox.Sort((x, y) => String.Compare(x.Title, y.Title));
                }
            }else {
                if(sortByDate && newestFirst){
                    //This will sort out the list of messages by newest to oldest
                    Outbox.Sort((x, y) => DateTime.Compare(x.Timesent, y.Timesent));
                }else if(sortByDate && newestFirst == false){
                    //This will sort out the list of messages by oldest to newest
                    Outbox.Sort((x, y) => DateTime.Compare(y.Timesent, x.Timesent));
                }else {
                    //This will sort out the list of messages by title in alphabetical order
                    Outbox.Sort((x, y) => String.Compare(x.Title, y.Title));
                }
            }

        }
    }
}