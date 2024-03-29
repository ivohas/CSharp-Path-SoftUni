USE [SoftUni]

CREATE TABLE [Students](
  [StudentID] INT PRIMARY KEY NOT NULL, 
  [Name] NVARCHAR(100) UNIQUE NOT NULL

)

CREATE TABLE [Exams](
  [ExamID] int PRIMARY KEY IDENTITY(101,1) NOT NULL,
  [Name] NVARCHAR(100) NOT NULL

)

CREATE TABLE [StudentsExams](
  [StudentID] INT  FOREIGN KEY REFERENCES [Students]([StudentID]),
  [ExamID] INT  FOREIGN KEY REFERENCES[Exams]([ExamID]) ,
  PRIMARY KEY (StudentID,ExamID)
 
) 

 