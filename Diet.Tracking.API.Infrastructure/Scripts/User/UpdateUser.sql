UPDATE
    "Projetos"."user"
SET
    email             = :Email,
    password          = :Password,
    first_name        = :FirstName,
    last_name         = :LastName,
    birth_date        = :BirthDate,
    biological_gender = :BiologicalGender,
    current_weight    = :CurrentWeight,
    goal_weight       = :GoalWeight,
    height            = :Height,
    body_mass_index   = :BMI,
    workout_frequency = :WorkoutFrequency,
    personal_goal     = :PersonalGoal
WHERE
    id = :Id;