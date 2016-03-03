USE StudentWallet
GO
/****** Object:  User [NT SERVICE\ReportServer]    Script Date: 3/2/2016 12:21:04 PM ******/
CREATE USER [NT SERVICE\ReportServer] FOR LOGIN [NT SERVICE\ReportServer] WITH DEFAULT_SCHEMA=[NT SERVICE\ReportServer]
GO
/****** Object:  User [##MS_PolicyEventProcessingLogin##]    Script Date: 3/2/2016 12:21:05 PM ******/
CREATE USER [##MS_PolicyEventProcessingLogin##] FOR LOGIN [##MS_PolicyEventProcessingLogin##] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [##MS_AgentSigningCertificate##]    Script Date: 3/2/2016 12:21:05 PM ******/
CREATE USER [##MS_AgentSigningCertificate##] FOR LOGIN [##MS_AgentSigningCertificate##]
GO
/****** Object:  DatabaseRole [RSExecRole]    Script Date: 3/2/2016 12:21:05 PM ******/
CREATE ROLE [RSExecRole]
GO
ALTER ROLE [RSExecRole] ADD MEMBER [NT SERVICE\ReportServer]
GO
/****** Object:  Schema [NT SERVICE\ReportServer]    Script Date: 3/2/2016 12:21:05 PM ******/
CREATE SCHEMA [NT SERVICE\ReportServer]
GO
/****** Object:  Schema [RSExecRole]    Script Date: 3/2/2016 12:21:05 PM ******/
CREATE SCHEMA [RSExecRole]
GO
/****** Object:  StoredProcedure [dbo].[Admin_login]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Admin_login]
	@em varchar(50),
	@pwd varchar(20), 
	@type int
AS
	select Employee.Email,Employee.Password,Employee.empId, Employee.empType_ID from Employee where Email=@em and  Password=@pwd and  empType_ID=@type
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[fetchAcademicYear]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fetchAcademicYear]
	@id int
AS
	SELECT Year,AcademicID from AcademicYear where AcademicID=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[fetchBoard]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fetchBoard]
	@id int

As
SELECT Name,Board_Id from Board where Board_Id=@id
return 0
GO
/****** Object:  StoredProcedure [dbo].[fetchCity]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fetchCity]
	@id int
AS
	SELECT Name,CityID from City where CityID=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[fetchCountry]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fetchCountry]
	@id int
AS
	SELECT Name,CountryID from Country where CountryID=@id
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[fetchEmployeeType]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fetchEmployeeType]
	@id int

As
SELECT TypeName,empType_ID from EmployeeType where empType_ID=@id
return 0
GO
/****** Object:  StoredProcedure [dbo].[fetchLogin]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fetchLogin]
	@em varchar(50),
	@pwd varchar(20) 
AS
	select Email,Password, empId,empType_ID from Employee where Email=@em and  Password=@pwd
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[insertAcademicYear]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--declare @y varchar(15)
--SELECT @y=Year FROM AcademicYear WHERE Year = '1991-1992'




CREATE PROCEDURE [dbo].[insertAcademicYear]
	@year varchar(15),
	@byWhom int,
	@returnVal int = 0 output
AS
Begin
	Begin Transaction
	declare @y varchar(15)
		SELECT @y=Year FROM AcademicYear WHERE Year = @year

			IF @y IS NULL 
			begin
				insert into AcademicYear(Year,CreatedByWhom) values (@year,@byWhom)
				set @returnVal = @@IDENTITY
					if(@@ERROR != 0)
					Begin
						print 'in'
						set @returnVal = 0
						print @returnVal
						rollback transaction
					End
					Else
					Begin
						print 'out'
						set @returnVal = 1
						print @returnVal
						commit transaction
					End
			End
			Else
			begin
			rollback transaction
				set @returnVal = -999
				print @returnVal
			End
End
GO
/****** Object:  StoredProcedure [dbo].[insertBoard]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--declare @y varchar(15)
--SELECT @y=Name FROM Board WHERE Name = 'CBSC'

CREATE PROCEDURE [dbo].[insertBoard]
	@Name varchar(15),
	@byWhom int,
	@returnVal int = 0 output
AS
Begin
	Begin Transaction
	declare @y varchar(15)
		SELECT @y=Name FROM Board WHERE Name = @Name

			IF @y IS NULL 
			begin
				insert into Board(Name,CreatedByWhom) values (@Name,@byWhom)
				set @returnVal = @@IDENTITY
					if(@@ERROR != 0)
					Begin
						print 'in'
						set @returnVal = 0
						print @returnVal
						rollback transaction
					End
					Else
					Begin
						print 'out'
						set @returnVal = 1
						print @returnVal
						commit transaction
					End
			End
			Else
			begin
			rollback transaction
				set @returnVal = -999
				print @returnVal
			End
End
GO
/****** Object:  StoredProcedure [dbo].[insertBoardSchoolMapping]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertBoardSchoolMapping]
	
AS
Begin

	Begin Transaction
	 declare @sch int,
	@board int,
	@bywhom int

	insert into BoardSchoolMapping(School_Id,Board_Id,CreatedByWhom)values (@sch,@board,@bywhom )
	if(@@ERROR != 0)
	Begin
		print 'in'
		rollback transaction
	End
	Else
	Begin
		print 'out'
		commit transaction
	End
	End
GO
/****** Object:  StoredProcedure [dbo].[insertCity]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--declare @y varchar(15)
--SELECT @y=Name ,@s=StateID FROM City WHERE Name = 'Ahmedabad' and StateID=1

CREATE PROCEDURE [dbo].[insertCity]
	@Name varchar(15),
	@StateID int,
	@byWhom int,
	@returnVal int = 0 output
AS
Begin
	Begin Transaction
	declare @y varchar(15),@s int
		SELECT @y=Name, @s=StateID FROM City WHERE Name = @Name and StateID=@StateID

			IF @y IS NULL 
			begin
				insert into City(Name,StateID,CreatedByWhom) values (@Name,@StateID,@byWhom)
				set @returnVal = @@IDENTITY
					if(@@ERROR != 0)
					Begin
						print 'in'
						set @returnVal = 0
						print @returnVal
						rollback transaction
					End
					Else
					Begin
						print 'out'
						set @returnVal = 1
						print @returnVal
						commit transaction
					End
			End
			Else
			begin
			rollback transaction
				set @returnVal = -999
				print @returnVal
			End
End
GO
/****** Object:  StoredProcedure [dbo].[insertClassTeacher]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertClassTeacher]
AS
Begin

	Begin Transaction
	 declare @teacher int,
	@stddiv int,
	@year int,
	@byWhom int

	insert into ClassTeacher (TeacherID,StandardDivisionID,AcadamicYear_Id,CreatedByWhom)values(@teacher,@stddiv,@year,@byWhom)
if(@@ERROR != 0)
	Begin
		print 'in'
		rollback transaction
	End
	Else
	Begin
		print 'out'
		commit transaction
	End
	End
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[insertCountry]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--declare @y varchar(15)
--SELECT @y=Name  FROM Country WHERE Name = 'India' 

CREATE PROCEDURE [dbo].[insertCountry]
	@Name varchar(15),
	@byWhom int,
	@returnVal int = 0 output
AS
Begin
	Begin Transaction
	declare @y varchar(15)
		SELECT @y=Name FROM Country WHERE Name = @Name 

			IF @y IS NULL 
			begin
				insert into Country(Name,CreatedByWhom) values (@Name,@byWhom)
				set @returnVal = @@IDENTITY
					if(@@ERROR != 0)
					Begin
						print 'in'
						set @returnVal = 0
						print @returnVal
						rollback transaction
					End
					Else
					Begin
						print 'out'
						set @returnVal = 1
						print @returnVal
						commit transaction
					End
			End
			Else
			begin
			rollback transaction
				set @returnVal = -999
				print @returnVal
			End
End
GO
/****** Object:  StoredProcedure [dbo].[insertDivison]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertDivison]

AS
Begin

	Begin Transaction
	 declare @div varchar(3),
	@byWhom	int

	insert into Division (Name,CreatedByWhom) values (@div,@byWhom)
	if(@@ERROR != 0)
	Begin
		print 'in'
		rollback transaction
	End
	Else
	Begin
		print 'out'
		commit transaction
	End
	End
GO
/****** Object:  StoredProcedure [dbo].[insertEmployee]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertEmployee]
AS
Begin

	Begin Transaction
	 declare @pass varchar(20),
	@fname varchar(20),
	@mname varchar(20),
	@lname varchar(20),
	@birthdate date,
	@email varchar(50),
	@gender bit,
	@type int,
	@contact_No numeric(10,0),
	@address varchar(100),
	@bywhom int
	

	insert into Employee(Password,FirstName,MiddleName,LastName,Birthdate,Email,Gender,ContactNo,Address,empType_ID,CreatedByWhom)values(@pass,@fname,@mname,@lname,@birthdate,@email,@gender,@contact_No,@address,@type,@bywhom)
if(@@ERROR != 0)
	Begin
		print 'in'
		rollback transaction
	End
	Else
	Begin
		print 'out'
		commit transaction
	End
	End
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[insertEmployeeType]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--declare @y varchar(15)
--SELECT @y=TypeName  FROM EmployeeType WHERE TypeName = 'Teacher' 

CREATE PROCEDURE [dbo].[insertEmployeeType]
	@TypeName varchar(15),
	@byWhom int,
	@returnVal int = 0 output
AS
Begin
	Begin Transaction
	declare @y varchar(15)
		SELECT @y=TypeName FROM EmployeeType WHERE TypeName = @TypeName 

			IF @y IS NULL 
			begin
				insert into EmployeeType(TypeName,CreatedByWhom) values (@TypeName,@byWhom)
				set @returnVal = @@IDENTITY
					if(@@ERROR != 0)
					Begin
						print 'in'
						set @returnVal = 0
						print @returnVal
						rollback transaction
					End
					Else
					Begin
						print 'out'
						set @returnVal = 1
						print @returnVal
						commit transaction
					End
			End
			Else
			begin
			rollback transaction
				set @returnVal = -999
				print @returnVal
			End
End
GO
/****** Object:  StoredProcedure [dbo].[insertFeesDetail]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertFeesDetail]
AS
Begin

	Begin Transaction
	 declare @std int,
	@shift int,
	@fees_sec int,
	@amount numeric(10,2),
	@yr int,
	@bywhom int

	insert into FeesDetail(StandardID,Shift_Id,Fees_Section_Id,Amount,Acadamic_ID,CreatedByWhom) values(@std,@shift,@fees_sec,@amount,@yr,@bywhom)

if(@@ERROR != 0)
	Begin
		print 'in'
		rollback transaction
	End
	Else
	Begin
		print 'out'
		commit transaction
	End
	End
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[insertFeesSection]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertFeesSection]
AS
Begin

	Begin Transaction
	 declare @name varchar(15),
@bywhom int	

	insert into FeesSection(Name,CreatedByWhom) values (@name,@bywhom)
if(@@ERROR != 0)
	Begin
		print 'in'
		rollback transaction
	End
	Else
	Begin
		print 'out'
		commit transaction
	End
	End
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[insertOccupation]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertOccupation]
				AS
Begin
declare @name varchar(20)

	insert into Occupation (name) values (@name)
if(@@ERROR != 0)
	Begin
		print 'in'
		rollback transaction
	End
	Else
	Begin
		print 'out'
		commit transaction
	End
	End
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[insertQualification]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertQualification]
			AS
Begin
declare @name varchar(20)

	insert into Qualification (Name) values (@name)
if(@@ERROR != 0)
	Begin
		print 'in'
		rollback transaction
	End
	Else
	Begin
		print 'out'
		commit transaction
	End
	End
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[insertReligion]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertReligion]
		AS
Begin
declare @name varchar(20)

	insert into Religion (Name) values (@name)
if(@@ERROR != 0)
	Begin
		print 'in'
		rollback transaction
	End
	Else
	Begin
		print 'out'
		commit transaction
	End
	End
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[InsertSchool]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[InsertSchool]
As
Begin

	Begin Transaction
	
		Declare @name varchar(20),
		 @off_no numeric(10,0),
		 @mob_no	numeric(10,0),
	@site	varchar(50),
	@add varchar(100),
	@CreatedBywhom int

	insert into School(Name,office_no,mob_no,WebsiteName,Address,CreatedByWhom)values(@name,@off_no,@mob_no,@site,@add,@CreatedBywhom)
	if(@@ERROR != 0)
	Begin
		print 'in'
		rollback transaction
	End
	Else
	Begin
		print 'out'
		commit transaction
	End
	End
GO
/****** Object:  StoredProcedure [dbo].[insertShift]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertShift]
	
AS
Begin

	Begin Transaction
	 declare @shift varchar(10),
	@byWhom int
	insert into Shift (Shift_Name,CreatedByWhom) values(@shift,@byWhom)
	if(@@ERROR != 0)
	Begin
		print 'in'
		rollback transaction
	End
	Else
	Begin
		print 'out'
		commit transaction
	End
	End
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[insertStandard]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertStandard]
AS
Begin

	Begin Transaction
	 declare @name varchar(20),
	@level int,
	@byWhom int

	insert into Standard(Name,LevelOfstd,CreatedByWhom) values (@name,@level,@byWhom)
	if(@@ERROR != 0)
	Begin
		print 'in'
		rollback transaction
	End
	Else
	Begin
		print 'out'
		commit transaction
	End
	End
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[insertStandardAcademicYear]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertStandardAcademicYear]
	@aca int,
	@std int,
	@smonth varchar(15),
	@emonth varchar(15),
	@bywhom int,
	@returnVal int = 0 output
AS
Begin

	Begin Transaction
	

		insert into AcadamicYearStandardMapping(Acadamic_Id,StandardId,Start_month,End_Month,CreatedByWhom) values (@aca,@std,@smonth,@emonth,@bywhom)


	if(@@ERROR != 0)
	Begin
		print 'in'
		set @returnVal = @@IDENTITY
		rollback transaction
	End
	Else
	Begin
		print 'out'
		commit transaction
	End
End
GO
/****** Object:  StoredProcedure [dbo].[insertStandardDivisonShift]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertStandardDivisonShift]
AS
Begin

	Begin Transaction
	 declare @stddivid int,
	@shiftid int,
	@year int,
	@s_time time,
	@e_time time,
	@bywhom int

	insert into StandarddivisonShiftMapping(StandardDivisionID,Shift_Id,AcadamicId,StartTime,endTime,CreatedByWhom) values (@stddivid,@shiftid,@year,@s_time,@e_time,@bywhom)
if(@@ERROR != 0)
	Begin
		print 'in'
		rollback transaction
	End
	Else
	Begin
		print 'out'
		commit transaction
	End
	End
GO
/****** Object:  StoredProcedure [dbo].[insertStandardSubject]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertStandardSubject]
AS
Begin

	Begin Transaction
	 declare @sub int,
	@std int,
	@yr int,
	@type varchar(15),
	@bywhom int

	insert into StandardSubjectMapping(SubjectID,StandardId,AcadamicId,Type,CreatedByWhom) values(@sub,@std,@yr,@type,@bywhom)
if(@@ERROR != 0)
	Begin
		print 'in'
		rollback transaction
	End
	Else
	Begin
		print 'out'
		commit transaction
	End
	End
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[insertStandardVDivison]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertStandardVDivison]

AS
Begin

	Begin Transaction
	 declare @std int,
	@div int,
	@year int,
	@byWhom int

	insert into StandardDivisionMapping(StandardID,DivisionID,AcademicID,CreatedBywhom) values(@std ,@div,@year,@byWhom)
if(@@ERROR != 0)
	Begin
		print 'in'
		rollback transaction
	End
	Else
	Begin
		print 'out'
		commit transaction
	End
	End
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[insertState]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertState]
		AS
Begin

	Begin Transaction
	 declare @state varchar(15),
	@country int,
	@bywhom int

	insert into State(CountryID,Name,CreatedByWhom)values(@country,@state,@bywhom)
	if(@@ERROR != 0)
	Begin
		print 'in'
		rollback transaction
	End
	Else
	Begin
		print 'out'
		commit transaction
	End
	End
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[insertSubject]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertSubject]
AS
Begin

	Begin Transaction
	 declare @name varchar(20),
	@bywhom int
insert into Subject(Name,CreatedByWhom) values (@name,@bywhom)
if(@@ERROR != 0)
	Begin
		print 'in'
		rollback transaction
	End
	Else
	Begin
		print 'out'
		commit transaction
	End
	End
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[insertSubjectTeacher]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertSubjectTeacher]
AS
Begin

	Begin Transaction
	 declare @sub int,
	@teacher int,
	@year int,
	@stddiv int,
	@byWhom int

	insert into SubjectTeacher (SubjectID,TeacherID,AcademicYearID,StandardDivisionID,CreatedByWhom) values(@sub,@teacher,@year,@stddiv,@byWhom)
if(@@ERROR != 0)
	Begin
		print 'in'
		rollback transaction
	End
	Else
	Begin
		print 'out'
		commit transaction
	End
	End
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[listAcademicYear]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listAcademicYear]	

AS
Begin
declare @qry varchar(max)

set @qry='SELECT * from AcademicYear'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listBoard]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listBoard]
	
AS
Begin
declare @qry varchar(max)

set @qry='SELECT * from Board'
execute(@qry)
RETURN 0
End
	
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[listcity]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listcity]
	
AS
Begin
declare @qry varchar(max)

set @qry='select [City].*,State.StateID,State.Name as statname,EmployeeType.empType_ID,EmployeeType.TypeName,Employee.empId,Employee.empType_ID
	FROM City INNER JOIN State
	ON City.StateID=State.StateID
	INNER JOIN EmployeeType
	ON City.CreatedByWhom=EmployeeType.empType_ID
	INNER JOIN Employee
	ON Employee.empType_ID=EmployeeType.empType_ID'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listClassTeacher]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listClassTeacher]
	
AS
Begin
declare @qry varchar(max)

set @qry='SELECT [ClassTeacher].*,AcademicYear.AcademicID,AcademicYear.Year,StandardDivisionMapping.StandardDivisionID,StandardDivisionMapping.StandardID,StandardDivisionMapping.DivisionID,Standard.StandardID,Standard.Name,Division.DivisionID,Division.Name as divname,Employee.empId,Employee.FirstName,Employee.LastName
	FROM[ClassTeacher] INNER JOIN StandardDivisionMapping
	ON ClassTeacher.StandardDivisionID = StandardDivisionMapping.StandardDivisionID
	INNER JOIN Standard
	ON Standard.StandardID =StandardDivisionMapping.StandardID
	INNER JOIN Division
	ON Division.DivisionID =StandardDivisionMapping.DivisionID
	INNER JOIN Employee
	ON Employee.empId =ClassTeacher.TeacherID
	INNER JOIN AcademicYear
	ON AcademicYear.AcademicID =ClassTeacher.AcadamicYear_Id'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listCountry]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listCountry]
	
AS
Begin
declare @qry varchar(max)

set @qry='select [Country].*,EmployeeType.empType_ID,
			EmployeeType.TypeName
			FROM Country
			INNER JOIN EmployeeType
			ON Country.CreatedByWhom=EmployeeType.empType_ID'
			
execute(@qry)
RETURN 0
End

--select [Country].*,EmployeeType.empType_ID,
--			EmployeeType.TypeName,Employee.empId,Employee.empType_ID
--			FROM Country
--			INNER JOIN EmployeeType
--			ON Country.CreatedByWhom=EmployeeType.empType_ID
--			INNER JOIN Employee
--			ON Employee.empType_ID=EmployeeType.empType_ID'
GO
/****** Object:  StoredProcedure [dbo].[listDivison]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listDivison]
	
AS
Begin
declare @qry varchar(max)

set @qry='SELECT * from Division'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listEmployee]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listEmployee]	

AS
Begin
declare @qry varchar(max)

set @qry='SELECT [Employee].*,EmployeeType.empType_ID,EmployeeType.TypeName
	from Employee INNER JOIN EmployeeType
	ON Employee.empType_ID =EmployeeType.empType_ID'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listEmployeeType]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listEmployeeType]
	

	
AS
Begin
declare @qry varchar(max)

set @qry='SELECT e.*,e.TypeName as Name from EmployeeType e left outer join EmployeeType e2 on  e.empType_ID=e2.empType_ID'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listFeesDetail]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listFeesDetail]
	
AS
Begin
declare @qry varchar(max)

set @qry='SELECT [FeesDetail].*,Standard.StandardID,Standard.Name,Shift.Shift_Id,Shift.Shift_Name,FeesSection.Fees_Section_Id,FeesSection.Name as HeadName,AcademicYear.AcademicID,AcademicYear.Year
	from FeesDetail
	INNER JOIN Standard
	ON FeesDetail.StandardID=Standard.StandardID
	INNER JOIN Shift
	ON FeesDetail.Shift_Id=Shift.Shift_Id
	INNER Join FeesSection
	ON FeesDetail.Fees_Section_Id=FeesSection.Fees_Section_Id
	INNER JOIN	AcademicYear
	ON FeesDetail.Acadamic_ID=AcademicYear.AcademicID'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listFeesSection]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listFeesSection]
	
AS
Begin
declare @qry varchar(max)

set @qry='SELECT * from FeesSection'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listOccupation]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listOccupation]
	
AS
Begin
declare @qry varchar(max)

set @qry='SELECT * from Occupation'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listQualification]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listQualification]
	
AS
Begin
declare @qry varchar(max)

set @qry='SELECT * from Qualification'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listreligion]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listreligion]

AS
Begin
declare @qry varchar(max)

set @qry='SELECT * from Religion'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listSchool]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listSchool]
	
AS
Begin
declare @qry varchar(max)

set @qry='select * from School'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listSchoolBoard]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listSchoolBoard]
	
AS

Begin
declare @qry varchar(max)

set @qry='select [Board].*,School.School_Id,School.Name as schoolname,[BoardSchoolMapping].*
	FROM Board INNER JOIN BoardSchoolMapping
	ON BoardSchoolMapping.Board_Id = Board.Board_Id
	INNER JOIN School
	ON School.School_Id=BoardSchoolMapping.School_Id'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listShift]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listShift]
	

AS
Begin
declare @qry varchar(max)

set @qry='SELECT * from Shift'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listStandard]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listStandard]
	
AS
Begin
declare @qry varchar(max)

set @qry='select * from Standard'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listStandardAcademicYear]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listStandardAcademicYear]
	

AS
Begin
declare @qry varchar(max)

set @qry='select [AcadamicYearStandardMapping].*,Standard.StandardID,Standard.Name,AcademicYear.AcademicID,AcademicYear.Year
	from [AcadamicYearStandardMapping] 
	INNER JOIN Standard 
	ON AcadamicYearStandardMapping.StandardId=Standard.StandardID
	INNER JOIN AcademicYear
	ON AcadamicYearStandardMapping.Acadamic_Id=AcademicYear.AcademicID'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listStandardDivison]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listStandardDivison]
	
AS
Begin
declare @qry varchar(max)

set @qry='select [StandardDivisionMapping].*,Standard.StandardID,Standard.Name,Division.DivisionID,Division.Name as DivName,AcademicYear.AcademicID,AcademicYear.Year
	FROM[StandardDivisionMapping] INNER JOIN Standard
	ON StandardDivisionMapping.StandardID = Standard.StandardID
	INNER JOIN Division
	on Division.DivisionID=StandardDivisionMapping.DivisionID
	INNER JOIN AcademicYear
	on AcademicYear.AcademicID=StandardDivisionMapping.AcademicID'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listStandardDivisonShift]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listStandardDivisonShift]
	

AS
Begin
declare @qry varchar(max)

set @qry='SELECT [StandarddivisonShiftMapping].*,StandardDivisionMapping.StandardID,StandardDivisionMapping.DivisionID,Standard.StandardID,Standard.Name as stdName,Division.DivisionID,Division.Name,Shift.Shift_Id,Shift.Shift_Name,AcademicYear.AcademicID,AcademicYear.Year
	from StandarddivisonShiftMapping INNER JOIN StandardDivisionMapping
	On StandarddivisonShiftMapping.StandardDivisionID=StandardDivisionMapping.StandardDivisionID
	INNER JOIN Standard
	ON StandardDivisionMapping.StandardID=Standard.StandardID
	INNER JOIN Division
	ON StandardDivisionMapping.DivisionID=Division.DivisionID
	INNER Join Shift
	On StandarddivisonShiftMapping.Shift_Id=Shift.Shift_Id
	INNER JOIN AcademicYear
	On StandarddivisonShiftMapping.AcadamicId=AcademicYear.AcademicID'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listStandardsubject]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listStandardsubject]
AS
Begin
declare @qry varchar(max)

set @qry='SELECT [StandardSubjectMapping].*,Subject.Name as subname,Subject.SubjectID,Standard.StandardID,Standard.Name,AcademicYear.AcademicID,AcademicYear.Year
	FROM StandardSubjectMapping INNER JOIN Standard
	ON StandardSubjectMapping.StandardId = Standard.StandardID
	INNER JOIN Subject
	ON StandardSubjectMapping.SubjectID=Subject.SubjectID
	INNER JOIN AcademicYear
	ON StandardSubjectMapping.AcadamicId=AcademicYear.AcademicID'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listState]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listState]
	
AS
Begin
declare @qry varchar(max)

set @qry='SELECT * from State'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listSubject]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listSubject]
	
AS
Begin
declare @qry varchar(max)

set @qry='SELECT * from Subject'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[listSubjectTeacher]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listSubjectTeacher]
	
AS
Begin
declare @qry varchar(max)

set @qry='SELECT [SubjectTeacher].*,AcademicYear.AcademicID,AcademicYear.Year,StandardDivisionMapping.StandardDivisionID,StandardDivisionMapping.StandardID,StandardDivisionMapping.DivisionID,Standard.StandardID,Standard.Name,Division.DivisionID,Division.Name as divname,Employee.empId,Employee.FirstName,Employee.LastName,Subject.SubjectID,Subject.Name as SubName
	FROM[SubjectTeacher] INNER JOIN StandardDivisionMapping
	ON SubjectTeacher.StandardDivisionID = StandardDivisionMapping.StandardDivisionID
	INNER JOIN Standard
	ON Standard.StandardID =StandardDivisionMapping.StandardID
	INNER JOIN Division
	ON Division.DivisionID =StandardDivisionMapping.DivisionID
	INNER JOIN Employee
	ON Employee.empId =SubjectTeacher.TeacherID
	INNER JOIN AcademicYear
	ON AcademicYear.AcademicID =SubjectTeacher.AcademicYearID
	INNER JOIN Subject
	ON Subject.SubjectID =SubjectTeacher.SubjectID'
execute(@qry)
RETURN 0
End
GO
/****** Object:  StoredProcedure [dbo].[test]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[test]
	@y varchar(20),
	@id int
AS
	Update AcademicYear set Year=@y where AcademicID=@id
RETURN 0

GO
/****** Object:  StoredProcedure [dbo].[updateAcademicYear]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateAcademicYear]
	@yr varchar(20),
	@id int,
	@returnVal int = 0 output
AS
Begin
	Begin Transaction
	declare @y varchar(15)
		SELECT @y=Year FROM AcademicYear WHERE Year = @yr

			IF @y IS NULL 
			begin
				Update AcademicYear set Year=@yr where AcademicID=@id
				set @returnVal = @@IDENTITY
					if(@@ERROR != 0)
					Begin
						print 'in'
						set @returnVal = 0
						print @returnVal
						rollback transaction
					End
					Else
					Begin
						print 'out'
						set @returnVal = 1
						print @returnVal
						commit transaction
					End
			End
			Else
			begin
			rollback transaction
				set @returnVal = -999
				print @returnVal
			End
End
GO
/****** Object:  StoredProcedure [dbo].[updateboard]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateboard]
	@name varchar(20),
	@id int,
	@returnVal int = 0 output
AS
	
Begin
	Begin Transaction
	declare @y varchar(15)
		SELECT @y=Name FROM Board WHERE Name = @name

			IF @y IS NULL 
			begin
				update Board set Name=@name where Board_Id=@id
				set @returnVal = @@IDENTITY
					if(@@ERROR != 0)
					Begin
						print 'in'
						set @returnVal = 0
						print @returnVal
						rollback transaction
					End
					Else
					Begin
						print 'out'
						set @returnVal = 1
						print @returnVal
						commit transaction
					End
			End
			Else
			begin
			rollback transaction
				set @returnVal = -999
				print @returnVal
			End
End
GO
/****** Object:  StoredProcedure [dbo].[updateCity]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateCity]
	@name varchar(20),
	@id int,
	@returnVal int = 0 output
AS
	
Begin
	Begin Transaction
	declare @y varchar(15)
		SELECT @y=Name FROM City WHERE Name = @name

			IF @y IS NULL 
			begin
				update City set Name=@name where CityID=@id
				set @returnVal = @@IDENTITY
					if(@@ERROR != 0)
					Begin
						print 'in'
						set @returnVal = 0
						print @returnVal
						rollback transaction
					End
					Else
					Begin
						print 'out'
						set @returnVal = 1
						print @returnVal
						commit transaction
					End
			End
			Else
			begin
			rollback transaction
				set @returnVal = -999
				print @returnVal
			End
End
GO
/****** Object:  StoredProcedure [dbo].[updateCountry]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateCountry]
	@name varchar(20),
	@id int,
	@returnVal int = 0 output
AS
	
Begin
	Begin Transaction
	declare @y varchar(15)
		SELECT @y=Name FROM Country WHERE Name = @name

			IF @y IS NULL 
			begin
				update Country set Name=@name where CountryID=@id
				set @returnVal = @@IDENTITY
					if(@@ERROR != 0)
					Begin
						print 'in'
						set @returnVal = 0
						print @returnVal
						rollback transaction
					End
					Else
					Begin
						print 'out'
						set @returnVal = 1
						print @returnVal
						commit transaction
					End
			End
			Else
			begin
			rollback transaction
				set @returnVal = -999
				print @returnVal
			End
End
GO
/****** Object:  StoredProcedure [dbo].[updateEmplyeeType]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateEmplyeeType]
	@name varchar(20),
	@id int,
	@returnVal int = 0 output
AS
	
Begin
	Begin Transaction
	declare @y varchar(15)
		SELECT @y=TypeName FROM EmployeeType WHERE TypeName = @name

			IF @y IS NULL 
			begin
				update EmployeeType set TypeName=@name where empType_ID=@id
				set @returnVal = @@IDENTITY
					if(@@ERROR != 0)
					Begin
						print 'in'
						set @returnVal = 0
						print @returnVal
						rollback transaction
					End
					Else
					Begin
						print 'out'
						set @returnVal = 1
						print @returnVal
						commit transaction
					End
			End
			Else
			begin
			rollback transaction
				set @returnVal = -999
				print @returnVal
			End
End
GO
/****** Object:  StoredProcedure [dbo].[updateFeesSection]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateFeesSection]
	@name varchar(20),
	@id int,
	@returnVal int = 0 output
AS
Begin
	Begin Transaction
	declare @y varchar(15)
		SELECT @y=Name FROM FeesSection WHERE Name = @name

			IF @y IS NULL 
			begin
				update FeesSection set Name=@name where Fees_Section_Id=@id
				set @returnVal = @@IDENTITY
					if(@@ERROR != 0)
					Begin
						print 'in'
						set @returnVal = 0
						print @returnVal
						rollback transaction
					End
					Else
					Begin
						print 'out'
						set @returnVal = 1
						print @returnVal
						commit transaction
					End
			End
			Else
			begin
			rollback transaction
				set @returnVal = -999
				print @returnVal
			End
End
GO
/****** Object:  Table [dbo].[AcadamicYearStandardMapping]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AcadamicYearStandardMapping](
	[Academic_year_standardId] [int] IDENTITY(1,1) NOT NULL,
	[Acadamic_Id] [int] NOT NULL,
	[StandardId] [int] NOT NULL,
	[Start_month] [varchar](10) NOT NULL,
	[End_Month] [varchar](10) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_AcadamicYearAccordingtoStamdard] PRIMARY KEY CLUSTERED 
(
	[Academic_year_standardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AcademicYear]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AcademicYear](
	[AcademicID] [int] IDENTITY(1,1) NOT NULL,
	[Year] [varchar](15) NOT NULL,
	[IsActiveYear] [bit] NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_AcademicYearMaster] PRIMARY KEY CLUSTERED 
(
	[AcademicID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Assignment]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Assignment](
	[AssignmentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Title] [varchar](20) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_Assignment] PRIMARY KEY CLUSTERED 
(
	[AssignmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AssignmentTeacherMapping]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignmentTeacherMapping](
	[Assign_acc_Teacher_Id] [int] IDENTITY(1,1) NOT NULL,
	[SubTeacherId] [int] NOT NULL,
	[AssingmentId] [int] NOT NULL,
	[Standard_id] [int] NOT NULL,
	[status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_AssignmentAccordingtoTeacher] PRIMARY KEY CLUSTERED 
(
	[Assign_acc_Teacher_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Attendance](
	[AttendanceID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[ClassTeacherID] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Remarks] [varchar](20) NOT NULL,
	[Present] [bit] NOT NULL,
	[AcadamicYearId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED 
(
	[AttendanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Board]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Board](
	[Board_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedbyWhom] [int] NULL,
 CONSTRAINT [PK_Board_Detail] PRIMARY KEY CLUSTERED 
(
	[Board_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BoardSchoolMapping]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoardSchoolMapping](
	[School_Board_Id] [int] IDENTITY(1,1) NOT NULL,
	[School_Id] [int] NOT NULL,
	[Board_Id] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_BoardAccordingSchool] PRIMARY KEY CLUSTERED 
(
	[School_Board_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Certificate]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Certificate](
	[CertificateID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[Purpose] [varchar](50) NOT NULL,
	[DateOfRequest] [date] NOT NULL,
	[CurrentStatus] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NOT NULL,
 CONSTRAINT [PK_Certificate] PRIMARY KEY CLUSTERED 
(
	[CertificateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[City]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[City](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[StateID] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_CityMaster] PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClassTeacher]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassTeacher](
	[ClassTeacherID] [int] IDENTITY(1,1) NOT NULL,
	[TeacherID] [int] NOT NULL,
	[StandardDivisionID] [int] NOT NULL,
	[AcadamicYear_Id] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Country](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_CountryMaster] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Division]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Division](
	[DivisionID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](3) NOT NULL,
	[Status] [bit] NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_DivisionMaster] PRIMARY KEY CLUSTERED 
(
	[DivisionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[empId] [int] IDENTITY(1,1) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[FirstName] [varchar](20) NOT NULL,
	[MiddleName] [varchar](20) NOT NULL,
	[LastName] [varchar](20) NOT NULL,
	[Birthdate] [date] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[ContactNo] [numeric](10, 0) NOT NULL,
	[Address] [varchar](max) NOT NULL,
	[empType_ID] [int] NULL,
	[Status] [bit] NULL,
	[CreatedDate] [date] NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_TeacherLogin] PRIMARY KEY CLUSTERED 
(
	[empId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeType]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeType](
	[empType_ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](20) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [nchar](10) NULL,
 CONSTRAINT [PK_Employe_Type] PRIMARY KEY CLUSTERED 
(
	[empType_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EventsList]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EventsList](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](10) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_EventsList] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Exam]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Exam](
	[ExamID] [int] IDENTITY(1,1) NOT NULL,
	[Term] [varchar](50) NOT NULL,
	[Label] [varchar](50) NOT NULL,
	[StandardID] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_Exam] PRIMARY KEY CLUSTERED 
(
	[ExamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ExamSchedule]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamSchedule](
	[ExamScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[ExamId] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
	[ExamDate] [date] NOT NULL,
	[Time] [time](7) NOT NULL,
	[ClassroomNumber] [numeric](5, 0) NOT NULL,
	[MarksOfferd] [numeric](3, 0) NOT NULL,
	[PassingMarks] [numeric](2, 0) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NOT NULL,
 CONSTRAINT [PK_ExamSchedule] PRIMARY KEY CLUSTERED 
(
	[ExamScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExamStandardMapping]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamStandardMapping](
	[ExamStandardID] [int] IDENTITY(1,1) NOT NULL,
	[ExamID] [int] NOT NULL,
	[DivisionID] [int] NOT NULL,
	[StandardDivisionID] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_ExamStandard] PRIMARY KEY CLUSTERED 
(
	[ExamStandardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FeesDetail]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeesDetail](
	[Fees_std_shift_Id] [int] IDENTITY(1,1) NOT NULL,
	[StandardID] [int] NOT NULL,
	[Shift_Id] [int] NOT NULL,
	[Fees_Section_Id] [int] NOT NULL,
	[Amount] [numeric](7, 0) NOT NULL,
	[Acadamic_ID] [int] NOT NULL,
	[Status] [bit] NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_Fees_Std_Shift] PRIMARY KEY CLUSTERED 
(
	[Fees_std_shift_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FeesSection]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FeesSection](
	[Fees_Section_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](15) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_Fees_Head] PRIMARY KEY CLUSTERED 
(
	[Fees_Section_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HealthInformation]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HealthInformation](
	[HealthID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[Height] [decimal](3, 1) NOT NULL,
	[Weight] [decimal](3, 1) NOT NULL,
	[Allergies] [varchar](50) NOT NULL,
	[Handicapped] [bit] NOT NULL,
	[BloodGroup] [char](2) NOT NULL,
	[PreviousIssues] [varchar](50) NOT NULL,
	[Disease] [varchar](50) NULL,
	[EyeProblem] [bit] NULL,
	[DoctorName] [varchar](50) NULL,
	[DoctorContactNo] [numeric](10, 0) NULL,
 CONSTRAINT [PK_HealthInformation] PRIMARY KEY CLUSTERED 
(
	[HealthID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Notification](
	[NotificationID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[Date] [date] NOT NULL,
	[TeacherID] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedByWhom] [int] NULL,
	[CreatedDate] [date] NOT NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[NotificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Occupation]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Occupation](
	[OccupationId] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Occupation] PRIMARY KEY CLUSTERED 
(
	[OccupationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ParentsGuardianDetail]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ParentsGuardianDetail](
	[ParentID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[FirstName] [varchar](20) NOT NULL,
	[MiddleName] [varchar](20) NOT NULL,
	[LastName] [varchar](20) NOT NULL,
	[Photo] [varchar](20) NULL,
	[BirthDate] [date] NULL,
	[Anniversary] [date] NULL,
	[QualificationID] [int] NOT NULL,
	[OccupationID] [int] NOT NULL,
	[HomeAddress] [varchar](50) NOT NULL,
	[OfficeAddress] [varchar](50) NULL,
	[ContactNo] [numeric](10, 0) NOT NULL,
	[AnnualIncome] [numeric](7, 0) NULL,
 CONSTRAINT [PK_Parents_GuardianDetails] PRIMARY KEY CLUSTERED 
(
	[ParentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PreviousSchoolDetail]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PreviousSchoolDetail](
	[PreviousSchoolingID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Board] [varchar](50) NOT NULL,
	[Standard] [varchar](10) NOT NULL,
	[Result] [varchar](50) NOT NULL,
	[Address] [varchar](max) NOT NULL,
 CONSTRAINT [PK_PreviousSchooling] PRIMARY KEY CLUSTERED 
(
	[PreviousSchoolingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Qualification]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Qualification](
	[QualificationId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Qualification] PRIMARY KEY CLUSTERED 
(
	[QualificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReferenceDetail]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ReferenceDetail](
	[ReferenceID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[ContactNo] [numeric](10, 0) NOT NULL,
	[Relation] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ReferenceDetails] PRIMARY KEY CLUSTERED 
(
	[ReferenceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Religion]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Religion](
	[ReligionID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ReligionMaster] PRIMARY KEY CLUSTERED 
(
	[ReligionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[School]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[School](
	[School_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[office_no] [numeric](10, 0) NOT NULL,
	[mob_no] [numeric](10, 0) NOT NULL,
	[WebsiteName] [varchar](50) NOT NULL,
	[Address] [varchar](max) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_SchoolDetail] PRIMARY KEY CLUSTERED 
(
	[School_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Shift]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Shift](
	[Shift_Id] [int] IDENTITY(1,1) NOT NULL,
	[Shift_Name] [varchar](20) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_Shift] PRIMARY KEY CLUSTERED 
(
	[Shift_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SiblingDetail]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SiblingDetail](
	[SiblingID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[FromOtherSchool] [bit] NOT NULL,
	[SiblingStudentID] [int] NULL,
	[SchoolName] [varchar](50) NULL,
	[Standard] [int] NULL,
 CONSTRAINT [PK_SiblingDetails] PRIMARY KEY CLUSTERED 
(
	[SiblingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Standard]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Standard](
	[StandardID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[LevelOfstd] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_StandardMaster] PRIMARY KEY CLUSTERED 
(
	[StandardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StandardDivisionMapping]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StandardDivisionMapping](
	[StandardDivisionID] [int] IDENTITY(1,1) NOT NULL,
	[StandardID] [int] NOT NULL,
	[DivisionID] [int] NOT NULL,
	[AcademicID] [int] NOT NULL,
	[Status] [bit] NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedBywhom] [int] NULL,
 CONSTRAINT [PK_StandardDivisionMaster] PRIMARY KEY CLUSTERED 
(
	[StandardDivisionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StandarddivisonShiftMapping]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StandarddivisonShiftMapping](
	[std_div_shift_Id] [int] IDENTITY(1,1) NOT NULL,
	[StandardDivisionID] [int] NOT NULL,
	[Shift_Id] [int] NOT NULL,
	[AcadamicId] [int] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[endTime] [time](7) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_Std_Div_shift] PRIMARY KEY CLUSTERED 
(
	[std_div_shift_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StandardEventMapping]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StandardEventMapping](
	[StandardWiseEventID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NOT NULL,
	[StandardDivisionID] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_StandardWiseEvents] PRIMARY KEY CLUSTERED 
(
	[StandardWiseEventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StandardNotificationMapping]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StandardNotificationMapping](
	[StandardWiseNotificationID] [int] IDENTITY(1,1) NOT NULL,
	[NotificationID] [int] NOT NULL,
	[StandardDivisionID] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedbyWhom] [int] NULL,
 CONSTRAINT [PK_StandardWiseNotification] PRIMARY KEY CLUSTERED 
(
	[StandardWiseNotificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StandardSubjectMapping]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StandardSubjectMapping](
	[StandardWiseSubjectID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NOT NULL,
	[StandardId] [int] NOT NULL,
	[Type] [varchar](20) NULL,
	[AcadamicId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_StandardWiseSubjectMaster] PRIMARY KEY CLUSTERED 
(
	[StandardWiseSubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[State]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[State](
	[StateID] [int] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_StateMaster] PRIMARY KEY CLUSTERED 
(
	[StateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[LoginID] [numeric](10, 0) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[FirstName] [varchar](20) NOT NULL,
	[MiddleName] [varchar](20) NOT NULL,
	[LastName] [varchar](20) NOT NULL,
	[Birthdate] [date] NULL,
	[Email] [varchar](50) NULL,
	[ContactNo] [numeric](10, 0) NOT NULL,
	[Photo] [varchar](50) NULL,
	[Gender] [bit] NOT NULL,
	[Address] [varchar](max) NOT NULL,
	[CityID] [int] NOT NULL,
	[Pincode] [numeric](7, 0) NOT NULL,
	[Nationality] [bit] NOT NULL,
	[Other_Nationality] [varchar](50) NOT NULL,
	[ReligionId] [int] NOT NULL,
	[MotherTongue] [varchar](10) NOT NULL,
	[LanguagesKnown] [varchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NOT NULL,
 CONSTRAINT [PK_StudentLogin_1] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentNotificationMapping]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentNotificationMapping](
	[StudentWiseNotificationID] [int] IDENTITY(1,1) NOT NULL,
	[NotificationID] [int] NOT NULL,
	[StandarDivisionID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_StudentWiseNotification] PRIMARY KEY CLUSTERED 
(
	[StudentWiseNotificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentStandardAcademicYearMapping]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentStandardAcademicYearMapping](
	[StudentAcadmicYearID] [int] IDENTITY(1,1) NOT NULL,
	[Academic_Year_StandardID] [int] NOT NULL,
	[StandardDivisionID] [int] NOT NULL,
	[StudentRollNo] [numeric](15, 0) NOT NULL,
	[StudentID] [int] NOT NULL,
	[StandardWiseSubjectID] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_StudentAcademicYear] PRIMARY KEY CLUSTERED 
(
	[StudentAcadmicYearID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subject]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Status] [bit] NULL,
	[CreatedDate] [date] NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_SubjectMaster] PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SubjectTeacher]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectTeacher](
	[SubjectTeacherID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NOT NULL,
	[TeacherID] [int] NOT NULL,
	[AcademicYearID] [int] NOT NULL,
	[StandardDivisionID] [int] NOT NULL,
	[Status] [bit] NULL,
	[CreatedDate] [date] NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_SubjectTeacherMaster] PRIMARY KEY CLUSTERED 
(
	[SubjectTeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TimeSlot]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSlot](
	[TimeSlotID] [int] IDENTITY(1,1) NOT NULL,
	[TimeTableID] [int] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[BreakTime] [time](7) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_TimeSlot] PRIMARY KEY CLUSTERED 
(
	[TimeSlotID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TimeTable]    Script Date: 3/2/2016 12:21:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeTable](
	[TimeTableID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectTeacherID] [int] NOT NULL,
	[StandardDivisionID] [int] NOT NULL,
	[Day] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedByWhom] [int] NULL,
 CONSTRAINT [PK_TimeTable] PRIMARY KEY CLUSTERED 
(
	[TimeTableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AcadamicYearStandardMapping] ADD  CONSTRAINT [DF_AcadamicYearStandardMapping_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[AcadamicYearStandardMapping] ADD  CONSTRAINT [DF_AcadamicYearStandardMapping_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[AcademicYear] ADD  CONSTRAINT [DF_AcademicYear_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Assignment] ADD  CONSTRAINT [DF_Assignment_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Assignment] ADD  CONSTRAINT [DF_Assignment_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[AssignmentTeacherMapping] ADD  CONSTRAINT [DF_AssignmentTeacherMapping_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Attendance] ADD  CONSTRAINT [DF_Attendance_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Attendance] ADD  CONSTRAINT [DF_Attendance_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Board] ADD  CONSTRAINT [DF_Board_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Board] ADD  CONSTRAINT [DF_Board_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[BoardSchoolMapping] ADD  CONSTRAINT [DF_BoardSchoolMapping_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[BoardSchoolMapping] ADD  CONSTRAINT [DF_BoardSchoolMapping_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Certificate] ADD  CONSTRAINT [DF_Certificate_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Certificate] ADD  CONSTRAINT [DF_Certificate_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[City] ADD  CONSTRAINT [DF_City_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[City] ADD  CONSTRAINT [DF_City_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ClassTeacher] ADD  CONSTRAINT [DF_ClassTeacherMaster_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[ClassTeacher] ADD  CONSTRAINT [DF_ClassTeacherMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF_Country_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF_Country_CreatedDTE]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Division] ADD  CONSTRAINT [DF_Division_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Division] ADD  CONSTRAINT [DF__DivisionM__Creat__4F67C174]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF__TeacherLo__Creat__505BE5AD]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[EmployeeType] ADD  CONSTRAINT [DF_EmployeeType_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[EmployeeType] ADD  CONSTRAINT [DF_EmployeeType_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[EventsList] ADD  CONSTRAINT [DF_EventsList_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[EventsList] ADD  CONSTRAINT [DF_EventsList_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Exam] ADD  CONSTRAINT [DF_Exam_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Exam] ADD  CONSTRAINT [DF_Exam_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ExamSchedule] ADD  CONSTRAINT [DF_ExamSchedule_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[ExamSchedule] ADD  CONSTRAINT [DF_ExamSchedule_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ExamStandardMapping] ADD  CONSTRAINT [DF_ExamStandardMapping_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[ExamStandardMapping] ADD  CONSTRAINT [DF_ExamStandardMapping_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[FeesDetail] ADD  CONSTRAINT [DF_FeesStandardShiftMapping_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[FeesDetail] ADD  CONSTRAINT [DF_FeesStandardShiftMapping_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[FeesSection] ADD  CONSTRAINT [DF_FeesSection_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[FeesSection] ADD  CONSTRAINT [DF_FeesSection_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Notification] ADD  CONSTRAINT [DF_Notification_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Notification] ADD  CONSTRAINT [DF_Notification_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[School] ADD  CONSTRAINT [DF_School_Staus]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[School] ADD  CONSTRAINT [DF_School_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Shift] ADD  CONSTRAINT [DF_Shift_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Shift] ADD  CONSTRAINT [DF_Shift_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Standard] ADD  CONSTRAINT [DF_Standard_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Standard] ADD  CONSTRAINT [DF_Standard_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[StandardDivisionMapping] ADD  CONSTRAINT [DF_StandardDivisionMapping_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[StandardDivisionMapping] ADD  CONSTRAINT [DF__StandardD__Creat__52442E1F]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[StandarddivisonShiftMapping] ADD  CONSTRAINT [DF_StandarddivisonShiftMapping_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[StandarddivisonShiftMapping] ADD  CONSTRAINT [DF_StandarddivisonShiftMapping_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[StandardEventMapping] ADD  CONSTRAINT [DF_StandardEventMapping_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[StandardEventMapping] ADD  CONSTRAINT [DF_StandardEventMapping_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[StandardNotificationMapping] ADD  CONSTRAINT [DF_StandardNotificationMapping_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[StandardNotificationMapping] ADD  CONSTRAINT [DF_StandardNotificationMapping_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[StandardSubjectMapping] ADD  CONSTRAINT [DF_StandardSubjectMapping_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[StandardSubjectMapping] ADD  CONSTRAINT [DF_StandardSubjectMapping_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[State] ADD  CONSTRAINT [DF_State_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[State] ADD  CONSTRAINT [DF_State_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[StudentNotificationMapping] ADD  CONSTRAINT [DF_StudentNotificationMapping_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[StudentStandardAcademicYearMapping] ADD  CONSTRAINT [DF_StudentStandardAcademicYearMapping_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[StudentStandardAcademicYearMapping] ADD  CONSTRAINT [DF_StudentStandardAcademicYearMapping_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Subject] ADD  CONSTRAINT [DF_Subject_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Subject] ADD  CONSTRAINT [DF_Subject_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[SubjectTeacher] ADD  CONSTRAINT [DF_SubjectTeacher_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[SubjectTeacher] ADD  CONSTRAINT [DF_SubjectTeacher_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[TimeSlot] ADD  CONSTRAINT [DF_TimeSlot_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[TimeSlot] ADD  CONSTRAINT [DF_TimeSlot_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[TimeTable] ADD  CONSTRAINT [DF_TimeTable_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[TimeTable] ADD  CONSTRAINT [DF_TimeTable_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
