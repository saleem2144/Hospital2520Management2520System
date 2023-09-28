// Define a Patient class that inherits from the User class.
public class Patient : User
{
    // Properties specific to the Patient class
    private string _email;
    private string _phone;
    private string _streetNo;
    private string _street;
    private string _city;
    private string _state;

    // Property getters and setters for the Patient-specific properties
    public string Email { get { return _email; } set { _email = value; } }
    public string Phone { get { return _phone; } set { _phone = value; } }
    public string Street { get { return _street; } set { _street = value; } }
    public string StreetNo { get { return _streetNo; } set { _streetNo = value; } }
    public string City { get { return _city; } set { _city = value; } }
    public string State { get { return _state; } set { _state = value; } }

    public Patient(string firstName, string lastName, string password, string email, string phone, string street, string streetNo, string city, string state) : base(firstName, lastName, password)
    {
        Email = email;
        Phone = phone;
        Street = street;
        StreetNo = streetNo;
        City = city;
        State = state;
    }

    // Override the ToString() method to provide a custom string representation of the Patient object.
    public override string ToString()
    {
        string toReturn = string.Format("{0,-20}{1,-20}{2,-20}{3,-20}", this.FirstName + " " + this.LastName, this.Email, this.Phone, this.StreetNo + " " + this.Street + ", " + this.City + ", " + this.State);
        return toReturn;
    }


    // Override the DisplayMenu method from the User class to provide Patient-specific functionality.

    public override void DisplayMenu(User currentLoginUser)
    {

        bool adminLoop = true;
        Patient patient = (Patient)currentLoginUser;
        // Display a menu for the Patient user.

        Utill.DisplayTitle("Patient Menu", patient.FirstName + " " + patient.LastName);

        while (adminLoop)
        {
            Console.WriteLine("\nPlease Choose an option:\r\n1. List Patient details\r\n2. List my Doctor details\r\n3. List All Appointments\r\n4. Book Appointment \r\n5. Exit to login\r\n6. Exit System");
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
                    Console.WriteLine(patient.FirstName+" "+patient.LastName+"'s Details");
                    Console.WriteLine("Patient ID: " + patient.ID);
                    Console.WriteLine("Full Name: " + patient.FirstName + " " + patient.LastName);
                    Console.WriteLine("Address: " + patient.StreetNo + " " + patient.Street + ", " + patient.City + ", " + patient.State);
                    Console.WriteLine("Email: " + patient.Email);
                    Console.WriteLine("Phone: " + patient.Phone);

                }
                else if (choice == "2")
                {
                    Utill.DisplayTitle("My Doctor", null);
                    Console.WriteLine("Your doctor: ");
                    Console.WriteLine(string.Format("{0,-20}{1,-20}{2,-20}{3,-20}", "Name", "| Email", "| Phone","| Address"));
                    Console.WriteLine("-------------------------------------------------------------------------------------------");
                    Doctor doctor = Utill.getDoctor(patient.ID);
                    Console.WriteLine(doctor);



                }
                else if (choice == "3")
                {
                    Utill.DisplayTitle("All Appointments", null);
                    Console.WriteLine(string.Format("{0,-20}{1,-20}{2,-20}", "Doctor", "| Patient", "| Description"));
                    Console.WriteLine("-------------------------------------------------------------------------------------------");
                    List<Appointment> assignedAppointments = Utill.getAllAppointments(patient);

                    foreach (Appointment app in assignedAppointments)
                    {
                        Console.WriteLine(app);
                    }
                }
                else if (choice == "4")
                {
                    Utill.DisplayTitle("Book Appointment", null);
                    List<Appointment> appointments= Utill.getAllAppointments(patient);

                    if(appointments.Count==0)
                    {
                        Console.WriteLine("You are not register with any doctor!  ");

                    }

                    Console.WriteLine("Please Choose which doctor would you like to register with: ");
                    int i = 1;
                    foreach(Doctor doctor in FileManager.doctorsList)    
                    {
                        Console.WriteLine(i + ": " + doctor);
                        i++;
                    }
                    Console.WriteLine("Please choose a doctor: ");
                    int ch = int.Parse(Console.ReadLine());
                    if (ch-1 < 0 || ch-1 >= FileManager.doctorsList.Count)
                        Console.WriteLine("Invalid choice");
                    else
                    {
                        Doctor choosenDoctor = FileManager.doctorsList[ch-1];
                        Console.WriteLine("You are booking new Appointment with " + choosenDoctor.FirstName + " ", choosenDoctor.LastName);
                        Console.WriteLine("Description of the Appointment: ");
                        string description = Console.ReadLine();
                        Appointment app=new Appointment(choosenDoctor,patient,description);
                        FileManager.appointmentsList.Add(app);

                        Console.WriteLine("The Appointment has been booked successfully!");
                    }


                }

                else if (choice == "5")
                {
                    FileManager.WriteDataToFile();

                    currentLoginUser = null;
                    adminLoop = false;

                }

                else if (choice == "6")
                {
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
