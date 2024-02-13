using System;


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
            Console.WriteLine("Welcome to ATM. Select Options:");
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
                Console.WriteLine("Insufficient balance to withdraw 😐");
            }
            
        }

        // balance check
        void balanceCheck(CardHolder currentUser)
        {
            Console.WriteLine($"Current Balance = {currentUser.getAccount_balanace()}");
        }

        

        printOptions();


    }

}

    



