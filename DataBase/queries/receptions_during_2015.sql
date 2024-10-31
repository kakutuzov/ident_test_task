-- Получить все дни из 2015 гда и количество приемов в этот день

create temp table  if not exists all_days_of_year as 
  select * 
  from generate_series(date '2015-01-01', date '2015-12-31', '1 day');

select ad.generate_series, count(r.id)
from all_days_of_year ad
left join receptions r on r.start_date_time = ad.generate_series
group by 1

