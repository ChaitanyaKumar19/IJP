SELECT 'CREATE DATABASE "PortalDB"' WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'PortalDB');\gexec
\c "PortalDB"

-- Job Table
create table if not exists "Job"
(
    "JobId" char(6) primary key,
    "JobTitle" text not null,
    "JobDescription" text not null,
    "Salary" numeric not null
);

-- Skill Table
create table if not exists "Skill"
(
    "SkillId" char(6) primary key,
    "SkillName" text not null,
    "SkillLevel" text not null check ("SkillLevel" in ('B','I','A'))
);

-- Job Skill Table
create table if not exists "JobSkill"
(
    "JobId" char(6) references "Job",
    "SkillId" char(6) references "Skill",
    "Exp" int not null,
    primary key("JobId", "SkillId")
);

-- Employee Table
create table if not exists "Employee"
(
    "EmpId" char(6) primary key,
    "EmpName" text not null,
    "EmailId" text not null,
    "PhoneNo" numeric not null,
    "TotalExp" int not null,
    "JobId" char(6) references "Job"
);

SELECT 'CREATE DATABASE "JobPostDB"' WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'JobPostDB');\gexec
\c "JobPostDB"

-- Job Table
Create Table if not exists "Job"
(
	"JobId" char(6) primary key
); 

-- Job Post Table
create table if not exists "JobPost"
(
    "PostId" int generated always as Identity primary key,
    "JobId" char(6) references "Job",
    "DoP" date not null,
    "LastDatetoApply" date not null,
    "NoOfVacancies" int not null
);

SELECT 'CREATE DATABASE "EmployeePostDB"' WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'EmployeePostDB');\gexec
\c "EmployeePostDB"

--JobPost Table
create table if not exists "JobPost"
(
	"PostId" int primary key
);

-- Employee
create table if not exists "Employee"
(
	"EmpId" char(6) primary key
);

--Emp Post Table
create table if not exists "EmployeePost"
(
    "PostId" int references "JobPost",
    "EmpId" char(6) references "Employee",
    "AppliedDate" date not null,
    "ApplicationStatus" text not null check ("ApplicationStatus" in ('Reviewing','Accepted','Rejected')) default 'Reviewing',
    primary key("PostId", "EmpId")
);

SELECT 'CREATE DATABASE "EmployeeSkillDB"' WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'EmployeeSkillDB');\gexec
\c "EmployeeSkillDB"

-- Employee Table
create table if not exists "Employee"
(
    "EmpId" char(6) primary key
);

-- Skill Table
create table if not exists "Skill"
(
    "SkillId" char(6) primary key
);

-- Emp Skill Table
create table if not exists "EmployeeSkill"
(
    "EmpId" char(6) references "Employee",
    "SkillId" char(6) references "Skill",
    "SkillExp" int not null,
    primary key("EmpId", "SkillId")
);
