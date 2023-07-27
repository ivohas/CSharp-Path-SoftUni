CREATE DATABASE University;
GO

USE University;

CREATE TABLE Majors
(
             MajorID INT NOT NULL,
             Name    NVARCHAR(50),
             CONSTRAINT PK_Majors PRIMARY KEY(MajorID)
);

CREATE TABLE Students
(
             StudentID     INT NOT NULL,
             StudentNumber INT NOT NULL,
             StudentName   NVARCHAR(255),
             MajorID       INT,
             CONSTRAINT PK_Students PRIMARY KEY(StudentID),
             CONSTRAINT FK_Students_Majors FOREIGN KEY(MajorID) REFERENCES Majors(MajorID)
);

CREATE TABLE Payments
(
             PaymentID     INT NOT NULL,
             PaymentDate   DATE DEFAULT GETDATE(),
             PaymentAmount DECIMAL(10, 2) NOT NULL,
             StudentID     INT NOT NULL,
             CONSTRAINT PK_Payments PRIMARY KEY(PaymentID),
             CONSTRAINT FK_Payments_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID)
);

CREATE TABLE Subjects
(
             SubjectID   INT NOT NULL,
             SubjectName NVARCHAR(255) NOT NULL,
             CONSTRAINT PK_Subjects PRIMARY KEY(SubjectID)
);

CREATE TABLE Agenda
(
             StudentID INT NOT NULL,
             SubjectID INT NOT NULL,
             CONSTRAINT PK_Agenda_StudentID_SubjectID PRIMARY KEY(StudentID, SubjectID),
             CONSTRAINT FK_Agenda_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
             CONSTRAINT FK_Agenda_Subjects FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID)
); 