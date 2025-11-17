
-[Project Details]
	  ✔️ תיאור עסקי (Business Need)

			מנהלי בטיחות בארגונים צריכים יכולת לעקוב אחר אירועי בטיחות, לסנן לפי קטגוריה/אזור/תאריכים, לזהות מגמות מסוכנות מוקדם, ולהתמקד באזורים בעייתיים.

			המערכת שבניתי מאפשרת:

			איסוף אירועים ממספר מקורות

			שליפה מהירה ומסוננת לפי פרמטרים רלוונטיים

			הצגת מגמות בפילוחים חכמים

			שמירת היסטוריה מלאה

			הפקת דוחות למקבלי החלטות

			המערכת משמשת כלי מרכזי בניהול בטיחות ארגוני, חקירת אירועים, והפחתת סיכונים.



-installation Guide:


-[v 1.1.0]
פתח את Package Manager Console ב-Visual Studio והרץ:

Install-Package EntityFramework

צור מסד נתונים בשם DatwiseDB ב-SQL Server (או עדכן את ה-connectionString כדי להתאים לשרת שלך).

הרץ את סקריפטי ה-SQL בתיקיית /db (create_schema.sql ו-seed_data.sql) כדי ליצור טבלאות ונתוני דמה.

פתוח את הפרויקט כ-Web Application (או Web Site) ב-Visual Studio targeting .NET Framework 4.8.1.

התחבר עם משתמש לדוגמה:
   - משתמש: `admin@datwise.com`
   - סיסמה: `P@ssw0rd!`