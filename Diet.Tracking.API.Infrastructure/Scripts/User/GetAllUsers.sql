SELECT
    id,
    first_name as FirstName,
    last_name as LastName,
    birth_date as BirthDate,
    biological_gender as BiologicalGender,
    current_weight as CurrentWeight,
    goal_weight as GoalWeight,
    height,
    workout_frequency as WorkoutFrequency,
    personal_goal as PersonalGoal
FROM
    "Projetos"."user"
ORDER BY
    id
LIMIT :PageSize
OFFSET (:PageNumber - 1) * :PageSize
