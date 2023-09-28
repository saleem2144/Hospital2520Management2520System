public class Appointment
{

    private Doctor _doctor;
    private Patient _patient;
    private string _description;

    public Doctor Doctor
    {
        get { return _doctor; }
        set { _doctor = value; }

    }

    public Patient Patient { get { return _patient; } set { _patient = value; } }

    public string Description { get { return _description; } set { _description = value; } }

    public Appointment(Doctor doctor, Patient patient, string description)
    {
        Doctor = doctor;
        Patient = patient;
        Description = description;
    }

    public override string ToString()
    {

        string toReturn = string.Format("{0,-20}{1,-20}{2,-20}",Doctor.FirstName+" "+Doctor.LastName,Patient.FirstName+" "+Patient.LastName,Description);
        return toReturn;

    }
}
