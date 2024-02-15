using System;
using System.ComponentModel.DataAnnotations;


public class CardHolder
    
{
    //Define a cardholder

    string cardnumber, firstname, lastname;
    int pin;
    double account_balanace;

    // class constructor
    public CardHolder(string cardnumber, string firstname, string lastname, int pin, double account_balanace)
    {
        this.cardnumber = cardnumber;
        this.firstname = firstname;
        this.lastname = lastname;
        this.pin = pin;
        this.account_balanace = account_balanace;
    }

    // get methods -> gets the informations
    public string getcardNumber()
    {
        return cardnumber;
    }

    public string getFirstname() { 
        return firstname;
    }

    public string getLastname()
    {
        return lastname;
    }

    public int getPin()
    {
        return pin;
    }

    public double getAccount_balanace()
    {
        return account_balanace;
    }


    // set method -> updates or set information
    public void setcardNumber(string new_cardnumber)
    {
        cardnumber = new_cardnumber;
    }

    public void setPin(int new_pin)
    {
        pin = new_pin;
    }

    public void setFirstname(string new_firstname)
    {
        firstname = new_firstname;
    }

    public void setLastname(string new_lastname)
    {
        lastname = new_lastname;
    }

    public void setDepositbalance(double new_balance)
    {
        account_balanace += new_balance;
    }
    public void setWithdrawbalance(double new_balance)
    {
        account_balanace -= new_balance;
    }


    // Main method -> first display
    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("1. Make Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        // Deposit option
        void makeDeposit(CardHolder currentUser)
        {
            Console.WriteLine("Enter deposit amount");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setDepositbalance(deposit);
            Console.WriteLine($"Deposit Successfull. New balance = {currentUser.getAccount_balanace()}");
        }

        // Withdraw Option
        void makeWithdraw(CardHolder currentUser)
        {
            Console.WriteLine("Enter withdrawal amount");
            double withdraw = Double.Parse(Console.ReadLine());
            // check balance
            if (withdraw < currentUser.getAccount_balanace())
            {
                currentUser.setWithdrawbalance(withdraw);
                Console.WriteLine($"Withdraw successfull. New Balance = {currentUser.getAccount_balanace()}");
            }
            else
            {
                Console.WriteLine("Insufficient balance to withdraw.");
            }
            
        }

        // balance check
        void balanceCheck(CardHolder currentUser)
        {
            Console.WriteLine($"Current Balance = {currentUser.getAccount_balanace()}");
        }

        

        // small database from constructor function

        List<CardHolder>atm_database = new List<CardHolder>();  // list instance of people

        //add people to list
        atm_database.Add(new CardHolder("1234567890123456", "John", "Doe", 1234, 50000));
        atm_database.Add(new CardHolder("9876543210987654", "Alice", "Smith", 5678, 250000));
        atm_database.Add(new CardHolder("2468135780246802", "Bob", "Ross", 1357, 1300.50));
        atm_database.Add(new CardHolder("9999888877776666", "fahim", "muntasir", 2424, 999999));


        // cardnumber operation
        Console.WriteLine("Enter Your Debit Card Number");
        string cardNum = "";
        CardHolder currentUser;

        while (true)
        {
            try
            {
                cardNum = Console.ReadLine();

                // match card number with database
                currentUser = atm_database.FirstOrDefault(card => card.cardnumber == cardNum);

                if (currentUser != null) {
                    break;
                }
                else { 
                    Console.WriteLine("Card not found, Try again");
                }
            }
            catch {
                Console.WriteLine("Card not found, Try again");
            }
        }

        // pin operation
        Console.WriteLine("Enter pin");
        int pinNum = 0;

        while (true)
        {
            try
            {
                pinNum = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == pinNum)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect pin");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect pin");
            }

        }

        // Welcome
        Console.WriteLine($"Welcome {currentUser.getFirstname()}. What do you want to do today?");
        

        int option = 0;
        do 
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine()) ;
            }
            catch
            {

            }
            if (option == 1) 
            { 
                makeDeposit(currentUser); 
            }
            else if (option == 2)
            {
                makeWithdraw(currentUser);
            }
            else if(option == 3)
            {
                balanceCheck(currentUser);
            }
            else if (option>=4)
            {
                Console.WriteLine("Thanks for banking with us");
            }
            
        } 
        while (option != 4);

        // Console.WriteLine("Thanks for banking with us");

    }

}

    



