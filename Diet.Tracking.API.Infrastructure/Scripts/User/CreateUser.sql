INSERT INTO "Projetos"."user" (
    first_name,
    last_name,
    birth_date,
    biological_gender,
    current_weight,
    goal_weight,
    height,
    workout_frequency,
    personal_goal
)
VALUES (
    :FirstName,
    :LastName,
    :BirthDate,
    :BiologicalGender,
    :CurrentWeight,
    :GoalWeight,
    :Height,
    :WorkoutFrequency,
    :PersonalGoal
);