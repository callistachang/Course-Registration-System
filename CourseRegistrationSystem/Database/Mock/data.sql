# staff create account
INSERT INTO accounts VALUES ("staff420", "3e07dd2f8e6b35cea12aed59f0ce5acb", "da1f41fe4b087bd5d9ec4bb967116cd5");
INSERT INTO staffs VALUES ("ce40ed63-bb89-49e7-a4ae-59a387e59396", "Vivian Smitha", "Female", "staff420");

# student create account
INSERT INTO accounts VALUES ("student0001", "3ba8951276e415746df81183ccc7f69b", "874db7690f9ced1c476424ecff303042");
INSERT INTO students VALUES ("U1234567G", "Anne Lim", 1, "Female", "Singaporean", "student0001");

# staff create course
INSERT INTO courses VALUES ("CZ6666", "JavaScript Fundamentals", "In this course, you will be learning JavaScript, the language of the devils.", "SCSE", 4, "ce40ed63-bb89-49e7-a4ae-59a387e59396");
INSERT INTO slots VALUES ("60f51df9-3bb0-4046-948b-9bb2aed137b2", "LT1", "Monday", "08:30:00", "09:30:00", "Lecture");
INSERT INTO courseslots VALUES ("60f51df9-3bb0-4046-948b-9bb2aed137b2", "CZ6666");

# and classes
INSERT INTO classes VALUES ("10001", "30", "CZ6666");
INSERT INTO slots VALUES ("1c82bb65-d7b3-422e-8fc6-be78a41e71db", "TR2", "Monday", "08:30:00", "09:30:00", "Tutorial");
INSERT INTO classslots VALUES ("1c82bb65-d7b3-422e-8fc6-be78a41e71db", "10001");

# student join class
INSERT INTO classstudents VALUES ("U1234567G", "10001");
