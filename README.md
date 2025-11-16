
installation Guide:


[v 1.1.0]
פתח את Package Manager Console ב-Visual Studio והרץ:

Install-Package EntityFramework

צור מסד נתונים בשם DatwiseDB ב-SQL Server (או עדכן את ה-connectionString כדי להתאים לשרת שלך).

הרץ את סקריפטי ה-SQL בתיקיית /db (create_schema.sql ו-seed_data.sql) כדי ליצור טבלאות ונתוני דמה.

פתוח את הפרויקט כ-Web Application (או Web Site) ב-Visual Studio targeting .NET Framework 4.8.1.