

INSERT INTO [dbo].[Folders]
           ([Id]
           ,[Name]
           ,[Descr]
           ,[CompanyId]
           ,[ProcedId])

SELECT [Id] + 71
      ,[Name]
      ,[Descr]
      ,[CompanyId]
      ,[ProcedId]
  FROM [GramDB].[dbo].[Folders_ToAdd]