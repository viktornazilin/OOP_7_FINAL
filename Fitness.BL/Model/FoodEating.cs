﻿using System;
namespace Fitness.BL.Model
{
	[Serializable]
	// Прием пищи
	public class Eating
	{
		public DateTime Moment { get; }

		public Dictionary<Food, double> Foods { get; }

		public User User { get; }

		public Eating(User user)
        {
			User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
			Moment = DateTime.UtcNow;
			Foods = new Dictionary<Food, double>();
        }

		public void Add(Food food, double weightProduct)
        {
			var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

			if(product == null)
            {
				Foods.Add(food, weightProduct);
            }
			else
            {
				Foods[product] += weightProduct;
            }
        }
	}
}

