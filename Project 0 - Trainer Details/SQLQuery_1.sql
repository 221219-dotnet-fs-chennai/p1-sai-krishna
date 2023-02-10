SELECT * from Trainer
SELECT * from Skills
DELETE from skills where Skill_id=15




SELECT * from Trainer as t
Inner JOIN Skills as s on
t.Trainer_id=s.trainer_id
Inner Join Education as e ON
t.Trainer_id=e.trainer_id
where t.Email='Sai@gmail.com';



select * from Movies