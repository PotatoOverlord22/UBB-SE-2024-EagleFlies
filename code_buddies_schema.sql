IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'CodeBuddiesDB')
BEGIN
    CREATE DATABASE CodeBuddiesDB;
END


USE CodeBuddiesDB

CREATE TABLE Buddies(
	
	id bigint PRIMARY KEY,
	buddy_name varchar(100),
	profile_photo_url varchar(100),
	buddy_status varchar(50)

);

INSERT INTO Buddies VALUES
(1, 'Raul', 'pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png', 'active'),
(2, 'Beti', 'pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png', 'inactive'),
(3, 'Deni', 'pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png', 'active'),
(4, 'Cosmin',  'pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png', 'inactive'),
(5, 'Dragos',  'pack://application:,,,/CodeBuddies;component/resources/pictures/dog_picture.png', 'inactive')



SELECT * from Buddies

CREATE TABLE Sessions(
	
	id bigint PRIMARY KEY,
	owner_id  bigint FOREIGN KEY REFERENCES Buddies(id),
	session_name varchar(50),
	creation_date DateTime,
	last_edit_date DateTime
)

INSERT INTO Sessions VALUES
(1, 1, 'session1', '2024-03-21T10:15:00', '2024-04-21T10:45:00'),
(2, 2, 'session2', '2024-02-21T10:15:00', '2024-04-21T10:55:00'),
(3, 3, 'session3', '2024-01-21T10:15:00', '2024-04-21T10:35:00')

SELECT * from Sessions


CREATE TABLE BuddiesSessions(
	buddy_id bigint FOREIGN KEY REFERENCES Buddies(id),
	session_id bigint FOREIGN KEY REFERENCES Sessions(id) ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY (buddy_id, session_id) 
)

delete from BuddiesSessions

INSERT INTO BuddiesSessions VALUES
(1, 1),
(2, 1),
(3, 1),
(2, 2),
(5, 2),
(1, 2)

select * from BuddiesSessions

CREATE TABLE Notifications(
	id bigint PRIMARY KEY,
	notification_timestamp DATETIME,
	notification_type varchar(50),
	notification_status varchar(50),
	notification_description varchar(1000),
	sender_id bigint FOREIGN KEY REFERENCES Buddies(id),
	receiver_id bigint FOREIGN KEY REFERENCES Buddies(id),
	session_id bigint FOREIGN KEY REFERENCES Sessions(id)
)

DELETE FROM Notifications

INSERT INTO Notifications VALUES
(1, '2024-04-21T08:30:00', 'successInformation', 'delivered', 'Cosmin accepted your invitation', 4, 1, 1),
(2, '2024-04-20T14:45:00', 'rejectInformation', 'delivered', 'Beti rejected your invitation', 2, 1, 1),
(3, '2024-04-21T10:15:00', 'invite',  'pending', 'Invited by Beti - Accept or Decline', 2, 1, 1),
(4, '2024-04-21T10:15:00', 'invite',  'pending', 'Invited by Cosmin - Accept or Decline', 4, 1, 3),
(5, '2024-04-21T10:15:00', 'invite',  'pending', 'Invited by Dragos - Accept or Decline', 5, 1, 2),
(6, '2024-04-21T10:15:00', 'invite',  'pending', 'Invited by Raul - Accept or Decline', 1, 2, 2)

SELECT * from Notifications

CREATE TABLE CodeContributions(
	id bigint PRIMARY KEY,
	buddy_id bigint FOREIGN KEY REFERENCES Buddies(id),
	contribution_value int,
	contribution_date DATETIME,
	session_id bigint FOREIGN KEY REFERENCES Sessions(id) ON DELETE CASCADE ON UPDATE CASCADE
)

INSERT INTO CodeContributions VALUES
(1, 1, 44, '2024-01-15T10:15:00', 1),
(2, 1, 55, '2024-01-19T10:15:00', 1),
(3, 2, 66, '2024-01-20T10:15:00', 1)

SELECT * FROM CodeContributions

CREATE TABLE CodeReviews(
	id bigint PRIMARY KEY,
	owner_id bigint FOREIGN KEY REFERENCES Buddies(id),
	code_section varchar(1000),
	code_review_status varchar(50),
)

INSERT INTO CodeReviews VALUES
(1, 1, 'section1', 'open'),
(2, 2, 'section2', 'closed'),
(3, 1, 'section3', 'open')

SELECT * FROM CodeReviews


CREATE TABLE CodeReviewsSessions(
	code_review_id bigint FOREIGN KEY REFERENCES CodeReviews(id) ON DELETE CASCADE ON UPDATE CASCADE,
	session_id bigint FOREIGN KEY REFERENCES Sessions(id) ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY (code_review_id)
)

INSERT INTO CodeReviewsSessions VALUES
(1, 1),
(2, 1),
(3, 2)

CREATE TABLE Messages(
	id bigint PRIMARY KEY,
	message_timestamp DATETIME,
	content VARCHAR(1000),
	sender_id  bigint FOREIGN KEY REFERENCES Buddies(id)
)

INSERT INTO Messages VALUES
(1, '2024-01-11T10:15:00', 'message1', 1),
(2, '2024-01-12T10:15:00', 'message2', 2),
(3, '2024-01-13T10:15:00', 'message3', 1),
(4, '2024-01-14T10:15:00', 'message4', 1),
(5, '2024-01-15T10:15:00', 'message5', 1),
(6, '2024-01-16T10:15:00', 'message6', 1)

CREATE TABLE MessagesCodeReviews(
	code_review_id bigint FOREIGN KEY REFERENCES CodeReviews(id) ON DELETE CASCADE ON UPDATE CASCADE,
	message_id bigint FOREIGN KEY REFERENCES Messages(id) ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY (message_id)
)



INSERT INTO MessagesCodeReviews VALUES
(1, 1),
(1, 2),
(2, 3)


CREATE TABLE MessagesSessions(
	session_id bigint FOREIGN KEY REFERENCES Sessions(id) ON DELETE CASCADE ON UPDATE CASCADE,
	message_id bigint FOREIGN KEY REFERENCES Messages(id) ON DELETE CASCADE ON UPDATE CASCADE,

	PRIMARY KEY (message_id)
)

INSERT INTO MessagesSessions VALUES
(1, 4),
(1, 5),
(2, 6)


select * from Messages




/*

select
    'data source=' + @@servername +
    ';initial catalog=' + db_name() +
    case type_desc
        when 'WINDOWS_LOGIN' 
            then ';trusted_connection=true'
        else
            ';user id=' + suser_name() + ';password=<<YourPassword>>'
    end
    as ConnectionString
from sys.server_principals
where name = suser_name()

*/