SELECT SUM(WizardDep.Difference) AS [SumDifference]
FROM
(
    SELECT FirstName,
           DepositAmount,
           LEAD(FirstName) OVER(ORDER BY Id) AS GuestWizard,
           LAG(FirstName) OVER(ORDER BY Id) AS GuestLagWizard,
           LEAD(DepositAmount) OVER(ORDER BY Id) AS GuestDeposit,
           LAG(DepositAmount) OVER(ORDER BY Id) AS GuestLagDeposit,
           DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id) AS Difference
		   --DepositAmount - LAG(DepositAmount) OVER (ORDER BY Id) AS Difference -- is same calculation BUT NEGATIVE

    FROM WizzardDeposits
) AS WizardDep; 