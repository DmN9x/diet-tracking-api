SELECT
    id,
    first_name as FirstName,
    last_name as LastName,
    birth_date as BirthDate,
    biological_gender as BiologicalGender,
    current_weight as CurrentWeight,
    goal_weight as GoalWeight,
    height,
    body_mass_index as BMI,
    workout_frequency as WorkoutFrequency,
    personal_goal as PersonalGoal
FROM
    "Projetos"."user"
WHERE
    id = :Id