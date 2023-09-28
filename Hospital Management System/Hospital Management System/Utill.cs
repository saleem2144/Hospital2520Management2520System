public class Utill
{
    // Method to get the next available ID and increment the ID count.
    public static int id_count = 10000;


    
    public static int getnextID()
    {
        return id_count++; 
    }


    // Method to filter and retrieve a Doctor by ID.
    public static Doctor filterDoctor(int id)
    {
        foreach (Doctor doctor in FileManager.doctorsList)
        {
            if(doctor.ID == id)
                return doctor;
        }
        return null;
    }


    // Method to filter and retrieve a Patient by ID.
    public static Patient filterPatient(int id)
    {
        foreach (Patient patient in FileManager.patientsList)
        {
            if (patient.ID == id)
                return patient;
        }
        return null;
    }

    // Method to display a title and welcome message.
    public static void DisplayTitle(string msg, string name)
    {
        Console.WriteLine("\n ---------------------------------------------\r\n|      DOTNET Hospital Management System      |\r\n ---------------------------------------------\r\n               " + msg + "\r\n ---------------------------------------------");
        if (name != null)
            Console.WriteLine("Welcome to DOTNET Hospital Management System " + name);
    }

    // Method to get a list of patients assigned to a Doctor.

    public static List<Patient> getAssignedPatients(Doctor doctor)
    {
        List<Patient> patients = new List<Patient>();
        foreach(Appointment appointment in FileManager.appointmentsList)
        {
            if (appointment.Doctor.ID == doctor.ID)
                patients.Add(appointment.Patient);
        }

        return patients;

    }

    // Method to get a specific patient assigned to a Doctor.
    internal static Patient getPatient(Doctor doctor,int id)
    {
        foreach (Appointment appointment in FileManager.appointmentsList)
        {
            if (appointment.Doctor.ID == doctor.ID && appointment.Patient.ID==id)
                return appointment.Patient;
        }
        return null;
    }


    // Method to get all appointments associated with a Doctor.
    public static List<Appointment> getAllAppointments(Doctor doctor)
    {
        List<Appointment> appointments = new List<Appointment>();
        foreach (Appointment appointment in FileManager.appointmentsList)
        {
            if (appointment.Doctor.ID == doctor.ID )
                appointments.Add( appointment);
        }
        return appointments;
    }


    // Method to get all appointments with a specific patient assigned to a Doctor.
    internal static List<Appointment> getAllAppointmentsWithPatient(Doctor doctor, int patientID)
    {
        List<Appointment> appointments = new List<Appointment>();
        foreach (Appointment appointment in FileManager.appointmentsList)
        {
            if (appointment.Doctor.ID == doctor.ID && appointment.Patient.ID==patientID)
                appointments.Add(appointment);
        }
        return appointments;
    }


    // Method to get the Doctor associated with a patient.
    public static Doctor getDoctor(int patientID)
    {
        Doctor doctor = null;
        foreach(Appointment appointment in FileManager.appointmentsList)
        {
            if (appointment.Patient.ID == patientID)
                doctor = appointment.Doctor;

        }

        return doctor;

        
    }

    // Method to get all appointments associated with a patient.
    public static List<Appointment> getAllAppointments(Patient patient)
    {
        List<Appointment> appointments = new List<Appointment>();
        foreach (Appointment appointment in FileManager.appointmentsList)
        {
            if (appointment.Patient.ID == patient.ID)
                appointments.Add(appointment);
        }
        return appointments;
    }
}
