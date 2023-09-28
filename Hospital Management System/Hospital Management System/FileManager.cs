using System.Numerics;

public class FileManager
{

    // Lists to store data for doctors, patients, admins, and appointments.
    public static List<Doctor> doctorsList = new List<Doctor>();
    public static List<Patient> patientsList = new List<Patient>();
    public static List<Administrator> adminsList = new List<Administrator>();
    public static List<Appointment> appointmentsList = new List<Appointment>();
    private static string dataFilePath = "data.txt"; // The path to data file

    //this method will read data from data.txt, users.txt file contains data about doctors, ptients, Administrators, receptionists and Appointment(data about appointment will be doctor id, patient id and description).
    //The mothod will store all the data in corresponding Lists
    public static void ReadDataFromFiles()
    {

           doctorsList = new List<Doctor>();
           patientsList = new List<Patient>();
           adminsList = new List<Administrator>();
           appointmentsList = new List<Appointment>();
        int last_id=10001; // used track last id of user
        try
        {
            // Read data from the file and populate your lists
            string[] lines = File.ReadAllLines(dataFilePath);
            foreach (string line in lines)
            {

                string[] parts = line.Split('|'); // Assuming your data is separated by '|'
                if (parts.Length >= 1)
                {
                    string dataType = parts[0];

                    if (dataType == "Doctor")
                    {
                        // Parse data for a Doctor and add it to doctorsList
                        if (parts.Length >= 11)
                        {
                            int id = int.Parse(parts[1]);
                            string firstName = parts[2];
                            string lastName = parts[3];
                            string password = parts[4];
                            string email = parts[5];
                            string phone = parts[6];
                            string street = parts[7];
                            string streetNo = parts[8];
                            string city = parts[9];
                            string state = parts[10];
                            Doctor doctor = new Doctor(firstName, lastName, password, email, phone, street, streetNo, city, state);
                            doctor.ID = id;
                            doctorsList.Add(doctor);
                            last_id = id;
                           
                        
                        }
                    }
                    else if (dataType == "Patient")
                    {
                        // Parse data for a Patient and add it to patientsList
                        if (parts.Length >= 11)
                        {
                            int id = int.Parse(parts[1]);
                            string firstName = parts[2];
                            string lastName = parts[3];
                            string password = parts[4];
                            string email = parts[5];
                            string phone = parts[6];
                            string street = parts[7];
                            string streetNo = parts[8];
                            string city = parts[9];
                            string state = parts[10];
                            Patient patient = new Patient(firstName, lastName, password, email, phone, street, streetNo, city,state);
                            patient.ID = id;
                            patientsList.Add(patient);
                            last_id = id;
                        }
                    }
                    else if (dataType == "Administrator")
                    {
                        // Parse data for an Administrator and add it to adminsList
                        if (parts.Length >= 5)
                        {
                            string firstName = parts[1];
                            string lastName = parts[2];
                            int id = int.Parse(parts[3]);
                            string password = parts[4];
                            Administrator admin = new Administrator(firstName, lastName, password);
                            admin.ID = id;
                            adminsList.Add(admin);
                            last_id = id;


                        }
                    }
                    else if (dataType == "Appointment")
                    {
                        // Parse data for an Appointment and add it to appointmentsList
                        if (parts.Length >= 4)
                        {
                            int doctorId = int.Parse(parts[1]);
                            int patientId = int.Parse(parts[2]);
                            string description = parts[3];

                            // Find the Doctor and Patient objects by their IDs
                            Doctor doctor = doctorsList.FirstOrDefault(d => d.ID == doctorId);
                            Patient patient = patientsList.FirstOrDefault(p => p.ID == patientId);

                            if (doctor != null && patient != null)
                            {
                                appointmentsList.Add(new Appointment(doctor, patient, description));
                            }
                            else
                            {
                               
                            }
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error reading data from file: " + e.Message);
        }
        Utill.id_count=last_id;
        Utill.id_count++;
    }


    //this method will write all lists data to data.txt
    public static void WriteDataToFile()
    {
        try
        {
            // Create or overwrite the data file
            using (StreamWriter writer = new StreamWriter(dataFilePath))
            {



                // Write data for each entity to the file
                foreach (Doctor doctor in doctorsList)
                {
                    string data = $"Doctor|{doctor.ID}|{doctor.FirstName}|{doctor.LastName}|{doctor.Password}|{doctor.Email}|{doctor.Phone}|{doctor.Street}|{doctor.StreetNo}|{doctor.City}|{doctor.State}";
                    writer.WriteLine(data);
                }

                foreach (Patient patient in patientsList)
                {
                    string data = $"Patient|{patient.ID}|{patient.FirstName}|{patient.LastName}|{patient.Password}|{patient.Email}|{patient.Phone}|{patient.Street}|{patient.StreetNo}|{patient.City}|{patient.State}";
                    writer.WriteLine(data);
                }

                

                foreach (Administrator admin in adminsList)
                {
                    string data = $"Administrator|{admin.FirstName}|{admin.LastName}|{admin.ID}|{admin.Password}";
                    writer.WriteLine(data);
                }

                foreach (Appointment appointment in appointmentsList)
                {
                    string data = $"Appointment|{appointment.Doctor.ID}|{appointment.Patient.ID}|{appointment.Description}";
                    writer.WriteLine(data);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error writing data to file: " + e.Message);
        }
    }


}
