--ok-- select * from [dbo].[AppAuth]
--truncate table [GramDB].[dbo].[AppAuth]
--INSERT INTO [GramDB].[dbo].[AppAuth] ([UserId],[CompanyId]) VALUES (1,999)
-----------------------------------------------
--ok-- select * from [dbo].[AppUsers]
--delete from [GramDB].[dbo].[AppUsers]
--DBCC CHECKIDENT ('[GramDB].[dbo].[AppUsers]', RESEED, 0)
--INSERT INTO [GramDB].[dbo].[AppUsers] ([WinUser],[FullName],[EmailAddress],[InsDate]) VALUES ('hkylidis','Kylidis Haralampos','hkylidis@moh.gr','20171001')
-----------------------------------------------
--ok-- select * from [dbo].[Company]
--truncate table [GramDB].[dbo].[Company]
--INSERT INTO [GramDB].[dbo].[Company] ([id],[Name]) VALUES (1,'MOTOR OIL')
--INSERT INTO [GramDB].[dbo].[Company] ([id],[Name]) VALUES (2,'AVIN')
--INSERT INTO [GramDB].[dbo].[Company] ([id],[Name]) VALUES (3,'LPC')
--INSERT INTO [GramDB].[dbo].[Company] ([id],[Name]) VALUES (4,'BFS')
--INSERT INTO [GramDB].[dbo].[Company] ([id],[Name]) VALUES (5,'��������')
--INSERT INTO [GramDB].[dbo].[Company] ([id],[Name]) VALUES (6,'MOTOR OIL TRADING')
--INSERT INTO [GramDB].[dbo].[Company] ([id],[Name]) VALUES (7,'��. �����. ���������')
--INSERT INTO [GramDB].[dbo].[Company] ([id],[Name]) VALUES (8,'CYTOP')
--INSERT INTO [GramDB].[dbo].[Company] ([id],[Name]) VALUES (9,'��.��.��.')
--INSERT INTO [GramDB].[dbo].[Company] ([id],[Name]) VALUES (10,'��.��.�.�.�')
--INSERT INTO [GramDB].[dbo].[Company] ([id],[Name]) VALUES (11,'�.�.��.�')
-----------------------------------------------
--xx-- select * from [dbo].[Contacts]
--truncate table [GramDB].[dbo].[Contacts]
-----------------------------------------------
--ok-- select * from [dbo].[Doc]
--truncate table [GramDB].[dbo].[Doc]
--INSERT INTO [GramDB].[dbo].[Doc] ([DocType] ,[DocName] ,[DocCont]) VALUES ('Manual', 'ProtocolManual.pdf', '0x25504.....')
-----------------------------------------------
--ok-- select * from [dbo].[DocsIds]
--truncate table [GramDB].[dbo].[DocsIds]
-----------------------------------------------
--ok-- select * from [dbo].[Folders]
--truncate table [GramDB].[dbo].[Folders]
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (1,'����� ������ �������', '����� ������ �������', 1, 1)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (2,'����� ������ �������', '����� ������ �������', 1, 2)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (3,'����� ������ �������', '����� ������ �������', 2, 1)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (4,'����� ������ �������', '����� ������ �������', 2, 2)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (5,'����� ������ �������', '����� ������ �������', 3, 1)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (6,'����� ������ �������', '����� ������ �������', 3, 2)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (7,'����� ������ �������', '����� ������ �������', 4, 1)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (8,'����� ������ �������', '����� ������ �������', 4, 2)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (9,'����� ������ �������', '����� ������ �������', 5, 1)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (10,'����� ������ �������', '����� ������ �������', 5, 2)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (11,'����� ������ �������', '����� ������ �������', 6, 1)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (12,'����� ������ �������', '����� ������ �������', 6, 2)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (13,'����� ������ �������', '����� ������ �������', 7, 1)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (14,'����� ������ �������', '����� ������ �������', 7, 2)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (15,'����� ������ �������', '����� ������ �������', 8, 1)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (16,'����� ������ �������', '����� ������ �������', 8, 2)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (17,'����� ������ �������', '����� ������ �������', 9, 1)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (18,'����� ������ �������', '����� ������ �������', 9, 2)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (19,'����� ������ �������', '����� ������ �������', 10, 1)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (20,'����� ������ �������', '����� ������ �������', 10, 2)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (21,'����� ������ �������', '����� ������ �������', 11, 1)
--INSERT INTO [GramDB].[dbo].[Folders] ([Id],[Name],[Descr],[CompanyId],[ProcedId]) VALUES (22,'����� ������ �������', '����� ������ �������', 11, 2)
-----------------------------------------------
--ok-- select * from [dbo].[Proced]
--truncate table [GramDB].[dbo].Proced
--INSERT INTO [GramDB].[dbo].[Proced] ([id],[Name],[ProcedId],[Counter],[YearInit]) VALUES (1,'�����������',1,'ES',0)
--INSERT INTO [GramDB].[dbo].[Proced] ([id],[Name],[ProcedId],[Counter],[YearInit]) VALUES (2,'����������',2,'EJ',0)
-----------------------------------------------
--ok-- select * from [dbo].[Protok] 
--truncate table [GramDB].[dbo].[Protok]
-----------------------------------------------
--ok-- select * from [dbo].[ProtokPdf]
--truncate table [GramDB].[dbo].[ProtokPdf]
-----------------------------------------------
--ok-- select * from [dbo].[ReceiverList]
--truncate table [GramDB].[dbo].[ReceiverList]
-----------------------------------------------
--ok-- select * from [dbo].[TableIds]
--truncate table [GramDB].[dbo].[TableIds]
--INSERT INTO [GramDB].[dbo].[TableIds] ([TABLENAME],[NUM]) VALUES ('DocsIds', 0)
--INSERT INTO [GramDB].[dbo].[TableIds] ([TABLENAME],[NUM]) VALUES ('Protok', 0)
--INSERT INTO [GramDB].[dbo].[TableIds] ([TABLENAME],[NUM]) VALUES ('VersionInfo', 1012)
--INSERT INTO [GramDB].[dbo].[TableIds] ([TABLENAME],[NUM]) VALUES ('Contacts', 10057) --??
-----------------------------------------------
--ok-- select * from [dbo].[ToCcBcc]
--truncate table [GramDB].[dbo].[ToCcBcc]
--INSERT INTO [GramDB].[dbo].[ToCcBcc] ([Id],[Name]) VALUES (1, 'To') 
--INSERT INTO [GramDB].[dbo].[ToCcBcc] ([Id],[Name]) VALUES (2, 'CC') 
--INSERT INTO [GramDB].[dbo].[ToCcBcc] ([Id],[Name]) VALUES (3, 'BCC') 
-----------------------------------------------
