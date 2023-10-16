CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


CREATE TABLE cults(
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(1000) NOT NULL,
  coverImg VARCHAR(500) NOT NULL,
  fee DOUBLE DEFAULT 0,
  invitationRequired BOOLEAN DEFAULT false,
  memberCount INT DEFAULT 0,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  leaderId VARCHAR(255) NOT NULL,
  
  FOREIGN KEY (leaderId) REFERENCES accounts (id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

INSERT INTO cults
(name, description, coverImg, fee, `invitationRequired`, `leaderId`)
VALUES
("Pumpkin Spice Life", "All about that PSL life, Don't hate just cause your coffee taste like dirt?!", "https://images.unsplash.com/photo-1569383893830-b73dc4a03af0?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1974&q=80", 5, false, '6216b36ebc31a249987812b1');

INSERT INTO cults
(name, description, coverImg, fee, `invitationRequired`, `leaderId`)
VALUES
("Cult Of Croc", "Best shoes on the planet. If you haven't worn them and think they are gross you just don't know.", "https://www.crocs.com/c/shop-by/style/fuzz-lined-shoes", 25, true, '6526c4304dedc9f41b528495');

INSERT INTO cults
(name, description, coverImg, fee, `invitationRequired`, `leaderId`)
VALUES
("Puuurfect Harmony", "All about those fuzzy feline friends and worshiping them. no we don't eat catnip, stop asking. you will be reported to the cyber-police.", "https://images.unsplash.com/photo-1511275539165-cc46b1ee89bf?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80", 0, false, '6526c4304dedc9f41b528495');
