using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassportCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IPassport> passports = new List<IPassport>();

            while (true)
            {
                Console.WriteLine("Passport {0}:", passports.Count + 1);
                Console.Write("Passport Number (or 'exit' to stop): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                string passportNumber = input;

                Console.Write("Nationality: ");
                string nationality = Console.ReadLine();

                Passport passport = new Passport
                {
                    PassportNumber = passportNumber,
                    Nationality = nationality
                };

                passports.Add(passport);
            }

            Console.WriteLine("\nPassport Validation Results:");
            foreach (IPassport passport in passports)
            {
                Console.WriteLine("Passport Number: {0}", passport.GetPassportNumber());
                Console.WriteLine("Nationality: {0}", passport.GetNationality());
                Console.WriteLine("Is Valid: {0}\n", passport.IsValid());
            }

           
            GeneratePassportReports(passports);
            GeneratePassportStatistics(passports);

            Console.ReadLine();
        }

        static void GeneratePassportReports(List<IPassport> passports)
        {
            Console.WriteLine("\nPassport Reports:");

            
            Console.WriteLine("Valid Passports:");
            List<IPassport> validPassports = passports.Where(p => p.IsValid()).ToList();
            foreach (IPassport passport in validPassports)
            {
                Console.WriteLine("Passport Number: {0}", passport.GetPassportNumber());
                Console.WriteLine("Nationality: {0}", passport.GetNationality());
                Console.WriteLine();
            }

            
            Console.WriteLine("Invalid Passports:");
            List<IPassport> invalidPassports = passports.Where(p => !p.IsValid()).ToList();
            foreach (IPassport passport in invalidPassports)
            {
                Console.WriteLine("Passport Number: {0}", passport.GetPassportNumber());
                Console.WriteLine("Nationality: {0}", passport.GetNationality());
                Console.WriteLine();
            }
        }

        static void GeneratePassportStatistics(List<IPassport> passports)
        {
            Console.WriteLine("\nPassport Statistics:");

            
            Console.WriteLine("Total Passports: {0}", passports.Count);

            
            int validPassports = passports.Count(p => p.IsValid());
            Console.WriteLine("Valid Passports: {0}", validPassports);

            
            int invalidPassports = passports.Count - validPassports;
            Console.WriteLine("Invalid Passports: {0}", invalidPassports);

            
            var nationalityDistribution = passports.GroupBy(p => p.GetNationality())
                                                  .Select(group => new
                                                  {
                                                      Nationality = group.Key,
                                                      Count = group.Count()
                                                  });
            Console.WriteLine("Nationality Distribution:");
            foreach (var item in nationalityDistribution)
            {
                Console.WriteLine("{0}: {1}", item.Nationality, item.Count);
            }
        }
        
    }
}
