using System;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
	public class ExerciseController : ControllerBase
	{
		private readonly User user;

		public List<Exercise> Exercises { get; }

		private const string EXERCISE_FILE_NAME = "exercises.dat";
		private const string ACTIVITY_FILE_NAME = "activity.dat";

		public List<Activity> Activities { get; }

		public ExerciseController(User user)
        {
			this.user = user ?? throw new ArgumentNullException(nameof(user));
			Exercises = GetAllExercises();
			Activities = GetAllActivities();
		}

		public void Add(Activity activity, DateTime begin, DateTime end)
		{
			var act = Activities.SingleOrDefault(a => a.Name == activity.Name);

			if (act == null)
			{
				Activities.Add(activity);

				var exercise = new Exercise(begin, end, activity, user);
				Exercises.Add(exercise);

			}
			else
			{
				var exercise = new Exercise(begin, end, activity, user);
				Exercises.Add(exercise);

			}
			Save();

		}

		private List<Activity> GetAllActivities()
		{
			return Load<List<Activity>>(ACTIVITY_FILE_NAME) ?? new List<Activity>();
		}

		private List<Exercise> GetAllExercises()
        {
			return Load<List<Exercise>>(EXERCISE_FILE_NAME) ?? new List<Exercise>();
        }

		private void Save()
        {
			Save(EXERCISE_FILE_NAME, Exercises);
			Save(ACTIVITY_FILE_NAME, Activities);
		}

	}
}

