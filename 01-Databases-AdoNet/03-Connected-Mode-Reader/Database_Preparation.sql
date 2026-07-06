CREATE DATABASE StudentDB;
GO
USE StudentDB;
GO

CREATE  TABLE STUDENT(
	Id INT PRIMARY KEY,
	Name VARCHAR(100),
	Email VARCHAR(50),
	Mobile VARCHAR(50)
)
GO

INSERT INTO STUDENT (id, Name,Email, Mobile ) VALUES ('101','Vasy BBB', 'dnskdfskd@gmail.com', '111111')
INSERT INTO STUDENT (id, Name,Email, Mobile ) VALUES ('102','Vasy ewBBB', 'dnsk112dfskd@gmail.com', '33333')
INSERT INTO STUDENT (id, Name,Email, Mobile ) VALUES ('103','Vasywe BBB', 'dnskdf33skd@gmail.com', '444')
INSERT INTO STUDENT (id, Name,Email, Mobile) VALUES ('104','Vasy eBBB', 'dnskdfsk4445d@gmail.com', '666667')
GO

---

CREATE PROCEDURE spGetStudents
As
BEGIN
	SELECT Id, Name, Email, Mobile FROM STUDENT
END

---

CREATE PROCEDURE spGetStudentId
(
	@Id INT
)
As
BEGIN
	SELECT Id, Name, Email, Mobile FROM STUDENT WHERE Id = @Id
END