public class Administrator : User
{
    public Administrator(string firstName, string lastName, string password) : base(firstName, lastName, password)
    {
    }


    public override  void DisplayMenu(User currentLoginUser)
    {

        bool adminLoop = true;
        Administrator admin = (Administrator)currentLoginUser;
        Utill.DisplayTitle("Administrator Menu", admin.FirstName + " " + admin.LastName);

        while (adminLoop)
        {
            Console.WriteLine("\nPlease Choose an option:\r\n1. List All doctors\r\n2. Check Doctor details\r\n3. List All patients\r\n4. check patient details\r\n5. Add doctor\r\n6. Add patient\r\n7. Logout\r\n8. Exit");
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

                    Utill.DisplayTitle("All Doctors", null);
                    Console.WriteLine("All doctors registered to DOTNET Hospital Management Systrem ");
                    Console.WriteLine(string.Format("{0,-20}{1,-20}{2,-20}{3,-20}", "Name","| Email Address","| Phone","| Address"));

                    
                    foreach(Doctor doctor in FileManager.doctorsList)
                    {
                        Console.WriteLine(doctor);
                    }
                }
                else if (choice == "2")
                {
                    Utill.DisplayTitle("Doctor Details", null);
                    Console.WriteLine("Please enter the id of doctor who's details you are checking or press n to return to the main menu:");
                    string input= Console.ReadLine();
                    if(input!="n")
                    {
                        int id = int.Parse(input);
                        Doctor doctor= Utill.filterDoctor(id);
                        if (doctor != null)
                        {
                            Console.WriteLine("Details for "+doctor.FirstName+" "+doctor.LastName);
                            Console.WriteLine(string.Format("{0,-20}{1,-20}{2,-20}{3,-20}", "Name", "| Email Address", "| Phone", "| Address"));
                            Console.WriteLine(doctor);

                        }
                        else
                            Console.WriteLine("Invalid Doctor ID");
                    }

                }
                else if (choice == "3")
                {
                    Utill.DisplayTitle("All Patients", null);
                    Console.WriteLine("All patients registered to DOTNET Hospital Management Systrem ");
                    Console.WriteLine(string.Format("{0,-20}{1,-20}{2,-20}{3,-20}", "Name", "| Email Address", "| Phone", "| Address"));


                    foreach (Patient patient in FileManager.patientsList)
                    {
                        Console.WriteLine(patient);
                    }
                }
                else if (choice == "4")
                {
                    Utill.DisplayTitle("Patient Details", null);
                    Console.WriteLine("Please enter the id of patient who's details you are checking or press n to return to the main menu:");
                    string input = Console.ReadLine();
                    if (input != "n")
                    {
                        int id = int.Parse(input);
                        Patient patient = Utill.filterPatient(id);
                        if (patient != null)
                        {
                            Console.WriteLine("Details for " + patient.FirstName + " " + patient.LastName);
                            Console.WriteLine(string.Format("{0,-20}{1,-20}{2,-20}{3,-20}", "Name", "| Email Address", "| Phone", "| Address"));
                            Console.WriteLine(patient);

                        }
                        else
                            Console.WriteLine("Invalid Patient ID");
                    }
                }
                else if (choice == "5")
                {

                    Utill.DisplayTitle("Add Doctor",null);
                    Console.WriteLine("Registering a new doctor with DORNET Hospital management System");
                    Console.Write("First Name: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Last Name: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Phone: ");
                    string phone = Console.ReadLine();
                    Console.Write("Street Number: ");
                    string streeNo= Console.ReadLine();
                    Console.Write("Street: ");
                    string street = Console.ReadLine();
                    Console.Write("City: ");
                    string city = Console.ReadLine();
                    Console.Write("State: ");
                    string state = Console.ReadLine();
                    Console.Write("Set Password; ");
                    string password= Console.ReadLine();

                    Doctor doctor=new Doctor(firstName,lastName,password,email,phone,street,streeNo,city,state);
                    FileManager.doctorsList.Add(doctor);
                    Console.WriteLine(firstName+" "+lastName+" Added to the system!");



                }
                else if (choice == "6")
                {
                    Utill.DisplayTitle("Add Patient", null);
                    Console.WriteLine("Registering a new Patient with DORNET Hospital management System");
                    Console.Write("First Name: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Last Name: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Phone: ");
                    string phone = Console.ReadLine();
                    Console.Write("Street Number: ");
                    string streeNo = Console.ReadLine();
                    Console.Write("Street: ");
                    string street = Console.ReadLine();
                    Console.Write("City: ");
                    string city = Console.ReadLine();
                    Console.Write("State: ");
                    string state = Console.ReadLine();
                    Console.Write("Set Password; ");
                    string password = Console.ReadLine();

                    Patient patient = new Patient(firstName, lastName, password, email, phone, street, streeNo, city, state);
                    FileManager.patientsList.Add(patient);
     
                    Console.WriteLine(firstName + " " + lastName + " Added to the system!");



                }
                else if (choice == "7")
                {
                    FileManager.WriteDataToFile();
                    
                    currentLoginUser = null;
                    adminLoop = false;
                }
                else if(choice=="8")
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

