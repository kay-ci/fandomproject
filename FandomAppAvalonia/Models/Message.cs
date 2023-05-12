using System.ComponentModel.DataAnnotations.Schema;

namespace UserInfo{
    public class Message
    {
        private string _text;
        private string _title;
        public int MessageID {get; set;}

        [ForeignKey("UserID")]
        public User Sender {get; set;}

        public List<User>? Recipients {get; set;} = new();

        public DateTime Timesent {get; set;}
        public string Text {
            get{return _text;} 
            set{ 
                if (!IsValid(value)){
                    throw new ArgumentException("Text property cannot be null or whitespace");
                }
                _text = value;
            }
        }
        public string Title {
            get{return _title;} 
            set{
                if (!IsValid(value)){
                    throw new ArgumentException("Title cannot be null or whitespace");
                }
                _title = value;
            }
        }
        //This field determines if the message has been read or not. Will get updated by UserMessage
        public bool Seen {get; set;}
        public bool Sent {get; set;}

        private Message(){}

        //Constructor for list of recipients
        public Message(User sender, List<User> recipients, string title, string text) {
            
            this.Sender = sender;
            this.Timesent = DateTime.Now;
            this.Text = text;
            this.Title = title;
            this.Seen = false;
            this.Sent = false;
            this.Recipients = recipients;
        }

        //Constructor for one recipient
        public Message(User sender, User recipient, string title, string text) {
            
            this.Sender = sender;
            this.Timesent = DateTime.Now;
            this.Text = text;
            this.Title = title;
            this.Seen = false;
            this.Sent = false;
            this.Recipients.Add(recipient);
        }

        public void MarkAsRead()
        { 
            this.Seen = true; 
        }

        public void MarkAsSent()
        { 
            this.Sent = true; 
        }
    
        public bool IsValid(string field){
            if (string.IsNullOrWhiteSpace(field)){
                return false;
            }
            return true;
        }
        
        public override bool Equals(object? obj){
            var item = obj as Message;
            if(ReferenceEquals(item, this)){
                return true;
            }
            if(item == null){
                return false;
            }
            return (
                this.Text == item.Text &&
                this.Title == item.Title &&
                this.Sender == item.Sender &&
                this.Recipients.SequenceEqual(item.Recipients) &&
                this.Timesent == item.Timesent
            );
        }
    }
}