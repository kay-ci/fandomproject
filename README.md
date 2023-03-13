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
Karekin: UserMessages and Message
Kayci: User and Profile
Fred: Fandom, Search and Events
Everyone: Utilities

How will you ensure that your application is robust and does not fail due to user errors?
Lots of validation provided by the Utilities class

How will you ensure you have stand alone classes can be tested?
Our Utilities class is a stand alone class that will be unit tested

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
- ToString()
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
- ToString()
- ClearProfile()

Fandom: 
- FandomName
- Category
- Description
- Picture
- ToString()

// Events will be age specific over 13 to create a user
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

Search:
- FindUser(): takes as parameter (country, city, category, fandom) and optional secondary parameter: 'keyword'
- FindEvent(): takes as parameter (country, city, category, fandom) and optional secondary parameter: 'keyword'
//The way the optional parameter will work is that it will either be filled out or an empty string. If it is an
//empty string, the method will act as if there is no keyword

Utilities:
- ValidateIfInt() //Checks if user input is an integer. For Console.Read()
- ValidateIntRange() //Checks if provided int is whithin range (one of the parameters of this method)
- ValidateCorrectUserData() //Checks if the values provided to create a new user make sense
- ValidateCorrectEventData() //Checks if the values provided to create a new event make sense
- ValidateIfUserIsOfAge() //Takes two parameters: user's age and age requirement. Will check if age is >=
//Will use above method also when creating an event to make sure the creator is of the age they specified


Unit tests:
Search:
- Make sure both FindUser and FindEvent return the expected things with mock data, testing all parameters

Utilities:
- Make sure all of the validation methods will return the expected results for different parameters
