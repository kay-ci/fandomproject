# FandomApp
**TEAMWORK AGREEMENTS**
What will you do to ensure your code is readable?
- adding comments
- proper tabbing and spacing 
- appropriate variable names and constants

What procedure will you put in place to ensure committed code is functional?
we will test and debug methods as we implement them.

How do you plan to test your code?
unit testing and debugging, writing a test class which we will use for our test class later on.

How do you plan to divide the work?


**PROFILES**
yes we are changing flavour to a fandom app 

Classes used:
user:
- username
- Profile
- List<Event> events
- UserMessages messages
- ChangePassword()
- DeleteAccount()
- ChangeUsername()
- RegisterAccount()
- GetEvents()


Profiles:
- name
- pronouns
- age
- school -> country
- program -> city
- courses -> List of categories (art, gaming, music)
- specific courses -> list of Fandom (specific artist, games, music artist)
- niche interest for a fandom
- list of badges (optional for implementation)
- description
- profile picture
- A list of other interest and hobbies
- CreateProfile()
- EditProfile()
- ClearProfile()

Fandom: 
- FandomName


Events:
- EventTitle
- Date (date and time)
- location
- List of Fandoms and categories
- ageRequirement
- User Owner
- List<User> attendees
- CreateEvent()
- EditEvent() (check owner is the one editing)
- AddUser() 
- RemoveUser()
- ShowAttendees()

Message:
- int id
- User Sender
- List<user> Recipient 
- TimeSent 
- Text
- bool seen

UserMessages:
- List<Message> Inbox
- List<Message> Outbox
- CreateMessage() 
- ReadMessage()
- SortMessages()



events will be age specific 
over 13 to create a user.

**EVENTS**

Messsage class :
sender 
receiver 
messsage
bool read

usermessages : manage 
2 lists<Message> (inbox, sent)
user id

SendMessage()
ReadMessage()
