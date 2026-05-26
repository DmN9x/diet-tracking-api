INSERT INTO "Projetos"."user" (
    email,
    password,
    first_name,
    last_name,
    birth_date,
    biological_gender,
    current_weight,
    goal_weight,
    height,
    body_mass_index,
    workout_frequency,
    personal_goal
)
VALUES (
    :Email,
    :Password,
    :FirstName,
    :LastName,
    :BirthDate,
    :BiologicalGender,
    :CurrentWeight,
    :GoalWeight,
    :Height,
    :BMI,
    :WorkoutFrequency,
    :PersonalGoal
);