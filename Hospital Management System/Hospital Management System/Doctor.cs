// Define a Doctor class that inherits from the User class.
public class Doctor : User
{
    // Properties specific to the Doctor class
    private string _email;
    private string _phone;
    private string _streetNo;
    private string _street;
    private string _city;
    private string _state;

    // Property getters and setters for the Doctor-specific properties
    public string Email { get { return _email; } set { _email = value; } }
    public string Phone { get { return _phone; } set { _phone = value; } }
    public string Street { get { return _street; } set { _street = value; } }
    public string StreetNo { get { return _streetNo; } set { _streetNo = value; } }
    public string City { get { return _city; } set { _city = value; } }
    public string State { get { return _state; } set { _state = value; } }

    // Constructor for creating Doctor objects with initial data.
    public Doctor(string firstName, string lastName, string password, string email, string phone, string street, string streetNo, string city, string state)
        : base(firstName, lastName, password)
    {
        // Initialize Doctor-specific properties
        Email = email;
        Phone = phone;
        Street = street;
        StreetNo = streetNo;
        City = city;
        State = state;
    }

    // Override the ToString() method to provide a custom string representation of the Doctor object.
    public override string ToString()
    {
        string toReturn = string.Format("{0,-20}{1,-20}{2,-20}{3,-20}", this.FirstName + " " + this.LastName, this.Email, this.Phone, this.StreetNo + " " + this.Street + ", " + this.City + ", " + this.State);
        return toReturn;
    }

    // Override the DisplayMenu method from the User class to provide Doctor-specific functionality.
    public override void DisplayMenu(User currentLoginUser)
    {

        bool adminLoop = true;
        Doctor doctor = (Doctor)currentLoginUser;
        Utill.DisplayTitle("Doctor Menu", doctor.FirstName + " " + doctor.LastName);

        while (adminLoop)
        {
            Console.WriteLine("\nPlease Choose an option:\r\n1. List Doctor details\r\n2. List Patients\r\n3. List All Appointments\r\n4. check particular patient \r\n5. List Appointments with patient\r\n6. Logout\r\n7. Exit");
            string choice = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(choice))
            {
                // Handle empty input
                Console.WriteLine("Invalid choice. Please try again.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            else
            {

                if (choice == "1")
                {

                    Utill.DisplayTitle("My Details", null);
                    Console.WriteLine(string.Format("{0,-20}{1,-20}{2,-20}{3,-20}", "Name", "| Email Address", "| Phone", "| Address"));
                        Console.WriteLine(doctor);
                    
                }
                else if (choice == "2")
                {
                    Utill.DisplayTitle("My Patients", null);
                    Console.WriteLine("Patients assigned to "+doctor.FirstName+" "+doctor.LastName+":\n");
                    List<Patient> assignedPatients = Utill.getAssignedPatients(doctor);
                    Console.WriteLine(string.Format("{0,-20}{0,-20}{1,-20}{2,-20}{3,-20}", "Patient", "| Doctor", "| Email Address", "| Phone", "| Address"));
                    Console.WriteLine("--------------------------------------------------------------------------------------------");

                    foreach (Patient patient in assignedPatients)
                    {
                        Console.WriteLine(string.Format("{0,-20}{0,-20}{1,-20}{2,-20}{3,-20}", patient.FirstName+" "+patient.LastName, doctor.FirstName+" "+doctor.LastName, patient.Email, patient.Phone, this.StreetNo + " " + this.Street + ", " + this.City + ", " + this.State));
                    }



                }
                else if (choice == "3")
                {
                    Utill.DisplayTitle("All Appointments", null);
                    Console.WriteLine(string.Format("{0,-20}{1,-20}{2,-20}", "Doctor", "| Patient", "| Description"));
                    Console.WriteLine("-------------------------------------------------------------------------------------------");
                    List<Appointment> assignedAppointments = Utill.getAllAppointments(doctor);

                    foreach (Appointment app in assignedAppointments)
                    {
                        Console.WriteLine(app);
                    }
                }
                else if (choice == "4")
                {
                    Utill.DisplayTitle("Check Patient Details", null);
                    Console.WriteLine("Enter the id of patient to check: ");
                    string input = Console.ReadLine();
                   
                        int id = int.Parse(input);
                    Patient patient = Utill.getPatient(doctor,id);
                    if (patient != null)
                    {
                        Console.WriteLine(string.Format("{0,-20}{0,-20}{1,-20}{2,-20}{3,-20}", "Patient", "| Doctor", "| Email Address", "| Phone", "| Address"));
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        Console.WriteLine(string.Format("{0,-20}{0,-20}{1,-20}{2,-20}{3,-20}", patient.FirstName + " " + patient.LastName, doctor.FirstName + " " + doctor.LastName, patient.Email, patient.Phone, this.StreetNo + " " + this.Street + ", " + this.City + ", " + this.State));
                        

                    }
                    else
                        Console.WriteLine("No Patient assigned with provided ID");
                       
                }
                
                else if (choice == "5")
                {
                    Utill.DisplayTitle("Appointmens with", null);
                    Console.WriteLine("Enter the id of patient you like to view Appointments for: ");
                    int patientID = int.Parse(Console.ReadLine());
                    List<Appointment> allAppointments = Utill.getAllAppointmentsWithPatient(doctor,patientID);
                    Console.WriteLine(string.Format("{0,-20}{1,-20}{2,-20}", "Doctor", "| Patient", "| Description"));
                    Console.WriteLine("-------------------------------------------------------------------------------------------");

                    foreach (Appointment app in allAppointments)
                    {
                        Console.WriteLine(app);
                    }

                }
               
                else if (choice == "6")
                {
                    // Save data to file and exit to login
                    FileManager.WriteDataToFile();
                    currentLoginUser = null;
                    adminLoop = false;
                }
                else if (choice == "7")
                {
                    // Save data to file and exit 
                    FileManager.WriteDataToFile();
                    Environment.Exit(0);
                }
                else
                {
                    // Handle empty input
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }


            }




        }

    }


}
