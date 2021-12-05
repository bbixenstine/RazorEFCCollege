# RazorEFCCollege
RazorCollege Initial version has single SQLite database with tables Student, Course and Enrollment 
It creates the database from scratch, then applies it, using 
var context = services.GetRequiredService(); context.Database.EnsureCreated(); DbInitializer.Initialize(context);
