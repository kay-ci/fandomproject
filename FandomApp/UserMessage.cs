namespace userInfo{
    //This class is filled out a little more than a skeleton class, we decided to get a lil headstart

    //This class will contain the Inbox and Outbox, which are Lists containing Message objects
    //It will be linked to the fan by the "user" field
    public class UserMessage{
        private User user;

        private List<Message> Inbox = new List<Message>();
        private List<Message> Outbox = new List<Message>();

        //Here we have two constructors. This one is for a completely new user
        public UserMessage(User user){
            this.user = user;
        }
        //This method would be used when we are taking a user from the database.
        //Because they already exist, they would have an Inbox and an Outbox already
        public UserMessage(User user, List<Message> Inbox, List<Message> Outbox){
            this.user = user;
            foreach(Message msg in Inbox){ this.Inbox.Add(msg); }
            foreach(Message msg in Outbox){ this.Outbox.Add(msg); }
        }

        //This is the most difficult method for this class. Essentially, we confirm with the user
        //the list of recipients they want to send it to (wip) and then make them write down
        //the text for the message. Once it is written, we confirm if the user wants to send the
        //message. If they do, we update this user's Outbox and the recipients' Inbox
        public void CreateMessage(List<User> recipients, string text){
            // Commented code is to be removed?

            // //This is where we ask the user for the recipients, for now we just take them in as an argument
            // Console.WriteLine($"You ({this.user.UserName}) are currently sending to: \n");
            // foreach(User recipient in recipients){
            //     Console.WriteLine($"    {recipient.UserName}\n");
            // }
            // //Now we make the user write the message should add validation to check if text is empty
            // Console.WriteLine("Now please write down the text you want to send:");
            // string text = Console.ReadLine();
            // Console.WriteLine("Are you sure you want to send this? Y/y or N/n");
            // //Here is some validation to make sure the user gives an appropriate answer for the above question
            // bool isAnswered = false;
            // while(isAnswered == false){
            //     string answer = Console.ReadLine();
            //     //If they answer no, the method will return nothing, ending it
            //     if(answer.Equals("N") || answer.Equals("n")) {return;}
            //     //If yes, we get out of the loop and continue
            //     if(answer.Equals("Y") || answer.Equals("y")){
            //         isAnswered = true;
            //         break;
            //     }
            //     //If they put some other answer or didn't type anything, we ask them to retype the answer
            //     Console.WriteLine("Please type Y or y for yes. N or n for no !");
            // }

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