using System;
namespace Fitness.BL.Model
{
	[Serializable]
	public class User
	{
        #region Свойства объекта
        public string Name { get; set; }

		public Gender Gender { get; set; }

		public DateTime BirthDate { get; set; }

		public double Weight { get; set; }

		public double Height { get; set; }

		public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }

        #endregion

        public User(string name,
			Gender gender,
			DateTime birthDate,
			double weight,
			double height)
		{
			#region проверка условий
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("Имя пользователя неверно", nameof(name));
			}
			if(gender == null)
            {
				throw new ArgumentNullException("Пол неверный", nameof(gender));
			}

			if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
			{
				throw new ArgumentException("Дата неверная", nameof(birthDate));
			}

			if (weight <= 0)
			{
				throw new ArgumentException("Вес неверный", nameof(weight));
			}

			if (height <= 0)
			{
				throw new ArgumentException("Рост неверный", nameof(height));
			}

			#endregion

			Name = name;
			Gender = gender;
			BirthDate = birthDate;
			Weight = weight;
			Height = height;
		}

		public User(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
			}

			Name = name;

		}


            

       
        public override string ToString()
        {
            return Name + " " + Age;
        }


    }
}

