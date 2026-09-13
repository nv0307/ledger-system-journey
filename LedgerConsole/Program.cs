using System;

// 1. VARIABLE MAPPING (Data Type Foundations)
string accountHolder = "Corporate Ledger Alpha"; // Text element mapping
decimal currentBalance = 5000.00m;              // The 'm' suffix forces high-precision decimal for currency
decimal interestRate = 0.045m;                  // 4.5% annual interest rate
int evaluationYears = 3;                        // Whole number integer for loops

Console.WriteLine($"--- Initializing Audit for Account: {accountHolder} ---");
Console.WriteLine($"Starting Balance: ${currentBalance}");

// 2. CONDITIONAL VALIDATION (if / else)
if (currentBalance <= 0)
{
    Console.WriteLine("Warning: Account has insufficient or zero funds for interest generation.");
}
else
{
    Console.WriteLine("Account status: Validated Active.");
}

// 3. CONTROL FLOW LOOPING (while loop)
Console.WriteLine($"\n--- Projecting {evaluationYears}-Year Simple Interest Accumulation ---");
int currentYear = 1;
while (currentYear <= evaluationYears)
{
    decimal interestEarned = currentBalance * interestRate;
    currentBalance += interestEarned; // Accruing the calculation directly
    
    Console.WriteLine($"Year {currentYear}: Earned ${interestEarned:F2} | New Balance: ${currentBalance:F2}");
    currentYear++;
}

// 4. COLLECTION INTEGRATION & ITERATION (foreach loop)
// Mock collection of incoming transaction adjustments
decimal[] pendingPostings = new decimal[] { 1250.50m, -400.00m, -85.25m, 2100.00m };
//This created a fixed-size array of high-precision decimal numbers.

Console.WriteLine("\n--- Processing Batch Posting Queue ---");
foreach (decimal postAmount in pendingPostings)
{
    // Evaluates numeric signs via standard switch patterns
    switch (postAmount)
    {
        case > 0:
            Console.WriteLine($"Posting CREDIT adjustment entry of: +${postAmount}");
            break;
        case < 0:
            Console.WriteLine($"Posting DEBIT adjustment entry of: -${Math.Abs(postAmount)}");
            break;
        default:
            Console.WriteLine("Skipping zero-value baseline tracking entry.");
            break;
    }
    
    currentBalance += postAmount;
}

// Final Verification Output
Console.WriteLine($"\nFinal Audited Reconciliation Balance: ${currentBalance:F2}");
