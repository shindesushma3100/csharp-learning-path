
## Practice 1: Nth Highest Salary
--------------------------------------------------------------------------
Step 2: Setup table (run once)
---------------------------------------------------------------------------
## sql
CREATE TABLE Employees (
    Id INT PRIMARY KEY,
    Name VARCHAR(50),
    Department VARCHAR(50),
    Salary DECIMAL(10,2)
);

INSERT INTO Employees VALUES
(1, 'Raj', 'IT', 60000),
(2, 'Priya', 'IT', 75000),
(3, 'Amit', 'HR', 50000),
(4, 'Sneha', 'HR', 55000),
(5, 'Karan', 'Finance', 90000),
(6, 'Neha', 'Finance', 85000),
(7, 'Rohit', 'IT', 75000);
-------------------------------------------------------------------------------
Step 3: Nth Highest Salary query
-------------------------------------------------------------------------------
## sql
SELECT DISTINCT Salary
FROM Employees
ORDER BY Salary DESC
OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY;
-- OFFSET 1 skips the highest, FETCH NEXT 1 gets the next one = 2nd highest
--------------------------------------------------------------------------------
Alternative using Window Functions (more flexible, works for "Nth" generically):
--------------------------------------------------------------------------------

## sql
SELECT Salary FROM (
    SELECT Salary, DENSE_RANK() OVER (ORDER BY Salary DESC) AS Rnk
    FROM Employees
) ranked
WHERE Rnk = 2; -- change to any N

--------------------------------------------------------------------------------
Why DENSE_RANK here, not RANK or ROW_NUMBER?
"Rohit and Priya both earn 75000. With ROW_NUMBER, they'd get different numbers (like 2 and 3), so asking for 'rank 2' might miss one of them or give an inconsistent answer. With DENSE_RANK, both tied salaries get the same rank, and the next distinct salary correctly becomes rank 3 — it respects the idea that 75000 truly is 'the 2nd distinct highest salary,' regardless of how many people share it."
-------------------------------------------------------------------------------
## Practice 2: Duplicate Records — Find and Delete
-------------------------------------------------------------------------------------------------
Step 1: Find duplicates
-----------------------------------

Say your table accidentally has repeated employee names:

## sql
SELECT Name, COUNT(*) AS OccurrenceCount
FROM Employees
GROUP BY Name
HAVING COUNT(*) > 1;

Why HAVING here, not WHERE? — same reasoning from the theory: COUNT(*) only exists after grouping, and HAVING is what filters groups, not individual rows.

--------------------------------------------------
Step 2: Delete duplicates (keeping only one copy)
------------------------------------------------

This is the trickier real-world version — you don't want to delete all copies, just the extras, keeping one:
-------------------------------------------------------------------------
## sql
WITH DuplicatesCTE AS (
    SELECT *,
           ROW_NUMBER() OVER (PARTITION BY Name, Department, Salary ORDER BY Id) AS RowNum
    FROM Employees
)
DELETE FROM DuplicatesCTE WHERE RowNum > 1;

Key logic:

PARTITION BY Name, Department, Salary groups rows that are considered duplicates of each other (adjust these columns to whatever defines a "duplicate" in your case)
ROW_NUMBER() OVER (...) numbers each row within its own group, starting at 1
So the first occurrence in each duplicate group gets RowNum = 1 (kept), and any additional copies get RowNum = 2, 3, ... (deleted)
This is a genuinely important real-world pattern — "keep one, delete the rest" comes up constantly when cleaning messy data

-----------------------------------------------------------
Practice 3: Running Total
--------------------------------------------------------------
## sql
SELECT Id, Name, Department, Salary,
       SUM(Salary) OVER (ORDER BY Id) AS RunningTotal
FROM Employees;
----------------------------------------------------------------
Key logic:

SUM(Salary) OVER (ORDER BY Id) is a window function — instead of collapsing all rows into one total like a normal SUM() with GROUP BY would, it calculates a cumulative total as it goes down the ordered rows
Each row's RunningTotal = sum of its own salary + every salary before it (based on the ORDER BY)
This is genuinely useful in real reporting — like tracking cumulative revenue day by day

If you want a running total per department instead of overall:

## sql
SELECT Id, Name, Department, Salary,
       SUM(Salary) OVER (PARTITION BY Department ORDER BY Id) AS DeptRunningTotal
FROM Employees;
----------------------------------------------------

PARTITION BY Department resets the running total separately for each department — same idea as GROUP BY, but combined with the ordered, cumulative behavior of a window function.
------------------------------------------------------------
## Practice 4: Pivot

A Pivot transforms rows into columns — say you want total salary per department, but shown as separate columns (IT, HR, Finance) instead of separate rows.
-------------------------------------------------------------
## sql
SELECT *
FROM (
    SELECT Department, Salary FROM Employees
) src
PIVOT (
    SUM(Salary) FOR Department IN ([IT], [HR], [Finance])
) AS PivotTable;

------------------------------------------------------------
Key logic:

The inner query pulls just the two relevant columns: Department and Salary
PIVOT (SUM(Salary) FOR Department IN ([IT], [HR], [Finance])) says: "turn each distinct department value into its own column, and put the summed salary in that column"
Result: instead of 3 rows (one per department), you get 1 row with 3 columns — IT, HR, Finance — each holding that department's total
The department names in the IN (...) list have to be known/specified ahead of time — this is a common limitation of static PIVOT in SQL Server, unlike dynamic pivoting which can handle unknown categories, but that's a more advanced technique for later

-----------------------------------------------------------
## Practice 5: Recursive CTE

Say you have an employee hierarchy where each employee has a manager (also an employee):
----------------------------------------------------------
## sql
CREATE TABLE EmployeeHierarchy (
    Id INT PRIMARY KEY,
    Name VARCHAR(50),
    ManagerId INT NULL
);

INSERT INTO EmployeeHierarchy VALUES
(1, 'CEO Karan', NULL),        -- top of hierarchy, no manager
(2, 'VP Priya', 1),
(3, 'VP Raj', 1),
(4, 'Manager Amit', 2),
(5, 'Manager Sneha', 2),
(6, 'Developer Rohit', 4);
Recursive CTE query — get the full chain under the CEO:
sql
WITH OrgChart AS (
    -- Base case: start with the CEO (no manager)
    SELECT Id, Name, ManagerId, 0 AS Level
    FROM EmployeeHierarchy
    WHERE ManagerId IS NULL

    UNION ALL

    -- Recursive case: find employees whose manager is already in OrgChart
    SELECT e.Id, e.Name, e.ManagerId, oc.Level + 1
    FROM EmployeeHierarchy e
    INNER JOIN OrgChart oc ON e.ManagerId = oc.Id
)
SELECT * FROM OrgChart
ORDER BY Level;
---------------------------------------------------------------
Key logic:

Base case (before UNION ALL): finds the starting point — here, the CEO, who has no manager
Recursive case (after UNION ALL): joins the table back to the CTE itself (OrgChart), finding employees whose manager was found in the previous step — this keeps happening automatically, level by level, until no more matches exist
Level tracks depth in the hierarchy — CEO is 0, VPs are 1, Managers are 2, Developer is 3 — useful for indenting an org chart visually in a report
This pattern generalizes to any parent-child structure — category trees, folder structures, comment threads with replies, org charts — anywhere data references itself