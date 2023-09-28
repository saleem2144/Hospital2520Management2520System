// This is a class definition for an abstract User class.
public abstract class User
{
    // Private fields to store user information.
    private int _id;         // User ID
    private string _firstName; // First name
    private string _lastName;  // Last name
    private string _password;  // Password

    // An abstract method declaration. Subclasses must implement this method.
    public abstract void DisplayMenu(User user);

    // Properties for accessing and modifying the private fields.
    public string FirstName
    {
        get { return _firstName; } // Getter for first name
        set { _firstName = value; } // Setter for first name
    }

    public string LastName
    {
        get { return _lastName; }  // Getter for last name
        set { _lastName = value; }  // Setter for last name
    }

    public int ID
    {
        get { return _id; }   // Getter for user ID
        set { _id = value; }   // Setter for user ID
    }

    public string Password
    {
        get { return _password; }  // Getter for password
        set { _password = value; }  // Setter for password
    }

    // Constructor for creating User objects with initial data.
    public User(string firstName, string lastName, string password)
    {
        FirstName = firstName;      // Initialize first name
        LastName = lastName;        // Initialize last name
        _id = Utill.getnextID();    // Initialize user ID (assuming there's a Utill class with a method getnextID())
        Password = password;        // Initialize password
    }

    // Override the ToString() method to provide a custom string representation of the User object.
    public override string ToString()
    {
        return string.Format("{0,-20}", FirstName + " " + LastName); // Format and return full name
    }
}
