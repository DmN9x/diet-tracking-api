UPDATE
    "Projetos"."user"
SET
    first_name        = :FirstName,
    last_name         = :LastName,
    birth_date        = :BirthDate,
    biological_gender = :BiologicalGender,
    current_weight    = :CurrentWeight,
    goal_weight       = :GoalWeight,
    height            = :Height,
    workout_frequency = :WorkoutFrequency,
    personal_goal     = :PersonalGoal
WHERE
    id = :Id;