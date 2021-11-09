using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyAppToTest
{
    public class BusinessLogic
    {
        public IManager Manager { get; set; }

        public BusinessLogic()
        {
            Manager = new Manager();
        }

        public Account Register(string name, string password,int age, string agestatus)
        {
            agestatus = AgeCheck(age);
            if (ValidatePassword(password))
            {
                var account = new Account()
                {
                    Name = name,
                    Password = password,
                    Age= age,
                    AgeStatus = agestatus
                };
                var newAccount = Manager.CreateAccount(account);

                return newAccount;
            }


            throw new Exception("Jelszó nem megfelelő");
        }
        public string Perform(bool b) 
        {
            if (b)
            {
                Manager.CrucialBusinessAction();
                return "OK";
            }

            return "HIBA";
        }
        
        public string AgeCheck(int age) => age >= 18
                ? "Nagykorú"
                : "Kiskorú";

        public Account NameModifier(Account acc, bool wantToModify, string newName)
        {
            
            if (wantToModify)
            {
                var newAccount =Manager.ModifyName(acc,newName);
                return newAccount;
            }
            return acc;
        }



        public bool ValidatePassword(string password)
        {
            var input = password;
            

            if (string.IsNullOrWhiteSpace(input))
            {
                Exception passZero = new Exception("Jelszó nem lehet üres");

                throw passZero;
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {

                return false;
            }
            else
            {
                return true;
            }
        }

        public int ParityChanger(int num)
        {
            return num + 1;
        }

        public int ChangeParityDecision(int num, bool wantToChange)
        {
            if (wantToChange)
            {
                return ParityChanger(num);
            }
            return num;
        }
    }


    
}
