CREATE TABLE [Employees] (
  [EmployeeID] INT,
  [FirstName] VARCHAR(20),
  [LastName] VARCHAR(20),
  [Wage] DECIMAL(10, 2),
  [WageType] VARCHAR(20),
  [Address] VARCHAR(100),
  [City] VARCHAR(50),
  [State] VARHCAR(20),
  [ZIP] VARCHAR(20),
  [StartDate] DATE,
  [TerminationDate] DATE,
  [ManagerID] INT,
  [Title] VARCHAR(50)
);

CREATE TABLE [Authors] (
  [AuthorID] INT,
  [AuthorFirstName] VARCHAR(20),
  [AuthorLastName] VARCHAR(20),
  [AuthorDateofBirth] DATE
);


CREATE TABLE [Books] (
  [ISBN] INT,
  [AuthorID] INT,
  [PublishDate] DATE,
  [PublisherID] INT,
  [QuantityHeld] INT,
  [QuantityCheckedOut] INT
);

CREATE TABLE [Publishers] (
  [PublisherID] INT,
  [PublisherName] VARCHAR(100)
);

CREATE TABLE [Customers] (
  [CustomerID] INT,
  [CustomerFirstName] VARCHAR(20),
  [CustomerLastName] VARCHAR(20),
  [SignupDate] DATE
);

CREATE TABLE [Transactions] (
  [TransactionID] INT,
  [ISBN] INT,
  [CheckoutDate] DATE,
  [CheckInDate] DATE,
  [CustomerID] INT,
  [EmployeeID] INT,
  [Quantity] INT
);
