# notes-web-app
RPNotes is a notes app that allows students to CRUD texts for specific lessons of a module. README includes database.

DROP TABLE IF EXISTS Lesson;
DROP TABLE IF EXISTS Topic;
DROP TABLE IF EXISTS Module;

CREATE TABLE Module (
    ModuleId VARCHAR (10)  NOT NULL PRIMARY KEY,
    Name     VARCHAR (100) NOT NULL
);

INSERT INTO Module (ModuleId, Name) VALUES 
('B215', 'Financial Accounting'),
('C286', 'Advanced Application Development in .NET')

CREATE TABLE Topic (
    TopicId  VARCHAR (50)  NOT NULL PRIMARY KEY,
    Title    VARCHAR (500) NOT NULL,
    ModuleId VARCHAR (10)  NOT NULL FOREIGN KEY REFERENCES Module (ModuleId)
);

INSERT INTO Topic (TopicId, Title, ModuleId) VALUES 
('Ajax', 'Ajax','C286'),
('Double Entry', 'Balancing Debit and Credit', 'B215'),
 ('Sales & Purchase', 'Accounting for buying and selling','B215'),
('EF', 'ASP.Net Entity Framework Core', 'C286'),
('jQuery', 'Basic jQuery Client-side Scripting', 'C286'),
('MVC', 'ASP.Net Model-View-Controller Framework', 'C286'),
('Web API', 'Provides data services to web applications', 'C286')

CREATE TABLE Lesson (
    ModuleId VARCHAR (10)   NOT NULL FOREIGN KEY REFERENCES Module(ModuleId),
    LessonId INT            NOT NULL,
    TopicId  VARCHAR (50)   NULL FOREIGN KEY REFERENCES Topic(TopicId),
    Notes    VARCHAR (1000) NOT NULL,
    Attachments VARCHAR (500)  NULL,
    PRIMARY KEY (ModuleId, LessonId)
);

INSERT INTO Lesson (ModuleId, LessonId, TopicId, Notes) VALUES 
('B215', 1, 'Double Entry', 'The whole system of double entry bookkeeping can be summarised in the following two rules:

All transactions have one entry in two different accounts (the double-entry bit)
All transactions have one debit entry (left side of account) and one credit entry (right side of account)'),
('B215', 2, 'Double Entry', 'Assets
Assets are any resources that are to be used in the business. Examples would include machinery, premises, stocks of goods and cash.

Liabilities
Liabilities refer to any borrowings undertaken by the firm to a third party, for example amounts owed to suppliers, bank overdrafts, loans, etc.

Capital
Capital refers to the value of the resources put into the firm by the owner(s).'),
('B215', 3, NULL, ''),
('B215', 4, NULL, ''),
('B215', 5, 'Sales & Purchase', 'Increases in stock
Purchases account - stocks of goods bought by the firm for resale
Returns inwards account - stocks previously sold that is returned by the customer due to the goods being unsuitable (e.g. they are damaged, the wrong type of goods, etc.)
Decreases in stock
Sales account - stocks of goods sold to customers
Returns outwards account - stocks previously purchased by the firm which is returned to the original supplier'),
('B215', 6, NULL, ''),
('B215', 7, NULL, ''),
('B215', 8, NULL, ''),
('B215', 9, NULL, ''),
('B215', 10, NULL, ''),
('B215', 11, NULL, ''),
('B215', 12, NULL, ''),
('B215', 13, NULL, ''),
('C286', 1, 'Ajax', 'Understanding the overall concepts and the rules of thumbs when making ajax call'),
('C286', 2, 'Ajax', ''),
('C286', 3, 'EF', ''),
('C286', 4, 'EF', ''),
('C286', 5, NULL, ''),
('C286', 6, NULL, ''),
('C286', 7, NULL, ''),
('C286', 8, NULL, ''),
('C286', 9, NULL, ''),
('C286', 10, NULL, ''),
('C286', 11, NULL, ''),
('C286', 12, NULL, ''),
('C286', 13, NULL, '')
