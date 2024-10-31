-- Получить список пациентов и врача с последнего приёма
with patients_a as(
 select p."name" as patient_name, max(r.start_date_time) as last_date
 from receptions r 
 join patients p on r.id_patients = p.id 
 join docktors d on r.id_docktors = d.id 
 group by p."name" 
) 

select distinct p.patient_name, d."name" 
from patients_a p 
join receptions r on p.last_date = r.start_date_time
join docktors d on r.id_docktors = d.id 