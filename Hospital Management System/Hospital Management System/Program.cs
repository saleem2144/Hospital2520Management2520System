using System;

namespace YourNamespace
{
    class Program
    {
        public static User currentLoginUser=null;
       
      
        static void Main(string[] args)
        {

          
           

            while (true)
            {

                FileManager.ReadDataFromFiles();
                Utill.DisplayTitle("Login",null);
               Console.Write("ID: ");
                int id=int.Parse(Console.ReadLine());
               
                Console.Write("Password: ");
                string password = ReadPassword();
                Console.WriteLine(password);

                currentLoginUser = AuthenticateUser(id,password);

                if (currentLoginUser != null)
                {
                    Console.WriteLine("Valid Credentials");

                    if (currentLoginUser is Administrator)
                    {
                        Administrator administrator = (Administrator)currentLoginUser;
                        administrator.DisplayMenu(currentLoginUser);
                    }
                    else if (currentLoginUser is Patient)
                    {
                       Patient p = (Patient)currentLoginUser;
                        p.DisplayMenu(currentLoginUser);

                    }
                  
                    else
                    {
                        Doctor doctor = (Doctor)currentLoginUser;
                        doctor.DisplayMenu(currentLoginUser);

                    }


                }
                else
                    Console.WriteLine("Invalid Credentials");

            
            }

         



        }


        

        private static void DisplayDoctorMenu()
        {
            throw new NotImplementedException();
        }

        private static void DisplayReceptionistMenu()
        {
            throw new NotImplementedException();
        }

        private static void DisplayPatientMenu()
        {
            throw new NotImplementedException();
        }

       


       
        private static User AuthenticateUser(int id, string password)
        {
            Console.WriteLine(FileManager.adminsList.Count);
          
            foreach(Administrator admin in FileManager.adminsList)
            {
                if (admin.ID == id && admin.Password.Equals(password))
                    return admin;
            }

            foreach(Doctor doctor in FileManager.doctorsList)
            {
                if (doctor.ID == id && doctor.Password.Equals(password))
                    return doctor;
            }

            foreach(Patient patient in FileManager.patientsList)
            {
                if (patient.ID == id && patient.Password.Equals(password))
                    return patient;
            }

            


            return null;

        }










        // Function to read the password with masking
        static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // Ignore key if it's not a printable character
                if (char.IsControl(key.KeyChar))
                    continue;

                password += key.KeyChar;
                Console.Write("*");
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine(); // Add a newline after password entry
            return password;
        }
    }




}
